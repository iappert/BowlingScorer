namespace CodingDojo
{
    using System.Collections.Generic;
    using System.Linq;

    public class BowlingScorer
    {
        private readonly int[] rolls;
        private int currentRoll;

        public BowlingScorer()
        {
            this.rolls = new int[21];
        }

        public int GetScore()
        {
            return this.GetScoreBoard().Last().SummedScore;
        }

        public IEnumerable<Frame> GetScoreBoard()
        {
            var scoreBoardAccumulator = new ScoreBoardAccumulator(this.rolls, this.currentRoll);

            return scoreBoardAccumulator.AccumulateScoreBoard();
        }

        public void Roll(int knockedPins)
        {
            this.rolls[this.currentRoll] = knockedPins;
            this.currentRoll += 1;
        }
    }
}