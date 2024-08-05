namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region if
            {
                int successCount;

                // "성공한 갯수를 입력하여 주세요" 를 띄움
                Console.WriteLine("성공한 갯수를 입력하여 주세요.");

                // 성공한 갯수를 입력받음. 
                successCount = int.Parse(Console.ReadLine());

                // if로 등급별 출력
                // 100초과일 경우 최대 100개까지 입력가능합니다 띄우고 종료
                if (successCount > 100)
                {
                    Console.WriteLine("최대 100개까지 입력가능합니다.");
                }
                else if (successCount == 100)
                {
                    Console.WriteLine("SS 등급입니다.");
                }
                else if (successCount >= 90)
                {
                    Console.WriteLine("S등급 입니다.");
                }
                else if (successCount >= 70)
                {
                    Console.WriteLine("A등급입니다.");
                }
                else if (successCount >= 40)
                {
                    Console.WriteLine("B등급 입니다.");
                }
                else
                {
                    Console.WriteLine("F등급 입니다.");
                }
            }
            #endregion

            #region switch
            {
                int num;

                //유저로부터 정수를 입력받기
                Console.WriteLine("지시해주십쇼");
                int.TryParse(Console.ReadLine(), out num);

                switch (num)
                {
                    //1을 입력받을 경우, "Cocked Pistol 발령"
                    case 1:
                        Console.WriteLine("Cocked Pistol 발령");
                        break;
                    //2일 경우, "Fast Pace 발령"
                    case 2:
                        Console.WriteLine("Fast Pace 발령");
                        break;
                    //3을 입력받을 경우, "Round House 발령"
                    case 3:
                        Console.WriteLine("Round House 발령");
                        break;
                    // 이외에 대한 입력값은 "비상 태세"
                    default:
                        Console.WriteLine("비상 태세");
                        break;
                }
            }
            #endregion
        }
    }
}
