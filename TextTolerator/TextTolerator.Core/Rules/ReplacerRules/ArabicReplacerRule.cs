using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Attributes;
using TextTolerator.Core.Results;

namespace TextTolerator.Core.Rules.ReplacerRules
{
    public class ArabicReplacerRule : ReplacerRule
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues =>
            new List<ReplacerRuleValue>()
            {
                new ReplacerRuleValue('أ', 'ا', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue('إ', 'ا', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue('آ', 'ا', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue('ؤ', 'و', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue('ئ', 'ي', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                
                new ReplacerRuleValue('ة', 'ه', CharPosition.End),
                new ReplacerRuleValue('ه', 'ة', CharPosition.End),
                new ReplacerRuleValue('ى', 'ي', CharPosition.End),
                new ReplacerRuleValue('ي', 'ى', CharPosition.End),


            };
    }
}
