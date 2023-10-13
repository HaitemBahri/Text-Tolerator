namespace TextTolerator.Core.Rules.ReplacerRules
{
    public class ArabicReplacerRule : ReplacerRuleBase
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues =>
            new List<ReplacerRuleValue>()
            {
                new ReplacerRuleValue("أ", "ا", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue("إ", "ا", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue("آ", "ا", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new ReplacerRuleValue("ؤ", "و", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue("ئ", "ي", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new ReplacerRuleValue("ض", "ظ", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue("ظ", "ض", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new ReplacerRuleValue("ذ", "د", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue("د", "ذ", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new ReplacerRuleValue("ت", "ث", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new ReplacerRuleValue("ث", "ت", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new ReplacerRuleValue("ة", "ه", CharPosition.End),
                new ReplacerRuleValue("ه", "ة", CharPosition.End),
                new ReplacerRuleValue("ى", "ي", CharPosition.End),
                new ReplacerRuleValue("ي", "ى", CharPosition.End),
            };
    }
}
