using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    public class Store : Behavior
    {
        private Player player;
        private Inventory inventory;
        private List<Weapon> weapons;
        private List<Weapon> playerWeapons;

        public Store(Player player, Inventory inventory, Item item)
        {
            this.player = player;

            this.inventory = inventory;

            this.weapons = item.WeaponsInfo();

            playerWeapons = inventory.playerWeapons;
        }

        public void StoreText() // 상점
        {
            int num = -1;
            while (num != 0)
            {
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.gold} G\n");

                Console.WriteLine("[아이템 목록]");
                ItemPrint();
                Console.WriteLine("\n1. 아이템 구매\n2. 아이템 판매");
                Console.WriteLine("0. 나가기");

                num = BehaviorText();
                switch (num)
                {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        PurchaseText();
                        break;
                    case 2:
                        Console.Clear();
                        SaleText();
                        break;
                    default:
                        Console.WriteLine("\r\n잘못된 입력입니다.");
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }
        }

        public void PurchaseText() // 상점 - 구매
        {
            int num = -1;
            while (num != 0)
            {
                Console.WriteLine("상점 - 아이템 구매\n");
                Console.WriteLine($"[보유 골드] {player.gold} G   \n");
                Console.WriteLine("[아이템 목록]");
                ItemsPurchase();
                Console.WriteLine("\n0. 나가기");

                num = BehaviorText();
                switch (num)
                {
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Purchase(num - 1);
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }
        }

        public void SaleText() // 상점 - 판매
        {
            int num = -1;
            while (num != 0)
            {
                Console.WriteLine("상점 - 아이템 판매\n");
                Console.WriteLine($"[보유 골드] {player.gold} G   \n");
                Console.WriteLine("[아이템 목록]");
                ItmeSale();
                Console.WriteLine("\n0. 나가기");

                num = BehaviorText();
                switch (num)
                {
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Sale(num - 1);
                        Console.Clear();
                        break;
                }
            }
        }

        public void Purchase(int num) // 구매
        {
            if (num >= 0 && num < weapons.Count)
            {
                Weapon weapon = weapons[num];
                if (player.gold >= weapon.Gold && weapon.Gold > 0)
                {
                    Console.WriteLine($"\n{weapon.Name}을(를) 구매했습니다!");
                    player.gold -= weapon.Gold;
                    weapon.Gold -= 2 * weapon.Gold; // 장비의 가격을 음수로 만들어서 판매 가능과 불가능을 구분
                    playerWeapons.Add(weapon);
                }
                else
                {
                    if(weapon.Gold < 0) Console.WriteLine("\n이미 구매한 아이템 입니다.     ");
                    else Console.WriteLine("\nGold가 부족합니다.      ");
                }
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.             ");
            }
        }

        public void Sale(int num) // 판매
        {
            if (num >= 0 && num < weapons.Count)
            {
                if (weapons[num].Install == true) // 장착 중인 아이템이면 해제
                {
                    weapons[num].Install = false;
                    player.DecreaseState(weapons[num].Type, weapons[num].Power);
                }

                Weapon playerWeapon = playerWeapons[num];
                player.gold -= playerWeapon.Gold * 85 / 100;
                playerWeapons.Remove(playerWeapon);
            }
        }

        public void ItemPrint() // 아이템 정보 출력
        {
            foreach (Weapon weapon in weapons)
            {
                if (weapon.Type == 1) Console.WriteLine($"- {weapon.Name} | 공격력: {weapon.Power} | 가격: {weapon.Gold} G");
                if (weapon.Type == 2) Console.WriteLine($"- {weapon.Name} | 방어력: {weapon.Power} | 가격: {weapon.Gold} G");
            }
        }

        private void ItemsPurchase() // 구매 아이템 정보 출력
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Gold > 0)
                {
                    if (weapons[i].Type == 1)Console.WriteLine($"-{i + 1} {weapons[i].Name} | 공격력: {weapons[i].Power} | 가격: {weapons[i].Gold} G");
                    if (weapons[i].Type == 2)Console.WriteLine($"-{i + 1} {weapons[i].Name} | 방어력: {weapons[i].Power} | 가격: {weapons[i].Gold} G");
                }
                else
                {
                    if (weapons[i].Type == 1) Console.WriteLine($"-{i + 1} {weapons[i].Name} | 공격력: {weapons[i].Power} | 가격: 구매완료");
                    if (weapons[i].Type == 2) Console.WriteLine($"-{i + 1} {weapons[i].Name} | 방어력: {weapons[i].Power} | 가격: 구매완료");
                }
            }
        }

        public void ItmeSale() // 판매 아이템 정보 출력
        {
            for (int i = 0; i < playerWeapons.Count; i++)
            {
                if (playerWeapons[i].Type == 1) Console.WriteLine($"-{i + 1} {playerWeapons[i].Name} | 공격력: {playerWeapons[i].Power} | 가격: {-playerWeapons[i].Gold * 0.85} G");
                if (playerWeapons[i].Type == 2) Console.WriteLine($"-{i + 1} {playerWeapons[i].Name} | 방어력: {playerWeapons[i].Power} | 가격: {-playerWeapons[i].Gold * 0.85} G");
            }
        }

    }
}
