using System;
using IKnowThatFlag.Entities;

namespace IKnowThatFlag.Models
{
    public class TopScoreModel
    {
        public int Score { get; }
        public TimeSpan TimeInGame { get; }
        public int RightAnswers { get; }
        public DateTime Date { get; }
        public GameMode GameMode { get; }

        public TopScoreModel(TopScore topScore)
        {
            Score = topScore.Score;
            TimeInGame = TimeSpan.FromMilliseconds(topScore.TimeInGame);
            RightAnswers = topScore.RightAnswers;
            Date = topScore.Date;
            GameMode = GameMode.Quiz;
        }

        public TopScoreModel(
            int scrore,
            TimeSpan timeInGame,
            int rightAnswers,
            DateTime date,
            GameMode gameMode)
        {
            Score = scrore;
            TimeInGame = timeInGame;
            RightAnswers = rightAnswers;
            Date = date;
            GameMode = gameMode;
        }
    }
}
