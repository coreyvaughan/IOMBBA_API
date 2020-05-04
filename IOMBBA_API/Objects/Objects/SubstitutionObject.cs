using Objects.Models;
using System;

namespace Objects.Objects
{
    /// <summary>
    /// An object to hold all details of a substitution.
    /// </summary>
    public class SubstitutionObject
    {
        public Guid SubstituteId { get; set; }
        public Guid SubstituteStatId { get; set; }
        public MemberModel SubstitutePlayerOff { get; set; }
        public MemberModel SubstitutePlayerOn { get; set; }
    }
}
