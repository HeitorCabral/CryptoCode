using Newtonsoft.Json;

namespace DarkEngine.CodeCompression
{
    internal class EncryptHelper
    {
        public static List<char> Chars
        {
            get
            {
                List<char> _Chars = new();
                _Chars.AddRange($" !{'\"'}#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[{'\\'}]^_`abcdefghijklmnopqrstuvwxyz{"{}"}~".ToArray());
                return _Chars;
            }
            private set { }
        }

        public static bool HasDuplicates(IList<char> Item, out char OUT)
        {
            Dictionary<char, bool> Map = new();

            for (int i = 0; i < Item.Count; i++)
            {
                if (Map.ContainsKey(Item[i]))
                {
                    OUT = Item[i];
                    return true;
                }

                Map.Add(Item[i], true);
            }

            OUT = ' ';
            return false;
        }

        public static void CreateBuildFile(string URL)
        {
            int ID;
            Random Random = new();
            List<EncryptKey> KeyJSON = new();
            List<char> RandomChars = Chars;

            for (int i = 0; i < Chars.Count; i++)
            {
                KeyJSON.Add(new EncryptKey(Chars[i], RandomChars[ID = Random.Next(RandomChars.Count)]));
                RandomChars.RemoveAt(ID);
            }

            string JSON = JsonConvert.SerializeObject(KeyJSON.ToArray(), Formatting.Indented);
            FileStream BuildFile = File.Create(URL);
            System.Text.Json.JsonSerializer.Serialize(BuildFile, JSON);
            BuildFile.Close();
        }
    }
}