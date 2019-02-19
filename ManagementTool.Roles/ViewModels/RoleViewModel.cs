using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementTool.DAL.Models;
using ManagementTool.Roles.Models;

namespace ManagementTool.Roles.ViewModels
{
    public class RoleViewModel
    {
        public RoleViewModel() { }
        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}