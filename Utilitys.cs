using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Input;


namespace Utilitys
{
    public static class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
        public static int Between(int minimumValue = 0, int maximumValue = 100)
        {
            if (minimumValue == 0 && maximumValue == 0) { return 0; }
            byte[] randomNumbers = new byte[1];
            _generator.GetBytes(randomNumbers);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumbers[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            int range = (maximumValue - 1) - minimumValue;
            double randomValueInRange = Math.Floor(multiplier * range);
            return (int)(minimumValue + randomValueInRange);
        }
    }

    public static class Extensions
    {
        public static T pop<T>(this List<T> list, int index = -1)
        {
            if (list.Count == 0) { throw new InvalidOperationException("Cannot pop from an empty list"); }

            if (index == -1) { index = list.Count - 1; }

            T temp = list[index];
            list.RemoveAt(index);
            return temp;
        }

        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }
    }

    /*
    private static void NUMBERSONLY(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
    */
}
