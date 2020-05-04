
using Objects.Models;

namespace Objects.Objects
{
    /// <summary>
    /// An object to hold member and team details for a specific member.
    /// </summary>
    public class MemberDetailsObject
    {
        public MemberModel Member { get; set; }
        public TeamModel Team { get; set; }
    }
}
