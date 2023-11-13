using TextTolerator.Core.Rules;
using TextTolerator.Core.Rules.PhoneNumberRules;

namespace TextTolerator.Core.RulesProviders
{
    public class PhoneNumberPolisherRulesProvider : IRulesProvider
    {
        public IEnumerable<IRule> GetRules()
        {
            return new List<IRule>()
            {
                new PhoneNumberBracketsPolisherRule(),
                new PhoneNumberSeparatorPolisherRule(),
            };
        }
    }
}
