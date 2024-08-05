### 해시 테이블
키값 인덱스로 찾기
```cs
internal class Program
{
	static void Main(string[] args)
	{
		Student[] students = new Student[10000]; //총 인덱스 갯수
		students[1111] = new Student() { name = "일일", phone = 01011111111 };
		students[1234] = new Student() { name = "일이", phone = 01012341234 };

		//찾고싶을때
		Student find = students[1111]; //일일
	}

	public class Student
	{
		public string name;
		public int phone; //키값이됨
	}
}

//해싱 : 20억개나 되는 핸드폰 번호 => 뒷자리만 쓰는 1만개로 뭉치기
//해시함수 : 너 핸드폰 뒷자리 뭐야 010111111111 => 1111
//탐색 : table[index]
```


```
// 이렇게 중간중간 비어있음
//   [0]   [1]   [2]        [27]        [66]       [997] [998] [999]
// ┌─────┬─────┬─────┬─  ─┬──────┬─  ─┬──────┬─  ─┬─────┬─────┬─────┐
// │     │     │  2  │....│ 8027 │....│ 2066 │....│     │ 998 │     │
// └─────┴─────┴─────┴─  ─┴──────┴─  ─┴──────┴─  ─┴─────┴─────┴─────┘
```
### 해시함수
키값을 해싱하여 고유한 index를 만드는 함수 (키는 해시 함수를 통해 해시값으로 변환되고 이 해시값은 값에 접근하는 데 사용된다)
조건으로 하나의 키값을 해싱하는 경우 반드시 항상 같은 index를 반환해야 함
대표적인 해시함수로 나눗셈법이 있음 ex. 2581 → (2581 % 1000) = 581. 해시 테이블의 인덱스 `581`에 저장
재해싱이 일어나는 순간: 용량의 70% 차지하는 순간
### 해시테이블 주의점 - 키 충돌
- 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
- 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
### 키충돌 해결방안
#### 1. 체이닝
같은 키값을  같은곳에 두어 분류해놓는 방식
```
// 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
// 장점 : 해시테이블에 자료사용률에 따른 성능저하가 적음
// 단점 : 해시테이블 외 추가적인 저장공간이 필요, 삽입삭제시 오버헤드가 발생
//
//   [0]   [1]   [2]        [81]      [997] [998] [999]
// ┌─────┬─────┬─────┬─  ─┬──────┬─  ─┬─────┬─────┬─────┐
// │     │     │     │....│  │   │....│     │     │     │
// └─────┴─────┴─────┴─  ─┴──│───┴─  ─┴─────┴─────┴─────┘
//                           ↓
//                        ┌──────┬─┐ ┌──────┬─┐
//                        │ 1081 │──→│ 2081 │ │
//                        └──────┴─┘ └──────┴─┘
```

#### 2. 개방주소법 (C#에서 사용)
- 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
- 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
- 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
- 단점 : 해시테이블에 자료사용률에 따른 성능저하가 발생. 겹칠일이 많아짐

ㄴ 선형 탐사: 배열을 순회하며 빈 공간에 바로 할당하는 방식
```
//                          
//   [0]   [1]   [2]        [81]   [82]       [997] [998] [999]
// ┌─────┬─────┬─────┬─  ─┬──────┬──────┬─  ─┬─────┬─────┬─────┐
// │     │     │     │....│ 1081 │      │....│     │     │     │
// └─────┴─────┴─────┴─  ─┴──────┴──────┴─  ─┴─────┴─────┴─────┘
//                          ↑2081(충돌)
//
//   [0]   [1]   [2]        [81]   [82]       [997] [998] [999]
// ┌─────┬─────┬─────┬─  ─┬──────┬──────┬─  ─┬─────┬─────┬─────┐
// │     │     │     │....│ 1081 │ 2081 │....│     │     │     │
// └─────┴─────┴─────┴─  ─┴──────┴──────┴─  ─┴─────┴─────┴─────┘
//                                 ↑(다음위치에 저장)
```
ㄴ 제곱 탐사: 겹쳤으면 1의 2제곱, 또 겹쳤으면 2의 2제곱, 3의 2제곱씩 늘려가며 인덱스를 탐색하고 데이터를 보관하는 방식
ㄴ 이중 해싱: 충돌된 값을 한번 더 해함


# Dictionary
C#에서 제공하는 해시테이블의 구현체
많은 자료에서 빨리빨리 찾고싶을때
내부적으로 해시테이블을 사용
`Dictionary<TKey, TValue>`

```cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 해시테이블 기반의 Dictionary 자료구조
        Dictionary<string, Monster> monsterDic = new Dictionary<string, Monster>();

        // 삽입
        monsterDic.Add("피카츄", new Monster("피카츄", MonsterType.Electric, 80)); 
        monsterDic.Add("파이리", new Monster("파이리", MonsterType.Fire, 90));
        monsterDic.Add("꼬부기", new Monster("꼬부기", MonsterType.Water, 70));
        monsterDic.Add("이상해씨", new Monster("이상해씨", MonsterType.Grass, 100));

        // 삭제
        monsterDic.Remove("이상해씨");

        // 탐색
        if (monsterDic.ContainsKey("피카츄")) // 포함 확인
        {
            Monster find = monsterDic["피카츄"]; // O(1)
            Console.WriteLine($"{find.name}, {find.type}, {find.hp}");
        }
    }
}

public enum MonsterType
{
    Fire,
    Water,
    Grass,
    Electric,
    Wind
}

public class Monster
{
    public string name;
    public MonsterType type;
    public int hp;

    public Monster(string name, MonsterType type, int hp)
    {
        this.name = name;
        this.type = type;
        this.hp = hp;
    }
}

```

