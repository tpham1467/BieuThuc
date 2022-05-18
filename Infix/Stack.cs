using System;

namespace Infix
{
	internal class Stack
	{
		static readonly int MAX = 100000;
		public int top { get; set; }
		string[] stack = new string[MAX];

		internal bool IsEmpty()
		{
			return (top < 0);
		}
		public Stack()
		{
			top = -1;
		}
		internal void Push(string data)
		{
			if (top >= MAX)
			{
				return;
			}
			else
			{
				stack[++top] = data;
				
			}
		}

		internal int Pop(ref string  data)
		{
			if (top < 0)
			{
				return 0;
			}
			else
			{
				data = stack[top--];
			}
			return 1;
		}
		internal string GetHead()
        {
			return  stack[top];
		}

		

		
	}

}
