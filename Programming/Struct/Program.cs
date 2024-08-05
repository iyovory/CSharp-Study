namespace ConsoleApp2
{
    internal class Program
    {

        #region 열거형 선언
        //제조사
        enum CarBrand
        {
            Honda, Audi, BMW, Kia
        }

        // 아이템 타입
        enum ItemType
        {
            방어구, 무기, 소모품
        }
        #endregion


        #region 구조체 선언
        //short형x, short형y 두가지를 가진 XYCoord라는 구조체를 선언한다.
        struct XYCoord
        {
            public short x;
            public short y;
        }

        //정수형 Dmg, 실수형 Critical, 문자열형 Name을 가진 구조체 틀을 만들고 구조체 이름은 Weapon으로 선언한다.
        struct Weapon
        {
            public int Dmg;
            public float Critical;
            public string Name;
        }

        //Car라는 구조체를 만든 후, 다음의 내부 속성을 추가한다. - 실수형 최고속도, 정수형 자동차넘버, 열거형 제조사(Honda, Audi, BMW, Kia 네가지 열거 속성 보유)
        struct Car
        {
            public float maxSpeed;
            public int carNumber;
            public CarBrand Brand;
        }


        //Item 이라는 구조체를 만든다. 이 아이템이라는 구조체는 문자열형인 아이템 이름, 정수형인 가격, 열거형인 아이템 타입(방어구, 무기, 소모품)의 속성을 가진다.
        struct Item
        {
            public string name;
            public int price;
            public ItemType itemType;
        }


        #endregion

        static void Main(string[] args)
        {
            // Sword와 Katana라는 객체를 만든 후, 본인이 원하는 수치를 각각 속성에 전부 추가한다.
            Weapon Sword = new Weapon();
            Weapon Katana = new Weapon();

            Sword.Dmg = 5;
            Sword.Critical = 50.5f;
            Sword.Name = "cocoa";

            Katana.Dmg = 10;
            Katana.Critical = 50f;
            Katana.Name = "genji gum";


            //아이템이 3개 들어가는 인벤토리라는 배열을 만들고, 배열 속 세번째 요소에, 아이템명으로 “악몽의 꽃 견갑”, 가격은 500, 아이템의 타입은 방어구이다. 인벤토리의 모든 속 내용을 출력하는 함수를 작성한다.
            // 플밍 질문방에 올린 상태입니다! 답변 받으면 재제출하겠습니다!
        }
    }
}
