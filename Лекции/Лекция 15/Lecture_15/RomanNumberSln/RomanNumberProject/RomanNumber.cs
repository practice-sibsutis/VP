using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RomanNumber.Models
{
    public class RomanNumber : ICloneable, IComparable
    {

        static Dictionary<int, string> ListNumbers = new Dictionary<int, string>
        { 
            { 1000, "M" },  
            { 900, "CM" },  
            { 500, "D" }, 
            { 400, "CD" },  
            { 100, "C" },
            { 90 , "XC" },  
            { 50 , "L" },  
            { 40 , "XL" },  
            { 10 , "X" },
            { 9  , "IX" },  
            { 5  , "V" },  
            { 4  , "IV" },  
            { 1  , "I" } 
        };

        private string RomanNum { get; set; }
        private ushort ArabicNum { get; set; }

        //Конструктор получает число n, которое должен представлять объект класса
        public RomanNumber(ushort n)
        {
           if (n <= 0 || n >= 4000)
                throw new RomanNumberException("Value is out of range from 1 to 4000");
            ArabicNum = n;
            RomanNum = ToRoman(n);
        }

        //Перевод арабского числа в римское
        private static string ToRoman(ushort n) => ListNumbers
            .Where(x => n >= x.Key)
            .Select(x => x.Value + ToRoman((ushort)(n - x.Key)))
            .FirstOrDefault();
        

        //Перевод римского числа в int
        public static int ToInt(RomanNumber romanNumber)=> romanNumber.ToString().Length == 0 ? 0 : 
            ListNumbers
            .Where(x => romanNumber.RomanNum.StartsWith(x.Value))
            .Select(x => 
            {
                romanNumber.RomanNum = romanNumber.RomanNum.Substring(x.Value.Length);
                return x.Key+ToInt(romanNumber);
            }
            ).First();

        

        //Сложение римских чисел
        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null && n2 is null) throw new RomanNumberException("At least one parameter must have a value");
            if (n1 is null) return n2;
            if (n2 is null) return n1;
            return new RomanNumber((ushort)(n1.ArabicNum +n2.ArabicNum));
        }

        public static RomanNumber operator+(RomanNumber? n1, RomanNumber? n2) => Add(n1, n2);

        //Вычитание римских чисел
        public static RomanNumber Sub(RomanNumber? n1, RomanNumber n2)
        {
            if (n1 is null && n2 is null) throw new RomanNumberException("At least one parameter must have a value");
            if (n1 is null) return n2;
            if (n2 is null) return n1;
            return new RomanNumber((ushort)(n1.ArabicNum - n2.ArabicNum));
        }

        public static RomanNumber operator-(RomanNumber? n1, RomanNumber? n2) => Sub(n1, n2);

        //Умножение римских чисел
        public static RomanNumber Mul(RomanNumber n1, RomanNumber n2)
        {
            return new RomanNumber((ushort)(n1.ArabicNum * n2.ArabicNum));
        }

        public static RomanNumber operator*(RomanNumber n1, RomanNumber n2) => Mul(n1, n2);

        //Целочисленное деление римских чисел
        public static RomanNumber Div(RomanNumber n1, RomanNumber n2) => new RomanNumber((ushort)(n1.ArabicNum / n2.ArabicNum));

        public static RomanNumber operator/(RomanNumber n1, RomanNumber n2) => Div(n1, n2);

        //Возвращает строковое представление римского числа, например, "XX" для числа двадцать 
        public override string ToString() => RomanNum;

        //Реализация интерфейса IClonable
        public object Clone() => MemberwiseClone();

        //Реализация интерфейса IComparable
        public int CompareTo(object? rn)
        {
            if(rn is null) throw new ArgumentException("Your value should not be null");
            if(rn is not RomanNumber) throw new ArgumentException("Cannot convert data type");
            return ArabicNum.CompareTo(((RomanNumber)rn).ArabicNum);
        }
    }
}
