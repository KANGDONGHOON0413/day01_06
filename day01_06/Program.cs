using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01_06
{
    public class currency
    {
        decimal money;
        public decimal Money { get { return money;  } }
        public currency(decimal money)
        {
            this.money = money;
        }
    }

    public class Won : currency
    {
        public Won(decimal money) : base(money) { }
        public override string ToString()
        {
            return Money + "won";
        }
    }
    public class Yen : currency
    {
        public Yen(decimal money) : base(money) { }
        public override string ToString()
        {
            return Money + "yen";
        }
        static public implicit operator Won(Yen yen)
        {
            return new Won(yen.Money * 10m);
        }
    }
    public class Dollar : currency
    {
        public Dollar(decimal money) : base(money) { }
        public override string ToString()
        {
            return Money + "doller";
        }
        static public explicit operator Won(Dollar dollar)
        {
            return new Won(dollar.Money * 13m);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Yen yen = new Yen(100);
            Won won01 = yen;    //암시적 형변환
            Won won02 = (Won)yen;   //명시적 형변환       implicit를 사용하여 암,명시적 형변환 가능
            Console.WriteLine(won01 + "\t" + won02);

            Dollar dollar = new Dollar(100);
            //Won won03 = dollar;   컴파일 오류가 발생하는데 이유는 explict를 사용하여 명시적 형변환만 인정하기 때문이다.
            Won won04 = (Won)dollar;    //명시적 형변환
            Console.WriteLine(won04);
        }
    }
}
