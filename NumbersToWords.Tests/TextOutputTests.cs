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

    [TestCase(0.01, "zero dollars and one cent")]
    [TestCase(0.02, "zero dollars and two cents")]
    [TestCase(0.03, "zero dollars and three cents")]
    [TestCase(0.04, "zero dollars and four cents")]
    [TestCase(0.05, "zero dollars and five cents")]
    [TestCase(0.06, "zero dollars and six cents")]
    [TestCase(0.07, "zero dollars and seven cents")]
    [TestCase(0.08, "zero dollars and eight cents")]
    [TestCase(0.09, "zero dollars and nine cents")]
    [TestCase(1, "one dollar and zero cents")]
    [TestCase(1.01, "one dollar and one cent")]
    [TestCase(2.02, "two dollars and two cents")]
    [TestCase(3.03, "three dollars and three cents")]
    [TestCase(4.04, "four dollars and four cents")]
    [TestCase(5.05, "five dollars and five cents")]
    [TestCase(6.06, "six dollars and six cents")]
    [TestCase(7.07, "seven dollars and seven cents")]
    [TestCase(8.08, "eight dollars and eight cents")]
    [TestCase(9.09, "nine dollars and nine cents")]
    [TestCase(10.10, "ten dollars and ten cents")]
    [TestCase(11.11, "eleven dollars and eleven cents")]
    [TestCase(12.12, "twelve dollars and twelve cents")]
    [TestCase(13.13, "thirteen dollars and thirteen cents")]
    [TestCase(14.14, "fourteen dollars and fourteen cents")]
    [TestCase(15.15, "fifteen dollars and fifteen cents")]
    [TestCase(16.16, "sixteen dollars and sixteen cents")]
    [TestCase(17.17, "seventeen dollars and seventeen cents")]
    [TestCase(18.18, "eighteen dollars and eighteen cents")]
    [TestCase(19.19, "nineteen dollars and nineteen cents")]
    [TestCase(10.2, "ten dollars and twenty cents")]
    [TestCase(10.3, "ten dollars and thirty cents")]
    [TestCase(10.4, "ten dollars and forty cents")]
    [TestCase(10.5, "ten dollars and fifty cents")]
    [TestCase(10.6, "ten dollars and sixty cents")]
    [TestCase(10.7, "ten dollars and seventy cents")]
    [TestCase(10.8, "ten dollars and eighty cents")]
    [TestCase(10.9, "ten dollars and ninety cents")]
    public void ArbitraryValueTests(decimal input, string expected)
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