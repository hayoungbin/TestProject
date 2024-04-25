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

            Items item1 = new Items();

            item1.itemName = "수련자 갑옷";
            item1.lore = "수련에 도움을 주는 갑옷입니다.";
            item1.value = 1000;
            item1.armorDef = 5;
            item1.notHave = true;
            item1.notUse = true;

            Items item2 = new Items();
            item2.itemName = "무쇠갑옷";
            item2.lore = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            item2.value = 1500;
            item2.armorDef = 9;
            item2.notHave = true;
            item2.notUse = true;

            Items item3 = new Items();
            item3.itemName = "스파르타의 갑옷";
            item3.lore = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
            item3.value = 3500;
            item3.armorDef = 15;
            item3.notHave = true;
            item3.notUse = true;

            Items item4 = new Items();

            item4.itemName = "낡은 검";
            item4.lore = "쉽게 볼 수 있는 낡은 검 입니다.";
            item4.value = 600;
            item4.weaponAtk = 2;
            item4.notHave = true;
            item4.notUse = true;

            Items item5 = new Items();
            item5.itemName = "청동 도끼";
            item5.lore = "어디선가 사용됐던 것 같은 도끼입니다.";
            item5.value = 1500;
            item5.weaponAtk = 5;
            item5.notHave = true;
            item5.notUse = true;

            Items item6 = new Items();
            item6.itemName = "스파르타의 창";
            item6.lore = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
            item6.value = 3500;
            item6.weaponAtk = 7;
            item6.notHave = true;
            item6.notUse = true;

            Items[] itemList = { item1, item2, item3, item4, item5, item6 };


            Status status = new Status();

            status.level = 1;
            status.name = "Guiano";
            status.job = "(전사)";
            status.atk = 10;
            status.def = 5;
            status.hp = 100;
            status.gold = 3500;

            int[] Wallet = { status.gold };

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
                            status.ViewStatus(status, itemList);
                            break;
                        case 2:
                            Backpack(itemList);
                            break;
                        case 3:
                            status.gold = Shop(Wallet, itemList);
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
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("                            엔터 키를 눌러 시작하세요");

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 25);
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
            for (int i = 0; i < 15; i++)
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
                Console.SetCursorPosition(i, 25);
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

            public void ViewStatus(Status status, Items[] item)
            {
                int myAtk = 0;
                int myDef = 0;

                Console.Clear();
                for (int i = 0; i < 80; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("=");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                for (int i = 0; i <=5; ++i)
                {
                    if (IsArmor(item, i))
                    {
                        myDef += ItemEffect(item, i);
                    }
                    else
                    {
                        myAtk += ItemEffect(item, i);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("     당신의 상태");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"     Lv : {status.level}");
                Console.WriteLine($"     {status.name}  {status.job}");
                if (myAtk == 0)
                {
                    Console.WriteLine($"     공격력 : {status.atk}");
                }
                else
                {
                    Console.WriteLine($"     공격력 : {status.atk + myAtk} + ({myAtk})");
                }
                if (myDef == 0)
                {
                    Console.WriteLine($"     방어력 : {status.def}");
                }
                else
                {
                    Console.WriteLine($"     방어력 : {status.def + myDef} + ({myDef})");
                }
                Console.WriteLine($"     체력   : {status.hp}");
                Console.WriteLine($"     소지금 : {status.gold} G");

                for (int i = 0; i < 10; i++)
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
                    Console.SetCursorPosition(i, 25);
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
                    ViewStatus(status, item);

                }

            }
        }
         static void Backpack(Items[] item)
        {
            Console.Clear();
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     인벤토리");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     아이템을 관리할 수 있습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            for (int i = 0; i <= 5; i++)
            {
                ShowMyItem(item, i);
            }

            for (int i = 0; i < 8; i++)
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
                Console.SetCursorPosition(i, 25);
                Console.Write("=");
            }
            Console.WriteLine("");

            string doIt;
            doIt = Console.ReadLine();

            if (doIt == "1")
            {
                UseBackPack(item);
            }
            else if (doIt == "0")
            {

            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(400);
                Backpack(item);
                
            }
        }
        static void UseBackPack(Items[] item)
        {
            Console.Clear();
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     인벤토리 - 장착 관리");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     아이템을 관리할 수 있습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            for (int i = 0; i <= 5; i++)
            {
                ShowMyItem(item, i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
            }

            Console.WriteLine("     0.나가기");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     장착/ 해제하고 싶은 아이템의 번호나 원하시는 행동의 번호를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 25);
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
                    case 1:
                        UseItem(item, num);
                        break;
                    case 2:
                        UseItem(item, num);
                        break;
                    case 3:
                        UseItem(item, num);
                        break;
                    case 4:
                        UseItem(item, num);
                        break;
                    case 5:
                        UseItem(item, num);
                        break;
                    case 6:
                        UseItem(item, num);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        UseBackPack(item);
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(400);
                UseBackPack(item);
            }
        }

        static int Shop(int[] gold, Items[] item)
        {


            Console.Clear();
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     상점");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.Write("      보유 금액 : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(gold[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" G");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            for (int i = 0; i <= 5; i++)
            {
                Console.Write("   ");
                PrintToShop(item, i);
            }
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine("");
            }

            Console.WriteLine("     ");
            Console.WriteLine("     1.아이템을 구매");
            Console.WriteLine("     0.나가기");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     원하시는 행동의 번호를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 25);
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
                    case 1:
                        ShopBuy(gold, item);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        Shop(gold, item);
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(400);
                Shop(gold, item);
            }
            return gold[0];
        }

        static void ShopBuy(int[] gold , Items[] item)
        {

            Console.Clear();
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     상점 [아이템을 구매]");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     아이템을 구매합니다.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.Write("   보유 금액 : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(gold[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" G");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            for (int i = 0; i <= 5; i++)
            {
                PrintToShop(item, i);
            }

            for (int i = 1; i <= 7; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("     ");
            Console.WriteLine("     0.나가기");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     구입하고자 하는 아이템이나 원하는 행동의 번호를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 25);
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
                    case 1:
                        BuyItem(item, num, gold);
                        break;
                    case 2:
                        BuyItem(item, num, gold);
                        break;
                    case 3:
                        BuyItem(item, num, gold);
                        break;
                    case 4:
                        BuyItem(item, num, gold);
                        break;
                    case 5:
                        BuyItem(item, num, gold);
                        break;
                    case 6:
                        BuyItem(item, num, gold);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        ShopBuy(gold, item);
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(400);
                ShopBuy(gold, item);
            }
        }
        static void IsBuyMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("이미 구입한 아이템입니다!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(400);
        }
        static void NowBuyMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("구매 성공!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(400);
        }
        static void NotMoneyMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("소지금이 부족합니다!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(400);
        }

        struct Items()
        {
            public string itemName;
            public string lore;
            public int value;
            public int weaponAtk;
            public int armorDef;
            public bool notHave;
            public bool notUse;
        }

        static void Print(Items[] item, int num)
        {
            if (item[num].weaponAtk == 0)
            {
                Console.Write($"{item[num].itemName}  |  {item[num].lore}  |  방어력 + {item[num].armorDef}  |");
            }
            else
            {
                Console.Write($"{item[num].itemName}  |  {item[num].lore}  |  공격력 + {item[num].weaponAtk} |");
            }
        }

        static void PrintToShop(Items[] item, int num)
        {
            Console.Write("   {0}.",num + 1);
            Print(item, num);
            if (item[num].notHave)
            {
                Console.WriteLine($"  {item[num].value} G");
            }
            else
            {
                Console.WriteLine("  [구매 완료]");
            }
        }
        static void ShowMyItem(Items[] item, int num)
        {

            if (item[num].notHave)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   {0}.", num + 1);
                Print(item, num);
                Console.WriteLine("  [미보유]");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (item[num].notUse)
                {
                    Console.Write("   {0}.", num + 1);
                    Print(item, num);
                    Console.WriteLine("  [보유중]");
                }
                else
                {
                    Console.Write("   {0}.[E]", num + 1);
                    Print(item, num);
                    Console.WriteLine("  [보유중]");
                }
            }
        }

        static void BuyItem(Items[] item, int num, int[] gold)
        {
            if (item[num - 1].notHave)
            {
                if (gold[0] >= 1000)
                {
                    item[num - 1].notHave = false;
                    int leftGold = gold[0] - item[num - 1].value;
                    gold[0] = leftGold;
                    NowBuyMessage();
                    ShopBuy(gold, item);
                }
                else
                {
                    NotMoneyMessage();
                    ShopBuy(gold, item);
                }
            }
            else
            {
                IsBuyMessage();
                ShopBuy(gold, item);
            }
        }
        static void UseItem(Items[] item, int num)
        {
            if (!item[num - 1].notHave)
            {
                if (item[num - 1].notUse)
                {
                    item[num - 1].notUse = false;
                    Console.WriteLine("아이템을 장착했습니다!");
                    Thread.Sleep(400);
                    UseBackPack(item);
                }
                else
                {
                    item[num - 1].notUse = true;
                    Console.WriteLine("아이템을 해제했습니다!");
                    Thread.Sleep(400);
                    UseBackPack(item);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 그 아이템은 가지고 있지 않습니다!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(400);
                UseBackPack(item);
            }
        }
        static int ItemEffect(Items[] item, int num)
        {
            if (item[num].notUse)
            {
                return 0;
            }
            else
            {
                if (item[num].armorDef == 0)
                {
                    int plusAtk = item[num].weaponAtk;
                    return plusAtk;
                }
                else
                {
                    int plusDef = item[num].armorDef;
                    return plusDef;
                }
            }
        }
        static bool IsArmor(Items[] item, int num)
        {
            if (item[num].armorDef == 0)
            {
                return false;
            }
            else
            {
                return  true;
            }
        }
    }
}