# 객체지향(OOP)과 클래스

절차지향 프로그래밍 - 소스코드에 순서에 따라 프로그램의 동작과 로직이 결정됨
작업(그래픽 등)이 많아질수록 어디에 둬야할지 헷갈리기때문에 순서가 꼬일수도 있다.
객체(클래스)지향 프로그래밍 - 그래서 담당자를 나눠서 상호작용함.


값 타입: 변수에 값이 직접적으로 저장됨(int 등) 깊은 복사
참조 타입: 변수의 데이터 주소가 저장됨 (클래스, 배열 등) 얕은 복사

객체: 붕어빵이란? / 몬스터란?
클래스: 붕어빵틀 (객체 설계도) /  몬스터의 공격력
인스턴스: 붕어빵 (실제로 객체) / 드래곤: 공격력 30

Class
이 객체의 변수, 함수를 정해줌
행동이 정해져있으니 다른 행동을 할 수가 없음
원본을 가리키고있음(원본의 주소를 가지고 있음)
struct랑 비슷함(주소 참조)

캡슐화라고함
private(정보은닉): 우선은 private 후에 외부에서 쓸 필요가 있으면 그때 public

```csharp
    internal class Program
    {
        enum CarType { Truck, Bus }
        class Car
        {
	        //필드(속성)
            public string name;
            public float speed;
            public CarType type;

            private bool turnOn;
            public int oilAmount;

			//메서드()
            public void Drive()
            {
                speed += 10;
            }
            public void Stop()
            {
                speed = 0;
            }
            public void TurnOn()
            {
                if (oilAmount > 0)
                {
                    turnOn = true;
                }
            }
            public void TurnOff()
            {
                
            }
        }


        static void Main(string[] args)
        {
            Car bongo = new Car();
            bongo.name = "봉고";
            bongo.speed = 0;
            bongo.type = CarType.Truck;

            bongo.Drive();

            //bongo.turnOn = true; 
            //turnOn이 private이라 외부에서 변경하려하면 실패. 외부가 아닌 TurnOn()에서 바꿔야함
        }
    }
}
```

```csharp

    internal class Program
    {
        class Player
        {
            private int hp;
            public void TakeDamage(int damage)
            {
                Console.WriteLine($"플레이어가 데미지를 {damage}받는다.");
                hp -= damage;
                Console.WriteLine($"플레이어의 체력이 {hp}가 되었다.");

                if (hp <= 0)
                {
                    Die();
                }
            }

            private void Die()
            {
                Console.WriteLine("플레이어가 쓰러집니다");
            }
        }

        class Monster
        {
            public string name;
            public int attackPoint;

            public void Attack(Player player)
            {
                Console.WriteLine($"{name}가 플레이어를 {attackPoint} 공격력으로 공격합니다.");
                player.TakeDamage(attackPoint);
            }
        }

        static void Main(string[] args)
        {

            Player player = new Player();       //new를 통해서 인스턴스를 만든다.

            Monster dragon = new Monster();
            dragon.name = "드래곤";
            dragon.attackPoint = 20;

            Monster orc = new Monster();
            dragon.name = "오크";
            dragon.attackPoint = 10;

            dragon.Attack(player);
        }
    }
```

객체 만들때 어떤식으로 만드는게 좋은지
SOLID원칙(준수해주면 좋다)

S: 단일 책임 원칙 single
	클래스(객체)는 단 하나의 기능만 가져야한다. (분리해서 만들자)
O: 개방 폐쇄 원칙 open
	public은 여러곳에서 쓸 수 있으면 좋지만(확장) 수정에는 닫혀있어야한다.
L: 리스코프 치환 원칙 listov
	다형성. 자식 객체는 언제나 부모 타입으로 교체될 수 있어야한다.
I: 인터페이스 분리 원칙 interface
	하나의 큰 인터페이스보다 용도에 맞는 인터페이스를 잘게 분리해야한다. (뭉뚱그려서 하나로 만들지 말자)
