using System.Collections.Generic;
using System.Threading.Tasks;
using IKnowThatFlag.Entities;
using IKnowThatFlag.Models;
using IKnowThatFlag.Services;
using SQLite;

namespace IKnowThatFlag.Repositories
{
    public class TopScoreRepository
    {
        SQLiteAsyncConnection dbConn { get; }

        public TopScoreRepository(ISqliteFileAccessHelper sqliteFileAccessHelper)
        {
            dbConn = new SQLiteAsyncConnection(sqliteFileAccessHelper.GetDBFilePath("flags.sqlite3"));
            dbConn.CreateTableAsync<TopScore>();
        }

        public async Task<List<TopScoreModel>> GetLast10TopScores()
        {
            var topScores = new List<TopScoreModel>();
            var entities = await dbConn.Table<TopScore>().OrderByDescending(e => e.Id).Take(10).ToListAsync();
            entities.ForEach(e => topScores.Add(new TopScoreModel(e)));
            return topScores;
        }

        public Task<int> Insert(TopScoreModel model) =>
            dbConn.InsertAsync(new TopScore
                {
                    Date = model.Date,
                    GameMode = 0,
                    RightAnswers = model.RightAnswers,
                    Score = model.Score,
                    TimeInGame = model.TimeInGame.TotalMilliseconds
                });
    }
}
