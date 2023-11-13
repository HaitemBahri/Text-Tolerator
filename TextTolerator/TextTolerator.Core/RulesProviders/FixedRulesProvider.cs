using TextTolerator.Core.Rules;

namespace TextTolerator.Core.RulesProviders
{
    public class FixedRulesProvider : IRulesProvider
    {
        private readonly List<IRule> _rules = new();

        public FixedRulesProvider(params IRule[] rules)
        {
            _rules = rules.ToList();
        }
        public IEnumerable<IRule> GetRules()
        {
            return _rules;
        }
    }
}
