namespace NumbersToWords.Core;

public static class NumbersToWordsConverter
{
    public static string Convert(decimal input)
    {
        var inputString = input.ToString("F2");
        return inputString;
    }
}
