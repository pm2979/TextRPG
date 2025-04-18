using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    public class Inventory : Behavior
    {
        public List<Weapon> playerWeapons;
        private Player player;

        public Inventory(Player player, List<Weapon> weapons)
        {
            this.player = player;

            playerWeapons = weapons;
        }

        public void InventoryText() //인벤토리
        {
            int num = -1;
            while (num != 0) // 장착하면 다시 숫자 입력
            {
                Console.WriteLine("인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine(" ");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine(" ");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                num = BehaviorText();
                switch (num)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        ItemInven();
                        break;
                    default:
                        Console.WriteLine("\r\n잘못된 입력입니다.");
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }
        }

        public void ItemInven() //장비 인벤토리
        {
            int num = -1;
            Console.WriteLine("인벤토리 - 장착 관리\r\n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine(" ");
            Console.WriteLine("[아이템 목록]");
            while (num != 0) // 장착하면 다시 숫자 입력
            {
                for (int i = 0; i < playerWeapons.Count; i++) // 장착 가능한 장비 확인
                {
                    if (playerWeapons[i].Type == 1) Console.WriteLine("-{0} {4}{1}  | 공격력 + {2} | {3}  ", i + 1, playerWeapons[i].Name, playerWeapons[i].Power, playerWeapons[i].Info, playerWeapons[i].Install ? "[E]" : " ");
                    if (playerWeapons[i].Type == 2) Console.WriteLine("-{0} {4}{1}  | 방어력 + {2} | {3}  ", i + 1, playerWeapons[i].Name, playerWeapons[i].Power, playerWeapons[i].Info, playerWeapons[i].Install ? "[E]" : " ");
                }
                Console.WriteLine(" ");
                Console.WriteLine("0. 나가기");
                num = BehaviorText();
                switch (num)
                {
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Install(num - 1);
                        Console.SetCursorPosition(0, 4);
                        break;
                }
            }
        }

        public void Install(int num)
        {
            if (num >= 0 && num < playerWeapons.Count)
            {
               WeaponInstall(num);
            }
            else
            {
                Console.WriteLine("\r\n잘못된 입력입니다.");
            }
        }

        private void WeaponInstall(int num) // 장착 또는 해제
        {
            Weapon install = playerWeapons[num];

            if (install.Install == true) // 장착 중인 아이템이면 해제
            {
                install.Install = false;
                player.DecreaseState(install.Type, install.Power);

            }
            else // 새로운 아이템을 장착
            {
                foreach(Weapon weapon in playerWeapons) // 같은 타입의 장비를 해제
                {
                    if(install.Type == weapon.Type && weapon.Install == true)
                    {
                        weapon.Install = false;
                        player.DecreaseState(weapon.Type, weapon.Power);
                    }
                }

                install.Install = true;
                player.IncreaseState(install.Type, install.Power);
            }
        }
    }
}
