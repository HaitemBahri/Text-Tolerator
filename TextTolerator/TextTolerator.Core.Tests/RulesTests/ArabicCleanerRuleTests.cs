using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Results;
using TextTolerator.Core.Rules.ReplacerRules;

namespace TextTolerator.Core.Tests.RulesTests
{
    public class ArabicCleanerRuleTests
    {
        private ArabicCleanerRule _sut = new();

        public ArabicCleanerRuleTests()
        {

        }

        public static TheoryData<string, string[], string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"بَاب", new string[]{ "بَاب", "باب" }, "(بَ) - Start"},
            {"باٌب", new string[]{ "باٌب", "باب" }, "(اٌ) - Mid"},
            {"ُباب", new string[]{ "ُباب", "باب" }, "(بُ) - End"},

            {"بَاَب", new string[]{ "بَاَب", "باَب" , "بَاب" , "باب" }, "() - Start, Mid"},
            {"بَابَ", new string[]{ "بَابَ", "بابَ" , "بَاب" , "باب" }, "() - Start, End"},
            {"باُبَ", new string[]{ "باُبَ", "بابَ", "باُب", "باب"}, "() - Mid, End"},

            {"بٌاَبُ", new string[]{  "بٌاَبُ", "باَبُ", "بٌابُ", "بٌاَب", "بابُ", "باَب", "بٌاب", "باب",}, "() - Start, Mid, End"},

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
}
