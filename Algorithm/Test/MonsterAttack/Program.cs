using System;

namespace MonsterAttackNamespace
{
    /*
    1. 모든 몬스터들은 이름을 가지고 공격을 할 수 있다.
    2. 각각의 몬스터들은 이름이 다르며 공격방법이 다르다.
    3. 몬스터에 이름을 추가하는 경우 주어진 이름으로 활동한다.
    */

    //ㅠㅠ.............................. 뒤죽박죽인데 복습 열심히 하겠습니다
    class MonsterAttack
    {
        public abstract class Monster
        {
            public string Name { get; set; }

            public Monster(string name)
            {
                Name = name;
            }

            public abstract void MonsterAttack();
        }

        #region 몬스터들 
        public class Pikachu : Monster
        {
            Monster pikachu = new Monster("피카츄");

            public override void MonsterAttack()
            {
                Console.WriteLine("백만볼트!");
            }
        }

        public class Charmander : Monster
        {
            Monster pikachu = new Monster("파이리");

            public override void MonsterAttack()
            {
                Console.WriteLine("화염방사!");
            }
        }

        public class Squirtle : Monster
        {
            Monster pikachu = new Monster("꼬부기");

            public override void MonsterAttack()
            {
                Console.WriteLine("물총발사!");
            }
        }

        public class Bulbasaur : Monster
        {
            Monster pikachu = new Monster("이상해씨");

            public override void MonsterAttack()
            {
                Console.WriteLine("덩굴채찍!");
            }
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Monster[] monsters = new Monster[5];
            monsters[0] = new Pikachu();
            monsters[1] = new Charmander();
            monsters[2] = new Squirtle();
            monsters[3] = new Bulbasaur();
            monsters[4] = new Pikachu("털뭉치");

            foreach (Monster monster in monsters)
            {
                Console.WriteLine($"{monster.Name} 공격해!");
                monster.MonsterAttack();
                Console.WriteLine();
            }
        }
    }
}
