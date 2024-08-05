namespace Additional
{
    //1. 유효한 아이디 검증
    /*
    온라인 게임의 아이디 유효성 검사에 대한 기능을 추가하려고 한다.
    ID에 특수문자('!', '@', '#', '$', '%', '^', '&', '*') 가 포함된 경우 허용하지 않는다.
    이 때 string 자료형에 IsAllowedID() 확장 메서드를 추가하여 ID에 대한 검증을 진행하고자 한다.
    */

    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("아이디를 입력하세요 : ");
            string id = Console.ReadLine();

            if (id.IsAllowedID())
            {
                Console.WriteLine("ID가 유효합니다.");
            }
            else
            {
                Console.WriteLine("ID에 허용되지 않는 특수문자가 있습니다.");
            }
        }

    }
     public static class Extend
    {
        public static bool IsAllowedID(this string id) //인터넷에는 (this string id)라 반환이 string으로 되어야한다는데 bool로 반환되어야하지않나요??
        {
            char[] banString = { '!', '@', '#', '$', '%', '^', '&', '*' };
            for (int i = 0; i < id.Length; i++)
            {
                for (int j = 0; j < banString.Length; j++)
                {
                    if (id[i] == banString[j])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
