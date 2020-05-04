using Objects.Models;
using Objects.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Objects.Interfaces
{
    public interface IMember
    {
        /// <summary>
        /// Get all member records held on the database.
        /// </summary>
        /// <returns>A list of member models</returns>
        List<MemberModel> GetAllMembers();

        /// <summary>
        /// Gets the details of all members on the database
        /// </summary>
        /// <returns>A list of member details objects</returns>
        List<MemberDetailsObject> GetAllMemberDetails();

        /// <summary>
        /// Gets the details of a member for a given id.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <returns>A MemberDetailsObject</returns>
        MemberDetailsObject GetMemberDetails(int id);

        /// <summary>
        /// Gets a member for a given id.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <returns>An action result</returns>
        Task<MemberModel> GetMember(int id);

        /// <summary>
        /// Edits an existing member record on the database.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <param name="form">The member details, passed in from the form</param>
        /// <returns>The new values of the edited record</returns>
        Task<MemberModel> EditMember(int id, MemberObject form);

        /// <summary>
        /// Adds a new member record to the database.
        /// </summary>
        /// <param name="form">The details of the new member to be added</param>
        /// <returns>The newly added member record.</returns>
        Task<MemberModel> AddMember(MemberObject form);

        /// <summary>
        /// Deletes an existing member from the database.
        /// </summary>
        /// <param name="id">The id of the member to be deleted</param>
        /// <returns>An action result</returns>
        Task DeleteMember(int id);
    }
}