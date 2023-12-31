﻿using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.ArabicRules
{
    [ArabicRule]
    public class ArabicCommonLetterReplacerRule : IRule
    {
        protected List<ReplacerRuleValue> ReplacerRuleValues =>
            new List<ReplacerRuleValue>()
            {
                new ReplacerRuleValue("أ", "ا", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new ReplacerRuleValue("إ", "ا", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new ReplacerRuleValue("آ", "ا", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new ReplacerRuleValue("ؤ", "و", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new ReplacerRuleValue("ئ", "ي", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new ReplacerRuleValue("ة", "ه", StringPosition.End),
                new ReplacerRuleValue("ه", "ة", StringPosition.End),
                new ReplacerRuleValue("ى", "ي", StringPosition.End),
                new ReplacerRuleValue("ي", "ى", StringPosition.End),
            };

        public List<string> ProcessText(string inputText)
        {
            var replacerRuleBase = new ReplacerRuleBase();

            return replacerRuleBase.ProcessText(inputText, ReplacerRuleValues);
        }
    }
}
