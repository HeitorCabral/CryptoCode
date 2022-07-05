namespace DarkEngine.CodeCompression
{
    public class Encrypt
    {
        public const string Build = "./Build.json";

        public string EditCode { get; private set; } = "";
        public string Encrypted { get; private set; } = "";
        public string Decrypted { get; private set; } = "";

        public Encrypt(string EditCode) => this.EditCode = EditCode;

        public bool IsInitialized { get; private set; } = false;

        public void Initialize()
        {
            if (!File.Exists(Build)) 
                EncryptHelper.CreateBuildFile(Build);

            IsInitialized = true;
        }

        public void CreateFile(string Folder, string FileName)
        {
            if (IsInitialized)
            {
                TextWriter BuildFile = new StreamWriter($"{Folder}{FileName}.CRYPTO");
                BuildFile.WriteLine(Encrypted);
                BuildFile.Close();
            }
            else MessageBox.Show("Encrypt not initialized", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool DecryptCode()
        {
            if (IsInitialized)
            {
                List<EncryptKey> Values = EncryptKey.ReadFile(Build);
                Dictionary<char, char> GetValue = EncryptKey.GetFromValue(Values);

                for (int i = 0; i < Encrypted.Length; i++)
                    Decrypted += GetValue[Encrypted[i]];

                return true;
            }
            else
            {
                MessageBox.Show("Encrypt not initialized", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public void EncryptCode()
        {
            if (IsInitialized)
            {
                List<EncryptKey> Keys = EncryptKey.ReadFile(Build);
                Dictionary<char, char> GetKey = EncryptKey.GetFromKey(Keys);

                for (int i = 0; i < EditCode.Length; i++)
                    for (int x = 0; x < GetKey.Keys.ToArray().Length; x++)
                        if (GetKey.Keys.ToArray()[x] == EditCode[i])
                            Encrypted += GetKey[EditCode[i]];
            }
            else MessageBox.Show("Encrypt not initialized", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}