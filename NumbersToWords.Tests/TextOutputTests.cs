using NumbersToWords.Core;

namespace NumbersToWords.Tests;

public class TextOutputTests
{
    [TestCase(123.45, "one hundred and twenty-three dollars and forty-five cents")]
    public void ProvidedExampleReturnsValidOutput(decimal input, string expected)
    {
        var structuredOutput = new NumbersToCurrencyWordsStructure(input);
        var result = structuredOutput.ToString();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-123.45, "negative one hundred and twenty-three dollars and forty-five cents")]
    public void ProvidedExampleNegativeReturnsValidOutput(decimal input, string expected)
    {
        var structuredOutput = new NumbersToCurrencyWordsStructure(input);
        var result = structuredOutput.ToString();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(123.456789, "one hundred and twenty-three dollars and forty-six cents")]
    [TestCase(123.454321, "one hundred and twenty-three dollars and forty-five cents")]
    public void RoundedValuesReturnsValidOutput(decimal input, string expected)
    {
        var structuredOutput = new NumbersToCurrencyWordsStructure(input);
        var result = structuredOutput.ToString();
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ZeroValueReturnsValidOutput()
    {
        var structuredOutput = new NumbersToCurrencyWordsStructure(decimal.Zero);
        var result = structuredOutput.ToString();
        const string expected = "zero dollars and zero cents";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DecimalMaxValueReturnsValidOutput()
    {
        var structuredOutput = new NumbersToCurrencyWordsStructure(decimal.MaxValue);
        var result = structuredOutput.ToString();
        const string expected = "seventy-nine octillion two hundred and twenty-eight septillion one hundred and sixty-two sextillion five hundred and fourteen quintillion two hundred and sixty-four quadrillion three hundred and thirty-seven trillion five hundred and ninety-three billion five hundred and forty-three million nine hundred and fifty thousand three hundred and thirty-five dollars and zero cents";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DecimalMinValueReturnsValidOutput()
    {
        var structuredOutput = new NumbersToCurrencyWordsStructure(decimal.MinValue);
        var result = structuredOutput.ToString();
        const string expected = "negative seventy-nine octillion two hundred and twenty-eight septillion one hundred and sixty-two sextillion five hundred and fourteen quintillion two hundred and sixty-four quadrillion three hundred and thirty-seven trillion five hundred and ninety-three billion five hundred and forty-three million nine hundred and fifty thousand three hundred and thirty-five dollars and zero cents";
        Assert.That(result, Is.EqualTo(expected));
    }
}