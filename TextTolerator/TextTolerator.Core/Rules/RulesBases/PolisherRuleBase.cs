namespace TextTolerator.Core.Rules.RulesBases
{
    public class PolisherRuleBase
    {
        public List<string> ProcessText(string inputText, List<PolisherRuleValue> ruleValues)
        {
            string currentResult = new(inputText);

            foreach (var ruleValue in ruleValues)
            {
                string replaceFrom = ruleValue.ReplaceFrom;

                if (inputText.Contains(replaceFrom))
                {
                    currentResult = currentResult.Replace(replaceFrom, "");
                }
            }

            return new List<string>() { currentResult, inputText };
        }
    }
}
