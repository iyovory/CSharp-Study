// 1. 갑옷과 내구도
/*
아래 코드의 빈칸을 작성하여 구현 의도를 충족시키는 프로그램을 작성하자.
플레이어가 피격을 받을 때마다 착용 중인 갑옷의 내구도를 1씩 감소시킨다.
갑옷의 내구도가 0이 될 때, 플레이어가 갑옷을 해제(UnEquip) 하도록 한다.
 */

public class Program
{
    public class Player
    {
        private Armor curArmor;

        public void Equip(Armor armor)
        {
            Console.WriteLine($"플레이어가 {armor.name} 을/를 착용합니다.");
            curArmor = armor;
            curArmor.OnBreaked += UnEquip; //빈칸: 갑옷의 OnBreaked 이벤트에 UnEquip 추가
        }

        public void UnEquip()
        {
            Console.WriteLine($"플레이어가 {curArmor.name} 을/를 해제합니다.");
            curArmor.OnBreaked -= UnEquip; //빈칸: 이벤트 구독 해제
            curArmor = null;
        }

        public void Hit()
        {
            //빈칸: 현재 갑옷의 내구도를 감소시키는 함수 호출
            if (curArmor != null)
            {
                curArmor.DecreaseDurability(); 
            }
        }
    }

    public class Armor
    {
        public string name;
        private int durability;

        public event Action OnBreaked;

        public Armor(string name, int durability)
        {
            this.name = name;
            this.durability = durability;
        }

        public void DecreaseDurability()
        {
            durability--;
            if (durability <= 0)
            {
                Break();
            }
        }

        private void Break()
        {
            Console.WriteLine("방어구가 부서졌습니다.");
            if (OnBreaked != null) //빈칸
            {
                OnBreaked();
            }
        }
    }

    static void Main(string[] args)
    {
        Player player = new Player();
        Armor ammor = new Armor("갑옷", 3);

        player.Equip(ammor);

        player.Hit();
        player.Hit();
        player.Hit();
    }
}