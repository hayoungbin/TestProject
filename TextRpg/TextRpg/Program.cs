using System.Xml;

namespace TextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int num;

            MainScene();
            Console.ReadLine();

            while (true)
            {
                StartScene();

                input = Console.ReadLine();
                if (int.TryParse(input, out num))
                {
                    switch (num)
                    {

                        case 1:
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.ReadLine();
                            break;
                    }
                }
                StartScene();
                Console.WriteLine("숫자를 입력해주세요!!!");

            }

        }


        static void MainScene()
        {
            Console.Clear();
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                              ====================");
            Console.WriteLine("                              =                  =");
            Console.WriteLine("                              =    [Text Rpg]    =");
            Console.WriteLine("                              =                  =");
            Console.WriteLine("                              ====================");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("                            엔터 키를 눌러 시작하세요");

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write("=");
            }
            Console.WriteLine("");
        }
        static void StartScene()
        {
            Console.Clear();
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("     이 곳에서 던전에서 들어가기 전 활동을 할 수 있습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("     1.상태 보기");
            Console.WriteLine("     2.인벤토리");
            Console.WriteLine("     3.상점");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     원하시는 행동을 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write("=");
            }
            Console.WriteLine("");
        }
    }
}