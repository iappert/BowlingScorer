namespace CodingDojo.Test
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class BowlingScorerTest
    {
        private BowlingScorer testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new BowlingScorer();
        }

        [Test]
        public void Foo()
        {
            this.testee.Should().NotBeNull();
        }
    }
}