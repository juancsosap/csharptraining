using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileProcess
{
    public class Word : IEquatable<Word>, IComparable<Word>
    {
        public String word { get; }
        public int quantity { get; }

        public Word(String word, int quantity)
        {
            this.word = word;
            this.quantity = quantity;
        }

        public int CompareTo(Word other)
        {
            if (other == null) return 1;
            else return this.word.CompareTo(other.word);
        }

        public bool Equals(Word other)
        {
            if (other == null) return false;
            return (this.word.Equals(other.word));
        }
    }
}
