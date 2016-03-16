using Lexm.Core.Extensions;
using NUnit.Framework;

namespace Lexm.Test
{
    [TestFixture]
    public class TransformerTest
    {
        [Test]
        public void ToGoogleSeachRequestTransform()
        {
            var str = "Купить AND (Вода OR Сок)";

            var query = str.ToGoogleSearchQuery();

            Assert.That(query == "Купить Вода | Сок");
        }

        [Test]
        public void ToYandexSeachRequestTransform()
        {
            var str = "Купить AND (Вода OR Сок)";

            var query = str.ToYandexSearchQuery();

            Assert.That(query == "Купить + (Вода | Сок)");
        }
    }
}
