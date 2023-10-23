using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.PhoneNumberRules
{
    public class PhoneNumberBracketsPolisherRule : PolisherRuleBase
    {
        protected override List<PolisherRuleValue> PolisherRuleValues => new() 
        {
            new PolisherRuleValue("(", StringPosition.Start | StringPosition.Mid | StringPosition.End),
            new PolisherRuleValue(")", StringPosition.Start | StringPosition.Mid | StringPosition.End),
        };
    }
}
