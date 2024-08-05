namespace ConsoleApp2
{
    internal class Program
    {
        enum Place
        {
            마을=1, 사냥터, 상점
        }
        enum State
        {
            idle=1, run, walk, die=9
        }

        static void Main(string[] args)
        {
            #region 1. 열거형 리팩토링
            {

                Console.WriteLine("이동 할 장소를 설정해주세요");
                Console.WriteLine("1. 마을");
                Console.WriteLine("2. 사냥터");
                Console.WriteLine("3. 상점");
                Place toDetermine;

                Place.TryParse(Console.ReadLine(), out toDetermine);

                Console.Clear(); //화면을 지워줍니다
                switch (toDetermine)
                {
                    case Place.마을:
                        Console.WriteLine("마을로 이동합니다");
                        break;
                    case Place.사냥터:
                        Console.WriteLine("사냥터로 이동합니다");
                        break;
                    case Place.상점:
                        Console.WriteLine("상점으로 이동합니다");
                        break;
                    default:
                        Console.WriteLine("1,2,3 어느것도 아니에요");
                        break;
                }
            }
            #endregion


            #region 2. 상태를 열거형으로 구현
            {
                //플레이어의 현재 행동이 int state 로 정의되어 있습니다.
                //state변수에 1이 담겨 있으면 idle, 2가 담겨있으면 run, 3이 들어있으면 walk , 9가 담겨있으면 죽은 상태
                //열거형을 활용하여 해당 코드를 어떻게 수정할 수 있는지 작성해주세요.
                //유저에게 콘솔 입력으로 1,2,3,9 외의 입력이 들어오면,
                //옳지 못한 입력이라고 출력 후, 다시 입력을 요구하는 기능을 만드세요

                State state;

                do
                {
                    Console.WriteLine("플레이어의 상태는? (1,2,3,9 중 택 1)");

                    State.TryParse(Console.ReadLine(), out state);

                    switch (state)
                    {
                        case State.idle:
                            Console.WriteLine("idle");
                            break;
                        case State.run:
                            Console.WriteLine("run");
                            break;
                        case State.walk:
                            Console.WriteLine("walk");
                            break;
                        case State.die:
                            Console.WriteLine("die");
                            break;
                        default:
                            Console.WriteLine("옳지 못한 입력입니다.");
                            break;
                    }
                } while (!(state == State.idle && state == State.run && state == State.walk && state == State.die));
                //여기에 다른 조건문을 써야할것같은데 뭐라 넣어야될지 조언 부탁드립니다... 시간이 얼마남지않아 이대로 첨부합니다 ㅠ
            }
            #endregion

        }
    }
}
