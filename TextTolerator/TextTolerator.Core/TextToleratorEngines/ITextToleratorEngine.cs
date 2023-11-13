using System.ComponentModel.DataAnnotations;
using TextTolerator.Core.Results;

namespace TextTolerator.Core.TextToleratorEngines
{
    public interface ITextToleratorEngine
    {
        public List<string> GetTextToleratorResult(string originalText);
    }
}
