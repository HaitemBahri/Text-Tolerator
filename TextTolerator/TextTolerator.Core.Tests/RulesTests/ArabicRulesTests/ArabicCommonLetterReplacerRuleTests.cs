using TextTolerator.Core.Rules.ArabicRules;

namespace TextTolerator.Core.Tests.RulesTests.ArabicRulesTests
{
    public class ArabicCommonLetterReplacerRuleTests
    {
        private ArabicCommonLetterReplacerRule _sut = new();

        public ArabicCommonLetterReplacerRuleTests()
        {

        }

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
    {
        {"أم", new List<string>(){ "أم", "ام" }, "(أ) - Start"},
        {"مأم", new List<string>(){ "مأم", "مام" }, "(أ) - Mid"},
        {"نمأ", new List<string>(){ "نما", "نمأ" }, "(أ) - End"},

        {"إنأم", new List<string>(){ "إنأم", "انأم", "إنام", "انام" }, "(أ) - Start, Mid"},
        {"أنمأ", new List<string>(){ "أنمأ", "انمأ", "أنما",  "انما" }, "(أ) - Start, End"},
        {"نأمأ", new List<string>(){ "نأمأ", "نامأ", "نأما",  "ناما" }, "(أ) - Mid, End"},

        {"أنإمأ", new List<string>(){ "أنإمأ",  "انإمأ", "أنامأ", "انامأ",  "أنإما", "انإما", "أناما",  "اناما" }, "(أ) -Start, Mid, End"},

        {"ىابس", new List<string>(){ "ىابس" }, "(ى) - Start"},
        {"حرىا", new List<string>(){ "حرىا" }, "(ى) - Mid"},
        {"بحرى", new List<string>(){ "بحرى", "بحري" }, "(ى) - End"},

        {"أمة", new List<string>(){ "أمة", "أمه", "امة", "امه",  }, "(أ) - Start (ة) - End"},
        {"مأمة", new List<string>(){ "مامه", "مأمه", "مامة", "مأمة"}, "(أ) - Mid (ة) - End"},
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
