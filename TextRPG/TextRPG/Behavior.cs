using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    public class Behavior
    {
        public int BehaviorText() // 행동
        {
            int number = 0;
            Console.Write("                                 \r\n");
            Console.Write("원하시는 행동을 입력해주세요.\r\n");
            Console.Write(">> ");
            string? num = Console.ReadLine();
            if(string.IsNullOrEmpty(num)) Console.Write("잘못된 입력입니다.");
            else number = int.Parse(num);
            return number;
        }

    }
}
