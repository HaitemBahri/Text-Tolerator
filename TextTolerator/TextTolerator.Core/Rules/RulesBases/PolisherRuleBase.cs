using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.RulesBases
{
    public abstract class PolisherRuleBase : IRule
    {
        protected abstract List<PolisherRuleValue> PolisherRuleValues { get; }

        public List<string> ProcessText(string inputText)
        {
            string currentResult = new(inputText);

            foreach (var ruleValue in PolisherRuleValues)
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
