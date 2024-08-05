
### 확장메소드
기존에 있는 클래스를 건드리지 않고, 기능을 추가할 수 있도록 하는 기능
확장 메서드는 기존 클래스에 코드를 수정하지 않고도 새로운 메서드를 추가하고 사용할 수 있도록 하는 기능
정적 클래스에 정의되어야 한다.
정적 함수로 정의해야 한다. (this 키워드)

```
public static int Test(this float target, int a) 
```
target: 뭘 확장하고싶은지, a: 그냥 매개변수
호출할때 그냥 Test(target인 여기만 씀)

```cs
namespace Additional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float value = 2.7f;

            Console.WriteLine(value.Round());

            string text = "aaaaa";
            string[] splited = text.Split(' ');
            Console.WriteLine(text.WordCount());
        }
    }

    public static class Extension
    {
        //반올림 기능
        public static int Round(this float target)
        {
            if(target % 1 >= 0.5f)
            {
                return (int)(target + 1);
            }
            else
            {
                return (int)(target);
            }
        }

        //string에 추가하는 기능
        public static int WordCount(this string text)
        {
            return text.Split(' ').Length;
        }
    }
}

```

### Property

```cs
namespace Additional
{
    internal class Property
    {
        public class Player
        {
            private int hp;

            // <Getter Setter>
            // 맴버변수가 외부객체와 상호작용하는 경우 Get(가져오기) & Set(설정) 함수를 구현해 주는 것이 일반적
            // 1. Get & Set 함수의 접근제한자를 설정하여 외부에서 맴버변수의 접근을 캡슐화함
            // 2. Get & Set 함수를 거쳐 맴버변수에 접근할 경우 호출스택에 함수가 추가되어 변경시점을 확인 가능

            public int GetHP()
            {
                return hp;
            }

            private void SetHP(int hp)
            {
                this.hp = hp;

            }

            //속성(Property)를 이용해서 간소화 표현
            private int mp;
            public int MP
            {
                get { return mp; }
                private set { mp = value; } //위랑 똑같은 역할
            }

            //AP 멤버변수를 선언과 동시에 get & set 속성 생성
            public int AP { get; set; }     

            private float rate;

            public int TotalDamage => (int)(AP * (1 + rate));
        }

        public static void Main()
        {
            Player player = new Player();

            //플레이어 체력 바꾸는건 금지
            //player.SetHP(0);

            //플레이어 체력 읽는건 가능
            Console.WriteLine($"플레이어의 체력 {player.GetHP}");

            //player.MP = 1;          //프로퍼티 set 호출
            int mp = player.MP;     //프로퍼티 get 호출

            player.AP = 1;          //간소화 표현 set
            int ap = player.AP;     //간소화 표현 get

            int totalDamage = player.TotalDamage;
        }
    }
}

```

# Operator Overloading
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class OperatorOverloading
    {
        /**********************************************************************
         * 연산자 재정의 (Operator Overloading)
         *
         * 사용자정의 자료형이나 클래스의 연산자를 재정의하여 여러 의미로 사용
         **********************************************************************/

        // <연산자 재정의>
        // 기본연산자의 연산을 함수로 재정의하여 기능을 구현
        // 기본연산자를 호환하지 않는 사용자정의 자료형에 기본연산자 사용을 구현함

        public struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            // 연산자 재정의를 통한 기본연산자 사용 구현
            public static Point operator +(Point left, Point right)
            {
                return new Point(left.x + right.x, left.y + right.y);
            }
        }


        void Main()
        {
            Point point = new Point(3, 3) + new Point(2, 5);        // point == (5, 8)
            // Point point = new Point(3, 3) - new Point(1, 2);     // error : - 기본연산자는 재정의되어 있지 않음
        }
    }
}
```

### Prameters
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Parameter
    {
        // <Named Parameter>
        // 함수의 매개변수 순서와 무관하게 이름을 통해 호출
        void Profile(int id, string name, string phone) { }

        void Main1()
        {
            // 함수 호출시 이름을 명명하고 순서와 상관없이 호출 가능
            Profile(phone: "010-1111-2222", id: 1, name: "홍길동");
            Profile(name: "홍길서", phone: "010-1234-5678", id: 2);
        }


        // <Optional Parameter>
        // 함수의 매개변수가 초기값을 갖고 있다면, 함수 호출시 생략하는 것을 허용하는 방법
        void AddStudent(string name, string home = "서울", int age = 8) { }   // 초기값이 있는 경우 미리 할당
        // void AddStudent(int age = 8, string home = "서울", string name) {} // error : 초기값이 있는 매개변수는 뒤부터 배치해야함

        void Main2()
        {
            AddStudent("철수");               // AddStudent("철수", "서울", 8);
            AddStudent("영희");               // AddStudent("영희", "서울", 8);
            AddStudent("민준", "인천");       // AddStudent("민준", "인천", 8);
            AddStudent("미영", age: 7);       // AddStudent("미영", "서울", 7);
        }


        // <Params Parameter>
        // 매개변수의 객수가 정해지지 않은 경우, 매개변수의 갯수를 유동적으로 사용하는 방법
        int Sum(params int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++) sum += values[i];
            return sum;
        }

        void Main3()
        {
            Sum(1, 3, 5, 7, 9);
            Sum(3, 5, 7);
            Sum();
        }


        // <in Parameter>
        // 매개변수를 입력전용으로 설정
        // 함수의 처음부터 끝까지 동일한 값을 보장하게 됨
        int Plus(in int left, in int right)
        {
            // left = 20;      // error : 입력전용 매개변수는 변경 불가
            return left + right;
        }

        void Main4()
        {
            int result = Plus(1, 3);
            Console.WriteLine($"{result}");     // output : 4
        }


        // <out Parameter>
        // 매개변수를 출력전용으로 설정
        // 함수의 반환값 외에 추가적인 출력이 필요할 경우 사용
        void Divide(int left, int right, out int quotient, out int remainder)
        {
            quotient = left / right;
            remainder = left % right;

            // 함수의 종료전까지 out 매개변수에 값이 할당 안되는 경우 오류
        }

        void Main5()
        {
            int quotient;
            Divide(5, 3, out quotient, out int remainder);
            Console.WriteLine($"{quotient}, {remainder}");  // output : 1, 2
        }


        // <ref Parameter>
        // 매개변수를 원본참조로 전달
        // 매개변수가 값형식인 경우에도 함수를 통해 원본값을 변경하고 싶을 경우 사용
        void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        void Main6()
        {
            int left = 10;
            int right = 20;
            Swap(ref left, ref right);
            Console.WriteLine($"{left}, {right}");      // output : 20, 10
        }
    }
}
```

