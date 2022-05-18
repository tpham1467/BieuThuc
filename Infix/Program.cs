using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Infix
{
	class Program
	{
		static int FoundSpace(string str)
		{
			for (int i = 0; i < str.Length; i++)
				if (str[i] == ' ')
					return i;
			return -1;
		}
		static bool check(string s)
        {
			foreach(char i in s)
            {
				if (i >= '0' && i <= '9')
                {
					return true;
                }

			}
			return false;
        }
		static void DeleteSpace(ref string str)
		{
			int spacePos;

			while ((spacePos = FoundSpace(str)) != -1)
				str = str.Remove(spacePos, 1);
		}

		static void ParseInput(string Input, List<string> M)
		{
			int length = Input.Length;
			int count = 0;

			for (int i = 0; i < length; i++)
			{
				if (Input[i] >= '0' && Input[i] <= '9')
				{
					if (i < length - 1)
					{
				           
						for (int j = i + 1; j < length; j++)
							if (
								Input[j] == ')' ||
								Input[j] == '*' ||
								Input[j] == '/' ||
								Input[j] == '+' ||
								Input[j] <= '-' ||
								Input[j] == '%' ||
								Input[j] == '^' ||
								Input[j] == '!' || j == length -1)
							{
			
							     if(j==length-1&&Input[j]==')')
                                {
									M.Add(Input.Substring(i, length - i-1));
									i = j-1;
								}
								else if (j == length - 1)
								{
									M.Add(Input.Substring(i, length - i));
									i = j;

								}
								else
								{
									M.Add(Input.Substring(i, j - i));
									i = j - 1;
								}
								break;
							}
					}
					else
					{
						M.Add(Input.Substring(i, length -i));
						break;
					}
				}
				else if (
					Input[i] == '(' ||
					Input[i] == ')' ||
					Input[i] == '*' ||
					Input[i] == '/' ||
					Input[i] == '+' ||
					Input[i] == '-' ||
					Input[i] == '%' ||
					Input[i] == '^' ||
					Input[i] == '!' 
					)
				{
					string temp = Convert.ToString( Input[i] );
			M.Add(temp);
		}
	}
	for(int i=1;i<M.Count;i++)
     {
		if(check(M[i-1])==false&&M[i]=="-")
                {
					M[i+1] = M[i+1].Insert(0, "-");
					M.RemoveAt(i);
                }
     }

}
static void Main(string[] args)
        {

			string[] a = File.ReadAllLines($"BIEUTHUC.INP");
			int n = 10; //Convert.ToInt32(a[0]);
			List<string> result = new List<string>();
			//for (int i = 1; i <= n; i++)
			//{
			//	Console.Write(i + ". ");
			//	Console.WriteLine(a[i]);
			//}

				for (int i = 1; i <= n; i++)
			{
				string Input;
				Input = Console.ReadLine();
				DeleteSpace(ref Input);
				
				Infix infix = new Infix();
				List<string> M = new List<string>();
				ParseInput(Input, M);
                for (int j = 0; j < M.Count; j++)
                {
                    Console.Write($" {M[j]} |");
                }
                Console.WriteLine();
                Console.WriteLine(infix.CalculateValue(M));
                //	result.Add(Convert.ToString(infix.CalculateValue(M)));
            }
			File.WriteAllLines("KETQUA.OUT",result.ToArray());
			//cout << "Equal: " << infix->calculateValue(M) << endl;
			//system("pause");
		}
    }
}
