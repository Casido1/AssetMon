namespace AssetMon.Commons.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime dob)
        {
            var today = DateTime.UtcNow.Date;

            var age = today.Year - dob.Year;

            if (dob > today.AddYears(-age)) age--;

            return age;
        }
    }
}
