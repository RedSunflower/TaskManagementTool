using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementTool.Roles.ViewModels
{
    public class UserWithRoleViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}