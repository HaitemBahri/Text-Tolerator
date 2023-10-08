using TextTolerator.Core.Results;
using TextTolerator.Core.RuleProviders;

namespace TextTolerator.Core.TextTolerators
{
    public class TextTolerator : ITextTolerator
    {
        private readonly IRuleProvider _textToleratorRuleProvider;

        public TextTolerator(IRuleProvider textToleratorRuleProvider)
        {
            _textToleratorRuleProvider = textToleratorRuleProvider;
        }

        public List<string> GetTextToleratorResult(string originalText)
        {
            var rules = _textToleratorRuleProvider.GetRules();

            var result = new List<string>();

            foreach(var rule in rules)
            {
                result.AddRange(rule.ProcessText(originalText));
            }

            return result;
        }
    }
}
