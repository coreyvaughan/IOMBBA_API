using Objects.Models;
using System.Collections.Generic;

namespace Objects.Objects
{
    /// <summary>
    /// An object to hold oncourt and offcourt team players lists for a fixture.
    /// </summary>
    public class PlayersListsObject
    {
        public List<MemberModel> HomeOncourtMembersList { get; set; }
        public List<MemberModel> AwayOncourtMembersList { get; set; }
        public List<MemberModel> HomeOffcourtMembersList { get; set; }
        public List<MemberModel> AwayOffcourtMembersList { get; set; }
    }
}
