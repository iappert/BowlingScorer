
namespace CodingDojo
{
    public class ScoreAccumulator
    {
        private readonly int[] rolls;

        public ScoreAccumulator(int[] rolls)
        {
            this.rolls = rolls;
        }

        public int Accumulate()
        {
            var summedScore = 0;
            var rollIndex = 0;
            for (var frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                if (this.IsStrike(rollIndex))
                {
                    summedScore += this.ScoreWithStrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (this.IsSpare(rollIndex))
                {
                    summedScore += this.ScoreWithSpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    summedScore += this.rolls[rollIndex] + this.rolls[rollIndex + 1];
                    rollIndex += 2;
                }
            }

            return summedScore;

        }

        private int ScoreWithStrikeBonus(int rollIndex)
        {
            return this.rolls[rollIndex] + this.rolls[rollIndex + 1] + this.rolls[rollIndex + 2];
        }

        private bool IsStrike(int rollIndex)
        {
            return this.rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return this.rolls[rollIndex] + this.rolls[rollIndex + 1] == 10;
        }

        private int ScoreWithSpareBonus(int rollIndex)
        {
            return this.rolls[rollIndex] + this.rolls[rollIndex + 1] + this.rolls[rollIndex + 2];
        }
    }
}