**enum**
직접 만드는 자료형(이미 있는건 int, float ...)
가독성 좋음
타입스크립트같은느낌?

class와 Main 사이에 작성해야함.
```
enum BurgerKingMenu
{
	Bulgogi, Monster, Cheese
}
```

Main 안에서 사용
```
BurgerKingMenu Chicken; //BurgerKingMenu안에 있는것만 사용 가능. int는 정수만 가능하고 이런것처럼

BurgerKingMenu bergerking = BurgerKingMenu.Mage;
switch (bergerking)
{
	case BurgerKingMenu.Bulgogi:
		Console.WriteLine("불고기");
		break;
}

여따 넣기
```

순서 자동으로 맥여짐
```
enum BurgerKingMenu
{
	Bulgogi=1, Monster, Cheese, exit=9, reset
}
// Monster, Cheese는 Bulgogi 따라 2,3
// reset은 exit따라 10이 됨

// 9를 입력하여도, exit을 입력하여도 똑같음(열거형에 적혀있던 내용을 그대로 기입해도됨)
```

```
// 입력받기
BurgerKingMenu bkOrder;
Enum.TryParse(Console.ReadLine(), out bkOrder);

Console.WriteLine("선택하신 메뉴는 bkOrder 입니다.");
```

의도하지 않은값
```
bkOrder = (BurgerKingMenu)7; 하면 7이 없는데도 7이라고 뜸
Console.WriteLine((int)bkOrder);
Console.WriteLine(bkOrder);

열거형 내에 특정 정의가 있는지 내장 함수가 있음.
Enum.IsDefined(typeof(BurgerKingMenu), 7);
```

예시
```
enum EquipType { Head, Body, Foot, Weapon, SIZE } //맨끝에 항상 SIZE

string[] equipment = new string[(int)EquipType.SIZE];

equipment[(int)EquipType.Head] = "철모자";
```

```
(int)job; //순서대로 숫자로 바뀜
(Job)2 //이것도 가능

Enum.TryPars("전사", out Job); //Job에 넣을 수 있음
bool success = Enum.IsDefined(typeof(Job), 5); //Job형의 멤버중 정수를 쓰는 멤버가 있는지 확인하고싶을때
```



int.Pasrse를 쓰지않고 변환하기(아스키코드 유니코드)
int value = int.Parse("123"); 
```
int value = 0;
for (int i = 0; i<"123".Length; i++)
{
	value *= 10;
	value += (int)"123"[i] - (int)'0';
}
Console.(value);
```





