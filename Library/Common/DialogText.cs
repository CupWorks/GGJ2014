using System;
using System.Collections.Generic;

namespace Library
{
	public class DialogText
	{
		public int Speaker { get; set; }

		public List<string> Texts { get; set; }

		public DialogText()
		{
			Speaker = 0;
			Texts = new List<string>();
			Texts.Add("Text");
		}
	}
}

