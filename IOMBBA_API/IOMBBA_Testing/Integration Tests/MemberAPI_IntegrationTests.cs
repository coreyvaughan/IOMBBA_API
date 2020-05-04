using Newtonsoft.Json;
using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IOMBBA_Testing.Integration_Tests
{
    /// <summary>
    /// Integration test to test interaction of Member API with the database.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1
    /// </summary>
    public class MemberAPI_IntegrationTests
    {
        private static Guid existingTeamId = new Guid("a69bb43d-c8ea-44b4-b546-44e63147be40");
        private static int existingMemberId1 = 41;
        private static int existingMemberId2 = 42;
        private static int existingMemberId3 = 43;

        /// <summary>
        /// Testing api/Member/GetAllMembers endpoint.
        /// </summary>
        [Fact]
        public async Task Get_All_Members()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Member/GetAllMembers");

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Member/GetAllMemberDetails endpoint.
        /// </summary>
        [Fact]
        public async Task Get_All_Member_Details()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Member/GetAllMemberDetails");

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        /// <summary>
        /// Testing api/Member/AddMember endpoint.
        /// </summary>
        [Fact]
        public async Task Add_Member()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PostAsync("api/Member/AddMember", new StringContent(
                    JsonConvert.SerializeObject(MockMemberObject()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Member/GetMemberDetails/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Member_Details_By_Id()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Member/GetMemberDetails/" + existingMemberId1);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Member/GetMember/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Member_By_Id()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Member/GetMember/" + existingMemberId1);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Member/EditMember/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Edit_Member()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PutAsync("api/Member/EditMember/" + existingMemberId2, new StringContent(
                    JsonConvert.SerializeObject(MockUpdatedMemberObject()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Member/DeleteMember/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Delete_Member()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.DeleteAsync("api/Member/DeleteMember/" + existingMemberId3);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }




        /// <summary>
        /// Mock member object data
        /// </summary>
        /// <returns>A mock member object</returns>
        private MemberObject MockMemberObject()
        {
            return new MemberObject
            {
                FirstName = "Test",
                Surname = "AddMember",
                ShirtNumber = "20",
                IsCoach = false,
                IsOfficial = false,
                IsPlayer = true,
                IsTableOfficial = false,
                Position = "Guard",
                RefQualifications = "",
                TableQualifications = "",
                MemberTeam = existingTeamId
            };
        }


        /// <summary>
        /// Existing Member object with updated values
        /// </summary>
        /// <returns>A mock member object</returns>
        private MemberObject MockUpdatedMemberObject()
        {
            return new MemberObject
            {
                FirstName = "UpdatedFirstName",
                Surname = "UpdatedSurname",
                ShirtNumber = "99",
                IsCoach = false,
                IsOfficial = false,
                IsPlayer = true,
                IsTableOfficial = false,
                Position = "Guard",
                RefQualifications = "",
                TableQualifications = "",
                MemberTeam = existingTeamId
            };
        }



    }
}
