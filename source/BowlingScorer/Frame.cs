
namespace CodingDojo
{
    using System.Collections.Generic;
    using System.Linq;

    public class Frame
    {
        
        private readonly IEnumerable<int> rolls;

        public Frame(int summedScore, IEnumerable<int> rolls)
        {
            this.SummedScore = summedScore;
            this.rolls = rolls;
        }

        public int SummedScore { get; private set; }

        public int? First
        {
            get
            {
                return this.rolls.Any() ? (int?)this.rolls.ElementAt(0) : null;
            }
        }

        public int? Second
        {
            get
            {
                return this.rolls.Count() > 1 ? (int?)this.rolls.ElementAt(1) : null;
            }
        }

        public int? Third
        {
            get
            {
                return this.rolls.Count() > 2 ? (int?)this.rolls.ElementAt(2) : null;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Frame)obj);
        }

        public override int GetHashCode()
        {
            return (this.SummedScore.GetHashCode() * 17) + this.First.GetHashCode() + this.Second.GetHashCode() + this.Third.GetHashCode();
        }

        private bool Equals(Frame other)
        {
            return this.SummedScore == other.SummedScore
                && this.First == other.First
                && this.Second == other.Second
                && this.Third == other.Third;
        }
    }
}