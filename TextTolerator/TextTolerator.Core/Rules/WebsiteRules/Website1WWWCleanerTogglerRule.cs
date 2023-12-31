﻿using TextTolerator.Core.Attributes;

namespace TextTolerator.Core.Rules.WebsiteRules
{
    [WebsiteRule]
    public class Website1WWWCleanerTogglerRule : IRule
    {
        private readonly string wwwTextLower = "www.";
        private readonly string WWWTextUpper = "WWW.";

        public List<string> ProcessText(string inputText)
        {
            List<string> result = new List<string>() { inputText };

            if (!IsWebsite(inputText))
            {
                return result;
            }

            if (inputText.StartsWith(wwwTextLower, StringComparison.InvariantCultureIgnoreCase))
            {
                string newResult = inputText.Remove(0, wwwTextLower.Length);
                result.Add(newResult);

            }
            else
            {
                string www = GetCorrectWWW(inputText);
                string newResult = String.Concat(www, inputText);

                result.Add(newResult);
            }

            return result;
        }

        private string GetCorrectWWW(string inputText)
        {
            if (inputText.All(c => char.IsUpper(c) || !char.IsLetter(c)))
            {
                return WWWTextUpper;
            }

            return wwwTextLower;
        }

        private bool IsWebsite(string inputText)
        {
            return Uri.IsWellFormedUriString(inputText, UriKind.RelativeOrAbsolute);

        }
    }
}
