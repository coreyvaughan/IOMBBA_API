using Objects.Models;
using System.Collections.Generic;

namespace Objects.Objects
{
    /// <summary>
    /// An object to hold all details related to a team and its roster.
    /// </summary>
    public class TeamObject
    {
        public TeamModel Team { get; set; }
        public List<MemberModel> MembersList { get; set; }
    }
}
