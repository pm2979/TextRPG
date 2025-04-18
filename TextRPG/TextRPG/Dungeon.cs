using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Dungeon : Behavior
    {
        Player player;
        bool isClear = true;
        int startHp;
        int startGold;
        
        public Dungeon(Player player) 
        {
            this.player = player;
        }

        public void DungeonText()
        {
            int num = -1;

            while (num != 0)
            {
                startGold = player.gold;
                startHp = player.hp;
                Console.WriteLine("던전입장\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine(" ");
                Console.WriteLine("[체 력] : {0}", player.hp);
                Console.WriteLine(" ");
                Console.WriteLine("1. 쉬운 던전     | 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전     | 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");
                Console.WriteLine("0. 나가기");

                num = BehaviorText();

                switch (num)
                {
                    case 0: // 나가기
                        Console.Clear();
                        break;
                    case 1: // 쉬움 던전
                        DungeonPlay(num);
                        break;
                    case 2: // 일반 던전
                        DungeonPlay(num);
                        break;
                    case 3: // 어려운 던전
                        DungeonPlay(num);
                        break;
                    default:
                        Console.WriteLine("\r\n잘못된 입력입니다.         ");
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }
        }


        public void DungeonPlay(int level) // 던전 플레이 (level = 던전 난이도)
        {
            int defens = RecommendedDefens(level);

            if (player.defens >= defens) //권장 방어력보다 방어력이 높으면 성공
            {
                DungeonClear(level);
            }
            else
            {
                Random randomClear = new Random();
                if (randomClear.Next(10) > 3) // 60%로 던전 클리어
                {
                    DungeonClear(level);
                }
                else // 던전 실패
                {
                    player.hp /= 2;
                    isClear = false;
                }
            }
            FailText();
            Console.SetCursorPosition(0, 0);
        }


        public void ClearText() // 던전 클리어 텍스트
        {
            int num = -1;
            while (num != 0)
            {
                Console.WriteLine("던전 클리어\r\n축하합니다!!");
                Console.WriteLine("쉬운 던전을 클리어 하였습니다.");
                Console.WriteLine(" ");
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {startHp} -> {player.hp}");
                Console.WriteLine($"Gold {startGold} -> {player.gold}");
                Console.WriteLine(" ");
                Console.WriteLine("0. 나가기");
                num = BehaviorText();

                switch (num)
                {
                    case 0: // 나가기
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("\r\n잘못된 입력입니다.       ");
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }
        }


        public void DungeonClear(int level) // 던전 클리어
        {
            Console.Clear();
            Random randomDamage = new Random();
            player.hp -= randomDamage.Next(20, 36) + player.defens - RecommendedDefens(level); // 랜덤 체력 감소

            player.gold += ClearMoney(level); // 클리어 보상

            player.clear++;
            isClear = true;
            ClearText();
        }


        private int RecommendedDefens(int level) // 권장 방어력
        {
            if (level == 1) return 5;
            else if (level == 2) return 11;
            else return 17;
        }


        private int ClearMoney(int level) // 클리어 보상
        {
            Random randomMoney = new Random();
            int gold = 0;

            switch (level)
            {
                case 1: // 쉬움 던전
                    gold = 900;
                    break;
                case 2: // 일반 던전
                    gold = 1700;
                    break;
                case 3: // 어려운 던전
                    gold = 2500;
                    break;
            }

            return gold + gold * randomMoney.Next((int)player.Power, (int)player.Power * 2) / 100;
        }


        private void FailText() // 실패 텍스트
        {
            if (!isClear)
            {
                Console.WriteLine("\r\n던전 클리어 실패!!     ");
                isClear = true;
            }
        }


    }
}
