using System.ComponentModel.DataAnnotations;
using TextTolerator.Core.Results;

namespace TextTolerator.Core.TextTolerators
{
    public interface ITextTolerator
    {
        public Result GetTextToleratorResult(string originalText);
    }
}
