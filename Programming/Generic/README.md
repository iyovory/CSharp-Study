# 제네릭
자료형의 형식을 지정하지 않고 함수를 정의
기능을 구현한 뒤 사용 당시에 자료형의 형식을 지정해서 사용

**오버로딩** 쓸 경우
```cs
// 오버로딩: 같은 이름의 함수를 다른 인자값(매개변수)을 통해 구현하는 경우
//          사용당시에 집어넣는 자료형으로 함수를 구분할 수 있기 때문에
//          같은 이름의 함수를 사용하는 것을 허락하는 기술

internal class Program
{
	static void Main(string[] args)
	{
		int a = 10;
		int b = 20;

		float a = 10;
		float b = 20;

		Util.Swap(ref a, ref b);

		Console.WriteLine($"a={a} b={b}");
	}
}

public static class Util
{
	public static void Swap(ref int left, ref int right)
	{
		int temp = left;
		left = right;
		right = temp;
	}
	public static void Swap(ref float left, ref float right)
	{
		float temp = left;
		left = right;
		right = temp;
	}
}
```

오버로딩은 함수명은 같은데 다른상황일때에 따라 다를때 쓰는게 좋음 
```cs
public class Player
{
	public void Attack(Monster monster)
	{
		//몬스터를 공격력만큼 공격합니다
	}
	public void Attack(Player player)
	{
		//플레이어를 밀칩니다
	}
	public void Attack(Wall wall)
	{
		//벽을 부숩니다
	}
}
```

**제네릭** 쓸 경우
같은걸반복할때 좋음
```cs
{
	static void Main(string[] args)
	{
		double a = 10;
		double b = 20;

		Util.Swap(ref a, ref b);

		Console.WriteLine($"a={a} b={b}");
	}
}

public static class Util
{
	public static void Swap<T>(ref T left, ref T right)
	{
		T temp = left;
		left = right;
		right = temp;
	}
}
```

제약조건 걸 수 있음
이 자리에는 이것만 올 수 있어
```cs
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 20;

            Util.Swap(ref a, ref b);

            Console.WriteLine($"a={a} b={b}");
        }
    }

    public static class Util
    {
        public static void Swap<T>(ref T left, ref T right) where T : struct // struct에 class,char도 올 수 있음
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
```

```cs
internal class Program
{
	static void Main(string[] args)
	{
		Monster orc1 = new Monster("오크");
		Monster orc2 = new Monster("오크");

		if (Util.Same(orc1, orc2)) 
		{
			Console.WriteLine("둘이 같은 몬스터입니다.");
		}
		else
		{
			Console.WriteLine("둘이 다른 몬스터입니다.");
		}
	}
}

public class Monster
{
	public string name;

	public Monster(string name)
	{
		this.name = name;
	}
}

public static class Util
{
	public static bool Same<T>(T left, T right) where T : Monster
	{
		return left.name == right.name;
	}
}
```

### 박싱, 언박싱
이걸 최소화해줘야함. 편하지만 이 과정에서 시간 많이 소요되어 성능 저하
```cs
//박싱 : 값형식 => 참조형식
int a = 5; //float, double, 구조체 다 object에 담을 수 있음
object b = a; //가장 최상위 부모클래스

//언박싱 : 값형식 => 참조형식 
int result = (int)left * (int)right;
```








