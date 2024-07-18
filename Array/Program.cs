namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.고정 배열 생성 및 출력
            {
                //4개의 정수를 담을 수 있는 배열을 하나 생성 후, 
                //사용자에게 순서대로 값 입력 받아 순서대로 배열에 담기. 
                //해당 문을 foreach로 출력해 보자

                // 4개의 정수를 담을 수 있는 배열을 하나 생성
                int[] array = new int[4];


                // "1~4번 요소를 입력하여주십시오" 출력 후 입력받기
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"{i + 1}번 요소를 입력하여주십시오");
                    int.TryParse(Console.ReadLine(), out array[i]);
                }

                // "입력된 요소는 다음과 같습니다" 다음 줄에 입력된 값들 4개 출력
                Console.WriteLine($"입력된 요소는 다음과 같습니다");

                foreach (int item in array)
                {
                    Console.Write($"{item} \t");
                }
            }
            #endregion


            #region 2.배열의 요소 변경 및 출력
            {
                //4x4 16개의 정수를 담을 수 있는 2차원 배열을 만든 후, 반복문을 이용하여 3의 배수들로 채워 넣는다.
                //그 후 2행3열 요소와 3행 2열 요소를 바꾼 후 출력해 보자


                // 4x4 16개의 정수를 담을 수 있는 2차원 배열을 선언
                int[,] array = new int[4, 4];


                // 반복문을 통하여 순서대로 3의 배수들로 채워넣음
                int count = 1;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        array[i, j] = count * 3;
                        count++;
                    }
                }


                //2행3열 요소와 3행 2열 요소를 바꾼다(자리바꿈)
                int change = array[1, 2];
                array[1, 2] = array[2, 1];
                array[2, 1] = change;


                // 4x4의 형태로 들어있는 숫자들을 출력
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            #endregion
        }
    }
}
