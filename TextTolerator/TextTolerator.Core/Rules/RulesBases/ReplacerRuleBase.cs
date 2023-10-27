namespace TextTolerator.Core.Rules.RulesBases;

public class ReplacerRuleBase
{
    public List<string> ProcessText(string inputText, List<ReplacerRuleValue> ruleValues)
    {
        SortedDictionary<int, KeyValuePair<string, string>> mask = new();

        foreach (var ruleValue in ruleValues)
        {
            string replaceFrom = ruleValue.ReplaceFrom;
            string replaceBy = ruleValue.ReplaceBy;

            if (inputText.Contains(replaceFrom))
            {
                for (int index = 0; ; index += replaceFrom.Length)
                {
                    index = inputText.IndexOf(replaceFrom, index, StringComparison.Ordinal);

                    if (index == -1)
                        break;

                    if (ruleValue.Position.IsStart() && index == 0 ||
                        ruleValue.Position.IsMid() && index > 0 && index < inputText.Length - 1 ||
                        ruleValue.Position.IsEnd() && index == inputText.Length - replaceFrom.Length)
                    {
                        mask.Add(index, new KeyValuePair<string, string>(replaceFrom, replaceBy));
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
                if ((i >> j & 1) == 1)
                {
                    int currentIndex = mask.ElementAt(j).Key;

                    currentResult = currentResult.Remove(currentIndex, mask.ElementAt(j).Value.Key.Length)
                        .Insert(currentIndex, mask.ElementAt(j).Value.Value.ToString());
                }
            }

            initialResults.Add(currentResult);
        }

        return initialResults;
    }


}
