using System;
using System.Collections.Generic;

namespace Library
{
	public class DialogScene
	{
		public List<DialogueText> DialogTexts { get; set; }

		public DialogScene()
		{
			DialogTexts = new List<DialogueText>();
		}
	}
}

