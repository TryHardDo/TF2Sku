using Sku.Enums;
using Sku.Models;
using TF2.Sku;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Starting unit test...");
        }

        [Test]
        public void TestFromString()
        {
            string testSku = "30743;5;u117";
            ItemElement item = TF2Sku.FromString(testSku);

            Assert.IsNotNull(item);
            Assert.That(item.Defindex, Is.EqualTo(30743));

            Assert.That(item.Quality, Is.EqualTo(EQuality.Unusual));
            Assert.That(item.Effect, Is.EqualTo(117));
        }

        [Test]
        public void TestToString()
        {
            ItemElement item = new ItemElement
            {
                Defindex = 123,
                Quality = EQuality.Unique,
                Killstreak = 3,
                Craftable = false
            };

            string sku = TF2Sku.FromObject(item);

            Assert.IsNotNull(sku);
            Assert.That(sku, Is.EqualTo("123;6;uncraftable;kt-3"));
        }
    }
}