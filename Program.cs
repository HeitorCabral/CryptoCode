using DarkEngine.CodeCompression;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new App());
    }
}