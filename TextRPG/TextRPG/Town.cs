using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    public class Town
    {
        private Player player;
        private Inventory inventory;
        private Store store;
        private Title title;
        private Rest rest;
        private Dungeon dungeon;

        private int number = 0;
        private bool isPlay = true;

        public Town()
        {
            List<Weapon> playerWeapons = new List<Weapon>(); // 무기 리스트

            Item item = new Item();

            player = new Player(); // 플레이어 먼저 생성

            rest = new Rest(player);

            dungeon = new Dungeon(player);

            inventory = new Inventory(player, playerWeapons); // 인벤토리는 플레이어와 무기 리스트 필요

            store = new Store(player, inventory, item); // 상점은 플레이어, 인벤토리, 아이템 필요

            title = new Title(); 
        }

        public void Start()
        {
            while (isPlay)
            {
                switch (number)
                {
                    case 0:
                        Console.Clear();
                        number = title.TitleText();
                        continue;
                    case 1:
                        Console.Clear();
                        player.StateText(); // 플레이어 상태
                        break;
                    case 2:
                        Console.Clear();
                        inventory.InventoryText(); // 인벤토리
                        break;
                    case 3:
                        Console.Clear();
                        store.StoreText(); // 상점
                        break;
                    case 4:
                        Console.Clear();
                        dungeon.DungeonText(); // 던전 입장
                        break;
                    case 5:
                        Console.Clear();
                        rest.RestText(); // 휴식하기
                        break;
                }

                number = 0; // 항상 타이틀로 돌아감
            }
        }
    }
}