### Indexer
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Indexer
    {
        // <인덱서 정의>
        // this[]를 속성으로 정의하여 클래스의 인스턴스에 인덱스 방식으로 접근 허용
        public class IndexerArray
        {
            private int[] array = new int[10];

            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    array[index] = value;
                }
            }
        }

        void Main1()
        {
            IndexerArray array = new IndexerArray();

            // 인덱서를 통한 인덱스 접근
            array[5] = 20;      // this[] set 접근
            int i = array[5];   // this[] get 접근
        }


        // <인덱서 자료형>
        // 인덱서는 다른 자료형 사용도 가능
        // 열거형을 통해 인덱서를 사용하는 경우도 빈번
        public enum Parts { Head, Body, Feet, Hand, SIZE }
        public class Equipment
        {
            string[] parts = new string[(int)Parts.SIZE];

            public string this[Parts type]
            {
                get
                {
                    return parts[(int)type];
                }
                set
                {
                    parts[(int)type] = value;
                }
            }
        }

        void Main2()
        {
            Equipment equipment = new Equipment();

            equipment[Parts.Head] = "낡은 헬멧";
            equipment[Parts.Feet] = "가죽 장화";

            Console.WriteLine($"착용하고 있는 신발 : {equipment[Parts.Feet]}");
        }
    }
}
```

### Nullable
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Nullable
    {
        void Main()
        {
            // <Nullable 타입>
            // 값형식의 자료형들은 null을 가질 수 없음
            // 값형식에도 null을 할당할 수 있는 Nullable 타입을 지원
            bool? b = null; //무슨형이라도
            int? i = 20;
            if (b != null) Console.WriteLine(b);    // b 값이 null
            if (i.HasValue) Console.WriteLine(i);   // i 값이 있으므로 20 출력


            // <Null 조건연산자>
            // ? 앞의 객체가 null 인 경우 null 반환
            // ? 앞의 객체가 null 이 아닌경우 접근
            NullClass instance = null;
            // instance.Func();                     // 예외발생 : instance가 null 이므로 접근할 객체가 없음
            Console.WriteLine(instance?.value);     // instance?.value는 null 반환
            instance?.Func();                       // instance?.Func()은 null 반환

            instance = new NullClass();
            Console.WriteLine(instance?.value);     // instance?.value는 5 반환
            instance?.Func();                       // instance?.Func()은 함수 호출


            // <Null 병합연산자>
            // ?? 앞의 객체가 null 인 경우 ?? 뒤의 객체 반환
            // ?? 앞의 객체가 null 이 아닌경우 앞의 객체 반환
            int[] array = null;
            int length = array?.Length ?? 0;        // 배열이 null 인경우 0 반환, 아닌경우 배열의 크기 반환


            // <Null 병합할당연산자>
            // ??= 앞의 객체가 null 인 경우 ??= 뒤의 객체를 할당
            // ??= 앞의 객체가 null 인 아닌경우 ??= 뒤의 객체를 할당하지 않음
            NullClass nullClass = null;
            nullClass ??= new NullClass();          // nullClass 가 null이므로 새로운 인스턴스 할당
            nullClass ??= new NullClass();          // nullClass 가 null이 아니므로 새로운 인스턴스 할당이 되지 않음
        }

        public class NullClass
        {
            public int value = 5;

            public void Func() { }
        }
    }
}
```

### Immutable 불변성
- 생성된 후 객체를 수정할 수 없다.
- 수정을 진행하는 경우 새로운 객체 수정된 객체를 만들어 참조한다.
- 가변으로 변경할 수 없다.

#### 스트링의 불변성
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional
{
    internal class StringImmutable
    {

        public class TestClass
        {
            public int value;
        }

        static void Main(string[] args)
        {
            TestClass left = new TestClass() { value = 10 };
            TestClass right = left;

            right.value = 20;

            Console.WriteLine(left.value); //20

            //원래 위같은데 참조형식이라
            //string은 안바뀜

            string a = "안녕하세요";
            string b = a;

            b = "Hello";

            Console.WriteLine(a); //안녕하세요
            Console.WriteLine(b); //Hello

            StringBuilder sb = new StringBuilder();
            sb.Append("asd");
            sb[0] = 'd';
            sb.Replace('s', 'd');
        }
    }
}

```
