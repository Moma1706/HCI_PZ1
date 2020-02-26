using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace HCIProject1
{
    [Serializable]
    public class Deck
    {

        public string DeckName { get; set; }
        public string DeckCLass { get; set; }
        public string Aboutn { get; set; }
        public int AvgMana { get; set; }
        public String DateTime { get; set; }
        private string Pic { get; set; }
        [XmlIgnore]
        public BitmapSource Img { get; set; }

        public Deck(string name,string deckClass,string abouth,int mana,string date,string pic)
        {
            DeckName = name;
            DeckCLass = deckClass;
            Aboutn = abouth;
            AvgMana = mana;
            DateTime = date;
            Pic = pic;
            Img = new ImageSourceConverter().ConvertFromString(pic) as BitmapSource;

        }

        public Deck()
        {

        }

        [XmlElement("slika")]
        public byte[] ImageBuffer
        {
            get
            {
                byte[] imageBuffer = null;

                if (Img != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        var encoder = new PngBitmapEncoder(); // or some other encoder
                        encoder.Frames.Add(BitmapFrame.Create(Img));
                        encoder.Save(stream);
                        imageBuffer = stream.ToArray();
                    }
                }

                return imageBuffer;
            }
            set
            {
                if (value == null)
                {
                    Img = null;
                }
                else
                {
                    using (var stream = new MemoryStream(value))
                    {
                        var decoder = BitmapDecoder.Create(stream,
                            BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        Img = decoder.Frames[0];
                    }
                }
            }
        }

    }
}
