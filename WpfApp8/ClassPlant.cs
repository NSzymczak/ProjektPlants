using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace ProjektPlant
{
		[XmlRoot(ElementName = "Plant")]
		public class ClassPlant
		{
			[XmlAttribute("ID")]
			public int ID { get; set; }

			[XmlAttribute("nameOfPlant")]
			public string nameOfPlant { get; set; }

			[XmlAttribute("nameOfPlantLatin")]
			public string nameOfPlantLatin { get; set; }

			[XmlAttribute("origin")] //pochodzenie
			public string origin { get; set; }

			[XmlAttribute("light")]
			public string light { get; set; }

			[XmlAttribute("water")]
			public int water { get; set; }

			[XmlAttribute("fertilizationSpringSummer")]
			public int fertilizationSpringSummer { get; set; }

			[XmlAttribute("fertilizationAutumnWinter")]
			public int fertilizationAutumnWinter { get; set; }

			[XmlAttribute("subsoil")]
			public string subsoil { get; set; }

			[XmlIgnore]
			public BitmapSource Image { get; set; }

			[XmlElement("Image")]
			public string ImageBuffer
			{
				get
				{
					string imageBuffer = "";

					if (Image != null)
					{
						using (var stream = new MemoryStream())
						{
							var encoder = new PngBitmapEncoder(); // or some other encoder
							encoder.Frames.Add(BitmapFrame.Create(Image));
							encoder.Save(stream);
							imageBuffer = Convert.ToBase64String(stream.ToArray());

						}
					}

					return imageBuffer;
				}
				set
				{
					if (value == "")
					{
						Image = null;
					}
					else
					{

						byte[] byteArray = Convert.FromBase64String(value);
						using (var stream = new MemoryStream(byteArray))
						{
							var decoder = BitmapDecoder.Create(stream,
								BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
							Image = decoder.Frames[0];
						}
					}
				}


			}

			public ClassPlant(int id, string nameOfPlant, string nameOfPlantLatin, string origin,
				string light, int water, int fertilizationSpringSummer, int fertilizationAutumnWinter,
				string subsoil, BitmapImage picture)
			{
				this.ID = id;
				this.nameOfPlant = nameOfPlant;
				this.nameOfPlantLatin = nameOfPlantLatin;
				this.origin = origin;
				this.light = light;
				this.water = water;
				this.fertilizationSpringSummer = fertilizationSpringSummer;
				this.fertilizationAutumnWinter = fertilizationAutumnWinter;
				this.subsoil = subsoil;
				Image = picture;
			}

			public ClassPlant(ClassPlant p)
			{
				this.ID = p.ID;
				this.nameOfPlant = p.nameOfPlant;
				this.nameOfPlantLatin = p.nameOfPlantLatin;
				this.origin = p.origin;
				this.light = p.light;
				this.water = p.water;
				this.fertilizationSpringSummer = p.fertilizationSpringSummer;
				this.fertilizationAutumnWinter = p.fertilizationAutumnWinter;
				this.subsoil = p.subsoil;
				this.Image = p.Image;
			}

			public ClassPlant() { }

		}
	}

