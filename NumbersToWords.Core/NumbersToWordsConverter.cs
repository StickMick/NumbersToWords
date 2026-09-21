using System.Text;

namespace NumbersToWords.Core;

public class NumbersToCurrencyWordsStructure
{
    public bool IsPositive { get; set; }

    // 30 digits
    public Octillions Octillions { get; set; }

    // 27 digits
    public Septillions Septillions { get; set; }

    // 24 digits
    public Sextillions Sextillions { get; set; }

    // 21 digits
    public Quintillions Quintillions { get; set; }

    // 18 digits
    public Quadrillions Quadrillions { get; set; }

    // 15 digits
    public Trillions Trillions { get; set; }

    // 12 digits
    public Billions Billions { get; set; }

    // 9 digits
    public Millions Millions { get; set; }

    // 6 digits
    public Thousands Thousands { get; set; }

    // 3 digits
    public Hundreds Hundreds { get; set; }

    public Cents Cents { get; set; }

    public NumbersToCurrencyWordsStructure(decimal input)
    {
        if (input >= 0)
        {
            IsPositive = true;
        }
        else
        {
            IsPositive = false;
            input = Math.Abs(input);
        }

        // Format F2 will round the cents
        var convertedString = input.ToString("F2");

        // Split into dollars and cents
        Cents = new Cents(Convert.ToInt16(convertedString.Split(".")[1]));

        var dollars = convertedString.Split(".")[0].PadLeft(30, '0');

        Octillions = new Octillions(Convert.ToInt16(dollars.Substring(0, 3)));
        Septillions = new Septillions(Convert.ToInt16(dollars.Substring(3, 3)));
        Sextillions = new Sextillions(Convert.ToInt16(dollars.Substring(6, 3)));
        Quintillions = new Quintillions(Convert.ToInt16(dollars.Substring(9, 3)));
        Quadrillions = new Quadrillions(Convert.ToInt16(dollars.Substring(12, 3)));
        Trillions = new Trillions(Convert.ToInt16(dollars.Substring(15, 3)));
        Billions = new Billions(Convert.ToInt16(dollars.Substring(18, 3)));
        Millions = new Millions(Convert.ToInt16(dollars.Substring(21, 3)));
        Thousands = new Thousands(Convert.ToInt16(dollars.Substring(24, 3)));
        Hundreds = new Hundreds(Convert.ToInt16(dollars.Substring(27, 3)));
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        if (!IsPositive) sb.Append("negative ");

        var dollars = new List<object>();

        if (Octillions.HasValue) dollars.Add(Octillions);
        if (Septillions.HasValue) dollars.Add(Septillions);
        if (Sextillions.HasValue) dollars.Add(Sextillions);
        if (Quintillions.HasValue) dollars.Add(Quintillions);
        if (Quadrillions.HasValue) dollars.Add(Quadrillions);
        if (Trillions.HasValue) dollars.Add(Trillions);
        if (Billions.HasValue) dollars.Add(Billions);
        if (Millions.HasValue) dollars.Add(Millions);
        if (Thousands.HasValue) dollars.Add(Thousands);
        dollars.Add(Hundreds);

        sb.AppendJoin(" ", dollars);

        if (Hundreds.Value == 1)
        {
            sb.Append("dollar and ");
        }
        else
        {
            sb.Append("dollars and ");
        }


        sb.Append(Cents);

        if (Cents.Value == 1)
        {
            sb.Append("cent");
        }
        else
        {
            sb.Append("cents");
        }

        return sb.ToString();
    }
}

public class Cents(short value) : WordCurrency("", value);

public class Hundreds(short value) : WordCurrency("", value);

public class Thousands(short value) : WordCurrency("thousand", value);

public class Millions(short value) : WordCurrency("million", value);

public class Billions(short value) : WordCurrency("billion", value);

public class Trillions(short value) : WordCurrency("trillion", value);

public class Quadrillions(short value) : WordCurrency("quadrillion", value);

public class Quintillions(short value) : WordCurrency("quintillion", value);

public class Sextillions(short value) : WordCurrency("sextillion", value);

public class Septillions(short value) : WordCurrency("septillion", value);

public class Octillions(short value) : WordCurrency("octillion", value);

public class WordCurrency(string magnitude, short value)
{
    public short Value { get; } = value;
    public bool HasValue => Value != 0;

    public override string ToString()
    {
        return Value switch
        {
            >= 0 and < 100 => ParseTens(Value, false),
            >= 100 and < 200 => "one hundred" + ParseTens((short)(Value - 100)),
            >= 200 and < 300 => "two hundred" + ParseTens((short)(Value - 200)),
            >= 300 and < 400 => "three hundred" + ParseTens((short)(Value - 300)),
            >= 400 and < 500 => "four hundred" + ParseTens((short)(Value - 400)),
            >= 500 and < 600 => "five hundred" + ParseTens((short)(Value - 500)),
            >= 600 and < 700 => "six hundred" + ParseTens((short)(Value - 600)),
            >= 700 and < 800 => "seven hundred" + ParseTens((short)(Value - 700)),
            >= 800 and < 900 => "eight hundred" + ParseTens((short)(Value - 800)),
            >= 900 and < 1000 => "nine hundred" + ParseTens((short)(Value - 900)),
            _ => string.Empty
        } + $" {magnitude}";
    }

    private string ParseTens(short digits, bool addAnd = true)
    {
        var result = digits switch
        {
            0 => "zero",
            > 0 and < 10 => $"{ParseOnes(digits)}",
            10 => "ten",
            11 => "eleven",
            12 => "twelve",
            13 => "thirteen",
            14 => "fourteen",
            15 => "fifteen",
            16 => "sixteen",
            17 => "seventeen",
            18 => "eighteen",
            19 => "nineteen",
            20 => "twenty",
            > 20 and < 30 => $"twenty-{ParseOnes((byte)(digits - 20))}",
            30 => "thirty",
            > 30 and < 39 => $"thirty-{ParseOnes((byte)(digits - 30))}",
            40 => "forty",
            > 40 and < 50 => $"forty-{ParseOnes((byte)(digits - 40))}",
            50 => "fifty",
            > 50 and < 60 => $"fifty-{ParseOnes((byte)(digits - 50))}",
            60 => "sixty",
            > 60 and < 70 => $"sixty-{ParseOnes((byte)(digits - 60))}",
            70 => "seventy",
            > 70 and < 80 => $"seventy-{ParseOnes((byte)(digits - 70))}",
            80 => "eighty",
            > 80 and < 90 => $"eighty-{ParseOnes((byte)(digits - 80))}",
            90 => "ninety",
            > 90 and < 100 => $"ninety-{ParseOnes((byte)(digits - 90))}",
            _ => string.Empty
        };

        return addAnd ? $" and {result}" : result;
    }

    private string ParseOnes(short digits)
    {
        if (digits is <= 0 or >= 10) return string.Empty;

        return digits switch
        {
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            6 => "six",
            7 => "seven",
            8 => "eight",
            9 => "nine",
            _ => throw new ArgumentOutOfRangeException(nameof(digits), digits, null)
        };
    }
}