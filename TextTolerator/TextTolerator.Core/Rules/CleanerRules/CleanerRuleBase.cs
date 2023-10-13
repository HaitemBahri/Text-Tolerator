using TextTolerator.Core.Rules.ReplacerRules;

namespace TextTolerator.Core.Rules.CleanerRules
{
    public abstract class CleanerRuleBase : IRule
    {
        protected abstract List<CleanerRuleValue> CleanerRuleValues { get; }

        public List<string> ProcessText(string inputText)
        {
            SortedDictionary<int, string> mask = new();

            foreach (var ruleValue in CleanerRuleValues)
            {
                string replaceFrom = ruleValue.ReplaceFrom;

                if (inputText.Contains(replaceFrom))
                {
                    for (int index = 0; ; index += replaceFrom.Length)
                    {
                        index = inputText.IndexOf(replaceFrom, index, StringComparison.Ordinal);

                        if (index == -1)
                            break;

                        if ((ruleValue.Position.IsStart() && index == 0) ||
                            (ruleValue.Position.IsMid() && (index > 0 && index < inputText.Length - 1)) ||
                            (ruleValue.Position.IsEnd() && index == inputText.Length - 1))
                        {
                            mask.Add(index, replaceFrom);
                        }
                    }
                }
            }

            int numberOfCharsToBeReplaced = mask.Count;

            int numberOfResults = (int)Math.Pow(2, numberOfCharsToBeReplaced);

            List<string> initialResults = new();

            for (int i = 0; i < numberOfResults; i++)
            {
                string currentResult = new(inputText);

                for (int j = numberOfCharsToBeReplaced - 1; j >= 0; j--)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        int currentIndex = mask.ElementAt(j).Key;   

                        currentResult = currentResult.Remove(currentIndex, mask.ElementAt(j).Value.Length);
                    }
                }

                initialResults.Add(currentResult);
            }

            return initialResults;
        }
    }
}
