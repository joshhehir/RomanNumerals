using NUnit.Framework;
using RomanNumerals;
using System;

namespace RomanNumeralsTests
{
    public class RomanNumeralTest
    {
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("VIII", 8)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("XI", 11)]
        [TestCase("MCMLXXXIX", 1989)]
        [TestCase("MMMCMXCIX", 3999)]
        public void RomanNumeralShouldBeConvertedToCorrectArabicNumbers(string romanNumeral, int expectedArabicNumber)
        {
            var result = new RomanNumeral().Convert(romanNumeral);

            Assert.AreEqual(expectedArabicNumber, result);
        }

        [TestCase(null, false)]
        [TestCase("aaa", false)]
        [TestCase("IV", true)]
        [TestCase("IA", false)]
        [TestCase("IIII", false)]
        public void RomanNumeralShouldValidateTheRomanNumeralPassedIn(string romanNumeral, bool expectedResult)
        {
            var result = new RomanNumeral().ValidRomanNumeral(romanNumeral);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void ConverterShouldThrowExceptionIfIncorrectRomanNumeralIsInputted()
        {
            var sut = new RomanNumeral();
            Assert.Throws<ArgumentException>(() => sut.Convert("aaa"));
        }
    }
}