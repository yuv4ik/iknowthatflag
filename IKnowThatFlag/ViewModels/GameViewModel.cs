using System;
using IKnowThatFlag.Models;
using IKnowThatFlag.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace IKnowThatFlag.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public Question Question { get; private set; }
        public string AnsweredQuestions => $"Answers: {gameService.AnsweredQuestions}";
        public string Score => $"Score: {gameService.Score}";
        public double TimeLeft { get; private set; }

        TimeSpan maxTime = TimeSpan.FromSeconds(10);
        TimeSpan interval = TimeSpan.FromSeconds(1);

        IGameService gameService { get; }
        NaiveTimer timer;

        [AlsoNotifyFor(nameof(AnsweredQuestions), nameof(Score))]
        public string SelectedAnswer { get; set; }

        void OnSelectedAnswerChanged()
        {
            timer.Stop();
            if (gameService.IsTheRightAnswer(SelectedAnswer))
            {
                // Get then next question
                Question = gameService.GetNextQuestion();
                StartTimer();
            }
            else
                GameOver();
        }

        public GameViewModel(
            IGameService gameService,
            INavigationService navigation) : base(navigation)
        {
            this.gameService = gameService;
            gameService.StartGame();
            Question = gameService.GetNextQuestion();
            StartTimer();
        }

        void StartTimer()
        {
            TimeLeft = maxTime.TotalSeconds;
            timer = new NaiveTimer(interval);
            timer.Start(HandleTimerTick);
        }

        void HandleTimerTick(int ticks)
        {
            if (ticks * interval.TotalSeconds >= maxTime.TotalSeconds)
            {
                timer.Stop();
                GameOver();
            }

            TimeLeft -= interval.TotalSeconds;
        }

        void GameOver()
        {
            gameService.EndGame();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.DisplayAlert("Game Over", $"The right answer was:\r\n {Question.TheRightAnswer}", "OK");
                await Navigation.PopModalAsync();
            });
        }
    }
}