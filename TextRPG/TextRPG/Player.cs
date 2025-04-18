using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Player : Behavior
    {
        public int maxHp { get; private set;} = 100;
        public int hp = 100;
        public float power { get; private set;} = 10f;
        public int weaponPower = 0;
        public int defens { get; private set; } = 5;
        private int weaponDefens = 0;

        private int level = 1;
        public int gold = 10000;
        public int clear = 0;

        public int Level 
        {
            get => level + clear; // level 과 clear의 합을 반환
            private set => level = value; // 외부 변환 x
        }

        public float Power // 총 공격력
        {
            get => power + weaponPower + clear * 0.5f;
            private set => power = value;
        }

        public int Defens // 총 방어력
        {
            get => defens + weaponDefens + clear;
            private set => defens = value;
        }

        public void StateText() // 플레이어 상태
        {
            int num = -1;
            Console.WriteLine("상태 보기\r\n캐릭터의 정보가 표시됩니다.");
            Console.WriteLine(" ");
            Console.WriteLine("Lv. {0} ", Level);
            Console.WriteLine("Chad (전사)");
            Console.WriteLine("공격력: {0} {1}  ", Power, weaponPower != 0 ? $"(+{weaponPower})" : "");
            Console.WriteLine("방어력: {0} {1}  ", Defens, weaponDefens != 0 ? $"(+{weaponDefens})" : "");
            Console.WriteLine("체 력: {0}  ", hp);
            Console.WriteLine("Gold: {0} G   ", gold);
            Console.WriteLine(" ");
            Console.WriteLine("0. 나가기");
            while (num != 0)
            {
                num = BehaviorText();
                switch (num)
                {
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("\r\n잘못된 입력입니다.");
                        Console.SetCursorPosition(0, 11);
                        break;
                }
            }
        }

        public void IncreaseState(int type, int amount) // 능력치 증가
        {
            if(type == 1)
            {
                weaponPower += amount;
            }
            else if(type == 2)
            {
                weaponDefens += amount;
            }
        }

        public void DecreaseState(int type, int amount) // 능력치 감소
        {
            if (type == 1)
            {
                weaponPower -= amount;
            }
            else if (type == 2)
            {
                weaponDefens -= amount;
            }
        }
    }


}
