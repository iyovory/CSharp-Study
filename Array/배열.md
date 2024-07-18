
인덱스를 통하여 배열요소(Element)에 접근할 수 있음
처음요소의 인덱스는 0부터 시작함
`자료형[] 배열이름 = new 자료형[크기];`

미리 갯수를 정해줘야하는이유 : 형에 따라 크기 차지 

```
//1.
int[] scores = new int[20];
//2.
string[] array;
array = new string[4]; //이렇게 몇자리를 쓸건지 선언해줘야함
//3.
int[] scores = new int[] { 1,2,3,4 }; //뒤에 요소 쓰면 갯수 안써도됨
```

자료형은 값 타입과 참조타입으로 나뉨
int,float같은 직접 숫자 대입은 값 타입
어디 공간에 대한 위치(주소)를 저장하는건 참조 타입 (int는 값 타입이므로 int 배열도 값 타입이다)

* for : 수정가능
```
int[] scores = new int[4];

scores[0] = 10;
scores[1] = 20;
//scores[2] 생략하면 0으로 들어감
scores[3] = 40;

for (int i = 0; i< scores.Length; i++){
	Console.WriteLine($"배열의 {i}번째 요소는: {scores[i]}");
```

* foreach : 열람만 
```
// element = 여기서 쓰고 버릴 아무 단어, 한가지 빼오는 요소
// scores 배열
int sum;
foreach (string score in scores)
{
	sum += score;
	Console.WriteLine(score) //score 자체를 바꿀 순 없음
}
```

몇번지에 있는지 찾을 수 있음
자료형크기 * 몇번째 + 현재위치크기
4 * 800 + 100

### 다차원 배열

```
string[,] shortCuts;
shortCuts = new string[3,4]; //3개의 줄, 4개의 칸 빌려오기
shortCuts[0,0] = "";
이걸 바로 선언하려면
string[,] shortCuts;
shortCuts = new string[3,4]
{
	{"0,0" , "0,1", "0,2", "0,3"},
	{"1,0" , "1,1", "1,2", "1,3"}
};
```

```
GetLength사용해야함

for (int i = 0; i < shortCuts.GetLength(0); i++)
{
    for (int j = 0; j < shortCuts.GetLength(1); j++)
    {
        Console.Write(shortCuts[i, j] + "\t");
    }
    Console.WriteLine();
}
```

```
// 테스트용 두가지 숫자 입력 적당히 받기
Console.WriteLine("행을 입력");
int input = int.Parse(Console.ReadLine());
Console.WriteLine("열을 입력");
int input2 = int.Parse(Console.ReadLine());
```

```
// 2차원 배열 생성1
int[,] asf = new int[input, input2];
System.Console.WriteLine(asf.Length);

// 2차원 배열 생성2
int[,] matrix = new int[3,100]; //앞에껀 위아래 후껀 좌우
Console.WriteLine(matrix.GetLength(0)); //3
Console.WriteLine(matrix.GetLength(1)); //100
```

```
for (int y=0; y < matrix.GetLength(0); y++)
{
	for (int x=0; x < matrix.GetLength(1); x++)
	{
		Console.WriteLine(matrix[y,x]);
	}
}
```

```
string[,] students = new string[3,10]; //3개 반이 있고 10명씩 있다.
students[2,1] //2번째 반에 1번째 학생
```

```
string[,] students = new string[3,4]
{
	{ "김김김", "이이이", "로로로", "르르르" },
};

int totalStudentCount = students.Length;

int classCount = students.GetLength(0); //반 수
int studentCount = students.GetLength(1); //학생 수
```

```
for (int i = 0; i < students.GetLength(0); i++)
{
    Console.WriteLine($"{i + 1}반!");
    for (int j = 0; j < students.GetLength(1); j++)
    {
        Console.WriteLine($"  {students[i, j]}");
    }
}
```

크기를 다르게 설정해야할경우
```
string[][] ddd= new string[4][]; // 몇반인지는 확실히 써야함. 그냥 배열이 4개 있다는 뜻
ddd[0] = new string[5];
ddd[1] = new string[3];
```

### 문자열
string text = "안녕하세요"; //얘가 사실은
char[] texts = new char[] {'안', '녕', '하', ...}; //얘다

char word = texg[2]; //하 - string은 사실 배열이다. 불러오는건 가능하지만 string의 불변성때문에 수정할수는 없다.
texts[0] = '한'; //이건 string이 아니기에 수정 가능 

* 배열로 만드는법
```
char[] userNumArray = userNum.ToString().ToCharArray();
Console.WriteLine(userNumArray[0]);
```
배열 자체를 직접 Console.WriteLine에 전달하면 배열의 타입 정보(즉, System.Int32[])를 출력하게 되어
join으로 출력해야함
```
Console.WriteLine("string.Join(", ", randomNum));
```