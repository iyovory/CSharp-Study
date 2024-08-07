
# 델리게이트
대리자 (Delegate)
함수를 가질수있는 변수 (함수의 주소를 가리키는 참조 타입)

```
//delegate 반환형 델리게이트이름(매개변수들);
public delegate float MyDel(float left, float right);
```


#### Func, Action
```cs

    internal class Program
    {
        public delegate float MyDel(float left, float right);
        public delegate void StrDel(string str);

        public static float Plus(float left, float right) { return left + right; }

        public class Logger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        public static void Message(string text) { Console.WriteLine(text); }    

        static void Main(string[] args)
        {
            MyDel delegate1 = Plus;

            Console.WriteLine($"{Plus(10,20)}");
            Console.WriteLine($"{delegate1(10,20)}");

            Logger logger = new Logger();
            StrDel delegate2 = logger.Log;
            Message("안녕하세요");
            delegate2("안녕하세요");

        }

        //일반화 델리게이트
        //어차피 델리게이트 많이 쓸건데 C#에서 미리 일반화 시켜둔 델리게이트 써주면 편하다.
        public static void GenericDel()
        {
            //<>안에 매개변수들 쓰고 마지막에 반환형써주기
            Func<float, double, int> func1 = Function;

            //void(반환안함) 매개변수만 쓰기
            Action<int, float> action1 = Action1;
        }

        public static int Function(float a, double b) { return 0; }
        public static void Action1(int a, float b) { }
    }
```

#### 콜백함수
델리게이트를 이용하여 특정조건에서 반응하는 함수를 구현
함수의 호출(Call)이 아닌 역으로 호출받을 때 반응을 참조하여 역호출(Callback)
```cs
void Main()
{
	File file = new File();

	Button saveButton = new Button();
	saveButton.callback = file.Save;

	Button loadButton = new Button();
	loadButton.callback = file.Load;

	saveButton.Click();     // output : 저장하기 합니다.
	loadButton.Click();     // output : 불러오기 합니다.
}

public class Button
{
	public Action callback;

	public void Click()
	{
		if (callback != null)
		{
			callback();
		}
	}
}

public class File
{
	public void Save()
	{
		Console.WriteLine("저장하기 합니다.");
	}

	public void Load()
	{
		Console.WriteLine("불러오기 합니다.");
	}
}
```

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateNEvent
{
    internal class InputHandle
    {
        public static void Main()
        {
            InputDevice device = new InputDevice();
            Player player = new Player();

            device.aKey = player.Jump;

            device.Input('a');

            device.aKey = player.Skill;

            device.Input('a');
        }

        public class InputDevice
        {
            public Action aKey;
            public Action sKey;

            public void Input(char key)
            {
                switch (key)
                {
                    case 'a':
                        aKey();
                        break;
                    case 's':
                        sKey();
                        break;
                }
            }
        }

        public class Player
        {
            public void Jump()
            {
                Console.WriteLine("플레이어 점프");
            }
            public void Skill()
            {
                Console.WriteLine("플레이어 스킬");
            }
        }
    }
}

```

```cs

    public class Customer
    {
        public void Request(Restaurant restaurant)
        {
            restaurant.OnAcceptable = Enter;
            //빈자리생기면 들어갈게
        }

        public void Enter(Restaurant restaurant)
        {
            restaurant.Enter();
        }
    }

    public class Restaurant
    {
        public Action<Restaurant> OnAcceptable;

        private int curCustomer = 5;
        private int maxCustomer = 10;

        public bool IsAcceptable()
        {
            return curCustomer < maxCustomer;
        }

        public void CheckCustomerCount()
        {
            //빈자리 있어요
            if (curCustomer < maxCustomer)
            {
                OnAcceptable(this);
            }
        }

        public void Enter()
        {
            if (IsAcceptable())
            {
                curCustomer++;
                Console.WriteLine("손님을 입장시킵니다.");
            }
            else
            {
                Console.WriteLine("손님이 가득차서 기다려야 합니다.");
            }

        }
    }


    static void Main(string[] args)
    {
        Customer customer = new Customer();
        Restaurant restaurant = new Restaurant();

        //customer.Enter(restaurant);
        //customer.Enter(restaurant); //손님이 계속 들어갈수있는지 물어보는 상태

        customer.Request(restaurant); //손님이 예약
    }
