using System;
using System.Xml;

namespace TextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int num;

            Status status = new Status();

            status.level = 1;
            status.name = "Guiano";
            status.job = "(전사)";
            status.atk = 10;
            status.def = 5;
            status.hp = 100;
            status.gold = 1500;

            MainScene();
            Console.ReadLine();

            while (true)
            {
                StartScene();

                input = Console.ReadLine();
                if (int.TryParse(input, out num))
                {
                    num = int.Parse(input);
                    switch (num)
                    {

                        case 1:
                            status.ViewStatus();
                            break;
                        case 2:
                            Backpack();
                            break;
                        case 3:
                            Console.WriteLine("3");
                            Console.ReadLine();
                            break;
                        default:
                            StartScene();
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(400);
                            break;
                    }
                }
                else
                {
                    StartScene();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(400);
                }


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
            Console.WriteLine("     원하시는 행동의 번호를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write("=");
            }
            Console.WriteLine("");
        }
        struct Status()
        {
            public int level;
            public string name;
            public string job;
            public int atk;
            public int def;
            public int hp;
            public int gold;

            public void ViewStatus()
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
                Console.WriteLine("     당신의 상태");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"     Lv : {level}");
                Console.WriteLine($"     {name}  {job}");
                Console.WriteLine($"     공격력 : {atk}");
                Console.WriteLine($"     방어력 : {def}");
                Console.WriteLine($"     체력   : {hp}");
                Console.WriteLine($"     소지금 : {gold} G");

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("     0.나가기");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     원하시는 행동의 번호를 입력해주세요");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < 80; i++)
                {
                    Console.SetCursorPosition(i, 20);
                    Console.Write("=");
                }
                Console.WriteLine("");

                string doIt;
                doIt = Console.ReadLine();

                if (doIt == "0")
                {

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(400);
                    ViewStatus();

                }

            }
        }
         static void Backpack()
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
            Console.WriteLine("     인벤토리");
            Console.WriteLine("     아이템을 관리할 수 있습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("     ");
            Console.WriteLine("     1.장착 관리");
            Console.WriteLine("     0.나가기");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     원하시는 행동의 번호를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write("=");
            }
            Console.WriteLine("");

            string doIt;
            doIt = Console.ReadLine();

            if (doIt == "1")
            {
                UseBackPack();
            }
            else if (doIt == "0")
            {

            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(400);
                Backpack();
                
            }
        }
        static void UseBackPack()
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
            Console.WriteLine("     인벤토리 - 장착 관리");
            Console.WriteLine("     아이템을 관리할 수 있습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("     ");
            Console.WriteLine("     ");
            Console.WriteLine("     0.나가기");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     원하시는 행동의 번호를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write("=");
            }
            Console.WriteLine("");

            int num;
            string doIt;
            doIt = Console.ReadLine();

            if (doIt == "0")
            {

            }
            else if (int.TryParse(doIt, out num))
            {
                switch (num)
                {
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        UseBackPack();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(400);
                UseBackPack();

            }
        }
    }
}