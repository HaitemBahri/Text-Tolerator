using TextTolerator.Core.Rules;

namespace TextTolerator.Core.RulesProviders
{
    public interface IRulesProvider
    {
        IEnumerable<IRule> GetRules();
    }
}
