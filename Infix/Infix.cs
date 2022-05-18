using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
namespace Infix
{
   public class Infix
    {
	public Infix()
        {

        }
	int UT(string x)
	{
		if (x == "^" || x == "!")
			return 3;

		if (x == "*" || x == "/" || x == "%")
			return 2;
		else if (x == "+" || x == "-")
			return 1;
		else if (x == "(")
			return 0;

		return -1;
	}

	int HT(string x)
	{
		if (x == "*" || x == "/" || x == "%" || x == "+" || x == "-" || x == "^" || x == "!")
			return 2;
		else
			return 1;
	}
	int Giaithua(int x)
	{
		int s = 1;
		for (int i = 1; i <= x; i++)
		{
			s *= i;
		}
		return s;
	}
	string calculateValue(string b, string x, string a)
	{
		float fResult = 0;
		if (x == "!")
		{
			fResult = Giaithua(Convert.ToInt32(a));
		}
		if (x == "^")
		{
			fResult = 1;

			for (int i = 1; i <= Convert.ToInt32(a); i++)
				fResult = fResult * (float)(Convert.ToDouble(b))	;
		}

		if (x == "%")
			fResult = (float)(Convert.ToDouble(b)) % (float)(Convert.ToDouble(a));

			if (x == "*")
				fResult = (float)(Convert.ToDouble(b)) * (float)(Convert.ToDouble(a));
			else if (x == "/")
				fResult = (float)(Convert.ToDouble(b)) / (float)(Convert.ToDouble(a));
			else if (x == "+")
				fResult = (float)(Convert.ToDouble(b)) + (float)(Convert.ToDouble(a));
			else if (x == "-")
			{
				if (b != ""&&a!="")
					fResult = (float)(Convert.ToDouble(b)) - (float)(Convert.ToDouble(a));
				else fResult = -(float)(Convert.ToDouble((a==""?b:a)));
			}
		string strResult = Convert.ToString((fResult));
		return strResult;
	}

		public float CalculateValue(List<string> M)
	{
		float fResult = 0;

		Stack Sh = new Stack();
		Stack St = new Stack();

			int iLength = M.Count;
					
		for (int i = 0; i < iLength; i++)
		{
			if (HT(M[i]) == 1 && M[i] != "(" && M[i] != ")")

				Sh.Push(M[i]);

			if (M[i] == "(")
				St.Push(M[i]);

			if (HT(M[i]) == 2)
			{
				while (!St.IsEmpty() && (UT(M[i]) <= UT(St.GetHead())))
				{
					string a = "";
					Sh.Pop(ref a);
					string x = "";
					string b = "";
						St.Pop(ref x);
					if (x != "!")
					{
								
						Sh.Pop(ref b);
					}

					Sh.Push(this.calculateValue(b, x, a));
				}
				St.Push(M[i]);
			}

			if (M[i] == ")")
			{
				while (St.GetHead() != "(")
				{

					string a = "";	
					Sh.Pop(ref a);
					string x = "";
					St.Pop(ref x);
					string b = "";
						if (x != "!")
						{

							Sh.Pop(ref b);
						}
						Sh.Push(this.calculateValue(b, x, a));
				}
				string c = "";
				St.Pop(ref c);
			}
		}

		while (!St.IsEmpty())
		{
			string a = "";
			Sh.Pop(ref a);
			string x = "";
			string b = "";
				St.Pop(ref x);
			if (x != "!")
			{

				Sh.Pop(ref b);
			}
			Sh.Push(this.calculateValue(b, x, a));
		}

		string strResult = "";
		Sh.Pop(ref strResult);
		fResult = (float)(Convert.ToDouble(strResult));
		return fResult;
	}
}
}
