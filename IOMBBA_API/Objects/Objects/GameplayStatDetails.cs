using Objects.Models;

namespace Objects.Objects
{
    /// <summary>
    /// An object to hold all details related to a statistic.
    /// </summary>
    public class GameplayStatDetails
    {
        public GameplayStatModel Stat { get; set; }
        public ShotModel Shot { get; set; }
        public GroupSubstitution GroupSubstitution { get; set; }
        public FoulModel Foul { get; set; }
    }
}

