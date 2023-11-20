using System.Diagnostics;

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

        //-------------------------------------------------------------------------------------------------------------
        // How to enumerate all the MenuItems of the Shell object and decide which one to hide/show programmatically ?
        //-------------------------------------------------------------------------------------------------------------
        foreach (var item in shell.Items)
        {
            Debug.WriteLine($"item.GetType(): {item.GetType()} | item.ClassId: {item.ClassId}");

            // Is it a MenuItem of the Shell object ?
            if (item.GetType().ToString().EqualsIgnoreCase("Microsoft.Maui.Controls.MenuShellItem"))
            {
                // NOTE: ClassId here is from MenuShellItem (internal class, not public) and not MenuItem. How To get the one from MenuItem?
                if (item.ClassId is null)                
                {
                    Debug.WriteLine("item.ClassId is null !!!");

                    // NOTE: item.IsVisible DOES work here to show/hide the MenuItem.
                    //item.IsVisible = false;

                    continue;
                }

                // This code is never executed - How to identify which MenuItem is item (if ClassId is null and it is not from MenuItem)?

                if (item.ClassId.EqualsIgnoreCase("mnuLogin"))      { item.IsVisible = !isLogged; }
                if (item.ClassId.EqualsIgnoreCase("mnuLogout"))     { item.IsVisible = isLogged; }
                if (item.ClassId.EqualsIgnoreCase("mnuConnect"))    { item.IsVisible = !isConnected; }
                if (item.ClassId.EqualsIgnoreCase("mnuDisconnect")) { item.IsVisible = isConnected; }
                if (item.ClassId.EqualsIgnoreCase("mnuSettings"))   { item.IsVisible = isAdmin; }
            }
        }
    }
}