```

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateNEvent
{
    internal class InputHandle
    {
        public static void Main()
        {
            InputDevice device = new InputDevice();
            Player player = new Player();

            device.aKey = player.Jump;

            device.Input('a');

            device.aKey = player.Skill;

            device.Input('a');
        }

        public class InputDevice
        {
            public Action aKey;
            public Action sKey;

            public void Input(char key)
            {
                switch (key)
                {
                    case 'a':
                        aKey();
                        break;
                    case 's':
                        sKey();
                        break;
                }
            }
        }

        public class Player
        {
            public void Jump()
            {
                Console.WriteLine("플레이어 점프");
            }
            public void Skill()
            {
                Console.WriteLine("플레이어 스킬");
            }
        }
    }
}

```


#### 지정자 (Specifier)
델리게이트를 지정자로 사용가능
함수를 매개변수로써 전달해서 사용가능
```cs
internal class Program
{
    public static void Main()
    {
        //bool bigger = Compare(3, 2, Bigger);
        //bool less = Compare(3, 2, Less);
        //bool equal = Compare(3, 2, Equal);
        
        int[] array = { 1, 3, 5, 7, 9 };

        int less = CountIf(array, 4, Less); //4보다 작은애 몇개있는지
        int bigger = CountIf(array, 4, Bigger);
        int equal = CountIf(array, 3, Equal);
    }

    public static bool Bigger(int left, int right)
    {
        return left > right;
    }

    public static bool Less(int left, int right)
    {
        return left < right;
    }
    public static bool Equal(int left, int right)
    {
        return left == right;
    }

    public static int CountIf(int[] array, int value, Func<int, int, bool> comparer)
    {
        int count = 0;
        foreach (int element in array)
        {
            if (comparer(element, value))
            {
                count++;
            }
        }
        return count;
    }

    public static bool Compare(int left, int right, Func<int,int,bool> comparer)
    {
        return comparer(left, right);
    }
}
```

### 델리게이트 체인
```cs

    public static void Main()
    {
        Action action;

        //1.
        action = AAA;
        action += BBB;
        action += CCC;
        action += CCC;
        action();

        //델리게이트 체인
        //AAA
        //BBB
        //CCC
        //CCC
        //만약 action -= CCC; 하면 마지막 CCC호출 안됨

        //2.
        action += AAA;
        action -= AAA;

        if (action != null)
        {
            action(); //null인데 실행하면 안됨
        }
    }

    public static void AAA()
    {
        Console.WriteLine("AAA");
    }
    public static void BBB()
    {
        Console.WriteLine("BBB");
    }
    public static void CCC()
    {
        Console.WriteLine("CCC");
    }
```

#### 이벤트
상태를 전하는
```cs
internal class Program
{
    public class Event
    {
        public class Player
        {
            public event Action OnDied;   //델리게이트에 event키워드를 붙임

            public void Die()
            {
                //나 죽었다!
                Console.WriteLine("플레이어가 죽었습니다.");

                if(OnDied != null)
                {
                    OnDied();   //일련의 사건이 발생했을때 이벤트 발생
                }
            }
        }
        
        public class UI
        {
            public void GameOverUI()
            {
                Console.WriteLine("게임오버 창을 띄웁니다.");
            }
        }
        public class Sound
        {
            public void DeadSound()
            {
                Console.WriteLine("서글픈 음악을 출력합니다.");
            }
        }
        public class Monster
        {
            public void AttackStop()
            {
                Console.WriteLine("몬스터가 공격을 멈춥니다.");
            }
        }

        public class Camera
        {
            public void Shake()
            {
                Console.WriteLine("카메라가 흔들립니다!");
            }
        }

        public static void Main()
        {
            Player player = new Player();
            UI ui = new UI();
            Sound sound = new Sound();
            Monster monster1 = new Monster();
            Camera cam = new Camera();

            player.OnDied += ui.GameOverUI;
            player.OnDied += sound.DeadSound;
            player.OnDied += monster1.AttackStop;

            //만약실수로 = 대입해버리면 이전내용들 사라지니까
            //player.OnDied = cam.Shake;

            //player.OnDied(); //그냥 이벤트를 외부에서 쓰면 안죽었는데 죽은것처럼됨
            //델리게이트 원본 그대로 이벤트로써 쓰기에는
            //1. =(대입) 해버리면 기존 반응할 객체들이 사라질 수 있음
            //2. 외부에서 이벤트를 발생시켜 의도치 않은 

            //델리게이트에 event키워드를 붙이는 경우
            //= (대입) 연산이 불가능해진다.기존 반응할 객체들이 사라지지 않음
            //    외부에서 이벤트 발생 금지시킴(발생은 player만 시킬수있음)
            player.Die();
        }
    }
}
```
