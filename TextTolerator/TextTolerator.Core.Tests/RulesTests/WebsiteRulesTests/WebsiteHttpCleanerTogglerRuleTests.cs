using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.WebsiteRules;

namespace TextTolerator.Core.Tests.RulesTests.WebsiteRulesTests
{
    public class WebsiteHttpCleanerTogglerRuleTests
    {
        private WebsiteHttpCleanerTogglerRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"https://www.google.com", new List<string>(){ "https://www.google.com", "www.google.com" }, ""},
            {"google.com", new List<string>(){ "google.com", "https://google.com"}, ""},

            {"https://www.google.com/maps", new List<string>(){ "https://www.google.com/maps", "www.google.com/maps" }, ""},
            {"google.com/maps", new List<string>(){ "google.com/maps", "https://google.com/maps"}, ""},

            {"HTTPS://WWW.GOOGLE.COM", new List<string>(){ "HTTPS://WWW.GOOGLE.COM", "WWW.GOOGLE.COM" }, ""},
            {"GOOGLE.COM/MAPS", new List<string>(){ "GOOGLE.COM/MAPS", "HTTPS://GOOGLE.COM/MAPS"}, ""},

            {"GOOGLE/MAPSقوقل", new List<string>(){ "GOOGLE/MAPSقوقل"}, ""},
            {"GOOGLE.COM MAPS", new List<string>(){ "GOOGLE.COM MAPS",}, ""},
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
