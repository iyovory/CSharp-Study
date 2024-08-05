namespace Class
{
    #region 1. 트레이너와 몬스터 제작하기
    /*
        트레이너와 몬스터 클래스를 구현하시오.
        트레이너는 최대 6마리의 몬스터를 가질 수 있다.
        트레이너가 몬스터 생성 시 몬스터의 체력을 지정 값으로 초기화 해야 한다.
        Main 함수에서 트레이너 인스턴스 생성 시, 트레이너의 이름을 초기화 해야 한다.
    */
    internal class Program
    {

        public class Trainer
        {
            public string name;
            string[] inventory = new string[6];

            public void GetMonster()
            {

            }
        }

        public class Monster
        {
            //멤버변수
            public string name;
            public int hp;

            public Monster(string _name, int _hp) //매개변수
            {
                name = _name; //이름이 똑같다면 this.name = name 해도됨
                hp = _hp;
            }
        }


        static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
            trainer.name = "지우";

            //Monster pikachu = new Monster() { name = "피카츄", hp = 100 }; 로 할때랑
            Monster pikachu = new Monster("피카츄", 100); // 이거랑 무슨 차이가 있나용?
            Monster bulbasaur = new Monster("이상해씨", 120);
            Monster charmander = new Monster("파이리", 110);
            Monster squirtle = new Monster("꼬부기", 130);
            Monster butterfree = new Monster("버터플", 90);
            Monster pidgeotto = new Monster("피죤투", 140);
        }
    }
    #endregion
}
