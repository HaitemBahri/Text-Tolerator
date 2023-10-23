using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.ArabicRules
{
    public class ArabicAccentPolisherRule : PolisherRuleBase
    {
        protected override List<PolisherRuleValue> PolisherRuleValues => new List<PolisherRuleValue>()
        {
                new PolisherRuleValue("َ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ً", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ُ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ٌ", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ِ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ٍ", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ّ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ْ", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ـ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
        };
    }
}
