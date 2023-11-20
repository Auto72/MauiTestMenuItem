namespace MauiAppDotNet8;

public static class StringExtensions
{
    public static bool EqualsIgnoreCase(this string a, string b) => a.Equals(b, StringComparison.CurrentCultureIgnoreCase);
}