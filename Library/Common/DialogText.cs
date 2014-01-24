using System;
using System.Collections.Generic;

namespace Library
{
	public class DialogueText
	{
		public int Speaker { get; set; }

		public List<string> Texts { get; set; }

		public DialogueText()
		{
			Speaker = 0;
			Texts = new List<string>();
			Texts.Add("Text");
		}
	}
}

