namespace TextTolerator.Core.Rules.ReplacerRules;

public abstract class ReplacerRuleBase : IRule
{
    protected abstract List<ReplacerRuleValue> ReplacerRuleValues { get; }

    public List<string> ProcessText(string inputText)
    {
        List<KeyValuePair<int, char>> mask = new();

        for (int i = 0; i < inputText.Length; i++)
        {
            foreach (var ruleValue in ReplacerRuleValues)
            {
                if (inputText[i] == ruleValue.ReplaceFrom)
                {
                    if ((ruleValue.Position.IsStart() && i == 0) ||
                        (ruleValue.Position.IsMid() && (i > 0 && i < inputText.Length - 1)) ||
                        (ruleValue.Position.IsEnd() && i == inputText.Length - 1))
                    {
                        mask.Add(new KeyValuePair<int, char>(i, ruleValue.ReplaceBy));

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

            for (int j = 0; j < numberOfCharsToBeReplaced; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    int currentIndex = mask[j].Key;

                    currentResult = currentResult.Remove(currentIndex, 1)
                        .Insert(currentIndex, mask[j].Value.ToString());
                }
            }

            initialResults.Add(currentResult);
        }

        return initialResults;
    }
}
