using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.CleanerRules
{
    public class PhoneNumberCleanerRule : CleanerRuleBase
    {
        protected override List<CleanerRuleValue> CleanerRuleValues => new()
        {
            new CleanerRuleValue("(", CharPosition.Start | CharPosition.Mid | CharPosition.End ),
            new CleanerRuleValue(")", CharPosition.Start | CharPosition.Mid | CharPosition.End ),
            new CleanerRuleValue("-", CharPosition.Start | CharPosition.Mid | CharPosition.End ),
            new CleanerRuleValue(" ", CharPosition.Start | CharPosition.Mid | CharPosition.End ),
        };
    }
}
