using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Weapon
    {
        public int Type; // 무기 타입 (1: 무기, 2: 방어구)
        public string Name; // 무기 이름
        public int Power; // 무기 파워
        public string Info; // 무기 정보
        public int Gold; // 무기 가격
        public bool Install; // 무기 장착 여무

        public Weapon(int type, string name, int power, string info, int gold, bool install)
        {
            Type = type;
            Name = name;
            Power = power;
            Info = info;
            Gold = gold;
            Install = install;
        }
    }
}
