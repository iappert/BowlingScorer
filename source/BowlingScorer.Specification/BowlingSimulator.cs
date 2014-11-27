
namespace CodingDojo.Specification
{
    using System.Collections.Generic;
    using System.Linq;

    public class BowlingSimulator
    {
        private List<InternalFrame> frames;

        private BowlingSimulator()
        {
            this.frames = new List<InternalFrame>();
        }

        public static BowlingSimulator Create()
        {
            return new BowlingSimulator();
        }

        public BowlingSimulator WithFrame(int summedScore)
        {
            this.frames.Add(new InternalFrame(summedScore));

            return this;
        }

        public BowlingSimulator AddRoll(int knockedPins)
        {
            this.frames.Last().AddRoll(knockedPins);

            return this;
        }

        public BowlingSimulator Play(BowlingScorer bowlingScorer)
        {
            foreach (var knockedPins in this.frames.SelectMany(x => x.Rolls))
            {
                bowlingScorer.Roll(knockedPins);
            }

            return this;
        }

        public int BuildSummedScore()
        {
            return this.frames.Sum(x => x.Score);
        }

        public IEnumerable<Frame> BuildScoreBoard()
        {
            var summedScore = 0;
            foreach (var internalFrame in this.frames)
            {
                yield return new Frame(summedScore += internalFrame.Score, internalFrame.Rolls);
            }
        }

        private class InternalFrame
        {
            private readonly List<int> rolls;

            public InternalFrame(int score)
            {
                this.Score = score;
                this.rolls = new List<int>();
            }

            public int Score { get; set; }

            public IEnumerable<int> Rolls
            {
                get
                {
                    return this.rolls;
                }
            }

            public void AddRoll(int knockedPins)
            {
                this.rolls.Add(knockedPins);
            }
        }
    }
}