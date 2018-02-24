using System;
using SQLite;

namespace IKnowThatFlag.Entities
{
    public class TopScore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Score { get; set; }
        public double TimeInGame { get; set; }
        public int RightAnswers { get; set; }
        public DateTime Date { get; set; }
        // https://stackoverflow.com/a/10811837/1970317
        public int GameMode { get; set; }
    }
}