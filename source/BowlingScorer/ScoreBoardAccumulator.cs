
namespace CodingDojo
{
    using System.Collections.Generic;

    public class ScoreBoardAccumulator
    {
        private readonly int[] knockedPins;

        public ScoreBoardAccumulator(int[] knockedPins)
        {
            this.knockedPins = knockedPins;
        }

        public IEnumerable<Frame> AccumulateScoreBoard()
        {
            var summedScore = 0;
            var rollIndex = 0;
            for (var frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                if (this.IsStrike(rollIndex))
                {
                    summedScore += this.ScoreWithStrikeBonus(rollIndex);
                    Frame currentFrame;
                    if (frameIndex != 9)
                    {
                        currentFrame = new Frame(summedScore, new[] { this.knockedPins[rollIndex] });
                    }
                    else
                    {
                        currentFrame = new Frame(
                            summedScore,
                            new[] { this.knockedPins[rollIndex], this.knockedPins[rollIndex + 1], this.knockedPins[rollIndex + 2] });
                    }

                    rollIndex++;

                    yield return currentFrame;
                }
                else if (this.IsSpare(rollIndex))
                {
                    summedScore += this.ScoreWithSpareBonus(rollIndex);
                    var currentFrame = new Frame(summedScore, new[] { this.knockedPins[rollIndex], this.knockedPins[rollIndex + 1] });
                    rollIndex += 2;
                    yield return currentFrame;
                }
                else
                {
                    summedScore += this.knockedPins[rollIndex] + this.knockedPins[rollIndex + 1];
                    var currentFrame = new Frame(summedScore, new[] { this.knockedPins[rollIndex], this.knockedPins[rollIndex + 1] });
                    rollIndex += 2;

                    yield return currentFrame;
                }
            }
        }

        private int ScoreWithStrikeBonus(int rollIndex)
        {
            return this.knockedPins[rollIndex] + this.knockedPins[rollIndex + 1] + this.knockedPins[rollIndex + 2];
        }

        private bool IsStrike(int rollIndex)
        {
            return this.knockedPins[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return this.knockedPins[rollIndex] + this.knockedPins[rollIndex + 1] == 10;
        }

        private int ScoreWithSpareBonus(int rollIndex)
        {
            return this.knockedPins[rollIndex] + this.knockedPins[rollIndex + 1] + this.knockedPins[rollIndex + 2];
        }
    }
}