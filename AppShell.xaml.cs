using System.Diagnostics;

namespace MauiAppDotNet8;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        if (sender is not MenuItem menuItem) { return; }

        // NOTE: menuItem.ClassId is fine here
        var classId = menuItem.ClassId;
        Debug.WriteLine($"classId: {classId}");

        if (classId.EqualsIgnoreCase("mnuLogin"))
        {
            // TODO
        }
        else if (classId.EqualsIgnoreCase("mnuLogout"))
        {
            // TODO
        }
        // ...
    }
}
