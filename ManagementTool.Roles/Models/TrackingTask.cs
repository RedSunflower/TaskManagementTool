using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ManagementTool.Roles.Models.Enumerations;

namespace ManagementTool.Roles.Models
{
    public class TrackingTask
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        [DataType(DataType.MultilineText)]
        public string TaskDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TillDate { get; set; }
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public int ParentId { get; set; }
        public string Progress { get; set; }
        [DisplayName("AssignedUser")]
        public string  ApplicationUserDetails { get; set; }
        [DisplayName("AssignedUser")]
        //[NotMapped]
        [StringLength(128)]
        public string UserId { get; set; }
        [NotMapped]
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}