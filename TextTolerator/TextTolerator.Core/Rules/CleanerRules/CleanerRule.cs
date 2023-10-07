using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Results;
using TextTolerator.Core.Rules.ReplacerRules;

namespace TextTolerator.Core.Rules.CleanerRules
{
    public abstract class CleanerRule : IRule
    {
        protected abstract List<CleanerRuleValue> CleanerRuleValues { get; }

        public Result ProcessText(Result result)
        {
            string[] currentResults = result.GetResultArray();

            foreach (string currentResult in currentResults)
            {
                foreach (var ruleValue in CleanerRuleValues)
                {
                    string[] resultList = ProcessCurrentRule(ruleValue, currentResult);
                    result.AddToResultList(resultList);
                }
            }

            return result;
        }

        private string[] ProcessCurrentRule(CleanerRuleValue ruleValue, string input)
        {
            var cc = input.ToCharArray();

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
                            .Insert(currentIndex, '\0'.ToString());

                        //UpdateIndicesAfterRemoval(replaceFromCharIndices);
                        //replaceFromCharIndices.Where()
                        //TODO update indices after removing a char
                    }
                }

                initialResults[i] = currentResult.Replace("\0", "");
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

        private void UpdateIndicesAfterRemoval(int[] indices)
        {
            for(int i = 0; i < indices.Length; i++)
            {
                indices[i] -= 1;
            }
        }
    }
}
