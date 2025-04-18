using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Rest : Behavior
    {
        Player player;

        public Rest(Player player) 
        {
            this.player = player;
        }

        public void RestText() // 휴식
        {
            int num = -1;
            while (num != 0)
            {
                Console.WriteLine("휴식하기");
                Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.gold} G");
                Console.WriteLine($"체력: {player.hp} / {player.maxHp}\n");

                Console.WriteLine("\n1. 휴식하기");
                Console.WriteLine("0. 나가기");

                num = BehaviorText();
                switch (num)
                {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        PlayerRest();
                        Console.SetCursorPosition(0, 0);
                        break;
                    default:
                        Console.WriteLine("\r\n잘못된 입력입니다.    ");
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }
        }

        public void PlayerRest() // 플레이어 체력 회복
        {
            if(500 <= player.gold) 
            {
                if (player.hp == player.maxHp) Console.WriteLine("\r\n최대 체력입니다.    ");
                else
                {
                    player.gold -= 500;
                    player.hp = player.maxHp;
                    Console.WriteLine("\r\n휴식을 완료했습니다.     ");
                }
            }
            else
            {
                Console.WriteLine("\r\nGold 가 부족합니다.      ");
            }
        }


    }
}
