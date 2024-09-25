using System.ComponentModel;
using System.Text;

namespace TextRPG_
{
    // public class Test2 { } //alt enter
    internal class Program
    {
        static string playerName = "";  //입력한 이름 저장

        static int playerGold = 1500; // 플레이어의 초기 골드
        static int playerHealth = 100; //기본 체력
        static int playerBaisicAttack = 10; //기본 공격력
        static int playerBasicDefense = 5; //기본 방어력



        //아이템 종류
        enum ItemType
        { Armor, Weapon }

        // 아이템
        class Item
        {
            public string Name { get; }
            public int Defense { get; }
            public int Attack { get; }
            public int Price { get; }
            public string Description { get; }
            public bool IsPurchased { get; set; } //true <-> false 변경될 수 있어서 set이 붙음
            public bool IsEquipped { get; set; }
            public ItemType Type { get; }

            public Item(string name, int defense, int attack, int price, string description, ItemType type, bool isPurchased = false, bool isEquipped = false)
            {
                Name = name;
                Defense = defense;
                Attack = attack;
                Price = price;
                Description = description;
                Type = type;
                IsPurchased = isPurchased;
                IsEquipped = isEquipped;
            }
        }

        static string GetStatString(Item item)
        {
            string stats = "";
            if (item.Attack > 0) stats += $"공격력 +{item.Attack} ";
            if (item.Defense > 0) stats += $"방어력 +{item.Defense}";
            return stats;
        }

        // 아이템 목록
        static List<Item> inventory = new List<Item>(); // 인벤토리
        static List<Item> equippedItems = new List<Item>();// 장착
        static List<Item> shopItems = new List<Item> // 상점



         {
        new Item("너덜너덜한 갑옷", 5, 0, 1000, "그래도 쓸만한 너덜너덜한 갑옷",ItemType.Armor),
        new Item("매우 평범한 갑옷", 9, 0, 1800, "아주 평범한 갑옷", ItemType.Armor),
        new Item("고양이털이 가득한 갑옷", 15, 0, 3500, "고양이 털이 휘날리는갑옷", ItemType.Armor),
        new Item("이상하게 생긴 검", 0, 2, 600, "생김새가 이상한 검", ItemType.Weapon),
        new Item("나무꾼이 아끼던 도끼", 0, 5, 1500,  "꽤 좋은 도끼일지도", ItemType.Weapon),
        new Item("쓸데없이 멋진 모닝스타", 0, 8, 2700, "잘 휘두르기만 하면", ItemType.Weapon)
         };


        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Welcome();
            Menu();
        }

