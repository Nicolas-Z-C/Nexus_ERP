using Ardalis.SmartEnum;
using Nexus.Domain.ValueObjects.Common;
using Nexus.Domain.ValueObjects.Names;
namespace Nexus.Domain.Enums
{
    public sealed class Currency : SmartEnum<Currency> 
    {

        public static readonly Currency USD = new ("USD",1,"$","Dolar EstadoUnidense",2);
        public static readonly Currency EUR = new ("EUR",2,"€","Euro",2 );
        public static readonly Currency CNY = new ("CNY",3,"¥","Yuan Chino",2);
        public static readonly Currency COP = new ("COP",4,"$","Peso Colombiano",0);
        private Currency(string code,int value ,string symbol, string name, int decimals) : base(code,value)
        {
            Symbol = symbol;
            Code = code;
            FullName = name;
            Decimals = decimals;
        }
        public string Symbol {get; private set;}
        public string Code {get; private set;}
        public string FullName {get; private set;}
        public int Decimals {get; private set;}
    }
}