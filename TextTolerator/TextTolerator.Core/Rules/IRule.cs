using TextTolerator.Core.Results;

namespace TextTolerator.Core.Rules
{
    public interface IRule
    {
        List<string> ProcessText(string inputText);
    }
}
