### 수도코드, 의사코드 작성 추천
한줄 한줄 단계별로 사람의 말로 미리 작성하는것

```
//1. 유저에게 입력하라는 안내 멘트를 출력
Console.WriteLine("입력해주세요");
//4. 그렇지 않다면, 만약 ~라면?
//5. 이도저도 아니라면?
```

### 콘솔 팁
```
//색상 변경
Console.ForegroundColor = ConsoleColor.Green; // <-> BackgroundColor
Console.WriteLine("내용내용내용");
Console.ResetColor();

//콘솔창 지우기
Console.Clear();
```

### 조건문
if, else if, else
순차적으로 처리되기때문에 제일 처음것이 맞으면 밑에껀 보지 않음 (적은 범위부터 큰범위로 파생되게끔하기)

```
int toDetermine; //문자열을 입력받아 변환 후 저장할 변수
bool isParsed; //변환 성공 여부

isParsed = int.TryParse(Console.ReadLine(), isParsed) //숫자면 if 문자면 else

if(isParsed) {
	Console.WriteLine("isParsed");
}else{
	Console.WriteLine("!isParsed");
}

string input = Console.ReadLine();
int number;
int.TryParse(input, out number);
if((number % 2 == 0){} //2의배수
if((number % 3 == 0){} //3의배수
```

### 논리 연산자
&& 	AND	둘 다 true여야 true
||	OR	한쪽이라도 true면 true

* if와 switch 조건문
if: 식일때(ex. 나누기가 0인것 등...)
case: 값일때(ex. 0일경우)

```
//2의 배수이면서 3의 배수인것은?
1. 중첩if
if((number % 2 == 0){
	if(number % 3 == 0){} 
}
2. 중첩if를 한줄로
if((number % 2 == 0 && number % 3 == 0){}
```

### switch
일치하는 분기점에 따른 행동
조건값에 따라 실행할 시작지점을 결정하는 조건문
한 케이스마다 break; 시켜줌
default == else

```
char key = 'w':
switch (key){
	case 'w':
		Console.WriteLine("위로 이동")'
		break;
	case 's':
		Console.WriteLine("아래로 이동")'
		break;
	}
	default:
		Console.WriteLine("이동하지 않습니다");
}
```

* if 대신 switch를 썼을때 좋은점
```
case 'w':
case 'W':
case 'ㅈ':
	Console.WriteLine("위로 이동")'
```
이렇게 연달아 쓸 수 있음.
if를 쓴다면 논리 연산자를 써야하므로 하나 추가될때 논리 고려해보고 써야함