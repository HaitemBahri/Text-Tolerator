using TextTolerator.Core.Rules;

namespace TextTolerator.Core.RuleProviders
{
    public interface IRuleProvider
    {
        IEnumerable<IRule> GetRules();
    }
}
