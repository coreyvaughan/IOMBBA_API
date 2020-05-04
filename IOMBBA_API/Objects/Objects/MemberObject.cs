using System;

namespace Objects.Objects
{
    /// <summary>
    /// An object to hold all details related to a member.
    /// </summary>
    public class MemberObject
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ShirtNumber { get; set; }
        public string Position { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsCoach { get; set; }
        public bool IsOfficial { get; set; }
        public bool IsTableOfficial { get; set; }
        public string RefQualifications { get; set; }
        public string TableQualifications { get; set; }
        public Guid MemberTeam { get; set; }
    }
}
