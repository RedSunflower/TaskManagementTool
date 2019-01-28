using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ManagementTool.Roles.Models;
using ManagementTool.Roles.Repository;
using Microsoft.AspNet.Identity.Owin;

namespace ManagementTool.Roles.Controllers
{
    public class TrackingTaskController : Controller
    {
        private ApplicationUserManager _userManager;
        private TrackingTaskRepository trackingTaskRepository = new TrackingTaskRepository();
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View(trackingTaskRepository.GetAll().OrderBy(x=>x.ProjectName));
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Details(int id)
        {
            var task = trackingTaskRepository.GetById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Create()
        {
           // ViewBag.ProgressList = CreateProgressList();
            return View();
           
        }
        
        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrackingTask task)
        {
            trackingTaskRepository.Insert(task);
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult AssignUser(int id)
        {
            // ViewBag.ProgressList = CreateProgressList();
            var task = trackingTaskRepository.GetById(id);
            task.ApplicationUsers = UserManager.Users.ToList();
            return View(task);
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        public async Task<ActionResult> AssignUser(TrackingTask task)
        {
            foreach (var user in UserManager.Users.ToList())
            {
                if (user.Id == task.UserId)
                {
                    task.ApplicationUserDetails = user.FullName + " " + user.Surname;
                    break;
                }
            }
            trackingTaskRepository.UpdateUser(task);
            await UserManager.SendEmailAsync(task.UserId, "You were assigned to task ",
                "Please login to system to see the details. Your project is "+task.ProjectName+",your task is "+task.TaskName);
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Edit(int id)
        {
           // ViewBag.ProgressList = CreateProgressList();
            var task = trackingTaskRepository.GetById(id);
            return View(task);
        }

        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TrackingTask task)
        {
            trackingTaskRepository.Update(task);
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Delete(int id)
        {
            var task = trackingTaskRepository.GetById(id);
            return View(task);
        }

        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TrackingTask task)
        {
            var deletedTask = trackingTaskRepository.GetById(task.Id);
            trackingTaskRepository.Delete(deletedTask.Id);
            return RedirectToAction("Index");
        }
        [CustomAuthorize]
        public ActionResult CreateSubTask(int id)
        {
            //ViewBag.ProgressList = CreateProgressList();
            var createdTask = trackingTaskRepository.GetById(id);
            TrackingTask subtask = new TrackingTask();
            subtask.ParentId = createdTask.Id;
            subtask.ProjectName = createdTask.ProjectName;
            subtask.ApplicationUserDetails = createdTask.ApplicationUserDetails;
            return View(subtask);

        }
        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateSubTask(TrackingTask subtask)
        {
            trackingTaskRepository.Insert(subtask);
            return RedirectToAction("Index");
        }

        public ActionResult EditSubtask(int id)
        {
            //ViewBag.ProgressList = CreateProgressList();
            var task = trackingTaskRepository.GetById(id);
            return View(task);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubtask(TrackingTask task)
        {
            trackingTaskRepository.Update(task);
            return RedirectToAction("Index");
        }
        [CustomAuthorize]
        public ActionResult DeleteSubtask(int id)
        {
            var task = trackingTaskRepository.GetById(id);
            return View(task);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubtask(TrackingTask task)
        {
            var deletedTask = trackingTaskRepository.GetById(task.Id);
            trackingTaskRepository.Delete(deletedTask.Id);
            return RedirectToAction("Index");
        }
        [CustomAuthorize]
        public ActionResult SubtaskDetails(int id)
        {
            var task = trackingTaskRepository.GetById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }
        public List<SelectListItem> CreateProgressList()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem() { Value = "0%", Text = "0%" },
                new SelectListItem() { Value = "10%", Text = "10%" },
                new SelectListItem() { Value = "20%", Text = "20%" },
                new SelectListItem() { Value = "30%", Text = "30%" },
                new SelectListItem() { Value = "40%", Text = "40%" },
                new SelectListItem() { Value = "50%", Text = "50%" },
                new SelectListItem() { Value = "60%", Text = "60%" },
                new SelectListItem() { Value = "70%", Text = "70%" },
                new SelectListItem() { Value = "80%", Text = "80%" },
                new SelectListItem() { Value = "90%", Text = "90%" },
                new SelectListItem() { Value = "100%", Text = "100%" }
            };
            return list;
        }
    }
}