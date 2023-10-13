using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.CleanerRules
{
    public class EnglishCleanerRule : CleanerRuleBase
    {
        protected override List<CleanerRuleValue> CleanerRuleValues => new()
        {
            new CleanerRuleValue("\'", CharPosition.Mid | CharPosition.End),

            new CleanerRuleValue("g", CharPosition.End),
            new CleanerRuleValue("G", CharPosition.End),
        };
    }
}
