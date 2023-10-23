using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.EnglishRules
{
    public class EnglishINGReplacerRule : ReplacerRuleBase
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("ing", "in'", StringPosition.End),
            new ReplacerRuleValue("ING", "IN'", StringPosition.End),

            new ReplacerRuleValue("in'", "ing", StringPosition.End),
            new ReplacerRuleValue("IN'", "ING", StringPosition.End),
        };
    }
}
