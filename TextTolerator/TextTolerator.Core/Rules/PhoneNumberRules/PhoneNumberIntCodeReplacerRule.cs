using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.PhoneNumberRules
{
    public class PhoneNumberIntCodeReplacerRule : ReplacerRuleBase
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("+", "00", StringPosition.Start),
            new ReplacerRuleValue("00", "+", StringPosition.Start),
        };
    }
}
