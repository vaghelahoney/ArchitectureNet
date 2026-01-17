using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuiteRx.Interface.Persistance.Extension
{
    public static class PasswordHelper
    {
        private const string LowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NumericChars = "0123456789";
        private const string SpecialChars = "!@#$%^&*()_-+=[{]};:<>|./?";
        private const string AllChars = LowerCaseChars + UpperCaseChars + NumericChars + SpecialChars;

        public static string PasswordGenerator(int length = 12)
        {

            if (length < 1)
                throw new ArgumentException("Password length must be positive.", nameof(length));

            // Use a cryptographically secure random number generator
            using (var rng = RandomNumberGenerator.Create())
            {
                var password = new StringBuilder();
                var data = new byte[length];
                rng.GetBytes(data); // Fill the byte array with random data

                for (int i = 0; i < length; i++)
                {
                    // Use the random byte to select a character from the character pool
                    // The modulo operation ensures the index is within the bounds of the string length
                    password.Append(AllChars[data[i] % AllChars.Length]);
                }

                // Optional: Shuffle the password to ensure characters aren't in a predictable order (e.g., all lowercase first)
                return new string(password.ToString().OrderBy(s => Guid.NewGuid()).ToArray());
            }
        }

    }
}