D: 의존 역전 원칙 Dependency
	고수준의 모듈은 저수준 모듈의 구현에 의존해선 안된다. (의존을 자식한테 하면 안된다)

### 메모리
프로그램을 처리하기 위해 필요한 정보를 저장하는 기억장치
프로그램은 메모리에 저장한 정보를 토대로 명령들을 수행함

### 메모리 구조
프로그램은 효율적인 메모리 관리를 위해 메모리영역을 구분

-----

```
/* <메모리 구조>
   (0x0000...) ┌─────────────┐
   낮은주소    │ 코드 영역   │ → 프로그램 코드
			   ├─────────────┤
			   │ 데이터 영역  │ → 정적변수
			   ├─────────────┤
			   │ 힙 영역      │ → 클래스 인스턴스
			   │.............│
			   │             │
			   │.............│
   높은주소     │ 스택 영역   │ → 지역변수, 매개변수
   (0xFFFF...) └─────────────┘
*/
```

코드 영역 - 프로그램이 실행할 코드(우리가 작성)  데이터가 변경되지 않은 읽기전용데이터. 프로그램 시작 지점에 메모리에 로드
데이터 영역 - 정적static변수(프로그램의 시작시 할당되며 종료시 삭제됨), 전역변수
힙 영역 - 클래스 인스턴트. 인스턴스를 참조하고 있는 변수(인스턴스)가 없을때 더이상 사용하지 않는다고 판단하여 가비지 컬렉터(GC)가 삭제함. 동적 메모리 저장. 사용자에 의해 생성
...
스택 영역 - 지역변수, 매개변수가 저장되는 영역. 함수의 호출시 할당되며 종료시 삭제됨

스택 - 후입선출 쌓다 힙메모리에 비해 작고 빠름

변수의 접근범위와 생존범위
```
/*
			 │ 메모리영역 │ 접근 범위  │ 생존 범위
	─────────┼───────────┼───────────┼───────────────────────────
	정적변수  │ 데이터영역 │ 모든 범위  │ 프로그램 시작에서 끝까지
	─────────┼───────────┼───────────┼───────────────────────────
	지역변수  │ 스택영역   │ 블록 내부  │ 블록 시작에서 끝까지
	매개변수  │           │           │
	─────────┼───────────┼───────────┼───────────────────────────
	클래스    │ 힙영역    │ 참조가능한  │  인스턴스 생성에서
	인스턴스  │           │ 모든 범위  │ 더이상 사용하지 않을때까지
*/

```

-----

메모리가 저장되고 삭제되는 과정을 할당과 해제(다시사용할수있도록 삭제)

구조체 -> 복사본전달
클래스 -> 원본전달 
```csharp
internal class Program
{
    struct ValueType
    {
        public int value;
    }

    class RefType
    {
        public int value;
    }
    static void Main(string[] args)
    {
	// 값 형식 (구조체)
        ValueType valueType1 = new ValueType() { value = 10 };
        ValueType valueType2 = valueType1;  //값이 복사
        valueType2.value = 20;  //값을 대입해도 원본에는 영향 없음
        Console.WriteLine(valueType1.value);    //10

	// 참조 형식 (클래스)
        RefType refType1 = new RefType() { value = 10 };
        RefType refType2 = refType1;  //객체주소가 복사
        refType2.value = 20;  //값을 대입하면 원본 데이터를 변경
        Console.WriteLine(refType1.value);    //20

    }
}
```

### 스택영역
함수호출스택을 이용하여 호출과 종료에 연관되는 데이터를 쌓으면서 관리
끝내자마자 삭제됨

