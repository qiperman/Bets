using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetsClient.MainService;


namespace BetsClient
{
    class Program
    {
        //Клиент для соединения с сервером
        static MainServiceClient client; 

        //Пользователь который вошел
        static Account user;

        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "Ставки";
                Console.WriteLine("Подключение к серверу...");

                //Соединение с сервером
                client = new MainServiceClient();

                //Печать заголовка
                PrintTitle();

                //Выбор команды
                int cmd = 0;
                do
                {
                    cmd = PrintCmd();
                    DoCmd(cmd);
                }
                while (cmd != 7);
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Не удалось подключится к серверу");
                Console.ReadKey();
            }

        }

        //Печать заголовка
        static void PrintTitle(bool updateInfo = true, bool withCmd = true)
        {

            //Обновить переменную пользователя?
            if(updateInfo)
                user = client.GetAccount(1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Здравствуйте, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(". Ваш баланс: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(user.balance);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            //Вывести список команд?
            if (withCmd)
            {
                Console.WriteLine("\n1. Внести деньги\n2. Вывести деньги\n3. Посмотреть ставки\n4. Посмотреть событие\n5. Сделать ставку\n6. Найти ставку\n7. Выход\n");
                Console.Write("Введите команду: ");
            }
        }

        //Ввод команды
        static int PrintCmd()
        {
            int cmd = 0;

            if (!((int.TryParse(Console.ReadLine(), out cmd)) && (cmd > 0) && (cmd < 8)))
            {
                Console.WriteLine("Введите правильную команду");
            }
            return cmd;
        }

        //Метод совершения команды
        static void DoCmd(int cmd)
        {
            //Печать заголовка без обновления пользователя и без списка команд
            PrintTitle(false, false);
            switch (cmd)
            {
                //Пополнить баланс
                case 1:
                    {
                        Console.Write("\nВведите сумму: ");
                        int sum;
                        while (!int.TryParse(Console.ReadLine(), out sum))
                        {
                            Console.Write("Введите сумму: ");
                        }
                        PrintTitle(false, false);
                        //Пополнить и вывести сообщение сервера
                        Console.WriteLine("\n"+client.Deposit(user.code,sum));
                        break;
                    }
                //Снятие денег с баланса
                case 2:
                    {
                        Console.Write("\nВведите сумму: ");
                        int sum;
                        while (!int.TryParse(Console.ReadLine(), out sum))
                        {
                            Console.Write("Введите сумму: ");
                        }
                        PrintTitle(false, false);
                        //Вывести и вывести сообщение сервера
                        Console.WriteLine("\n" + client.Withdraw(user.code, sum));
                        break;
                    }
                //Вывести все ставки данного пользователя
                case 3:
                    {
                        //Получение ставок с сервера
                        Bet[] bets = client.GetBets(user.code);
                        //Печать заголовков таблицы ставок 
                        PrintBetTitle();
                        foreach(Bet bet in bets)
                        {
                            //Печать ставки
                            PrintBet(bet);
                        }
                        break;
                    }
                //Вывод всех событий
                case 4:
                    {
                        PrintEvents(client.GetEvents());
                        break;
                    }
                //Поставить ставку
                case 5:
                    {
                        Console.WriteLine("\nВведите тип ставки какой хотите поставить:\n");
                        Console.WriteLine("1. Простая\n2. Система\n3. Суперэксресс\n");

                        
                        Console.Write("Введите число: ");
                        //Выбрать тип ставки которой хотят поставить
                        int code;
                        while (!int.TryParse(Console.ReadLine(), out code))
                        {
                            Console.Write("Введите число: ");
                        }
                        switch (code)
                        {
                            //Поставить простую ставку
                            case 1: MakeSimpleBet(); break;
                            case 2: Console.WriteLine("Поставить ставку система"); break;
                            case 3: Console.WriteLine("Поставить экспресс"); break;
                        }
                       break;
                    }
                //Найти ставку
                case 6:
                    {
                        Bet[] bets = client.GetBets(user.code);
                        Console.WriteLine("\n1. По коду\n2. Дате\n3. Активные ставки\n4. Выйгранные ставки\n5. Проигранные ставки\n6. Простые ставки\n7. Ставки система\n8. Экспрессы\n");

                        Console.Write("Введите число: ");
                        //Выбрать критерий поиска
                        int code;
                        while (!int.TryParse(Console.ReadLine(), out code))
                        {
                            Console.Write("Введите число: ");
                        }
                        switch (code)
                        {
                          
                            case 1: GetBetByCode(); break;
                            case 2: GetBetByDate(bets); break;


                            case 3: GetBetByStatus(bets, status.active); break;
                            case 4: GetBetByStatus(bets, status.win); break;
                            case 5: GetBetByStatus(bets, status.loss); break;

                            case 6: GetBetByType(bets, BetType.simple); break;
                            case 7: GetBetByType(bets, BetType.system); break;
                            case 8: GetBetByType(bets, BetType.express); break;


                        }

                        break;
                    }

            }
            ConsoleKey key;
            Console.WriteLine("\nНажмите Enter для выхода в главное меню");
            do
            {
                key = Console.ReadKey().Key;
            }
            while (key != ConsoleKey.Enter);
            PrintTitle();

        }

        //Вывод событий
        static void PrintEvents(Event[] events)
        {         
            Console.WriteLine("\n{0,3}| {1,25}| {2,4}", "#", "Name", "Rate");
            Console.WriteLine("---------------------------------------");


            foreach (Event betEvent in events)
            {
                Console.WriteLine("{0,3}| {1,25}| {2,4}", betEvent.code, betEvent.name, betEvent.rate);
            }
        }

        //Поставить простую ставку
        static void MakeSimpleBet()
        {
            Event[] events = client.GetEvents();
            PrintEvents(events);

            Console.Write("\nВведите код событие на которое хотите поставить: ");
            int code;
            while (!int.TryParse(Console.ReadLine(), out code))
            {
                Console.Write("Введите число: ");
            }

            //Выбор ставки для проверки на существование 
            var betEvent = from betevent in events
                           where betevent.code == code
                           select betevent;

            if (betEvent.Count() > 0)
            {
                //Ввод данных для ставки
                foreach (Event betEvent1 in betEvent)
                {
                    Console.Write("\nВведите сумму: ");
                    int sum;
                    while (!int.TryParse(Console.ReadLine(), out sum))
                    {
                        Console.Write("Введите сумму: ");
                    }
                    Console.WriteLine(client.MakeBet(user.code, sum, betEvent1.code, BetType.system));
                }
            }
            else
            {
                Console.WriteLine("Не найдены ставки");
            }
        }

        static void GetBetByCode()
        {
            Console.Write("\nВведите код события: ");

            int code;

            while (!int.TryParse(Console.ReadLine(), out code))
            {
                Console.Write("Введите код события: ");
            }

            //получение ставки по коду
            Bet bet = client.GetBet(code);


            if (bet.betEvent != null)
            {
                PrintBetTitle();
                PrintBet(bet);
            }
            else
            {
                Console.WriteLine("Не найдены ставки");
            }
        }

        static void GetBetByDate(Bet[] bets)
        {
            Console.Write("\nВведите дату события(в виде dd.MM.yyy): ");

            DateTime date;

            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("\nВведите дату события(в виде dd.MM.yyy): ");
            }
            //Выбрать ставку по дате которую ввел пользователь
            var searchbets = from bet in bets
                             where bet.date.ToShortDateString() == date.ToShortDateString()
                             select bet;

            if (searchbets.Count() > 0)
            {
                PrintBetTitle();
                foreach (Bet betEvent1 in searchbets)
                {
                    PrintBet(betEvent1);
                }
            }
            else
            {
                Console.WriteLine("Не найдены ставки");
            }

        }

        static void GetBetByType(Bet[] bets, BetType type)
        {
            var searchbets = from bet in bets
                             where bet.type == type
                             select bet;

            if (searchbets.Count() > 0)
            {
                PrintBetTitle();
                foreach (Bet betEvent1 in searchbets)
                {

                    PrintBet(betEvent1);
                }
            }
            else
            {
                Console.WriteLine("Не найдены ставки");
            }

        }

        static void GetBetByStatus(Bet[] bets, status status)
        {
            var searchbets = from bet in bets
                             where bet.result == status
                             select bet;

            if (searchbets.Count() > 0)
            {
                PrintBetTitle();
                foreach (Bet betEvent1 in searchbets)
                {

                    PrintBet(betEvent1);
                }
            }
            else
            {
                Console.WriteLine("Не найдены ставки");
            }
        }

        //Печать заголовков таблицы ставок
        static void PrintBetTitle()
        {
            Console.WriteLine("\n{0,2}| {1,25}| {6,10}| {2,4}| {3,10}| {4,6}| {5,4}", "#", "Name", "Rate", "Sum", "Result", "Sum", "Date");
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        //Вывод ставки
        static void PrintBet(Bet betEvent1)
        {
            Console.Write("{0,2}", betEvent1.code);
            Console.WriteLine("| {0,25}| {5,10}| {1,4}| {2,10}| {3,6}| {4,4}", betEvent1.betEvent.name, betEvent1.betEvent.rate, betEvent1.sum, betEvent1.result, betEvent1.winnigSum,betEvent1.date.ToShortDateString());
      
        }
    }
}
