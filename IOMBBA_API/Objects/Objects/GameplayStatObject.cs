using Objects.Models;

namespace Objects.Objects
{
    /// <summary>
    /// An object to hold all details related to a statistic.
    /// </summary>
    public class GameplayStatObject
    {
        public GameplayStatModel Stat { get; set; }
        public ShotModel Shot { get; set; }
        public MemberModel Member { get; set; }
        public TeamModel Team { get; set; }
        public FoulModel Foul { get; set; }
    }
}
