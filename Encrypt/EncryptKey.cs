using Newtonsoft.Json;

namespace DarkEngine.CodeCompression
{
    internal struct EncryptKey
    {
        public char Key { get; set; }
        public char Value { get; set; }

        public EncryptKey(char key, char value)
        {
            Key = key;
            Value = value;
        }

        public string FromJSON() => $"{Key} : {Value}";

        public static Dictionary<char, char> GetFromKey(List<EncryptKey> Keys)
        {
            Dictionary<char, char> Result = new();

            for (int i = 0; i < Keys.Count; i++) 
                Result.Add(Keys[i].Key, Keys[i].Value);

            return Result;
        }

        public static Dictionary<char, char> GetFromValue(List<EncryptKey> Keys)
        {
            Dictionary<char, char> Result = new();

            for (int i = 0; i < Keys.Count; i++)
                Result.Add(Keys[i].Value, Keys[i].Key);

            return Result;
        }

        public static List<EncryptKey> ReadFile(string URL)
        {
            StreamReader Reader = new(URL);
            string JSON = Reader.ReadToEnd();

            if (JsonConvert.DeserializeObject(JSON) is not string Result) return new();

            StringReader ResultEdit = new(Result);
            List<string> ResultLine = new();

            string? CurrentLine = ResultEdit.ReadLine();

            while (CurrentLine != null)
            {
                ResultLine.Add(CurrentLine);
                CurrentLine = ResultEdit.ReadLine();
            }

            List<EncryptKey> ResultKeys = new();

            char KeyResult = '.';

            for (int i = 0; i < ResultLine.Count; i++)
            {
                if (ResultLine[i].Contains("Key"))
                {
                    string Key = ResultLine[i].Split(':')[1];
                    if (Key.Length >= 3) KeyResult = Key.Length == 6 ? Key[^3] : Key[2];
                    else KeyResult = ':';
                }

                if (ResultLine[i].Contains("Value"))
                {
                    string Value = ResultLine[i].Split(':')[1];
                    ResultKeys.Add(new EncryptKey(KeyResult, Value == " \"" ? ':' : Value[^2]));
                }
            }

            return ResultKeys;
        }
    }
}