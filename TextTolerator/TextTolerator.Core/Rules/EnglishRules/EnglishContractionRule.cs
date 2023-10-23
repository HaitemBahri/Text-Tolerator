using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.EnglishRules
{
    public class EnglishContractionRule : ReplacerRuleBase
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("n't", " not", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue(" not ", "n't ", StringPosition.Mid | StringPosition.End),

            new ReplacerRuleValue("'s", " is", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue(" is ", "'s ", StringPosition.Mid | StringPosition.End),

            new ReplacerRuleValue("'ve", " have", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue(" have ", "'ve ", StringPosition.Mid | StringPosition.End),
        };
    }
}
