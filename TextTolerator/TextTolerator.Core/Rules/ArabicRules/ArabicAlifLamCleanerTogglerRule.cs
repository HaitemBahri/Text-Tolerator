using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.ArabicRules
{
    public class ArabicAlifLamCleanerTogglerRule : CleanerTogglerRuleBase
    {
        protected override List<CleanerTogglerRuleValue> CleanerTogglerRuleValues => new()
        {
            new CleanerTogglerRuleValue("ال", StringPosition.Start),
        };
    }
}
