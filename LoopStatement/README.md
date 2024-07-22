# 반복문

### 전위연산/후위연산
Console.WriteLine(value); //0
Console.WriteLine(value++); //0 일단 값 준다음에 늘려
Console.WriteLine(value); //1

Console.WriteLine(value); //0
Console.WriteLine(++value); //0 늘린 다음에 값 줘 
Console.WriteLine(value); //1


### for 반복문
```
for(int counter = 0; counter < 10; counter++)
{
	Console.WriteLine("");
}
```
1. 초기식: 반복을 몇부터 시작할것인지?
int counter = 0;

2. 조건식
counter < 10
무조건 이 수 만큼 반복됨
counter = 10을 쓸 경우에 false라서 바로 안돌아감

3. 증감식
counter++ (counter = counter+1)

홀수/짝수 구하기
```
for(int i = 0; i < 10; i++)
{
	if(i % 2 == 0)
	{
		// 짝수
	}
}
```

##### 반복문속의 반복문
구구단
```
for(int i = 2; i < 10; i++)
{
	for(int j = 1; i < 10; j++)
	{
	
	}
}
```

학생수
```
for(int ban = 1; ban <= 8; ban++)
{
	Console.WirteLine($"{ban}반에 갑니다");

	for(int student = 1; ban <= 30; student++)
	{
		Console.WirteLine($"	{student}번 학생 나오세요");
	}
}
```


### while 반복문
조건식의 true, false에 따라 블록을 반복
```
int coin = 300;
while (coin > 0)
{
	Console.WriteLine("100원 동전을 꺼냅니다");
	coin -= 100;
}
3번반복
```

* for, while 차이점:
for는 몇 번 반복할지
while는 맞을때 까지(플레이어 살아있을때까지, 가지고있는 카드들이 소진될때까지)

### do while 반복문]
블록을 1회 실행 후 조건식의 true, false에 따라 블록을 반복(실행을 먼저 해본다음에 조건 체크하고 맞으면 반복)
비밀번호 체크할때 씀

```
int input = 0;
do
{
	Console.Write("1에서 9 사이의 수를 입력하세요");
	string text = Console.ReadLine();
	int.TryParse(text, out input);
} while (input < 1||9 < input); //여기에  false 넣으면 틀렸을경우 무한입력
```

* while, do while 차이점:
while 확인 후에 실행할지
do while 실행한 다음 확인


### break 문
가장 가까운 반복문을 멈추고 넘어가는 키워드

무한히 증가하다가 조건이 맞으면 멈추는 기능

```
int increasingNum = 1;
int endPoint 10;

while(true) //무한반복
{
	increasingNum = increasingNum * 2;
	//복합할당  increasingNum *= 2
	Console.WriteLine(increasingNum);

	if(increasingNum > endPoint)
	{
		Console.WriteLine("{endPoint} 초과로 종료");
		break;
	}
}
```

```
int inventorySlot = 20;
int potionPosition = 5;

for(int i = 0; i < inventorySlot; i++)
{
	Console.WriteLine($"{i}번째 칸에서 포션 찾기를 시도합니다");
	if(i == potionPosition)
	{
		Console.WriteLine($"포션을 찾았고 먹었습니다.");
	break; //먹었는데도 나머지 15개도 다 찾고있을 필요 없으니 걸어줌

	}
}
```

```
int num = 35;
for(int i = 2; i < num; i++)
{
	if(num % i == 0)
	{
		Console.WriteLine($"{num}을 나눌 수 있는 가장 작은 수는 {i} 입니다.");
		break;
	}
}
```


### continue 문
넘기고 다음 반복을 시작하는 키워드

```
int counter = 0;
while(counter<13)
{
	coutner++;
	if(counter%2==0)
	{
		continue;
	}
	Console.WriteLine("출력안되고 다시 counter++");
}
```

만약 2, 3의 배수인 수라면 출력
```
for (int i = 1; i < 10; i++)
{
    if (i % 2 != 0 && i % 3 != 0)
    {
        continue; //아닌것들은 넘어가짐
    }
    Console.WriteLine($"{i}는 2의 배수이거나 3의 배수입니다."); //2,3,4,6,8,9
}
```




