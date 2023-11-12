namespace DiyorMarket.Extensions
{
    public static class StringExtensions
    {
        public static int CountVowel(this string str)
        {
            int count = 0;

            foreach (char c in str)
            {
                if (c == 'a' || c == 'o' || c == 'u')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
