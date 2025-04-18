using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    internal class Title : Behavior
    {
        public int TitleText() //타이틀
        {
            int num = -1;
            while (num <= 0 || num > 5)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine(" ");
                Console.WriteLine("1. 상태 보기\r\n2. 인벤토리\r\n3. 상점\r\n4. 던전입장\r\n5. 휴식하기");
                num = BehaviorText();
                if (num <= 0 || num > 5)
                {
                    Console.WriteLine("\r\n잘못된 입력입니다.");
                    Console.SetCursorPosition(0, 0);
                }
            }
            return num;
        }
    }
}