        static void Welcome()
        {
            while (true)
            {
                Console.Clear();

                //Welcome
                Console.WriteLine();
                Console.WriteLine(" __      __           ___                                            ");
                Console.WriteLine("/\\ \\  __/\\ \\         /\\_ \\                                           ");
                Console.WriteLine("\\ \\ \\/\\ \\ \\ \\     __ \\//\\ \\      ___     ___     ___ ___       __   ");
                Console.WriteLine(" \\ \\ \\ \\ \\ \\ \\  /'__`\\ \\ \\ \\    /'___\\  / __`\\ /' __` __`\\   /'__`\\ ");
                Console.WriteLine("  \\ \\ \\_/ \\_\\ \\/\\  __/  \\_\\ \\_ /\\ \\__/ /\\ \\L\\ \\/\\ \\/\\ \\/\\ \\ /\\  __/ ");
                Console.WriteLine("   \\ `\\___x___/\\ \\____\\ /\\____\\\\ \\____\\\\ \\____/\\ \\_\\ \\_\\ \\_\\\\ \\____\\");
                Console.WriteLine("    '\\/__//__/  \\/____/ \\/____/ \\/____/ \\/___/  \\/_/\\/_/\\/_/ \\/____/ ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("고양이 마을에 오신 캔따개 " + playerName + "님 환영합니다.");
                Console.WriteLine("당신은 고양이님들의 식사준비 담당입니다.");
                Console.WriteLine("당장 던전에 들어가 식재료를 구해와야합니다.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("ᕦ[ •́ ﹏ •̀ ]⊃¤=[]::::::::>");
                Console.WriteLine();
                Console.WriteLine("캔따개님의 이름을 입력해주세요. (2~10글자)");
                string input = Console.ReadLine();

                if (input.Length >= 2 && input.Length <= 10)
                {
                    playerName = input;
                    break;
                }
                else
                {
                    Console.WriteLine("사용할 수 없는 이름입니다.");
                    Thread.Sleep(400);
                    Main();//이름 다시 입력
                }
            }
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();

                // 고양이
                Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣶⣄⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣦⣄⡀⣠⣾⡇⠀⠀⠀⠀");
                Console.WriteLine("⠀⠀⠀⠀⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀");
                Console.WriteLine("⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⢿⣿⣿⣿⡇⠀⠀⠀⠀");
                Console.WriteLine("⠀⣶⣿⣦⣜⣿⣿⣿⡟⠻⣿⣿⣿⣿⣿⣿⣿⡿⢿⡏⣴⣺⣦⣙⣿⣷⣄⠀⠀⠀");
                Console.WriteLine("⠀⣯⡇⣻⣿⣿⣿⣿⣷⣾⣿⣬⣥⣭⣽⣿⣿⣧⣼⡇⣯⣇⣹⣿⣿⣿⣿⣧⠀⠀");
                Console.WriteLine("⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠸⣿⣿⣿⣿⣿⣿⣿⣷⠀");

                Console.WriteLine();

                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전");
                Console.WriteLine("0. 게임 종료");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("원하시는 행동을 입력해주세요. >> ");


                string input = Console.ReadLine(); //행동 입력

                switch (input)
                {
                    case "1":
                        ShowStatus();
                        break;
                    case "2":
                        ShowInventory();
                        break;
                    case "3":
                        ShowShop();
                        break;
                    case "4":
                        Dungeon();
                        break;
                    case "0":
                        return; // 게임 종료
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        break;
                }
            }
        }



        // 상태 보기
        static void ShowStatus()
        {

            Console.Clear();

            //장비장착으로 추가되는 공격력과 방어력
            int equipmentAttack = equippedItems.Sum(Item => Item.Attack); //=> 각 아이템의 attack,defense값 가져오기 
            int equipmentDefense = equippedItems.Sum(item => item.Defense); //sum 각 아이템의 attack,defense값 더하기 (LINQ의 메서드)

            //총 공격력과 방어력 (기본 +장비)
            int totalAttack = playerBaisicAttack + equippedItems.Sum(item => item.Attack);
            int totalDefense = playerBasicDefense + equippedItems.Sum(item => item.Defense);
            Console.WriteLine();
            Console.WriteLine("ᕦ༼ ˵ ◯ ਊ ◯ ˵ ༽ᕤ");
            Console.WriteLine();
            Console.WriteLine("**▬▬█ 상태보기 █▬▬**");
            Console.WriteLine();
            Console.WriteLine("캐릭터의 정보입니다");
            Console.WriteLine();
            Console.WriteLine($"Lv. 01");
            Console.WriteLine($"{playerName} (캔따개)");
            Console.WriteLine($"공격력 : {totalAttack} (+{equipmentAttack})");
            Console.WriteLine($"방어력 : {totalDefense} (+{equipmentDefense})");
            Console.WriteLine($"체력 : {playerHealth}");
            Console.WriteLine($"Gold : {playerGold} G");
            Console.WriteLine();
            Console.Write("0. 나가기 >> ");

            string input = Console.ReadLine();
            if (input == "0") return;
            else
                Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(400);
            ShowStatus();

        } //0이 아니면, 문구 출력 후 ShowStatus 다시 호출


        // 인벤토리 보기
        static void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("(㇏(•̀ ᢍ •́ )ノ)");
            Console.WriteLine();
            Console.WriteLine("**▬▬█ 인벤토리 █▬▬**");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            if (inventory.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
            }
            else
            {
                int index = 1;
                foreach (var item in inventory)
                {
                    string equippedStatus = item.IsEquipped ? "[E]" : "";
                    Console.WriteLine($"{index}. {equippedStatus} {item.Name} ||{item.Type}| {item.Description} | 방어력 +{item.Defense}| 공격력 +{item.Attack} ");
                    index++;
                }
            }
            Console.WriteLine("01. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요. >> ");
            string input = Console.ReadLine();


            if (input == "0") return;
            else if (input == "01") ManageEquipment();
            else
                Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(400);
            ShowInventory();
        }

