namespace ConsoleApp1
{
    internal class Program
    {

        #region 1. 다수의 인자값 요구 함수 구현
        //4개의 정수를 인자로 받아 가장 큰 수를 출력하는 함수 제작

        static void FindLargestNumber()
        {
            int[] array = new int[4];

            //int 자료형에서 가질 수 있는 최소 값으로 시작
            //최소한 처음 배열에 들어 있는 값보다 작아야 모든 값과 비교할 수 있기 때문
            int maxValue = int.MinValue;

            Console.WriteLine("4개의 정수를 입력해주세요");

            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out array[i]))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("정수를 입력해주세요");
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    //maxValue보다 배열의 값이 크다면 담기(처음엔 무조건 큼)
                    maxValue = array[i];
                }
            }

            Console.WriteLine($"가장 큰 수는 {maxValue} 입니다.");
        }
        #endregion

        #region 2. 다수의 인자값 및 반환형을 가진 함수 구현
        // 5개의 float형을 인자로 받아, 그 중 가장 큰 두 수의 합을 실수형으로 반환하는 함수
        static void Sum()
        {
            float[] array = new float[5];

            float maxValue = float.MinValue;
            float maxNextValue = float.MinValue;

            Console.WriteLine("5개의 실수를 입력해주세요");

            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    if (float.TryParse(Console.ReadLine(), out array[i]))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("실수를 입력해주세요");
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxNextValue = maxValue;
                    maxValue = array[i];
                }
                else if (array[i] > maxNextValue)
                {
                    maxValue = array[i];
                }
            }

            Console.WriteLine($"제일 큰 두 수의 합은 {maxValue + maxNextValue} 입니다.");

        }
        #endregion

        #region 3. 특정 조건을 포함한 함수 제작
        //2개의 정수를 입력 받고, 두 수의 차이가 100 미만일 경우 참, 아니면 거짓 반환하는 함수
        static void UnderHundred()
        {
            int[] array = new int[2];

            Console.WriteLine("2개의 정수를 입력해주세요");

            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out array[i]))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("정수를 입력해주세요");
                    }
                }
            }


            if (array[0] >= array[1])
            {
                if (array[0] - array[1] > 100)
                {
                    Console.WriteLine("참");
                }
                else
                {
                    Console.WriteLine("거짓");
                }
            }
            else if (array[1] >= array[0])
            {
                if (array[1] - array[0] > 100)
                {
                    Console.WriteLine("참");
                }
                else
                {
                    Console.WriteLine("거짓");
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            FindLargestNumber();
            Sum();
            UnderHundred();
        }
    }
}
