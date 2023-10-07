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

        public Result GetTextToleratorResult(string originalText)
        {
            var rules = _textToleratorRuleProvider.GetRules();

            var result = new Result(originalText);

            foreach(var rule in rules)
            {
                rule.ProcessText(result);
            }

            return result;
        }
    }
}
