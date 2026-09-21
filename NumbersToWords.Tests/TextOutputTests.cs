using NumbersToWords.Core;

namespace NumbersToWords.Tests;

public class TextOutputTests
{
    [TestCase(123.45, "one hundred and twenty-three dollars and forty-five cents")]
    public void ProvidedExampleReturnsValidOutput(decimal input, string expected)
    {
        var result = NumbersToWordsConverter.Convert(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-123.45, "negative one hundred and twenty-three dollars and forty-five cents")]
    public void ProvidedExampleNegativeReturnsValidOutput(decimal input, string expected)
    {
        var result = NumbersToWordsConverter.Convert(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(123.456789, "negative one hundred and twenty-three dollars and forty-six point cents")]
    [TestCase(123.454321, "negative one hundred and twenty-three dollars and forty-five point cents")]
    public void RoundedValuesReturnsValidOutput(decimal input, string expected)
    {
        var result = NumbersToWordsConverter.Convert(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ZeroValueReturnsValidOutput()
    {
        var result = NumbersToWordsConverter.Convert(decimal.Zero);
        var expected =
            "zero dollars and zero cents";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DecimalMaxValueReturnsValidOutput()
    {
        var result = NumbersToWordsConverter.Convert(decimal.MaxValue);
        var expected =
            "seventy-nine octillion two hundred twenty-eight septillion one hundred sixty-two sextillion five hundred fourteen quintillion two hundred sixty-four quadrillion three hundred thirty-seven trillion five hundred ninety-three billion five hundred forty-three million nine hundred fifty thousand three hundred thirty-five dollars";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DecimalMinValueReturnsValidOutput()
    {
        var result = NumbersToWordsConverter.Convert(decimal.MinValue);
        var expected =
            "negative seventy-nine octillion two hundred twenty-eight septillion one hundred sixty-two sextillion five hundred fourteen quintillion two hundred sixty-four quadrillion three hundred thirty-seven trillion five hundred ninety-three billion five hundred forty-three million nine hundred fifty thousand three hundred thirty-five dollars";
        Assert.That(result, Is.EqualTo(expected));
    }
}