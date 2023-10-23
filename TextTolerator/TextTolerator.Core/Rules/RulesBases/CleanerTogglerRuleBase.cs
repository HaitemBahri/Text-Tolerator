using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.RulesBases
{
    public abstract class CleanerTogglerRuleBase : IRule
    {
        protected abstract List<CleanerTogglerRuleValue> CleanerTogglerRuleValues { get; }

        public List<string> ProcessText(string inputText)
        {
            List<string> initialResults = new() { inputText };

            foreach (var ruleValue in CleanerTogglerRuleValues)
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
