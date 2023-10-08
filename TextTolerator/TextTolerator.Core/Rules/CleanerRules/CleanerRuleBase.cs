namespace TextTolerator.Core.Rules.CleanerRules
{
    public abstract class CleanerRuleBase : IRule
    {
        protected abstract List<CleanerRuleValue> CleanerRuleValues { get; }

        public List<string> ProcessText(string inputText)
        {
            List<KeyValuePair<int, char>> mask = new();

            char placeHolder = '0';

            for (int i = 0; i < inputText.Length; i++)
            {
                foreach (var ruleValue in CleanerRuleValues)
                {
                    if (inputText[i] == ruleValue.ReplaceFrom)
                    {
                        if ((ruleValue.Position.IsStart() && i == 0) ||
                            (ruleValue.Position.IsMid() && (i > 0 && i < inputText.Length - 1)) ||
                            (ruleValue.Position.IsEnd() && i == inputText.Length - 1))
                        {
                            mask.Add(new KeyValuePair<int, char>(i, placeHolder));

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
                        int currentIndex = mask[j].Key;

                        currentResult = currentResult.Remove(currentIndex, 1);
                    }
                }

                initialResults.Add(currentResult);
            }

            return initialResults;
        }
    }
}
