using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var currentText = new Stack<string>();
            currentText.Push("");
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var commandNum = int.Parse(input[0]);
                switch (commandNum)
                {
                    case 1:
                        currentText.Push(currentText.Peek() + input[1]);
                        break;
                    case 2:
                        var text = currentText.Peek();
                        var length = int.Parse(input[1]);
                        text = text.Substring(0, text.Length - length);
                        currentText.Push(text);
                        break;
                    case 3:
                        var index = int.Parse(input[1]);
                        string inputText = currentText.Peek();
                        Console.WriteLine(inputText[index - 1]);
                        break;
                    case 4:
                        currentText.Pop();
                        break;
                }
            }
        }
    }
}