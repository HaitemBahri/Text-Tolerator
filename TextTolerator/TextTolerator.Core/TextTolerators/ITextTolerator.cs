using System.ComponentModel.DataAnnotations;
using TextTolerator.Core.Results;

namespace TextTolerator.Core.TextTolerators
{
    public interface ITextTolerator
    {
        public List<string> GetTextToleratorResult(string originalText);
    }
}
