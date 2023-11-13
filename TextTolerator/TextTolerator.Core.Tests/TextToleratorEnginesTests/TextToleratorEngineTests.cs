using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.ArabicRules;
using TextTolerator.Core.RulesProviders;
using TextTolerator.Core.TextToleratorEngines;

namespace TextTolerator.Core.Tests.TextToleratorEnginesTests
{
    public class TextToleratorEngineTests
    {
        private TextToleratorEngine _sut;

        public static TheoryData<IRulesProvider, string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {new GenericRulesProvider<PhoneNumberRuleAttribute>() ,"+449738 88514", 
                new List<string>(){ "+449738 88514", "00449738 88514", "+44973888514", "0044973888514" }, 
                "Generic Rules for PhoneNumbers"},

            {new GenericRulesProvider<PhoneNumberRuleAttribute>() ,"+44(97)38 88514",
                new List<string>(){ "+449738 88514", "00449738 88514", "+44973888514", "0044973888514",
                                    "+44(97)38 88514", "0044(97)38 88514", "+44(97)3888514", "0044(97)3888514" },
                "Generic Rules for PhoneNumbers"},

            {new GenericRulesProvider<ArabicRuleAttribute>() ,"القلْعَة",
                new List<string>(){ "القلْعَه", "القلْعَة", "القلعه", "القلعة", "قلْعَه", "قلْعَة", "قلعه", "قلعة"}, 
                "Generic Rules for Arabic Text"},

            {new FixedRulesProvider(new ArabicAccentPolisherRule()) ,"القُـرْآنُ الكَرِيـمْ",
                new List<string>(){ "القُـرْآنُ الكَرِيـمْ", "القرآن الكريم"},
                "Polisher Rules for Arabic Text"},

            {new GenericRulesProvider<EnglishRuleAttribute>() ,"subsidise",
                new List<string>(){ "subsidize", "subsidise", "SUBSIDIZE", "SUBSIDISE", "Subsidize", "Subsidise", },
                "Generic Rules for English Text"},

            {new FixedRulesProvider(new ArabicCommonLetterReplacerRule(), new ArabicAlifLamCleanerTogglerRule()) ,"الإقْلاعي",
                new List<string>(){ "الإقْلاعي", "الإقْلاعى", "الاقْلاعي", "الاقْلاعى", "إقْلاعي", "إقْلاعى", "اقْلاعي", "اقْلاعى", },
                "Generic Rules for English Text"},

            {new GenericRulesProvider<WebsiteRuleAttribute>() ,"google.com",
                new List<string>(){ "google.com", "Google.com", "GOOGLE.COM",
                                    "https://google.com", "Https://google.com", "HTTPS://GOOGLE.COM",
                                    "www.google.com", "Www.google.com", "WWW.GOOGLE.COM", 
                                    "https://www.google.com", "Https://www.google.com", "HTTPS://WWW.GOOGLE.COM", },
                "Generic Rules for Website"},

        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectResultTheoryData))]
        public void ShouldReturnCorrectResult(IRulesProvider rulesProvider ,string input, List<string> expectedResult, string testDataName)
        {
            _sut = new TextToleratorEngine(rulesProvider);

            var actualResult = _sut.GetTextToleratorResult(input);

            expectedResult.Sort();
            actualResult.Sort();

            Assert.Equal(expectedResult, actualResult);
        }

    }
}
