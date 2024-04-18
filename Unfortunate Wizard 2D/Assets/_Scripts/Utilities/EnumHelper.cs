using System;

public static class EnumHelper
{
    
    public static string ReplaceUnderscoreWithSpace(this Enum value)
    {
        // put spaces between words
        string text = value.ToString();
        text = text.Replace("_", " ");
        return text;
    }
    
    public static string InsertSpacesBeforeCapitals(this Enum value)
    {
        // TODO: don't separate acronyms
        string text = value.ToString();
        text = System.Text.RegularExpressions.Regex.Replace(text, "([A-Z])", " $1");
        return text;
    }
}