namespace MauiAppDotNet8;

public partial class App : Application
{
    public static bool IsConnected { get; set; } = false;
    public static bool IsLogged { get; set; } = false;
    public static bool IsAdmin { get; set; } = false;

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
