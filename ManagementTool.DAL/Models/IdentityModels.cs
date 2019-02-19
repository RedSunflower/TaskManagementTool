using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ManagementTool.DAL.Models
{
        public class ApplicationUser : IdentityUser
        {
            [Display(Name = "Full Name"), Required]
            [StringLength(200)]
            public string FullName { get; set; }
            [Display(Name = "Surname"), Required]
            [StringLength(200)]
            public string Surname { get; set; }
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
            public virtual ICollection<TrackingTask> Tasks { get; set; }
        }
        public class ApplicationRole : IdentityRole
        {
            public ApplicationRole() : base() { }
            public ApplicationRole(string roleName) : base(roleName) { }
        }
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }
            public static ApplicationDbContext Create()
            {

                return new ApplicationDbContext();
            }
            public virtual DbSet<TrackingTask> Tasks { get; set; }

      //  public System.Data.Entity.DbSet<ManagementTool.DAL.Models.ApplicationUser> ApplicationUsers { get; set; }

        // public System.Data.Entity.DbSet<ManagementTool.Roles.ViewModels.TrackingTaskViewModel> TrackingTaskViewModels { get; set; }
    }
    }

