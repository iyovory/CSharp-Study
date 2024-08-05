namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. 입력받은 횟수만큼 반복하는 기능 제작
            {

                int num;

                Console.Write("몇회 반복하시겠습니까? ");

                //입력을 받기
                int.TryParse(Console.ReadLine(), out num);

                //받은 숫자만큼 돌리기
                for (int i = 1; i <= num; i++)
                {
                    //돌아가면서 "n 회 반복중입니다" 출력
                    Console.WriteLine($"{i}회 반복중입니다");
                }
            }
            #endregion

            #region 2. 다수의 입력을 받아 횟수만큼 반복하는 기능 제작
            {
                //예를 들어 유저가 4와 7을 입력하였다면 4+5+6+7의 결과값인 22를 출력해야 한다

                int smallNum;
                int bigNum;
                int sum = 0;

                Console.Write("두 수 사이의 합을 구합니다. 시작할 작은 수를 입력하여주세요 ");

                //입력을 받기
                int.TryParse(Console.ReadLine(), out smallNum);

                //"끝 수를 입력해주세요" 출력
                Console.Write("끝 수를 입력해주세요  ");

                //입력을 받기
                int.TryParse(Console.ReadLine(), out bigNum);

                //반복문을 통하여 시작부터 끝 수까지 합을 임의의 변수에 저장
                for (int i = smallNum; i <= bigNum; i++)
                {
                    sum += i;
                }

                Console.Write($"{smallNum}과 {bigNum} 사이 숫자의 합은 {sum}입니다");
            }
            #endregion

            #region 3. 구구단 기능 제작
            {
                while (true)
                {
                    int dan;

                    Console.WriteLine("1~9를 입력해주세요.");

                    //입력을 받기
                    int.TryParse(Console.ReadLine(), out dan);

                    // dan이 0보다 크고 10까지 작을때에만 실행
                    if (dan > 0 && dan < 10)
                    {
                        //반복문을 통하여 해당 구구단 출력
                        for (int i = 1; i <= 9; i++)
                        {
                            Console.WriteLine($"{dan}x{i} = {dan * i}");
                        }
                        break;
                    }
                }

                /*
                    [do while로 하는법]
                    int dan;
                    bool success;

                    do
                    {		
	                    Console.Write("1~9를 입력해주세요.");
	                    success = int.TryParse(Console.ReadLine(), out dan);

	                    if (success == false || dan < 1 || dan >9)
	                    {
		                    Console.WriteLine("잘못된 수를 입력하셨습니다.");
	                    }
                    } while (success = false || dan < 1 || dan > 9); //다시 반복시키기
                */
            }
            #endregion

            #region 4. 별찍기 기능 구현
            {

                #region 1번
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        //i만큼 *이 출력되도록
                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
                #endregion

                #region 2번
                {
                    //글자길이는 5, 공백은 하나씩 줄고, 별은 하나씩 늘고
                    for (int i = 1; i <= 5; i++)
                    {
                        /*
                             for (int j = 1; j <= 5 -i;  j++)
                            {
	                                Console.Write(" ");
                            }
                        */
                        for (int space = 4; space >= i; space--)
                        {
                            Console.Write(" ");
                        }
                        for (int star = 1; star <= i; star++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
                #endregion

                #region 3번
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        for (int star = 5; star >= i; star--)
                        {
                            Console.Write("*");
                        }
                        for (int space = 0; space <= i; space++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
                #endregion

                #region 4번
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        for (int space = 1; space < i; space++)
                        {
                            Console.Write(" ");
                        }
                        for (int star = 5; star >= i; star--)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
                #endregion
            }
            #endregion

            #region 심화 과제 1. 조건에 따른 무한 반복 기능
            {
                int num;

                Console.WriteLine("숫자를 입력하세요 ^-^");

                while (true)
                {

                    //입력을 받기
                    int.TryParse(Console.ReadLine(), out num);

                    if (!(num == 1 || num == 2 || num == 3))
                    {
                        Console.WriteLine("다시 입력하세요 -ㅅ-");
                        continue;
                    }

                    break;
                }
                Console.WriteLine();
            }
            #endregion

            #region 심화 과제 2. 입력을 통한 다이아몬드 출력 기능 구현
            {
                int num;

                Console.WriteLine("출력할 다이아몬드를 홀수로 입력:");

                while (true)
                {

                    //입력을 받기
                    int.TryParse(Console.ReadLine(), out num);

                    if (num == 1)
                    {
                        Console.WriteLine("1이 아닌값을 입력하세요");
                        continue;
                    }
                    if (num % 2 != 1)
                    {
                        Console.WriteLine("홀수를 입력하세요");
                        continue;
                    }

                    int minusSpace = (num - 1) / -2;
                    int plusSpace = (num - 1) / 2;

                    for (int y = minusSpace; y <= plusSpace; y++)
                    {
                        for (int x = minusSpace; x <= plusSpace; x++)
                        {
                            // Math.Abs : 절대값으로 바꿔줌(- => +, + => +)
                            int vertical = Math.Abs(x);
                            int horizontal = Math.Abs(y);

                            if (vertical + horizontal <= plusSpace)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }

                    break;
                }
            }
            #endregion


        }
    }
}
