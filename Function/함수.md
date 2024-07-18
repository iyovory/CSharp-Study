함수명만 보고도 어떤 동작을 하는지 알 수 있음
한꺼번에 기능을 편집할 수 있음
조건문이 너무 길어질 경우에도 함수를 사용한다.(가독성)

### void 반환값이 없는 함수
static void 함수명(){} //반환값이 없으면 앞에 void를 붙임
return; //하는건 괜찮 

static void 함수명(string text){
	Console.WriteLine(text);
} //입력값을 요구하고, 연산 후 반환이 없는 형태의함수

static이 붙어있는 함수끼리 불러올 수 있음

```
static void MoveFoward()
{
	Console.WriteLine("전방으로 이동");
}

while(true){
	switch(Console.ReadKey(true).Key)
	//true면 전방이동, false면 w이동
	{
		case ConsoleKey.W:
		break;
	}
}
```

열거형 쓸 수 있음
```
public static void Attack(int power, Monster monster)
{
	Console($"{monster.name} 공격을 시도합니다.");
}
```

```

static void MoveUp()
{
	Console.WriteLine("위쪽으로 이동");
}

while(true){
	ConsoleKey key = Console.ReadKey().key; //ConsoleKey는 Shift나 이런거 같이눌렀는지 다 잡아줌

	switch(key)
	{
		case ConsoleKey.W:
		case ConsoleLey.UpArrow:
		MoveUp();
		break;
	}
}
```

### 반환값이 있는 함수

원주율을 반환하는 함수
```
static double GetPI()
{
	double pi = 3.141592;
	Console.WriteLine("파이값을 반환하였습니다");
	return pi;
}

static void Main(string[] args)
{
	GetPI();//이렇게만하면 파이값 안뜸. pi는 다른 함수에서 쓰이는 지역변수이기때문에
	
	double returnedDoubleNum = GetPI(); //함수의 반환형에 있는 형태로 선언해줘야함 3.141592
	Console.WriteLine(returnedDoubleNum);
	

}
```

```
static int GetInt(string inputComment, string inputComment){
    int value;
    while (true)
    {
        Console.Write("정수를 입력해주세요: ");
    
        bool success = int.TryParse(Console.ReadLine(), out value);
        if (success)
        {
            break;
        }
        else
        {
            Console.WriteLine("정수만 입력해주세요");
        }
    }
    return value;
    }
}
static void Main(string[] args)
{
    int input = GetInt("첫번째 수 입력: ", "제대로 입력하세요.");
}
```

```
public struct Monster
{
	public string name;
	public int level;
}

pulic static Monster MakeMonster(string name)
{
	switch (name)
	{
		case "오크":
			 return new Monster() { name="오크", level=1 };
		deafult:
			break;
	}
	return new Monster();
}

static void Main(string[] args)
{
    Monster orc1 = MakeMonster("오크");
}
```

```
static int GetDamage(int attack, float buff, float rate)
{
	//기본공격력 * 버프력 => 크리티컬(2배 데미지)
	return (int)(attack * (1 + buff));
}

static void Main(string[] args)
{
	int damage = GetDamage(10, 0.2f, 0.1f);
}

```

이렇게 끝내고싶을때도 return 가능
```
        static void Print(String name)
        {
            if (name == "")
            {
                Console.WriteLine($"이름을 입력해주세요");
                return;
            }
            Console.WriteLine($"이름: {name}");
        }
```

### out 인자, 파라미터
추가적인 반환값이 필요할때
(왜 return에서 한번에 여러개 내보내지않고 out을 따로 쓰게끔 만들었을까요? => return은 함수의 끝을 의미하기 떄문에 여러개를 끝낼순 없습니다)
```

        //return은 원랜 하나밖에 return못하는데 out을 쓰면 여러개 반환 가능
        //몫이랑 나머지를 한번에 계산하는 함수
        //return 5 / 3; return 5 % 3;
        static bool Divide(int left, int right, out int quotient, out int remain)
        {
            if (right ==0)
            {
                Console.WriteLine("0으로는 나눌 수 없습니다.");
                quotient = 0;
                remain = 0;
                return false;
            }
            quotient = left / right;
            remain = left % right;
            return true; //코드경로의 일부만 값을 반환합니다. 안쓰면 뜸
        }

        static void Main(string[] args)
        {
            Divide(10, 4, out int quotient, out int remain); //int선언 해줘야 쓸 수 있음
            Console.WriteLine($"10을 4로 나눈 몫은 {quotient}, 나머지는 {remain}");
                
        }
```

### 디버깅
함수도 F11로 단계별로 볼 수 있음
함수 호출 스택 : F11을 누르면 나오는 호출스택이 있는데, 제일 위에있는거부터 하게됨(밑에있는 블록을 먼저 뺄 수 없듯이)


### ref
원본(Main)을 바꾸는 효과
Call by Value(복사본), Call by Refference(바로가기)
메모장 바로가기에서 바꾸면 원본도 바뀌는 효과

```
        static void UpgradeDamage(ref int damage)
        {
            damage = damage + 10;
        }

        static void Main(string[] args)
        {
            int damage = 10;
            UpgradeDamage(ref damage); 

            Console.WriteLine(damage); //원래는 그냥 10이 출력되는데(다른 지역변수니까)
                                       //ref를 통해 20이 됨
        }
```

### 배열
배열자체가 원래 가리키는 형태라서 
배열을 전달해줄땐 애초에 있던 가리키는걸 주는 형태다