using System.Collections.Immutable;
using TextTolerator.Core.Results;
using TextTolerator.Core.RulesProviders;

namespace TextTolerator.Core.TextToleratorEngines
{
    public class TextToleratorEngine : ITextToleratorEngine
    {
        private readonly IRulesProvider _textToleratorRuleProvider;

        public TextToleratorEngine(IRulesProvider textToleratorRuleProvider)
        {
            _textToleratorRuleProvider = textToleratorRuleProvider;
        }

        public List<string> GetTextToleratorResult(string originalText)
        {
            var results = new List<string>() { originalText };

            var rules = _textToleratorRuleProvider.GetRules();

            foreach (var rule in rules)
            {
                foreach (var result in results.ToImmutableArray())
                {
                    var currentResults = rule.ProcessText(result);

                    foreach (var currentResult in currentResults)
                    {
                        if(!results.Contains(currentResult))
                        {
                            results.Add(currentResult);
                        }
                    }
                }
            }

            return results;
        }
    }
}
