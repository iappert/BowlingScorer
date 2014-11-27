namespace CodingDojo.Specification
{
    using FluentAssertions;

    using Machine.Specifications;

    [Subject("BowlingScorer")]
    public class When_bowling_without_bonuses
    {
        static BowlingScorer bowlingScorer;
        static int score;
        static BowlingSimulator bowlingSimulator;
        static int expected;

        Establish context = () =>
        {
            bowlingScorer = new BowlingScorer();

            bowlingSimulator = BowlingSimulator
                .Create()
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(7)
                        .AddRoll(4)
                        .AddRoll(3)
                    .WithFrame(4)
                        .AddRoll(2)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(9)
                        .AddRoll(6)
                        .AddRoll(3)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(8)
                        .AddRoll(0)
                    .WithFrame(9)
                        .AddRoll(8)
                        .AddRoll(1)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(7)
                        .AddRoll(1)
                .Play(bowlingScorer);

            expected = bowlingSimulator.BuildSummedScore();
        };

        Because of = () => score = bowlingScorer.GetScore();

        It should_return_score = () => 
            score.Should().Be(expected);
    }

    [Subject("BowlingScorer")]
    public class When_bowling_with_spare_bonus
    {
        static BowlingScorer bowlingScorer;
        static int score;
        static BowlingSimulator bowlingSimulator;
        static int expected;

        Establish context = () =>
        {
            bowlingScorer = new BowlingScorer();

            bowlingSimulator = BowlingSimulator
                .Create()
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(7)
                        .AddRoll(4)
                        .AddRoll(3)
                    .WithFrame(4)
                        .AddRoll(2)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(9)
                        .AddRoll(6)
                        .AddRoll(3)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(18)
                        .AddRoll(8)
                        .AddRoll(2)
                    .WithFrame(9)
                        .AddRoll(8)
                        .AddRoll(1)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(7)
                        .AddRoll(1)
                .Play(bowlingScorer);

            expected = bowlingSimulator.BuildSummedScore();
        };

        Because of = () => score = bowlingScorer.GetScore();

        It should_return_score = () => 
            score.Should().Be(expected);
    }

    [Subject("BowlingScorer")]
    public class When_bowling_with_strike_bonus
    {
        static BowlingScorer bowlingScorer;
        static int score;
        static BowlingSimulator bowlingSimulator;
        static int expected;

        Establish context = () =>
        {
            bowlingScorer = new BowlingScorer();

            bowlingSimulator = BowlingSimulator
                .Create()
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(7)
                        .AddRoll(4)
                        .AddRoll(3)
                    .WithFrame(4)
                        .AddRoll(2)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(9)
                        .AddRoll(6)
                        .AddRoll(3)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(19)
                        .AddRoll(10)
                    .WithFrame(9)
                        .AddRoll(8)
                        .AddRoll(1)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(7)
                        .AddRoll(1)
                .Play(bowlingScorer);

            expected = bowlingSimulator.BuildSummedScore();
        };

        Because of = () => score = bowlingScorer.GetScore();

        It should_return_score = () => 
            score.Should().Be(expected);
    }

    [Subject("BowlingScorer")]
    public class When_bowling_with_strike_bonus_in_tenth_game
    {
        static BowlingScorer bowlingScorer;
        static int score;
        static BowlingSimulator bowlingSimulator;
        static int expected;

        Establish context = () =>
        {
            bowlingScorer = new BowlingScorer();

            bowlingSimulator = BowlingSimulator
                .Create()
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(7)
                        .AddRoll(4)
                        .AddRoll(3)
                    .WithFrame(4)
                        .AddRoll(2)
                        .AddRoll(2)
                    .WithFrame(8)
                        .AddRoll(6)
                        .AddRoll(2)
                    .WithFrame(9)
                        .AddRoll(6)
                        .AddRoll(3)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(19)
                        .AddRoll(10)
                    .WithFrame(9)
                        .AddRoll(8)
                        .AddRoll(1)
                    .WithFrame(5)
                        .AddRoll(3)
                        .AddRoll(2)
                    .WithFrame(30)
                        .AddRoll(10)
                        .AddRoll(10)
                        .AddRoll(10)
                .Play(bowlingScorer);

            expected = bowlingSimulator.BuildSummedScore();
        };

        Because of = () => score = bowlingScorer.GetScore();

        It should_return_score = () => 
            score.Should().Be(expected);
    }
}