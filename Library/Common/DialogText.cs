using System;
using System.Collections.Generic;

namespace Library
{
	public class DialogText
	{
		public int Speaker { get; set; }

		public List<string> Texts { get; set; }

		protected int current = 0;

		public DialogText()
		{
			Speaker = 0;
			Texts = new List<string>();
		}

		public bool SetNext()
		{
			if (current < Texts.Count - 1)
			{
				current++;
				return true;
			}
			else
			{
				return false;
			}
		}

		public string GetCurrent()
		{
			return Texts[current];
		}
	}
}