함수호출스택
```csharp
void Stack2(int a)
{
	a=3;
}
void Stack1(int a)
{
	a=2;
	Stack2(a);
}
void Main1(int a)
{
	int a=1;
	Stack1(a);
}


/*
                          ┌───────────┐               ┌───────────┐               ┌───────────┐
                          │           │               │           │               │           │
                          │           │               │           │               ├───────────┤
                          │           │               │           │               │ Stack2()  │
                          │           │               │           │               │ a = 3     │
                          │           │               ├───────────┤               ├───────────┤
                          │           │               │ Stack1()  │               │ Stack1()  │
                          │           │               │ a = 2     │               │ a = 2     │
                          ├───────────┤               ├───────────┤               ├───────────┤
                          │ Main1()   │               │ Main1()   │               │ Main1()   │
                          │ a = 1     │               │ a = 1     │               │ a = 1     │
             Main1 호출 → └───────────┘ Stack1 호출 → └───────────┘ Stack2 호출 → └───────────┘

                          ┌───────────┐               ┌───────────┐               ┌───────────┐
                          │           │               │           │               │           │
                          │           │               │           │               │           │
                          │           │               │           │               │           │
                          │           │               │           │               │           │
                          ├───────────┤               │           │               │           │
                          │ Stack1()  │               │           │               │           │
                          │ a = 2     │               │           │               │           │
                          ├───────────┤               ├───────────┤               │           │
                          │ Main1()   │               │ Main1()   │               │           │
                          │ a = 1     │               │ a = 1     │               │           │
            Stack2 종료 → └───────────┘ Stack1 종료 → └───────────┘  Main1 종료 → └───────────┘
*/
```

### 힙 영역
클래스 인스턴스가 보관하는 영역
프로그램은 가비지 콜렉터를 통해 더이상 사용하지 않는 인스턴스를 수거함

가비지 콜렉터
```csharp
class HeapClass { }

void Main2()
{
	// 함수 시작시
	// 지역변수 local 이 스택 영역에 저장됨

	HeapClass local;              // 함수 시작시 이미 메모리에 할당되어 있음
	local = new HeapClass();      // 인스턴스를 힙영역에 생성하고 주소값을 local에 보관

	// 함수 종료시
	// 지역변수 local 이 함수 종료와 함께 소멸됨
	// 인스턴스 new HeapClass() 는 함수 종료와 함께 더이상 참조하는 변수가 없음
	// 인스턴스 new HeapClass() 는 가비지가 되어 가비지 컬렉터가 동작할 때 소멸됨
}

/*
			   ┌─────────────┐                   ┌─────────────┐
			   │             │                   │             │
			   │             │              0x56 ├─────────────┤
			   │             │               ┌──→│ HeapClass   │
			   │             │               │   │ 인스턴스    │
			   │             │               │   ├─────────────┤
			   │             │               │   │             │
			   │             │               │   │             │
			   │             │               │   │             │
			   ├─────────────┤               │   ├─────────────┤
			   | local(null) |               └───│ local(0x56) │
	함수시작 → └─────────────┘   인스턴스 생성 → └─────────────┘
								 
			   ┌─────────────┐                   ┌─────────────┐
			   │             │                   │             │
			   ├─────────────┤                   │             │
	   더이상  │ HeapClass   │                   │             │
	  참조없음 │ 인스턴스    │                   │             │
			   ├─────────────┤                   │             │
			   │             │                   │             │
			   │             │                   │             │
			   │             │                   │             │
			   │             │                   │             │
			   │             │   가비지 콜렉터   │             │
	함수종료 → └─────────────┘       동작시    → └─────────────┘
*/

```


### Static
**메모리 상주**
프로그램 시작부터 끝날때까지 똑같은 자리에 고정해놓고 사용
볼륨설정같이 게임 내의 상황이 바뀌어도 변화되지 않을 값

static변수는 시작부터 데이터영역에 자리가 있기때문에 실체(인스턴스)가 없어도 됨
```csharp
    internal class Program
    {
        class Student
        {
            public static int count; // static
            public int id;
        }

        static void Main(string[] args)
        {
            Student.count = 0; // (O) 작동. 하나를 다같이 공통으로 씀
            Student.id = 0; // (X) 오류. Student student1 = new Student() { id = 1 }; 작동
        }
    }
```

