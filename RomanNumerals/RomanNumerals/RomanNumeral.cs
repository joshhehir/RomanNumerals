using System.Text;

namespace RomanNumerals
{
    public class RomanNumeral
    {
        readonly Dictionary<char, int> romanNumerals = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

        static void Main()
        { }

        public int Convert(string romanNumeral)
        {
            if (!ValidRomanNumeral(romanNumeral))
            {
                throw new ArgumentException("The roman numeral inputted is incorrect");
            }

            int result = 0;

            var remainingRomanNumeral = new StringBuilder(romanNumeral);

            int i;

            for (i = 0; i < romanNumerals.Count; i++)
            {
                while (remainingRomanNumeral.Length > 0 && remainingRomanNumeral[0] == romanNumerals.ElementAt(i).Key)
                {
                    if (remainingRomanNumeral.Length > 1 && romanNumerals.ElementAt(i).Value < romanNumerals[remainingRomanNumeral[1]])
                    {
                        result -= romanNumerals.ElementAt(i).Value;
                    }
                    else
                    {
                        result += romanNumerals.ElementAt(i).Value;
                    }

                    remainingRomanNumeral.Remove(0, 1);
                    i = 0;
                }
            }

            return result;
        }

        public bool ValidRomanNumeral(string romanNumeral)
        {
            if (romanNumeral == null)
            {
                return false;
            }

            if (romanNumeral.Length >= 4)
            {
                for (var i = 0; i < romanNumeral.Length - 3; i++)
                {
                    if (romanNumeral[i] == romanNumeral[i + 1] && romanNumeral[i] == romanNumeral[i + 2]
                        && romanNumeral[i] == romanNumeral[i + 3])
                    {
                        return false;
                    }
                }
            }

            return IsInvalidRomanNumeralCharacter(romanNumeral);
        }

        bool IsInvalidRomanNumeralCharacter(string romanNumeral)
        {
            int numberOfCharactersChecked = 0;

            for (var i = 0; i < romanNumeral.Length; i++)
            {
                numberOfCharactersChecked +=
                    romanNumerals.Where((t, position) => romanNumeral[i] == romanNumerals.ElementAt(position).Key).Count();
            }

            return numberOfCharactersChecked == romanNumeral.Length;
        }
    }
}