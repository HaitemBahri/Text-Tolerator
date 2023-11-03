using TextTolerator.Core.Results;
using TextTolerator.Core.RulesProviders;

namespace TextTolerator.Core.TextTolerators
{
    public class TextTolerator : ITextTolerator
    {
        private readonly IRulesProvider _textToleratorRuleProvider;

        public TextTolerator(IRulesProvider textToleratorRuleProvider)
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
