# 인터페이스
인터페이스 사용할때 해당 인터페이스 잡고 [Ctrl] + [.] 누를경우 자동 인터페이스 생성됨
- 인터페이스를 상속받아 구현한 클래스는 자동으로 해당 인터페이스로 형변환이 됨(업캐스팅) (명시적 형변환이 필요하지 않다)


C#에선 다중상속 막음(여러 부모를 가질 수 없음)
```cs
public class Lock //잠금장치에 대한 기능
{
	//public string name = "잠금장치";
}

public class Entrance //입구에 대한 기능
{
	//public string name = "입구";
}

//public class Door : Lock, Entrance //Door은 두 기능 다 필요한데 다중상속불가. name이 둘 다 있는경우 누구말을 들어야됨?? 이래서 안됨
public class Door : Lock
{

}
```

인터페이스는 여러개를 포함할 수 있다.
```cs
public interface IEnterable //인터페이스 이름은 맨 처음에 대문자I로 시작해야함
{
	//int a; // (X) 변수,함수 불가
	public void Enter();
}

public interface IOpenable
{
	public void Open();
}

public class Chest : IOpenable //chest: 열수있는 상자
{
	public void Open() //안쓰면 오류남. 상속받은경우 강제로 써야함
	{
		Console.WriteLine("상자를 엽니다.");
	}
}

public class Door : IOpenable, IEnterable //인터페이스는 여러개 상속 가능
{
	public void Open()
	{
		Console.WriteLine("문을엽니다.");
	}
	public void Enter()
	{
		Console.WriteLine("입장합니다.");
	}
}

static void Main(string[] args)
{
	Console.WriteLine("Hello, World!");
}
```

```cs
namespace Interface
{
    internal class Program
    {
        // <인터페이스 포함>  
        // 상속처럼 정의한 인터페이스를 클래스 : 뒤에 선언하여 사용  
        // 인터페이스를 포함하는 경우 반드시 인터페이스에서 정의한 함수를 구현해야 함  
        // 인터페이스는 여러개 포함 가능  
        public class Duenson : IEnterable
        {
            public void Enter()
            {
                Console.WriteLine("던전에 입장합니다.");
            }
        }

        public class Chest : IOpenable, IDamagable
        {
            public void Open()
            {
                Console.WriteLine("상자를 엽니다.");
            }

            public void TakeDamage(int damage)
            {
                Console.WriteLine("상자가 부셔집니다.");
                Console.WriteLine("소량의 재료들을 떨어뜨립니다.");
            }
        }

        public class Door : IEnterable, IOpenable
        {
            private int hp = 10;

            public void Enter()
            {
                Console.WriteLine("문으로 들어갑니다.");
            }

            public void Open()
            {
                Console.WriteLine("문을 엽니다.");
            }
        }

        public class Car : IEnterable, IOpenable
        {
            private bool isOpened;

            public void Enter()
            {
                if (isOpened)
                {
                    Console.WriteLine("차에 탑승합니다.");
                }
                else
                {
                    Console.WriteLine("먼저 차를 열어주세요.");
                }
            }

            public void Open()
            {
                isOpened = true;
                Console.WriteLine("차의 잠금장치를 해제하고 엽니다.");
            }
        }

        public class Player
        {
            private int attackAmount = 5;

            public void Enter(IEnterable enterable)
            {
                enterable.Enter();
            }

            public void Open(IOpenable openable)
            {
                openable.Open();
            }

            public void Attack(IDamagable damagable)
            {
                damagable.TakeDamage(attackAmount);
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();

            Duenson duenson = new Duenson();
            Chest chest = new Chest();
            Door door = new Door();

            player.Attack(chest);

            player.Enter(duenson);
            player.Enter(door);

            player.Open(chest);
            player.Open(door);

            Car car = new Car();
            player.Enter(car);
            player.Open(car);
            player.Enter(car);
        }
    }
}
```

### 추상클래스와 인터페이스

Bank : Building
**추상클래스** (A는 B다)
부모클래스의 기능을 통해 자식클래스의 기능을 확장하는 경우 사용

**인터페이스** (A는 B할수있다)
인터페이스를 사용하는 모든 클래스와 상호작용이 가능한 효과

```cs

//인터페이스
public interface IEnterable 
{
	void Enter();
}

//추상클래스
public abstract class Building
{
	public abstract void Enter();
}

public class Car : IEnterable
{
	public void Enter()
	{
	}
}
public abstract class Bank : Building
{
	public override void Enter()
	{

	}
}
```

같이 쓸거면 상속은 앞에, 인터페이스는 뒤에 쭉 붙여주면된다.
```cs
internal class Architecture
{
	//인터페이스
	public interface IEnterable 
	{
		void Enter();
	}

	//추상클래스
	public abstract class Building : IEnterable 
	{
		public void Enter()
		{
			Console.WriteLine("건물에 들어갑니다.");
		}
	}

	//상속이 적합 - 은행은 건물이다.
	public class Bank : Building
	{
	}

	//인터페이스가 적합 - 차는 들어갈 수 있다.
	public class Car : IEnterable
	{
		public void Enter()
		{
			Console.WriteLine("차문을 열고 들어갑니다");
		}
	}
}
```

인터페이스 안에서는 관련있는것만 들어갈수있도록 분리해서 만들기
```cs

//public interface IMonster
//{
//    void Move();
//    void TakeDamage(int damage);
//}
public interface IMoveable
{
	void Move();
}
public interface IDamagable
{
	void TakeDamage(int damage);
}

public class Monster 
{
	public void Move()
	{
		Console.WriteLine("몬스터가 이동합니다.");
	}

	public void TakeDamage(int damage)
	{
		Console.WriteLine("몬스터가 데미지를 받습니다.");
	}

	// public class EvilPlant : Monster //움직일 수 없는 몬스터이지만 Monster Move를 수행할 수 있는 상황이 되어버린다.
	public class EvilPlant : Monster, IDamagable 
	{

	}

	//public class Ghost : Monster //데미지를 받을 수 없는 몬스터이지만 Monster TakeDamage를 수행할 수 있는 상황이 되어버린다.
	public class Ghost : Monster, IDamagable
	{
		
	}

	public class Wall
	{
		//데미지를 받을 수 있도록 구성하고 싶은 몬스터가 아닐때
	}
}
```