namespace List
{
    internal class Program
    {

        //어떻게 손대야할지 모르겠습니다...  강의 들을때는 이해가는것같다가도 왜그럴까요?ㅠㅠ
        //(빨간줄도 안뜨고 코드 엔터시 이상하게 줄바꿈되는 상태입니다)
        #region 1. 동적 인벤토리 구현하기

        /*
            프로그램 시작 시 인벤토리는 빈 상태에서 시작한다.
            프로그램이 구동되는 동안 입력마다 콘솔에 지속적으로 인벤토리의 상태를 표시한다
            인벤토리는 최대 9개의 아이템을 가질 수 있다.
            인벤토리는 빈칸 없이 앞부터 채워서 가진다
            숫자키 0을 누르면 랜덤으로 아이템의 종류를 획득하고 인벤토리에 추가한다
            숫자키 1~9를 누르면 해당하는 숫자의 아이템을 제거한다
            구현 클래스
            Inventory
            Item
            Potion : Item
            Weapon : Item
            Armor : Item
            Accessory : Item
            Food : Item
        */

        public class Item
        {
            protected string name = "비어있음";
        }

        public class Potion : Item
        {
            public Potion()
            {
                name = "Potion";
                // inventory.Add(this); // inventory가 어떤 클래스의 인스턴스인지 명확하지 않습니다.
            }
        }

        public class Weapon : Item
        {
            public Weapon()
            {
                name = "Weapon";
                // inventory.Add(this);
            }
        }

        public class Armor : Item
        {
            public Armor()
            {
                name = "Armor";
                // inventory.Add(this);
            }
        }

        public class Accessory : Item
        {
            public Accessory()
            {
                name = "Accessory";
                // inventory.Add(this);
            }
        }

        public class Food : Item
        {
            public Food()
            {
                name = "Food";
                // inventory.Add(this);
            }
        }

        public class Inventory
        {
            List<string> inventory = new List<string>();

            List<string> function = new List<string>
            {
                "Potion",
                "Weapon",
                "Armor",
                "Accessory",
                "Food"
            };

            public void RandomItemFunction()
            {
                // 랜덤 아이템 추가 로직이 필요합니다.
            }

            public Inventory()
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '0':
                        RandomItemFunction();
                        break;
                    case '1':
                        // list.Remove(1);
                        break;
                    case '2':
                        // list.Remove(2);
                        break;
                    case '3':
                        // list.Remove(3);
                        break;
                        //... '9'
                }

                foreach (string item in inventory)
                {
                    Console.WriteLine($"{item}");
                }
            }
        }
        #endregion


        //일단 예시처럼 7,3을 넣고 만들고싶은데 그것도 막히네요..
        //k번만큼 이동후에 3보다 적어지면 Next를 어떻게 쓰나요?
        #region 2. 요세푸스 순열

        /*
        아래의 요세푸스 순열에 대한 설명을 보고 N와 K 가 주어지면 결과를 출력하는 프로그램으로 구현하시오.

        1번부터 N번까지 N명의 사람이 원을 이루면서 앉아있고, 양의 정수 K(≤ N)가 주어진다. 
        이제 순서대로 K번째 사람을 제거한다. 한 사람이 제거되면 남은 사람들로 이루어진 원을 따라 이 과정을 계속해 나간다. 
        이 과정은 N명의 사람이 모두 제거될 때까지 계속된다. 원에서 사람들이 제거되는 순서를 (N, K)-요세푸스 순열이라고 한다. 
        예를 들어 (7, 3)-요세푸스 순열은 <3, 6, 2, 7, 5, 1, 4>이다. 
        */

        public Yosepuse(int n = 7, int k = 3)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            LinkedListNode<int> firstNode = linkedList.First;

            //n번만큼 채우기
            for (int i = 0; i < n; i++)
            {
                linkedList[i] = i + 1;
            }

            //나눠질때까지
            for (int i = 0; i < n % k; i++)
            {
                //k번만큼 이동
                for (int i = 0; i < k; i++)
                {
                    LinkedListNode<int> nextNode = firstNode.Next;
                }
            }
        }


        #endregion

        static void Main(string[] args)
        {
        }
    }
}
