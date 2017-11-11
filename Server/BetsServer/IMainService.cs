using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BetsServer
{
    [ServiceContract]
    public interface IMainService
    {
        //Метод проверки соединения с сервером, возвращает true если соединение есть
        [OperationContract]
        bool TestConnection();
        
        //Метод получение информации о Аккаунте, возвращает тип класса Account
        [OperationContract]
        Account GetAccount(int code);
        
        //Метод пополнения баланса, возвращает строку результата
        [OperationContract]
        string Deposit(int usercode, decimal sum);

        //Метод снятие денег с баланса, возвращает строку результата
        [OperationContract]
        string Withdraw(int usercode, decimal sum);

        //Метод для совершения ставки, возвращает строку результата
        [OperationContract]
        string MakeBet(int accountId, decimal sum, int eventCode, BetType type);

        //Возвращает список ставок
        [OperationContract]
        List<Bet> GetBets(int code);

        //Возвращает список событий
        [OperationContract]
        List<Event> GetEvents();

        //Возвращает ставку
        [OperationContract]
        Bet GetBet(int betCode);

        
    }

    //Данные аккаунта
    [DataContract]
    public class Account
    {
        [DataMember]
        public int code {get; set;}
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public decimal balance { get; set; }
    }

    //Тип Статуса ставки
    public enum status
    {
        active,
        win,
        loss,
        draw
    }


    //Тип ставки
    public enum BetType
    {
        simple,
        system,
        express
    }

    //Данные Ставки
    [DataContract]
    public class Bet
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public decimal sum { get; set; }

        [DataMember]
        public  status result { get; set; }

        [DataMember]
        public decimal winnigSum{ get; set; }

        [DataMember]
        public Event betEvent;

        [DataMember]
        public BetType type { get; set; }

       [DataMember]
        public int accountId { get; set; }

    }

    //Данные события
    [DataContract]
    public class Event
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public decimal rate { get; set; }
    }
}
