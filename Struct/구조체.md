**struct**
여러 데이터를 저장하기 위한 단위용도로 사용
데이터와 관련 기능을 캡슐화 할 수 있는 값 형식

```
//class 밑에 Main 위에
struct Student
{
	public string name;
	public int id;
	public int age;
	public string type;
	private float eye;
	//아무것도 적지않으면 기본값 private
}

Student student1 = new Student();

student1.name = "홍길동";
student1.eye = 1.5f; //외부에선 private이라 수정 불가
```


```
enum State { Ready, Process, Done, Reward }
struct Quest
{
	public string name;
	public string description;
	public State state;
	public int exp;
	public int gold;
}

Quest[] quests = new Quest();

quest[0].name = "고블린을 잡아주세요";
quest[0].description = "용사여 우리마을이 위기를 맞이했네... 앞에 보이는 고블린을 처치해주게";
quest[0].state = State.Ready;
quest[0].exp = 10;
quest[0].gold = 0;

//수행중으로 변경
quest[0].state = State.Process; 
```

```
public enum Type { Equip, Usalbe }

Item potion = new Item() { name="포션", type=Item.Type.Usable; }
//=
Item potion = new Item();
potion.name = "포션";
potion.type = Item.Type.Usable;
```

배열일때
```
        public struct Inventory
        {
            public string name;
            public int count;
        }

            data.inventory = new Inventory[5];
```