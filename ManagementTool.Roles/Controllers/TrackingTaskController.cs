using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ManagementTool.DAL.Models;
using ManagementTool.DAL.Repository;
using Microsoft.AspNet.Identity.Owin;
using ManagementTool.BLL;
using ManagementTool.Roles.ViewModels;
using AutoMapper;

namespace ManagementTool.Roles.Controllers
{
    public class TrackingTaskController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly ITrackingTaskBusinessLogic businessLogic;
        public TrackingTaskController(ITrackingTaskBusinessLogic logic)
        {
            businessLogic = logic;
        }
        public TrackingTaskController()
        {
        }
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
            var tasks = businessLogic.GetAll();
            List<TrackingTaskViewModel> models = new List<TrackingTaskViewModel>();
            foreach(var task in tasks)
            {
                models.Add(Mapper.Map<TrackingTaskViewModel>(task));
            }
            return View(models);
        }
        [HttpGet]
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Details(int id)
        {
            try
            {
              var task = Mapper.Map<TrackingTask,TrackingTaskViewModel>(businessLogic.GetById(id));
              return View(task);
            }
            catch
            {
                return HttpNotFound();
            }
            
        }
        [HttpGet]
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Create()
        {
            // ViewBag.ProgressList = CreateProgressList();
            return View();

        }

        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrackingTaskViewModel  taskModel)
        {
            var task = Mapper.Map<TrackingTaskViewModel, TrackingTask>(taskModel);
            try
            {
                businessLogic.Add(task);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        [HttpGet]
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult AssignUser(int id)
        {
            // ViewBag.ProgressList = CreateProgressList();
            try
            {
                var task = Mapper.Map<TrackingTask, TrackingTaskViewModel>(businessLogic.GetById(id));
                task.ApplicationUsers = UserManager.Users.ToList();
                return View(task);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        public async Task<ActionResult> AssignUser(TrackingTaskViewModel taskModel)
        {
            try
            {
                var task = Mapper.Map<TrackingTaskViewModel, TrackingTask>(taskModel);
                foreach (var user in UserManager.Users.ToList())
                {
                    if (user.Id == task.UserId)
                    {
                        task.ApplicationUserDetails = user.FullName + " " + user.Surname;
                        break;
                    }
                }
                businessLogic.Update(task);
                await UserManager.SendEmailAsync(task.UserId, "You were assigned to task ",
                    "Please login to system to see the details. Your project is " + task.ProjectName + ",your task is " + task.TaskName);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        [HttpGet]
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Edit(int id)
        {
            // ViewBag.ProgressList = CreateProgressList();
            try
            {
                var task = Mapper.Map<TrackingTask, TrackingTaskViewModel>(businessLogic.GetById(id));
                return View(task);
            }
            catch(Exception e) 
            {
                return View(e.Message);
            }
        }

        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrackingTaskViewModel taskModel)
        {
            var task = Mapper.Map<TrackingTaskViewModel, TrackingTask>(taskModel);
            try
            {
                businessLogic.Update(task);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        [HttpGet]
        [CustomAuthorize(Roles = "Admin, Manager")]
        public ActionResult Delete(int id)
        {
            try
            {
                var task = Mapper.Map<TrackingTask, TrackingTaskViewModel>(businessLogic.GetById(id));
                return View(task);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
            
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TrackingTaskViewModel taskModel)
        {
            try
            {
                var deletedTask = Mapper.Map<TrackingTaskViewModel, TrackingTask>(taskModel);
                businessLogic.Delete(deletedTask.Id);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        [HttpGet]
        [CustomAuthorize]
        public ActionResult CreateSubTask(int id)
        {
            //ViewBag.ProgressList = CreateProgressList();
            try
            {
                var createdTask = Mapper.Map<TrackingTask, TrackingTaskViewModel>(businessLogic.GetById(id));
                TrackingTaskViewModel subtask = new TrackingTaskViewModel();
                subtask.ParentId = createdTask.Id;
                subtask.ProjectName = createdTask.ProjectName;
                subtask.ApplicationUserDetails = createdTask.ApplicationUserDetails;
                return View(subtask);
            }catch(Exception e)
            {
                return View(e.Message);
            }

        }
        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubTask(TrackingTaskViewModel subtaskModel)
        {
            var subtask = Mapper.Map<TrackingTaskViewModel, TrackingTask>(subtaskModel);
            try
            {
                businessLogic.Add(subtask);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
            
        }
        [HttpGet]
        [CustomAuthorize]
        public ActionResult EditSubtask(int id)
        {
            //ViewBag.ProgressList = CreateProgressList();
            try
            {
                var task = Mapper.Map<TrackingTask, TrackingTaskViewModel>(businessLogic.GetById(id));
                return View(task);
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubtask(TrackingTaskViewModel taskModel)
        {
            var task = Mapper.Map<TrackingTaskViewModel, TrackingTask>(taskModel);
            try
            {
                businessLogic.Update(task);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        [HttpGet]
        [CustomAuthorize]
        public ActionResult DeleteSubtask(int id)
        {
            try
            {
                var task = Mapper.Map<TrackingTask, TrackingTaskViewModel>(businessLogic.GetById(id));
                return View(task);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubtask(TrackingTaskViewModel taskModel)
        {
            try
            {
                var deletedTask = Mapper.Map<TrackingTaskViewModel, TrackingTask>(taskModel);
                businessLogic.Delete(deletedTask.Id);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        [HttpGet]
        [CustomAuthorize]
        public ActionResult SubtaskDetails(int id)
        {
            try
            {
                var task = Mapper.Map<TrackingTask, TrackingTaskViewModel>(businessLogic.GetById(id));
                return View(task);
            }
            catch 
            {
                return HttpNotFound();
            }
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