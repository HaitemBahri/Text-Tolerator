﻿using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.EnglishRules
{
    [EnglishRule]
    public class EnglishContractionRule : IRule
    {
        protected List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("n't", " not", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue(" not ", "n't ", StringPosition.Mid | StringPosition.End),

            new ReplacerRuleValue("'s", " is", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue(" is ", "'s ", StringPosition.Mid | StringPosition.End),

            new ReplacerRuleValue("'ve", " have", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue(" have ", "'ve ", StringPosition.Mid | StringPosition.End),
        };

        protected List<ReplacerRuleValue> SpecialReplacerRuleValues => new()
        {
            new ReplacerRuleValue("cannot", "can't", StringPosition.Mid | StringPosition.End),
            new ReplacerRuleValue("can't", "cannot", StringPosition.Mid | StringPosition.End),
        };
        public List<string> ProcessText(string inputText)
        {
            var replacerRuleBase = new ReplacerRuleBase();

            if(SpecialReplacerRuleValues.Any(x => inputText.Contains(x.ReplaceFrom)))
            {
                return replacerRuleBase.ProcessText(inputText, SpecialReplacerRuleValues);
            }

            return replacerRuleBase.ProcessText(inputText, ReplacerRuleValues);
        }
    }
}
