using System;
using System.IO;
using System.Xml.Serialization;

namespace Library
{
	public class Serializer
	{
		public static string RootPath { get; set; }

		static Serializer()
		{
			RootPath = "Assets/Resources/";
		}

		public static void Serialize<TObject>(string filePath, TObject @object)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TObject));
			FileStream fileStream = new FileStream(RootPath + filePath, FileMode.Create);
			xmlSerializer.Serialize(fileStream, @object);
			fileStream.Close();
		}

		public static TObject Deserialize<TObject>(string filePath)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TObject));
			FileStream fileStream = new FileStream(RootPath + filePath, FileMode.Open);
			TObject @object = (TObject)xmlSerializer.Deserialize(fileStream);
			fileStream.Close();

			return @object;
		}
	}
}

