using System;
using System.Collections.Generic;
using System.Linq;
using IKnowThatFlag.Models;
using IKnowThatFlag.Entities;
using SQLite;
using IKnowThatFlag.Services;

namespace IKnowThatFlag.Repositories
{
    public class FlagsRepository
    {
        public List<FlagModel> Flags 
        {
            get
            {
                if (flags != null) return flags;
                flags = new List<FlagModel>();
                var entities = dbConn.Table<Flag>().ToList();
                entities.ForEach(e => flags.Add(new FlagModel(e)));
                return flags;
            }
        }

        List<FlagModel> flags;
        SQLiteConnection dbConn { get; }
        Random random { get; }

        public FlagsRepository(ISqliteFileAccessHelper sqliteFileAccessHelper)
        {
            dbConn = new SQLiteConnection(sqliteFileAccessHelper.GetDBFilePath("flags.sqlite3"));
            random = new Random();
        }

        public FlagModel GetRandomFlag(Func<FlagModel, bool> alreadyPlayed)
        {
            FlagModel country = null;
            do
            {
                country = Flags[random.Next(Flags.Count)];
            }
            while (alreadyPlayed(country));
            return country;
        }

        public List<string> GetRandomFlagCountries(int max = 3)
        {
            var randomFlagCountries = new List<string>();
            for (int i = 0; i < max; i++)
                randomFlagCountries.Add(Flags[random.Next(Flags.Count)].Country);

            return randomFlagCountries;
        }
    }
}
