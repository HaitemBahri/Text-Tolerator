namespace TextTolerator.Core.Rules.RulesBases
{
    public class CleanerTogglerRuleBase
    {
        public List<string> ProcessText(string inputText, List<CleanerTogglerRuleValue> ruleValues)
        {
            List<string> initialResults = new() { inputText };

            foreach (var ruleValue in ruleValues)
            {
                string replaceFrom = ruleValue.ReplaceFrom;

                var initialResultsCopy = new List<string>(initialResults);

                foreach (var result in initialResultsCopy)
                {
                    if (ruleValue.Position.IsStart() && result.StartsWith(replaceFrom) ||
                        ruleValue.Position.IsEnd() && result.EndsWith(replaceFrom))
                    {
                        var newResult = result.Replace(replaceFrom, "");

                        initialResults.Add(newResult);
                    }

                    else if (ruleValue.Position.IsStart() && !result.StartsWith(replaceFrom))
                    {
                        var newResult = result.Insert(0, replaceFrom);

                        initialResults.Add(newResult);
                    }

                    else if (ruleValue.Position.IsEnd() && !result.EndsWith(replaceFrom))
                    {
                        var newResult = result.Insert(result.Length - 1, replaceFrom);

                        initialResults.Add(newResult);
                    }
                }
            }

            return initialResults;
        }

    }
}
