using ManagementTool.DAL.Models;
using ManagementTool.DAL.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementTool.Roles.ViewModels
{
    public class TrackingTaskViewModel
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string TaskName { get; set; }
        [DataType(DataType.MultilineText)]
        public string TaskDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TillDate { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public int ParentId { get; set; }
        public string Progress { get; set; }
        [DisplayName("AssignedUser")]
        public string ApplicationUserDetails { get; set; }
        [DisplayName("AssignedUser")]
        [StringLength(128)]
        public string UserId { get; set; }
        [NotMapped]
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}