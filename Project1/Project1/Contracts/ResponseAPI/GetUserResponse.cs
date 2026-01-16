using System;
using System.Collections.Generic;

namespace BackendApi.Contracts.User
{
    public class GetUserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}