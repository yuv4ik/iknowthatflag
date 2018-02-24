using System.Collections.Generic;

namespace IKnowThatFlag.Models
{
    public class Question
    {
        public List<string> Options { get; set; }
        public string TheRightAnswer { get; set; }
        public string Flag { get; set; }
    }
}
