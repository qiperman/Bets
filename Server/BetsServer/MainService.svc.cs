using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace BetsServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MainService.svc or MainService.svc.cs at the Solution Explorer and start debugging.
    public class MainService : IMainService
    {
        //Строка подключения
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BetBase;Integrated Security=True";
        //Подключение 
        static SqlConnection connection;

        //Метод проверки соединения с сервером, возвращает true если соединение есть
        public bool TestConnection()
        {
            return true;
        }

        //Конструктор Подключения к базе
        public MainService()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Метод получение информации о Аккаунте, возвращает тип класса Account
        public Account GetAccount(int code)
        {
            Account user = new Account();
            try
            {
                //Получает данные об аккаунте с кодом = code
                string sqlExpression = "SELECT * FROM Users WHERE UserId = " + code;
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные заполняет 
                {
                    reader.Read();
                    user.code = Convert.ToInt32(reader.GetValue(0));
                    user.name = reader.GetValue(1).ToString();
                    user.balance = Convert.ToDecimal(reader.GetValue(2));
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
           
        }
        //Метод пополнения баланса, возвращает строку результата
        public string Deposit(int code, decimal sum)
        {
            Account user = GetAccount(code);
            user.balance += sum;
            try
            {
                string sqlExpression = string.Format("UPDATE Users SET Balance = @balance WHERE UserId = @code");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@balance", user.balance));
                command.Parameters.Add(new SqlParameter("@code", user.code));
                int number = command.ExecuteNonQuery();
                if (number > 0)
                {
                    return "Пополнение на "+sum+" выполнено успешно";
                }
                throw new Exception("Произошла ошибка пополнения");
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        //Метод снятие денег с баланса, возвращает строку результата
        public string Withdraw(int code, decimal sum)
        {
            Account user = GetAccount(code);
             try
            {
                if (user.balance < sum) throw new Exception("Не хватает средств на счете");
                user.balance -= sum;
                string sqlExpression = string.Format("UPDATE Users SET Balance = @balance WHERE UserId = @code");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@balance", user.balance));
                command.Parameters.Add(new SqlParameter("@code", user.code));

                int number = command.ExecuteNonQuery();
                if (number > 0)
                {
                    return "Снятие " + sum + " успешно выполнено";
                }
                throw new Exception("Произошла ошибка снятия");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Метод для совершения ставки, возвращает строку результата
        public string MakeBet(int accountId, decimal sum, int eventCode, BetType type)
        {
            Account user = GetAccount(accountId);
            string sqlExpression = "";
            try
            {
                if (user.balance < sum) throw new Exception("Не хватает денег, для ставки");
                sqlExpression = string.Format("INSERT INTO Bets (Sum, eventCode, type, accountId,Date, Result) VALUES (@sum, @eventCode,@type,@userCode,@date,@result)");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@sum",sum));
                command.Parameters.Add(new SqlParameter("@eventCode", eventCode));
                command.Parameters.Add(new SqlParameter("@type", type));
                command.Parameters.Add(new SqlParameter("@userCode", user.code));
                command.Parameters.Add(new SqlParameter("@date", DateTime.Now));
                command.Parameters.Add(new SqlParameter("@result", status.active));
                int number = command.ExecuteNonQuery();
                if (number > 0)
                {
                    Withdraw(user.code,sum);
                    return "Ставка сделана";
                }
                throw new Exception("Не удалось поставить ставку, повторите позже");
            }
            catch(Exception ex)
            {
                return ex.Message; // ex.Message;
            }
        }
        //Возвращает список ставок
        public List<Bet> GetBets(int code)
        { 
            List<Bet> bets = new List<Bet>();

             try
            {
                string sqlExpression = string.Format("SELECT * FROM [BetBase].[dbo].[Bets] INNER JOIN [BetBase].[dbo].[Events] ON Bets.eventCode = Events.code WHERE [BetBase].[dbo].[Bets].accountId = @code");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@Code", code));
                               SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())
                    {
                        Bet bet = new Bet();
                        bet.code = Convert.ToInt32(reader.GetValue(0));
                        bet.date = Convert.ToDateTime(reader.GetValue(1));
                        bet.sum = Convert.ToDecimal(reader.GetValue(2));
                        switch (Convert.ToInt32(reader.GetValue(3)))
                        {
                            case 0: bet.result = status.active; break;
                            case 1: bet.result = status.win; break;
                            case 2: bet.result = status.loss; break;
                            case 3: bet.result = status.draw; break;
                        }
                        bet.winnigSum = Convert.ToDecimal(reader.GetValue(4));
                        bet.betEvent = new Event();
                        bet.betEvent.code = Convert.ToInt32(reader.GetValue(5));
                        bet.betEvent.name = reader.GetValue(9).ToString();
                        bet.betEvent.rate = Convert.ToDecimal(reader.GetValue(10));
                        bet.accountId = Convert.ToInt32(reader.GetValue(7));
                        switch (Convert.ToInt32(reader.GetValue(6)))
                        {
                            case 1: bet.type = BetType.simple; break;
                            case 2: bet.type = BetType.system; break;
                            case 3: bet.type = BetType.express; break;
                        }
                        bets.Add(bet);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bets;
        }
        //Возвращает ставку
        public Bet GetBet(int betCode)
        {
            Bet bet = new Bet();
            try
            {
                string sqlExpression = string.Format("SELECT * FROM [BetBase].[dbo].[Bets] INNER JOIN [BetBase].[dbo].[Events] ON Bets.eventCode = Events.code WHERE [BetBase].[dbo].[Bets].BetsId = @betCode");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@betCode", betCode));
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())
                    {

                        bet.code = Convert.ToInt32(reader.GetValue(0));
                        bet.date = Convert.ToDateTime(reader.GetValue(1));
                        bet.sum = Convert.ToDecimal(reader.GetValue(2));
                        switch (Convert.ToInt32(reader.GetValue(3)))
                        {
                            case 0: bet.result = status.active; break;
                            case 1: bet.result = status.win; break;
                            case 2: bet.result = status.loss; break;
                            case 3: bet.result = status.draw; break;
                        }
                        bet.winnigSum = Convert.ToDecimal(reader.GetValue(4));
                        bet.betEvent = new Event();
                        bet.betEvent.code = Convert.ToInt32(reader.GetValue(5));
                        bet.betEvent.name = reader.GetValue(9).ToString();
                        bet.betEvent.rate = Convert.ToDecimal(reader.GetValue(10));
                        bet.accountId = Convert.ToInt32(reader.GetValue(7));
                        switch (Convert.ToInt32(reader.GetValue(6)))
                        {
                            case 1: bet.type = BetType.simple; break;
                            case 2: bet.type = BetType.system; break;
                            case 3: bet.type = BetType.express; break;
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bet;
        }
        //Возвращает список событий
        public List<Event> GetEvents()
        { 
            List<Event> events = new List<Event>();


            try
            {
                string sqlExpression = string.Format("SELECT * FROM [BetBase].[dbo].[Events]");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())
                    {
                        Event betEvent = new Event();
                        betEvent.code = Convert.ToInt32(reader.GetValue(0));
                        betEvent.name = reader.GetValue(1).ToString();
                        betEvent.rate = Convert.ToDecimal(reader.GetValue(2));
                        events.Add(betEvent);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return events;
        }
    }
}
