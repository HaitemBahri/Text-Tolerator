using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.PhoneNumberRules
{
    public class PhoneNumberSeparatorCleanerRule : CleanerRuleBase
    {
        protected override List<CleanerRuleValue> CleanerRuleValues => new()
        {
            new CleanerRuleValue(" ", StringPosition.Start | StringPosition.Mid | StringPosition.End ),
            new CleanerRuleValue("-", StringPosition.Start | StringPosition.Mid | StringPosition.End ),
        };
    }
}
