using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Objects.Interfaces;
using Objects.Models;
using Objects.Objects;

namespace IOMBBA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]

    public class MemberController : ControllerBase
    {
        // Declare the interface.
        private readonly IMember memberService;

        public MemberController(IMember context)
        {
            memberService = context;
        }

        /// <summary>
        /// Get all member records held on the database.
        /// </summary>
        /// <returns>A list of member models</returns>
        [HttpGet]
        [Route("GetAllMembers")]
        public List<MemberModel> GetAllMembers()
        {
            return memberService.GetAllMembers();
        }

        /// <summary>
        /// Gets the details of all members on the database
        /// </summary>
        /// <returns>A list of member details objects</returns>
        [HttpGet]
        [Route("GetAllMemberDetails")]
        public List<MemberDetailsObject> GetAllMemberDetails()
        {
            return memberService.GetAllMemberDetails();
        }

        /// <summary>
        /// Gets the details of a member for a given id.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <returns>A MemberDetailsObject</returns>
        [HttpGet]
        [Route("GetMemberDetails/{id}")]
        public MemberDetailsObject GetMemberDetails(int id)
        {
            return memberService.GetMemberDetails(id);
        }

        /// <summary>
        /// Gets a member for a given id.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <returns>An action result</returns>
        [HttpGet("{id}")]
        [Route("GetMember/{id}")]
        public async Task<MemberModel> GetMember([FromRoute] int id)
        {
            return await memberService.GetMember(id);
        }

        /// <summary>
        /// Edits an existing member record on the database.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <param name="form">The member details, passed in from the form</param>
        /// <returns>The new values of the edited record</returns>
        [HttpPut("{id}")]
        [Route("EditMember/{id}")]
        public async Task<MemberModel> EditMember([FromRoute] int id, [FromBody] MemberObject form)
        {
            return await memberService.EditMember(id, form);
        }

        /// <summary>
        /// Adds a new member record to the database.
        /// </summary>
        /// <param name="form">The details of the new member to be added</param>
        /// <returns>An action result</returns>
        [HttpPost]
        [Route("AddMember")]
        public async Task<MemberModel> AddMember([FromBody] MemberObject form)
        {
            return await memberService.AddMember(form);
        }

        /// <summary>
        /// Deletes an existing member from the database.
        /// </summary>
        /// <param name="id">The id of the member to be deleted</param>
        /// <returns>An action result</returns>
        [HttpDelete("{id}")]
        [Route("DeleteMember/{id}")]
        public async Task DeleteMember([FromRoute] int id)
        {
            await memberService.DeleteMember(id);
        }
    }
}