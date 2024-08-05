using System.Threading;

public class Program
{
    // 몬스터 데이터베이스 구현하기
    /*
    다음의 조건을 충족하는 프로그램을 구현하시오
    구현 클래스
    MonsterData
    Monster
    프로그램 시작 시 MonsterData는 몬스터 이름 기준의 string Key 값으로 딕셔너리에 저장한다.
    최소 5종류 이상 저장한다.
    Monster 클래스의 인스턴스 생성 시, 생성자를 사용해 딕셔너리에 저장된 MonsterData 클래스의 정보를 불러와 인스턴스의 데이터를 초기화해야 한다.
    */

    public enum MonsterType { Fire, Water, Grass, Electric, Wind }

    public class MonsterData
    {
        public static Dictionary<string, Monster> monsterDictionary = new Dictionary<string, Monster>();
        public static void Initaialize()
        {
            monsterDictionary.Add("피카츄", new Monster("피카츄", MonsterType.Electric, 100));
            monsterDictionary.Add("파이리", new Monster("파이리", MonsterType.Fire, 90));
            monsterDictionary.Add("꼬부기", new Monster("꼬부기", MonsterType.Water, 110));
            monsterDictionary.Add("이상해씨", new Monster("이상해씨", MonsterType.Grass, 120));
            monsterDictionary.Add("피죤", new Monster("피죤", MonsterType.Wind, 60));
        }
    }

    public class Monster
    {
        public string name;
        public MonsterType type;
        public int hp;
        
        public Monster(string name)
        {
            Monster data = MonsterData.monsterDictionary[name]; 
            this.name = data.name;
            this.type = data.type;
            this.hp = data.hp;
        }

        public Monster (string name, MonsterType type, int hp)
        {
            this.name = name;
            this.type = type;
            this.hp = hp;
        }
    }


    static void Main(string[] args)
    {
        MonsterData.Initaialize();

        Monster monster1 = new Monster("피카츄");
        Monster monster2 = new Monster("파이리");
        Monster monster3 = new Monster("꼬부기");
        Monster monster4 = new Monster("이상해씨");
        Monster monster5 = new Monster("피죤");

        /*
        따라하긴 했는데...
        Monster (string name, MonsterType type, int hp)는 생성하고자 만든걸 알겠는데,
        Monster(string name) 함수는 딕셔너리에 등록해두면 키값만 부르면 등록되어있는게 나온다는걸 나타내고자 하는건가요?
        */
    }



    #region 예시
    //public static class MonsterData
    //{
    //    public static Dictionary<string, Monster> dict;

    //    // 몬스터 사전을 초기화 하기 위한 함수
    //    // 또는, static 생성자를 쓸 수 있다.
    //    public static void Initialize()
    //    {
    //        dict = new Dictionary<string, Monster>();

    //        dict.Add("피카츄", new Monster("피카츄", MonsterType.Electric, 100));
    //        dict.Add("파이리", new Monster("파이리", MonsterType.Fire, 90));
    //        dict.Add("꼬부기", new Monster("꼬부기", MonsterType.Water, 110));
    //        dict.Add("이상해씨", new Monster("이상해씨", MonsterType.Grass, 120));
    //        dict.Add("피죤", new Monster("피죤", MonsterType.Wind, 60));
    //    }
    //}

    //public class Monster
    //{
    //    private string name;
    //    public string Name { get => name; set => name = value; }

    //    private MonsterType type;
    //    public MonsterType Type { get => type; set => type = value; }

    //    private int hp;
    //    public int HP { get => hp; set => hp = value; }

    //    public Monster(string name)
    //    {
    //        Monster data = MonsterData.dict[name];
    //        this.name = data.name;
    //        this.type = data.type;
    //        this.hp = data.hp;
    //    }

    //    public Monster (string name, MonsterType type, int hp)
    //    {
    //        this.name = name;
    //        this.type = type;
    //        this.hp = hp;
    //    }
    //}


    //static void Main()
    //{
    //    MonsterData.Initialize();

    //    Monster monster1 = new Monster("피카츄");
    //    Monster monster2 = new Monster("파이리");
    //    Monster monster3 = new Monster("꼬부기");
    //    Monster monster4 = new Monster("이상해씨");
    //    Monster monster5 = new Monster("피죤");
    //}
    #endregion

}