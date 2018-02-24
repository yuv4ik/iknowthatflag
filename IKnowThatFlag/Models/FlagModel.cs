using IKnowThatFlag.Entities;

namespace IKnowThatFlag.Models
{
    public class FlagModel
    {
        public string Country { get; }
        public string ImageFileName { get; }

        public FlagModel(Flag entity)
        {
            Country = entity.Country;
            ImageFileName = entity.ImageFileName;
        }
    }
}
