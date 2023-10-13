using TextTolerator.Core.Rules.CleanerRules;

namespace TextTolerator.Core.Tests.RulesTests
{
    public class ArabicCleanerRuleTests
    {
        private ArabicCleanerRule _sut = new();

        public ArabicCleanerRuleTests()
        {

        }

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"بَاب", new List<string>(){ "بَاب", "باب" }, "(بَ) - Start"},
            {"باٌب", new List<string>(){ "باٌب", "باب" }, "(اٌ) - Mid"},
            {"بابُ", new List<string>(){ "بابُ", "باب" }, "(بُ) - End"},

            {"بَاَب", new List<string>(){ "بَاَب", "باَب" , "بَاب" , "باب" }, "() - Start, Mid"},
            {"بَابَ", new List<string>(){ "بَابَ", "بابَ" , "بَاب" , "باب" }, "() - Start, End"},
            {"باُبَ", new List<string>(){ "باُبَ", "بابَ", "باُب", "باب"}, "() - Mid, End"},

            {"بٌاَبُ", new List<string>(){ "بٌاَبُ", "باَبُ", "بٌابُ", "بٌاَب", "بابُ", "باَب", "بٌاب", "باب",}, "() - Start, Mid, End"},

            {"بَـاَبُ", new List<string>(){ "بَـاَبُ", "بـاَبُ", "بَاَبُ", "بَـابُ", "بَـاَب", "باَبُ", "بـابُ", "بـاَب",
                                         "بَابُ", "بَاَب", "بَـاب", "بابُ", "باَب", "بَاب", "بـاب", "باب", }, "() - Start, Mid, Mid, End"},
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectResultTheoryData))]
        public void ShouldReturnCorrectResult(string input, List<string> expectedResult, string testDataName)
        {
            var actualResult = _sut.ProcessText(input);

            expectedResult.Sort();
            actualResult.Sort();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
