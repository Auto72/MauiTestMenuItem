using System.Diagnostics;
using System.Reflection;

namespace MauiAppDotNet8;

public partial class MainPage : ContentPage
{
    private int _count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e) => CounterBtn.Text = $"Clicked {++_count} time{(_count > 1 ? "s" : "")}";

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        MainPage.ShowMenusForThisPage(App.IsLogged, App.IsConnected, App.IsAdmin);
    }

    private static void ShowMenusForThisPage(bool isLogged, bool isConnected, bool isAdmin)
    {
        if (Application.Current?.MainPage is not Shell shell) { return; }

        foreach (ShellItem item in shell.Items)
        {
            Debug.WriteLine($"item.GetType(): {item.GetType()} | item.ClassId: {item.ClassId}");

            if (item is null) { continue; }

            // Is it a MenuShellItem ?
            if (item.GetType().ToString().EqualsIgnoreCase("Microsoft.Maui.Controls.MenuShellItem"))
            {
                // MenuShellItem
                Type msiType = item.GetType();
                PropertyInfo? mi = msiType.GetProperty("MenuItem");
                if (mi is null) { continue; }
                if (mi.GetValue(item) is not MenuItem m) { continue; }

                if (m.ClassId.EqualsIgnoreCase("mnuLogin")) { item.IsVisible = !isLogged; }
                if (m.ClassId.EqualsIgnoreCase("mnuLogout")) { item.IsVisible = isLogged; }
                if (m.ClassId.EqualsIgnoreCase("mnuConnect")) { item.IsVisible = !isConnected; }
                if (m.ClassId.EqualsIgnoreCase("mnuDisconnect")) { item.IsVisible = isConnected; }
                if (m.ClassId.EqualsIgnoreCase("mnuSettings")) { item.IsVisible = isAdmin; }
            }
        }
    }
}
