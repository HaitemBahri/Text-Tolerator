using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.EnglishRules
{
    public class EnglishSZReplacerRule : ReplacerRuleBase
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("ise", "ize", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue("ize", "ise", StringPosition.Mid | StringPosition.End),

            new ReplacerRuleValue("yse", "yze", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue("yze", "yse", StringPosition.Mid | StringPosition.End),

            new ReplacerRuleValue("ISE", "IZE", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue("IZE", "ISE", StringPosition.Mid | StringPosition.End),

            new ReplacerRuleValue("YSE", "YZE", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue("YZE", "YSE", StringPosition.Mid | StringPosition.End),
        };
    }
}
