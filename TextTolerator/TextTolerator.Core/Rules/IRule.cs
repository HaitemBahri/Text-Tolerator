using TextTolerator.Core.Results;

namespace TextTolerator.Core.Rules
{
    public interface IRule
    {
        Result ProcessText(Result result);
    }
}
