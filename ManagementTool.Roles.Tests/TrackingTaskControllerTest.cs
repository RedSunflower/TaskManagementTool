using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagementTool.DAL.Models;
using ManagementTool.DAL.Repository;
using ManagementTool.Roles.Controllers;
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ManagementTool.BLL;
using ManagementTool.Roles.ViewModels;
using AutoMapper;

namespace ManagementTool.Roles.Tests
{
    [TestClass]
    public class TrackingTaskControllerTest
    {
        [TestMethod]
        public void Index_Model_IsEntittyObjectCollection_moq()
        {
            var mock = new Mock<ITrackingTaskBusinessLogic>();
            var controller = new TrackingTaskController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<TrackingTaskViewModel>));
        }

        //[TestMethod]
        //public void CreatePost_Result_RedirectToActionIndex_moq()
        //{
        //    var mock = new Mock<ITrackingTaskBusinessLogic>();
        //    var controller = new TrackingTaskController(mock.Object);
        //    TrackingTaskViewModel task = new TrackingTaskViewModel();
        //    ActionResult result = controller.Create(task);
        //    Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        //    var redirectResult = result as RedirectToRouteResult;
        //    Assert.AreEqual(redirectResult.RouteValues["action"], "Index");
        //}
        //[TestMethod]
        //public void CreatePost_Result_Add_IsCalled_moq()
        //{
        //    var mock = new Mock<ITrackingTaskBusinessLogic>();
        //    var controller = new TrackingTaskController(mock.Object);
        //    TrackingTaskViewModel task = new TrackingTaskViewModel();
        //    ActionResult result = controller.Create(task);
        //    mock.Verify(e => e.Add(task));// how to map ?
        //}
        //[TestMethod]
        //public void EditGet_Model_IsEntityObject_moq(int id)
        //{
        //    var mock = new Mock<ITrackingTaskBusinessLogic>();
        //    var controller = new TrackingTaskController(mock.Object);
        //    var task = mock.Object.GetById(id);
        //    ViewResult result = controller.Edit(task.Id) as ViewResult;
        //    Assert.IsInstanceOfType(result.Model, typeof(TrackingTaskViewModel));
        //}
        //[TestMethod]
        //public void EditPost_Result_IsUpdateIsCalled_moq()
        //{
        //    var mock = new Mock<ITrackingTaskBusinessLogic>();
        //    var controller = new TrackingTaskController(mock.Object);
        //    TrackingTaskViewModel task = new TrackingTaskViewModel();
        //    ActionResult result = controller.Edit(task);
        //    mock.Verify(e => e.Update(task));
        //}
        //[TestMethod]
        //public void DeletePost_Result_IsDeleteIsCalled_moq()
        //{
        //    var mock = new Mock<ITrackingTaskBusinessLogic>();
        //    var controller = new TrackingTaskController(mock.Object);
        //    var task = new TrackingTaskViewModel();
        //    ActionResult result = controller.Delete(task);
        //    mock.Verify(e => e.Delete(task.Id));

        //}
        //[TestMethod]
        //public async Task AssignUserPost_Result_IsUpdateUserCalled_moq()
        //{
        //    var mock = new Mock<ITrackingTaskBusinessLogic>();
        //    var controller = new TrackingTaskController(mock.Object);
        //    TrackingTaskViewModel task = new TrackingTaskViewModel();
        //    ActionResult result = await controller.AssignUser(task);
        //    mock.Verify(e => e.UpdateUser(task));
        //}

    }
}
