namespace ConsoleGame
{
    internal class Program
    {
        public enum PlaceState
        {
            Empty = ' ',
            WallX = 'x',
            WallY = 'y',
            Field = 'f',
            Water = 'w',
            Harvest = 'h',
        }

        public struct Point
        {
            public int x;
            public int y;
        }

        public struct Inventory
        {
            public string name;
            public int count;
        }

        public struct Data
        {
            public bool running;
            public PlaceState[,] map;
            public Point playerPosition;
            public Inventory[] inventory;
        }

        static Data data;
        static bool harvestMessage = false;

        static void Main(string[] args)
        {
            Start();

            while (data.running)
            {
                Render();
                //Input();
                //Update();
            }

            //End();  
        }

        static void Start()
        {

            data = new Data();
            data.running = true;

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           클로버 농장            =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();

            //커서 안깜빡임
            Console.CursorVisible = false;

            //인벤토리 초기화
            data.inventory = new Inventory[5];
            for (int i = 0; i < data.inventory.Length; i++)
            {
                data.inventory[i].name = "";
                data.inventory[i].count = 0;
            }

            // 영역 밖으로 안넘어가게 && data.playerPosition.x + 1 < data.map.GetLength(1)) 대신 벽쳐줌
            data.map = new PlaceState[,]
            {
                { PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX },
                { PlaceState.WallY, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Field, PlaceState.WallY },
                { PlaceState.WallY, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Field, PlaceState.WallY },
                { PlaceState.WallY, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Field, PlaceState.WallY },
                { PlaceState.WallY, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.Empty, PlaceState.WallY },
                { PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX, PlaceState.WallX }
                
                //{
                //    { 'x','x','x','x','x','x','x','x' },
                //    { 'y',' ',' ',' ',' ',' ','f','y' },
                //    { 'y',' ',' ',' ',' ',' ','f','y' },
                //    { 'y',' ',' ',' ',' ',' ','f','y' },
                //    { 'y',' ',' ',' ',' ',' ',' ','y' },
                //    { 'x','x','x','x','x','x','x','x' }
                //};
            };
            data.playerPosition = new Point() { x = 2, y = 2 };

            Console.WriteLine();
            Console.WriteLine("    계속하려면 아무키나 누르세요    ");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrintInventory()
        {
            for (int i = 0; i < data.inventory.Length; i++)
            {
                if (data.inventory[i].count >= 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{data.inventory[0].name}를 획득했다.");
                    Console.WriteLine($"{data.inventory[0].name} - {data.inventory[0].count}개");
                    Console.WriteLine();
                }
            }

            if (harvestMessage)
            {
                Console.ReadKey(true);
                harvestMessage = false;
            }
        }

        static void PrintMap()
        {
            for (int y = 0; y < data.map.GetLength(0); y++)
            {
                for (int x = 0; x < data.map.GetLength(1); x++)
                {
                    switch (data.map[y, x])
                    {
                        case PlaceState.Empty:
                            Console.Write(" ");
                            break;
                        case PlaceState.Field:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("□");
                            Console.ResetColor();
                            break;
                        case PlaceState.Water:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case PlaceState.Harvest:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("♣");
                            Console.ResetColor();
                            break;
                        case PlaceState.WallX:
                            Console.Write("━");
                            break;
                        case PlaceState.WallY:
                            Console.Write("┃");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
        static void PrintPlayer()
        {
            Console.SetCursorPosition(data.playerPosition.x, data.playerPosition.y);
            Console.Write("●");
            Console.ResetColor();
        }

        static void Render()
        {
            Console.Clear();

            PrintMap();
            PrintPlayer();
            KeyAction();
            PrintInventory();
        }

        #region 상하좌우 이동 함수
        static void MoveUp()
        {
            if (data.map[data.playerPosition.y - 1, data.playerPosition.x] == PlaceState.Empty)
            {
                data.playerPosition.y = data.playerPosition.y - 1;
            }
        }
        static void MoveLeft()
        {
            if (data.map[data.playerPosition.y, data.playerPosition.x - 1] == PlaceState.Empty)
            {
                data.playerPosition.x = data.playerPosition.x - 1;
            }
        }
        static void MoveRight()
        {
            if (data.map[data.playerPosition.y, data.playerPosition.x + 1] == PlaceState.Empty)
            {
                data.playerPosition.x = data.playerPosition.x + 1;
            }
        }
        static void MoveDown()
        {
            if (data.map[data.playerPosition.y + 1, data.playerPosition.x] == PlaceState.Empty)
            {
                data.playerPosition.y = data.playerPosition.y + 1;
            }
        }
        #endregion

        #region 농작 함수

        //물주기 Field => Water
        static void ConvertToWater()
        {
            if (data.map[data.playerPosition.y, data.playerPosition.x + 1] == PlaceState.Field)
            {
                data.map[data.playerPosition.y, data.playerPosition.x + 1] = PlaceState.Water;
            }
            if (data.map[data.playerPosition.y, data.playerPosition.x - 1] == PlaceState.Field)
            {
                data.map[data.playerPosition.y, data.playerPosition.x - 1] = PlaceState.Water;
            }
            if (data.map[data.playerPosition.y + 1, data.playerPosition.x] == PlaceState.Field)
            {
                data.map[data.playerPosition.y + 1, data.playerPosition.x] = PlaceState.Water;
            }
            if (data.map[data.playerPosition.y - 1, data.playerPosition.x] == PlaceState.Field)
            {
                data.map[data.playerPosition.y - 1, data.playerPosition.x] = PlaceState.Water;
            }
        }

        //열매맺기 Water => Harvest
        static void ConvertToHarvest()
        {
            if (data.map[data.playerPosition.y, data.playerPosition.x + 1] == PlaceState.Water)
            {
                data.map[data.playerPosition.y, data.playerPosition.x + 1] = PlaceState.Harvest;
            }
            if (data.map[data.playerPosition.y, data.playerPosition.x - 1] == PlaceState.Water)
            {
                data.map[data.playerPosition.y, data.playerPosition.x - 1] = PlaceState.Harvest;
            }
            if (data.map[data.playerPosition.y + 1, data.playerPosition.x] == PlaceState.Water)
            {
                data.map[data.playerPosition.y + 1, data.playerPosition.x] = PlaceState.Harvest;
            }
            if (data.map[data.playerPosition.y - 1, data.playerPosition.x] == PlaceState.Water)
            {
                data.map[data.playerPosition.y - 1, data.playerPosition.x] = PlaceState.Harvest;
            }
        }

        //수확하기 Harvest => Field
        static void ConvertToField()
        {
            void Harvest()
            {
                data.inventory[0].name = "클로버";
                data.inventory[0].count = data.inventory[0].count += 1;
            }

            if (data.map[data.playerPosition.y, data.playerPosition.x + 1] == PlaceState.Harvest)
            {
                data.map[data.playerPosition.y, data.playerPosition.x + 1] = PlaceState.Field;
                Harvest();
            }
            if (data.map[data.playerPosition.y, data.playerPosition.x - 1] == PlaceState.Harvest)
            {
                data.map[data.playerPosition.y, data.playerPosition.x - 1] = PlaceState.Field;
                Harvest();
            }
            if (data.map[data.playerPosition.y + 1, data.playerPosition.x] == PlaceState.Harvest)
            {
                data.map[data.playerPosition.y + 1, data.playerPosition.x] = PlaceState.Field;
                Harvest();
            }
            if (data.map[data.playerPosition.y - 1, data.playerPosition.x] == PlaceState.Harvest)
            {
                data.map[data.playerPosition.y - 1, data.playerPosition.x] = PlaceState.Field;
                Harvest();
            }

            harvestMessage = true;
        }
        #endregion

        static void KeyAction()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;

                //나중엔 case ConsoleKey.Spacebar: 에 한번에 해보기
                //case ConsoleKey.Spacebar:
                //    ConvertToField();
                //    ConvertToHarvest();
                //    ConvertToWater();
                //    break;
                case ConsoleKey.Z:
                    ConvertToWater();
                    break;
                case ConsoleKey.X:
                    ConvertToHarvest();
                    break;
                case ConsoleKey.C:
                    ConvertToField();
                    break;
            }
        }
    }
}
