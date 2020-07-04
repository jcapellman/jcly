using System;
using System.Linq;

namespace jcly.lib.Helpers
{
    public static class KeyGenerator
    {
        private static readonly Random random = new Random();

        private const string KEY_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string Generate(int length = 8) =>
            new string(Enumerable.Repeat(KEY_CHARACTERS, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}