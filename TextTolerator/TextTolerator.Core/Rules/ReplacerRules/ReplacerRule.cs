using TextTolerator.Core.Results;

namespace TextTolerator.Core.Rules.ReplacerRules;

public abstract class ReplacerRule : IRule
{
    protected abstract List<ReplacerRuleValue> ReplacerRuleValues { get; }

    public Result ProcessText(Result result)
    {
        string[] currentResults = result.GetResultArray();

        foreach (string currentResult in currentResults)
        {
            foreach (var ruleValue in ReplacerRuleValues)
            {
                string[] resultList = ProcessCurrentRule(ruleValue, currentResult);
                result.AddToResultList(resultList);
            }
        }

        return result;
    }

    private string[] ProcessCurrentRule(ReplacerRuleValue ruleValue, string input)
    {
        int[] replaceFromCharIndices = GetCharIndices(input, ruleValue.ReplaceFrom);

        List<int> replaceFromCharIndicesList = replaceFromCharIndices.ToList();

        if (!ruleValue.Position.IsStart())
        {
            replaceFromCharIndicesList.Remove(0);
        }

        if (!ruleValue.Position.IsMid())
        {
            replaceFromCharIndicesList.RemoveAll(x => x > 0 && x < input.Length - 1);
        }

        if (!ruleValue.Position.IsEnd())
        {
            replaceFromCharIndicesList.Remove(input.Length - 1);
        }

        replaceFromCharIndices = replaceFromCharIndicesList.ToArray();


        int numberOfResults = (int)Math.Pow(2, replaceFromCharIndices.Length);

        string[] initialResults = new string[numberOfResults];

        for (int i = 0; i < numberOfResults; i++)
        {
            string currentResult = new(input);

            for (int j = 0; j < replaceFromCharIndices.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    int currentIndex = replaceFromCharIndices[j];

                    currentResult = currentResult.Remove(currentIndex, 1)
                        .Insert(currentIndex, ruleValue.ReplaceBy.ToString());
                }
            }

            initialResults[i] = currentResult;
        }

        return initialResults;
    }

    private int[] GetCharIndices(string text, char replaceFrom)
    {
        List<int> indices = new();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == replaceFrom)
            {
                indices.Add(i);
            }
        }

        return indices.ToArray();
    }
}