### 클래스 생성자
반환형이 없는 클래스이름의 함수 생성자
객체의 인스턴스가 생성될 때 호출되는 특수한 메서드
쓰는이유: 설정해야할껄 까먹을 수 있으니까

초기셋팅할때 쓰임(기본값들)

```csharp
internal class Program
{

    class Monster
    {
        public string name;
        public int hp;
        //이렇게 더 짧게도 사용가능
        //public string name="슬라임";
        //public int hp="100";

        //생성자
        //이게 없다면 "이름의 몬스터: 체력은 0" 이렇게 출력됨
        public Monster()
        {
            name = "몬스터";
            hp = 100;
        }
        //Monster monster1 = new Monster(); 한다면 기본으로 이게 나옴

        public void PrintInfo()
        {
            Console.WriteLine($"{name} 이름의 몬스터: 체력은 {hp}");
        }
    }


    static void Main(string[] args)
    {
        //Monster monster = new Monster() { name = "슬라임", hp = 100 };
        Monster monster = new Monster();
        monster.PrintInfo();
    }
}
```

### this
멤버변수와 매개변수의 이름이 같을때 사용
```csharp

        class Monster
        {
            public string name;
        }
	    public Monster(string name)
	    {
		    this.name = name;
	    }
```

### 구조체로 하는법
```csharp
        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }
        static void Main(string[] args)
        {

            Point playerPos = new Point(1,2);
        }
```

### 같은 프로젝트 내에 여러 cs파일

솔루션 탐색기에서 프로젝트 말고 sln 우측클릭해서 새 항목 추가(클래스 추가하기)

같은 프로젝트내에서는 다른파일에 있는 내용을 부를 수 있다.

GameData.cs
```csharp
public class GameData
{
	public int gold;
	public void ShowGold()
	{
		Console.WriteLine($"현재까지 모은 골드는 {gold}");
	}
} 
```

Program.cs
```csharp
static void Main(string[] args)
{
	GameData gameData = new GameData();
	gameData.gold = 100;
	gameData.ShowGold();
}
```

### namespace

GameData.cs
```csharp
namespace ABC
public class GameData
{
	public int gold;
	public void ShowGold()
	{
		Console.WriteLine($"현재까지 모은 골드는 {gold}");
	}
} 
```

GameData2.cs
```csharp
namespace CBA
public class GameData
{
	public int gold;
	public void ShowGold()
	{
		Console.WriteLine($"현재까지 모은 골드는 {gold}");
	}
} 
```

Program.cs
```csharp
static void Main(string[] args)
{
	ABC.GameData gameData = new ABC.GameData();
	gameData.gold = 100;
	gameData.ShowGold();
}
```
### partial
같은 클래스를 다른 파일이나 다른 곳에서 분리해서 만드는 방법

같은 namespace의 다른내용이면 불러올 수 있다

### 얕은 복사
참조 주소만 복사하는 것
(얕은 복사는 객체의 참조를 복사하여 원본 객체와 복사본 객체가 동일한 참조 주소를 참조)
일반적으로 객체를 할당하는 것은 얕은 복사를 의미합니다. 

### 깊은 복사
값을 직접 복사하여 새로운 객체를 만드는 것을 말한다
구조체는 값 형식이기 때문에 기본적으로 복사가 일어나면 깊은 복사가 수행됩니다.

```csharp

    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10; 
            int b = 20;

            //Swap(a, b); //복사한거라 원본값은 바뀌지 않음 call by value
            Swap(ref a, ref b); //원본주소인 참조를 전달 call by reference

            Console.WriteLine($"a={a} b={b}");
        }

        //public static void Swap(int left, int right)
        public static void Swap(ref int left, ref int right) //원본주소인 참조를 전달 call by reference
        {
            int temp = left;
            left = right;
            right = temp;
        }
    }
```