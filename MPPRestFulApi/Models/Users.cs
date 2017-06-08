using System;
using System.Collections.Generic;

namespace MPPRestFulApi.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Subscribe { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
