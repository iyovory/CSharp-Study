using System;

namespace SwapNamespace
{
    /*
    1. 두 매개변수를 서로 교환하는 함수를 제작한다.
    2. 함수는 같은 자료형의 매개변수 2개를 요구한다.
    3. 함수는 매개변수로 어떠한 자료형이던 대응할 수 있어야 한다. 
    */
    internal class Swap
    {
        static void Main(string[] args)
        {
            int iLeft = 10;
            int iRight = 20;
            Util.Swap(ref iLeft, ref iRight);
            Console.WriteLine("int 자료형을 사용한 Swap 함수");
            Console.WriteLine($"({iLeft} , {iRight})");
            Console.WriteLine();

            double dLeft = 3.5;
            double dRight = 8.8;
            Util.Swap(ref dLeft, ref dRight);
            Console.WriteLine("double 자료형을 사용한 Swap 함수");
            Console.WriteLine($"({dLeft} , {dRight})");
        }

        public class Util
        {
            public static void Swap<T>(ref T iLeft, ref T iRight)
            {
                T temp = iLeft;
                iLeft = iRight;
                iRight = temp;
            }
        }
    }
}
