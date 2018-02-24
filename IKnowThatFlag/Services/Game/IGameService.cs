using System.Threading.Tasks;
using IKnowThatFlag.Models;

namespace IKnowThatFlag.Services
{
    public interface IGameService
    {
        int Score { get; }
        int AnsweredQuestions { get; }

        void StartGame();
        Task EndGame();
        bool IsTheRightAnswer(string answer);
        Question GetNextQuestion();

    }
}
