using TextTolerator.Core.Results;
using TextTolerator.Core.Rules.ReplacerRules;

namespace TextTolerator.Core.Tests.RulesTests;

public class ArabicReplacerRuleTests
{
    private ArabicReplacerRule _sut = new();

    public ArabicReplacerRuleTests()
    {

    }

    public static TheoryData<string, string[], string> ShouldReturnCorrectResultTheoryData => new()
    {
        {"أم", new string[]{ "أم", "ام" }, "(أ) - Start"},
        {"مأم", new string[]{ "مأم", "مام" }, "(أ) - Mid"},
        {"تمأ", new string[]{ "تمأ", "تما" }, "(أ) - End"},

        {"إتأم", new string[]{ "إتأم", "اتأم", "إتام", "اتام" }, "(أ) - Start, Mid"},
        {"أتمأ", new string[]{ "أتمأ", "اتمأ", "أتما",  "اتما" }, "(أ) - Start, End"},
        {"تأمأ", new string[]{ "تأمأ", "تامأ", "تأما",  "تاما" }, "(أ) - Mid, End"},

        {"أتإمأ", new string[]{ "أتإمأ",  "اتإمأ", "أتامأ", "اتامأ",  "أتإما", "اتإما", "أتاما",  "اتاما" }, "(أ) -Start, Mid, End"},

        {"ىابس", new string[]{ "ىابس" }, "(ى) - Start"},
        {"حرىا", new string[]{ "حرىا" }, "(ى) - Mid"},
        {"بحرى", new string[]{ "بحرى", "بحري" }, "(ى) - End"},


    };

    [Theory]
    [MemberData(nameof(ShouldReturnCorrectResultTheoryData))]
    public void ShouldReturnCorrectResult(string input, string[] expectedResult, string testDataName)
    {
        var result = new Result(input);

        _sut.ProcessText(result);

        var actualResult = result.GetResultArray().ToArray();

        Assert.Equal(expectedResult, actualResult);
    }

}
