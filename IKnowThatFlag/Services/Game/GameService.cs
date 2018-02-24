using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKnowThatFlag.Models;
using IKnowThatFlag.Repositories;
using Xamarin.Forms;

namespace IKnowThatFlag.Services
{
    public class GameService : IGameService
    {
        public int Score { get; private set; }
        public int AnsweredQuestions { get; private set; }

        List<FlagModel> playedCountries = new List<FlagModel>();
        FlagsRepository flagsRepository { get; }
        TopScoreRepository topScoreRepository { get; }
        DateTime gameStartTimeStamp;

        Question currentQuestion;

        public GameService(
            FlagsRepository flagsRepository,
            TopScoreRepository topScoreRepository) 
        {
            this.flagsRepository = flagsRepository;
            this.topScoreRepository = topScoreRepository;
        }

        public bool IsTheRightAnswer(string answer)
        {
            var isRight = answer.Equals(currentQuestion.TheRightAnswer, StringComparison.OrdinalIgnoreCase);

            if(isRight)
            {
                AnsweredQuestions++;
                Score += 10;
            }

            return isRight;
        }

        public async Task EndGame()
        {
            if (Score == 0) return;
            var elapsedTimeInGame = TimeSpan.FromMilliseconds((DateTime.Now - gameStartTimeStamp).TotalMilliseconds);
            var topScoreModel = new TopScoreModel(Score, elapsedTimeInGame, AnsweredQuestions, DateTime.Now, GameMode.Quiz);
            topScoreRepository.Insert(topScoreModel);
        }

        public Question GetNextQuestion()
        {
            if(playedCountries.Count == flagsRepository.Flags.Count)
            {
                // TODO: Win! All the questions answered
            }

            var country = flagsRepository.GetRandomFlag(c => playedCountries.Contains(c));
            var options = flagsRepository.GetRandomFlagCountries();
            options.Add(country.Country);
            options = options.OrderBy(a => Guid.NewGuid()).ToList();

            var question = new Question
            {
                Flag = Device.RuntimePlatform == Device.iOS ? $"png1000px/{country.ImageFileName}.png" : $"{country.ImageFileName}.png",
                Options = options,
                TheRightAnswer = country.Country
            };

            playedCountries.Add(country);

            return currentQuestion = question;
        }

        public void StartGame()
        {
            playedCountries.Clear();
            Score = AnsweredQuestions = 0;
            gameStartTimeStamp = DateTime.Now;
        }
    }
}
