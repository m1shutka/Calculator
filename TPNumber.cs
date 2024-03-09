using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator
{
    class TPNumber
    {
        private string number;//поле число
        private int p;//основание сс
        private int accuracy;//точность задания числа

        //конструктор для числа в десятичной сс
        public TPNumber(double n, int p, int accuracy)
        {
            number = Convert_10_p.Do(n, p, accuracy);
            this.p = p;
            this.accuracy = accuracy;
        }

        //конструктор для числа заданного в виде строки
        public TPNumber(string value, int p, int accuracy)
        {
            number = value;
            this.p = p;
            this.accuracy = accuracy;
        }

        //создание копии
        public TPNumber Copy()
        {
            return new TPNumber(number, p, accuracy);
        }

        //св-во для получения числа в строковом виде
        public string Number
        {
            get { return number; }
        }

        //св-во для получения числа в числовом виде
        public double DecimalNumber
        {
            get { return Convert_p_10.Do(number, p); }
        }

        //св-во для получения/задания основания в строковом виде
        public string StrP
        {
            get{ return p.ToString(); }
            set
            {
                number = Convert_10_p.Do(Convert_p_10.Do(number, p), Convert.ToInt32(value), accuracy);
                p = Convert.ToInt32(value);
            }
        }

        //св-во для получения/задания основания в числовом виде
        public int IntP
        {
            get{ return p; }
            set
            {
                number = Convert_10_p.Do(Convert_p_10.Do(number, p), value, accuracy);
                p = value;
            }
        }

        //св-во для получения/задания точности в числовом виде
        public int IntAcc
        {
            get{ return accuracy; }
            set
            {
                number = Convert_10_p.Do(Convert_p_10.Do(number, p), p, value);
                accuracy = value;
            }
        }

        //св-во для получения/задания точности в строковом виде
        public string StrAcc
        {
            get{ return accuracy.ToString(); }
            set
            {
                number = Convert_10_p.Do(Convert_p_10.Do(number, p), p, Convert.ToInt32(value));
                accuracy = Convert.ToInt32(value);
            }
        }

        //оператор сложения
        public static TPNumber operator +(TPNumber n1, TPNumber n2)
        {
            return new TPNumber(n1.DecimalNumber + n2.DecimalNumber, n1.IntP, 4);
        }

        //оператор вычитания
        public static TPNumber operator -(TPNumber n1, TPNumber n2)
        {
            return new TPNumber(n1.DecimalNumber - n2.DecimalNumber, n1.IntP, 4);
        }

        //оператор умножения
        public static TPNumber operator *(TPNumber n1, TPNumber n2)
        {
            return new TPNumber(n1.DecimalNumber * n2.DecimalNumber, n1.IntP, 4);
        }

        //оператор деления
        public static TPNumber operator /(TPNumber n1, TPNumber n2)
        {
            return new TPNumber(n1.DecimalNumber / n2.DecimalNumber, n1.IntP, 10);
        }

        //возведение в квадрат
        public TPNumber Sqr()
        {
            return new TPNumber(DecimalNumber * DecimalNumber, IntP, accuracy);
        }

        //обращение числа
        public TPNumber Rev()
        {
            return new TPNumber(1 / DecimalNumber, IntP, accuracy);
        }
    }
}