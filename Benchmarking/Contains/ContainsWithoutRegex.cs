using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Benchmarking
{
    public class ContainsRegex
    {
        public bool VersionWithRegex(string strToFind, string input)
        {
            var regex = new Regex($".*({strToFind})[/.].*", RegexOptions.IgnoreCase);
            return regex.Match(input).Success;
        }

        public bool VersionWithIndex(string strToFind, string input)
        {
            return
                input.IndexOf($"{strToFind}/", StringComparison.InvariantCultureIgnoreCase) != -1 ||
                input.IndexOf($"{strToFind}.", StringComparison.InvariantCultureIgnoreCase) != -1;
        }

        public bool VersionWithoutRegex(string strToFind, string input)
            => Contains(input, strToFind, '.') || Contains(input,  strToFind, '/');

        private bool Contains(string input, string strToFind, char suffix)
        {
            var limit = input.Length - (strToFind.Length + 1);
            var c0 = char.ToUpperInvariant(strToFind[0]);

            for (int i = 0; i <= limit; i++)
            {
                if (char.ToUpperInvariant(input[i]) == c0)
                {
                    bool success = true;

                    for (int j = 1; j < strToFind.Length; j++)
                    {
                        if (char.ToUpperInvariant(input[i + j]) != char.ToUpperInvariant(strToFind[j]))
                        {
                            success = false;
                            break;
                        }
                    }

                    if (success && char.ToUpperInvariant(input[i + strToFind.Length]) == char.ToUpperInvariant(suffix))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
