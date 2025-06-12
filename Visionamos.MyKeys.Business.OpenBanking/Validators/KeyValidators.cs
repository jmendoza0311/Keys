using System.Globalization;

namespace Visionamos.MyKeys.Business.OpenBanking.Validators
{
    public static class KeyValidators
    {
        public static bool IsValidDate(string date) =>
            date.Length == 8 && date.All(char.IsDigit) &&
            DateTime.TryParseExact(date, "yyyyMMdd", null, DateTimeStyles.None, out _);

        public static bool IsValidTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time) || time.Length != 6 || !time.All(char.IsDigit))
                return false;
            try
            {
                var hour = int.Parse(time[..2]);
                var minute = int.Parse(time.Substring(2, 2));
                var second = int.Parse(time.Substring(4, 2));
                return hour is >= 0 and <= 23 && minute is >= 0 and <= 59 && second is >= 0 and <= 59;
            }
            catch 
            {
                return false;
            }
        }
        public static bool IsValidSequence(string sequence) =>
            sequence.Length == 16 && sequence.All(char.IsDigit);
    }
}
