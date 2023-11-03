using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules;
using TextTolerator.Core.Rules.ArabicRules;
using TextTolerator.Core.Rules.PhoneNumberRules;

namespace TextTolerator.Core.RulesProviders
{
    public class PolisherRulesProvider : IRulesProvider
    {
        public IEnumerable<IRule> GetRules()
        {
            return new List<IRule>()
            {
                new ArabicAccentPolisherRule(),
                new PhoneNumberBracketsPolisherRule(),
                new PhoneNumberSeparatorPolisherRule(),
            };
        }
    }
}
