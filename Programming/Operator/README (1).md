### operator

1. / (나누기)
정수형이랑 정수형 계산했을때 무조건 정수형으로 결과 나옴. 소수점 버려버림 (ex. 5/2 = 2) 

소수점이 필요하다면 하나라도 소수점 적용 
(ex. 5.0/2.0 or 5.0/2)

ex. 실수형일경우
```
float divideNum;
divideNum = 2 / 5 => (X) 결과 0 나옴 정수형으로 계산해서
divideNum = 2f / 5f => (O)
```

* 임시로 형변환 하는법
ex 1. 실수형으로 바꾸기
int num = 9;
(float)num 이렇게

ex 2. 셋이 나눠가져야하는 상황
float reward = 1000.0f;
int exp = (int)(reward / 3); 


2. % (나머지)
125 % 10 하면 젤 끝에있는 5 출력됨
125 세번째에있는 125/1%10 = 2 (/1생략가능)
125 두번째에있는 125/10%10 = 2
125 첫번째에있는 125/100%10 = 1

* 복합대입연산자
두 줄 써야될걸 한 줄로 쓸 수 있음
playerHP = playerHP - damage
playerHP -= damage

* ReadLine 사용자가 입력
	콘솔 출력만 있음. 입력 받는것만 가능
	
	
	1.
	string input;
	input = Console.ReadLine(); // 입력받은 내용에 대해서 집어넣기
	Console.WriteLine("입력하신 내용은 {0} 입니다.", input);
	
	2.
	Console.WriteLine("나이를 입력하십시오");
	string age;
	age = Console.ReadLine();



* 문자열 보간 $
	{0}, {1} 이렇게 안하고 한번에 적을수있음.
	숫자도 문자열로 바뀌니 주의!
	Console.WriteLine($"당신의 나이는 {age}입니다");

### 숫자로 변환

1. Parse
나만 입력할 수 있는 데이터에 쓰는게 좋다.
int age;
int.Parse(age);
문자로 대답할 경우엔 오류 발생

Console.Write("나이를 입력하세요 : ");
string input = Console.ReadLine();
int age = int.Parse(input); // int형으로 입력받음

```
            float num1;
            float num2;
            Console.WriteLine("첫 번째 실수를 입력하여 주세요");
            num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("두 번째 실수를 입력하여 주세요");
            num2 = float.Parse(Console.ReadLine());
            Console.WriteLine($"두 수의 합은 {num1 + num2} 입니다");
```


2. TryParse
유저가 입력할 수 있는 데이터에 쓰는게 좋다.
int.TryParse("변환을 시도할 문자열", out 담고자하는정수);
문자로 대답할 경우엔 오류 발생 안하고 0으로 대답됨

Console.Write("나이를 입력하세요 : ");
int age;
bool success = int.TryParse(input, out age);
=> input에 3 넣었으면 age 3. input에 "셋" 넣었으면 age 0

bool success = int.TryParse(input, out age); // 바뀌는게 성공하면 true 반환

Console.WriteLine($"나이를 변환한 결과는 {success} 입니다.");
age+=1;
Console.WriteLine($"내년의 나이는 {age}입니다.");

[실수의 부정확함] 부동소수점
0.5 0.25 0.125 0.0625
0.5 (1/2) → 0.1
0.25 (1/4) → 0.01
0.125 (1/8) → 0.001
0.0625 (1/16) → 0.0001

2진수라서 절반씩밖에 계산못함.
만약 0.19 이러면 0.125 + 0.0625 이런식으로 계속 더해줌

float value = 10000001;
Console.WirteLine(value);
value값 10000000 나옴











