using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.ReplacerRules
{
    public class EnglishReplacerRule : ReplacerRuleBase
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue('s', 'z', CharPosition.Mid),
            new ReplacerRuleValue('z', 's', CharPosition.Mid),

            new ReplacerRuleValue('S', 'Z', CharPosition.Mid),
            new ReplacerRuleValue('Z', 'S', CharPosition.Mid),
        };
    }
}
