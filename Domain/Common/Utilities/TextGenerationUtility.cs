using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Mechanic.Domain.Common.Utilities
{

    public class TextGenerationUtility
    {
        private static int DEFAULT_MIN_PASSWORD_LENGTH = 6;
        private static int DEFAULT_MAX_PASSWORD_LENGTH = 10;

        private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnpqrstwxyz";



        public static string GenerateRandomDigits(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than zero.", nameof(length));
            }

            var random = new Random();
            var passwordBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                passwordBuilder.Append(random.Next(0, 10));
            }

            return passwordBuilder.ToString();
        }
        public static string GenerateRandomPassword(PasswordOptions opts)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789",                   // digits
                "!@$?_-"                        // non-alphanumeric
            };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
    } 

}

