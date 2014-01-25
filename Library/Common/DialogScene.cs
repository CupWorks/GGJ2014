using System;
using System.Collections.Generic;

namespace Library
{
	public class DialogScene
	{
		public List<DialogText> DialogTexts { get; set; }

		protected int current = 0;

		public DialogScene()
		{
			DialogTexts = new List<DialogText>();
		}

		public bool SetNext()
		{
			if (current < DialogTexts.Count - 1)
			{
				current++;
				return true;
			}
			else
			{
				return false;
			}
		}

		public DialogText GetCurrent()
		{
			return DialogTexts[current];
		}
	}
}

