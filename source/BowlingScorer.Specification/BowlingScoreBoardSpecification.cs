namespace CodingDojo.Specification
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Machine.Specifications;

    [Subject("BowlingScorer")]
    public class When_getting_ScoreBoard
    {
        static BowlingScorer bowlingScorer;
        static IEnumerable<Frame> score;
        static BowlingSimulator bowlingSimulator;
        static IEnumerable<Frame> expected;

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
                        .AddRoll(9)
                        .AddRoll(1)
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

            expected = bowlingSimulator.BuildScoreBoard();
        };

        Because of = () => score = bowlingScorer.GetScoreBoard();

        It should_return_score = () =>
            score.Should().Equal(expected);
    }

    [Subject("BowlingScorer")]
    public class When_getting_ScoreBoard_for_a_perfect_game
    {
        static BowlingScorer bowlingScorer;
        static IEnumerable<Frame> score;
        static BowlingSimulator bowlingSimulator;
        static IEnumerable<Frame> expected;

        Establish context = () =>
        {
            bowlingScorer = new BowlingScorer();

            bowlingSimulator = BowlingSimulator
                .Create()
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                    .WithFrame(30)
                        .AddRoll(10)
                        .AddRoll(10)
                        .AddRoll(10)
                .Play(bowlingScorer);

            expected = bowlingSimulator.BuildScoreBoard();
        };

        Because of = () => score = bowlingScorer.GetScoreBoard();

        It should_return_score = () =>
            score.Should().Equal(expected);
    }
}