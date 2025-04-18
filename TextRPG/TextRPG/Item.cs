using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    public class Item
    {
        public List<Weapon> weapons = new List<Weapon>()
        {
            new Weapon((int)ItemType.Weapon, "낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다.", 500, false),
            new Weapon((int)ItemType.Weapon, "청동 도끼", 5, "어디선가 사용됐던 도끼입니다.", 1500, false),
            new Weapon((int)ItemType.Weapon, "강철 검", 7, "대장장이가 강철로 만든 검입니다.", 2000, false),
            new Weapon((int)ItemType.Weapon, "스파르타의 창", 9, "스파르타 전사들이 쓰던 창입니다.", 3500, false),
            new Weapon((int)ItemType.Armor, "수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000, false),
            new Weapon((int)ItemType.Armor, "무쇠갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, false),
            new Weapon((int)ItemType.Armor, "스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false)
        };

        public List<Weapon> WeaponsInfo() // 모든 아이템 정보
        {
            return weapons;
        }
    }

    public enum ItemType 
    {
        Weapon = 1,
        Armor
    }
}
