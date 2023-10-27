namespace TextTolerator.Core.Rules.WebsiteRules
{
    public class WebsiteHttpCleanerTogglerRule : IRule
    {
        private readonly string HttpTextLower = "https://";
        private readonly string HttpTextUpper = "HTTPS://";

        public List<string> ProcessText(string inputText)
        {
            List<string> result = new List<string>() { inputText };

            if (!IsWebsite(inputText))
            {
                return result;
            }

            if (inputText.StartsWith(HttpTextLower, StringComparison.InvariantCultureIgnoreCase))
            {
                string newResult = inputText.Remove(0, HttpTextLower.Length);
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
                return HttpTextUpper;
            }

            return HttpTextLower;
        }

        private bool IsWebsite(string inputText)
        {
            return Uri.IsWellFormedUriString(inputText, UriKind.RelativeOrAbsolute);

        }
    }
}