        // 상점 보기
        static void ShowShop()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("¯\\_( ◉ 3 ◉ )_/¯");
            Console.WriteLine();
            Console.WriteLine("**▬▬█ 상점 █▬▬**");
            Console.WriteLine();
            Console.WriteLine($"[보유 골드] {playerGold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < shopItems.Count; i++)
            {
                Item item = shopItems[i];
                string Purchasedstatus = item.IsPurchased ? "구매완료" : $"{item.Price}G";  // 가격 or 구매완료
                Console.WriteLine($"{i + 1}. {item.Name} ||{item.Type}| {item.Description} | 방어력 +{item.Defense}| 공격력 +{item.Attack}|| {Purchasedstatus}");
            }

            Console.WriteLine("01. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요. >> ");
            string input = Console.ReadLine();

            if (input == "01") BuyItem(); // 아이템 구매

            if (input == "0") return;

            //상점에서 구매 전 0번으로 나가기는 바로 되는데
            //상점에서 구매창 보고 0번으로 나가기 하면 바로 안되고 두세 번 입력해야 됨..ㅠ_ㅠ,,,why

            else if (input != "01" && input != "0")
                Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(400);
            ShowShop();
        }

        // 아이템 구매
        static void BuyItem()
        {
            Console.Clear();

            Console.WriteLine("** 아이템 구매 **");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("구매할 아이템 번호를 입력해주세요. >> ");


            int index = int.Parse(Console.ReadLine()) - 1; //아이템 목록이 1번부터 뜰거라서 -1 해주기
            if (index < 0 || index >= shopItems.Count)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(400);
                BuyItem();
            }

            Item selectedItem = shopItems[index];

            if (selectedItem.IsPurchased) //이미 구매
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
                Thread.Sleep(400);
                ShowShop();
            }
            else if (playerGold >= selectedItem.Price) //골드 충분
            {
                playerGold -= selectedItem.Price; // 골드차감
                inventory.Add(selectedItem); // 인벤토리에 아이템 추가
                selectedItem.IsPurchased = true; // 구매 완료 표시
                Console.WriteLine($"{selectedItem.Name}을 구매하였습니다.");
                Thread.Sleep(400);
                ShowShop();
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다."); //골드 부족
                Thread.Sleep(400);
                ShowShop();
            }

            //외않되ㅠ
            //Console.WriteLine("0. 나가기");
            //string exit = Console.ReadLine();

            //if (exit == "0") return;

            //else
            //Console.WriteLine("잘못된 입력입니다.");
            //Thread.Sleep(400);
            //BuyItem();

        }
        // 장착,해제 관리
        static void ManageEquipment()
        {
            Console.Clear();
            Console.WriteLine("ヽ(ΦωΦヽ)");
            Console.WriteLine();
            Console.WriteLine("**▬▬█ 장착,해제 관리 █▬▬**");

            if (inventory.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
                return;
            }

            for (int i = 0; i < inventory.Count; i++)
            {
                Item item = inventory[i];
                string equippedStatus = item.IsEquipped ? "[E]" : "";
                Console.WriteLine($"{i + 1}. {item.Name} | 공격력 +{item.Attack} | 방어력 +{item.Defense}");
            }

            Console.WriteLine("장착, 해제할 아이템의 번호를 입력해주세요. >> ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= inventory.Count)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            Item selectedItem = inventory[index];

            if (selectedItem.IsEquipped)
            {
                selectedItem.IsEquipped = false;
                equippedItems.Remove(selectedItem);
                Console.WriteLine($"{selectedItem.Name}을(를) 해제했습니다..");
            }
            else
            {
                selectedItem.IsEquipped = true;
                equippedItems.Add(selectedItem);
                Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다.");

            }
        }

        //던전
        static void Dungeon()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("ᕙ( ︡’︡ 益 ’︠)ง▬▬█");
            Thread.Sleep(800);
            Console.WriteLine("아주 강한 괴물이 나왔습니다!!!");
            Thread.Sleep(900);
            Console.WriteLine("당신은 죽었습니다.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter로 환생하세요.");
            Console.ReadLine();
            Main();
        }
    }
}