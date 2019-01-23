using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementTool.Roles.Models;
using ManagementTool.Roles.Repository;

namespace ManagementTool.Roles.Controllers
{
    public class TrackingTaskController : Controller
    {
        private TrackingTaskRepository trackingTaskRepository = new TrackingTaskRepository();
        // GET: TrackingTask
        [Authorize]
        public ActionResult Index()
        {
            return View(trackingTaskRepository.GetAll());
        }
        [CustomAuthorize]
        // GET: TestDatas/Details/5
        public ActionResult Details(int id)
        {
            var testData = trackingTaskRepository.GetById(id);
            if (testData == null)
            {
                return HttpNotFound();
            }
            return View(testData);
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        // GET: TestDatas/Create
        public ActionResult Create()
        {
            ViewBag.ProgressList = CreateProgressList();
            return View();
           
        }
        [CustomAuthorize]
        public ActionResult CreateSubTask(int id)
        {
            ViewBag.ProgressList = CreateProgressList();
            var createdTask = trackingTaskRepository.GetById(id);
            TrackingTask subtask = new TrackingTask();
            subtask.ParentId = createdTask.Id;
            subtask.ProjectName = createdTask.ProjectName.ToString();
            return View(subtask);

        }
        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubTask([Bind(Include = "Id,ProjectName,TaskName,TaskDescription,StartDate,TillDate,Status,Priority,ParentId,Progress")] TrackingTask subtask)
        {
            trackingTaskRepository.Insert(subtask);
            return RedirectToAction("Index");
        }

        // POST: TestDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectName,TaskName,TaskDescription,StartDate,TillDate,Status,Priority,ParentId,Progress")] TrackingTask task)
        {
            trackingTaskRepository.Insert(task);
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        // GET: TestDatas/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ProgressList = CreateProgressList();
            var testData = trackingTaskRepository.GetById(id);
            return View(testData);
        }

        // POST: TestDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectName,TaskName,TaskDescription,StartDate,TillDate,Status,Priority,Progress")] TrackingTask testData)
        {
            trackingTaskRepository.Update(testData);
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin, Manager")]
        // GET: TestDatas/Delete/5
        public ActionResult Delete(int id)
        {
            var testData = trackingTaskRepository.GetById(id);
            return View(testData);
        }

        // POST: TestDatas/Delete/5
        [CustomAuthorize(Roles = "Admin, Manager")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Delete(TrackingTask testData)
        {
            var daletedTestData = trackingTaskRepository.GetById(testData.Id);
            trackingTaskRepository.Delete(daletedTestData.Id);
            return RedirectToAction("Index");
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