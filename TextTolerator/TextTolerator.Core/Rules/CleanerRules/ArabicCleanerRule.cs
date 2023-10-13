namespace TextTolerator.Core.Rules.CleanerRules
{
    public class ArabicCleanerRule : CleanerRuleBase
    {
        protected override List<CleanerRuleValue> CleanerRuleValues =>
            new List<CleanerRuleValue>()
            {
                new CleanerRuleValue("َ", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue("ً", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new CleanerRuleValue("ُ", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue("ٌ", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new CleanerRuleValue("ِ", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue("ٍ", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new CleanerRuleValue("ّ", CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue("ْ", CharPosition.Start | CharPosition.Mid | CharPosition.End),

                new CleanerRuleValue("ـ", CharPosition.Start | CharPosition.Mid | CharPosition.End),

            };
    }
}
