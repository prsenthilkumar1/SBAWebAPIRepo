using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SBAWebAPI;
using SBAWebAPI.Controllers;
using System.Web.Http;
using SBAWebAPI.Models;

namespace SBANUnit
{
    [TestFixture]
    public class SBANUnitTest
    {
        public static UserModel FirstCase = new UserModel { EmployeeID = "A64", FirstName = "Prabhu", LastName = "Durai", Role = "M" };
        public static UserModel SecondCase = new UserModel { EmployeeID = "A65", FirstName = "Mohan", LastName = "M", Role = "M" };

        public static ProjectModel FirstProjectTestCase = new ProjectModel { Project = "Kores", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 15 , UserID  =1};
        public static ProjectModel SecondProjectTestCase = new ProjectModel { Project = "Project5", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 20, UserID = 2 };

        public static TaskModel FirstTaskTestCase = new TaskModel { ProjectID = 7, TaskName = "Task54", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 15, Status = "InProgress", ParentID = 1 };
        public static TaskModel SecondTaskTestCase = new TaskModel { ProjectID = 8, TaskName = "Task76", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 20, Status = "InProgress", ParentID = 1003 };


        [Test]
        [TestCase("Senthil", 1)]
        [TestCase("Goutham", 2)]
        public void Test_UserGet(string fristName, int UserID)
        {
            var controller = new UserAPIController();

            List<UserModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.UserID == UserID).FirstOrDefault();
            Assert.AreEqual(fristName, result.FirstName);
        }

        [Test]
        [TestCaseSource("FirstCase")]
        [TestCaseSource("SecondCase")]
        public void Test_UserPost(UserModel userModel)
        {
            var controller = new UserAPIController();
            controller.Post(userModel);
            List<UserModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.EmployeeID == userModel.EmployeeID).FirstOrDefault();
            Assert.AreEqual(userModel.FirstName, result.FirstName);
        }

        [Test]
        [TestCase("Senthil", 1)]
        [TestCase("Goutham", 2)]
        public void Test_UserPut(string lastName, int UserID)
        {
            var controller = new UserAPIController();
            List<UserModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.UserID == UserID).FirstOrDefault();
            result.LastName = lastName;
            controller.Put(result);
            List<UserModel> resoponse2 = controller.Get();
            var result2 = resoponse2.Where(t => t.UserID == UserID).FirstOrDefault();
            Assert.AreEqual(lastName, result2.LastName);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void Test_UserDelete(int UserID)
        {
            var controller = new UserAPIController();
            List<UserModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.UserID == UserID).FirstOrDefault();
            controller.Delete(result);
            List<UserModel> resoponse2 = controller.Get();
            var result2 = resoponse2.Where(t => t.UserID == UserID).FirstOrDefault();
            Assert.That(result2, Is.Null);
        }


        [Test]
        [TestCase("WB", 1)]
        [TestCase("Project2", 7)]
        public void Test_ProjectGet(string projectName, int ProjectID)
        {
            var controller = new ProjectAPIController();

            List<ProjectDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.PDProjectID == ProjectID).FirstOrDefault();
            Assert.AreEqual(projectName, result.PDProjectName);
        }

        [Test]
        [TestCaseSource("FirstProjectTestCase")]
        [TestCaseSource("SecondProjectTestCase")]
        public void Test_ProjectPost(ProjectModel projectModel)
        {
            var controller = new ProjectAPIController();
            controller.Post(projectModel);
            List<ProjectDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.PDProjectID == projectModel.Project_ID).FirstOrDefault();
            Assert.AreEqual(projectModel.Project, result.PDProjectName);
        }

        [Test]
        [TestCase("Project54", 1)]
        [TestCase("Project77", 7)]
        public void Test_ProjectPut(string projectName, int Project_ID)
        {
            var controller = new ProjectAPIController();
            List<ProjectDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.PDProjectID == Project_ID).FirstOrDefault();
            ProjectModel project = new ProjectModel()
            {
                UserID = result.UserID,
                Priority = result.PDPriority,
                Project = projectName,
                Project_ID = result.PDProjectID,
                StartDate = result.PDStartDate,
                EndDate = result.PDEndDate
            };
            controller.Put(project);
            List<ProjectDetailModel> resoponse2 = controller.Get();
            var result2 = resoponse2.Where(t => t.PDProjectID == Project_ID).FirstOrDefault();
            Assert.AreEqual(projectName, result2.PDProjectName);
        }

        [Test]
        [TestCase(1)]
        [TestCase(7)]
        public void Test_ProjectDelete(int ProjectID)
        {
            var controller = new ProjectAPIController();
            List<ProjectDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.PDProjectID == ProjectID).FirstOrDefault();
            ProjectModel project = new ProjectModel()
            {
                UserID = result.UserID,
                Priority = result.PDPriority,
                Project = result.PDProjectName,
                Project_ID = result.PDProjectID,
                StartDate = result.PDStartDate,
                EndDate = result.PDEndDate
            };
            controller.Delete(project);
            List<ProjectDetailModel> resoponse2 = controller.Get();
            var result2 = resoponse2.Where(t => t.PDProjectID == ProjectID).FirstOrDefault();
            Assert.That(result2, Is.Null);
        }


        [Test]
        [TestCase("Icon Creation", 2)]
        [TestCase("Task 1", 1003)]
        public void Test_TaskGet(string taskName, int TaskID)
        {
            var controller = new TaskAPIController();

            List<TaskDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.TaskID == TaskID).FirstOrDefault();
            Assert.AreEqual(taskName, result.TaskName);
        }

        [Test]
        [TestCaseSource("FirstTaskTestCase")]
        [TestCaseSource("SecondTaskTestCase")]
        public void Test_TaskPost(TaskModel taskModel)
        {
            var controller = new TaskAPIController();
            controller.Post(taskModel);
            List<TaskDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.TaskID == taskModel.TaskID).FirstOrDefault(); 
            Assert.AreEqual(taskModel.TaskName, result.TaskName);
        }

        [Test]
        [TestCase("Task54", 2)]
        [TestCase("Task77", 1003)]
        public void Test_TaskPut(string taskName, int TaskID)
        {
            var controller = new TaskAPIController();
            List<TaskDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.TaskID == TaskID).FirstOrDefault();
            TaskModel task = new TaskModel()
            {
                EndDate = result.TaskEndDate,
                ParentID = result.ParentTaskID,
                Priority = result.TaskPriority,
                ProjectID = result.TaskProjectID,
                StartDate = result.TaskStartDate,
                Status = result.TaskStatus,
                TaskName = taskName,
                TaskID = result.TaskID
            };
            controller.Put(task);
            List<TaskDetailModel> resoponse2 = controller.Get();
            var result2 = resoponse2.Where(t => t.TaskID == TaskID).FirstOrDefault();
            Assert.AreEqual(taskName, result2.TaskName);
        }

        [Test]
        [TestCase(2)]
        [TestCase(1003)]
        public void Test_TaskDelete(int TaskID)
        {
            var controller = new TaskAPIController();
            List<TaskDetailModel> resoponse = controller.Get();
            var result = resoponse.Where(t => t.TaskID == TaskID).FirstOrDefault();
            TaskModel task = new TaskModel()
            {                
                TaskID = result.TaskID
            };
            controller.Delete(task);
            List<TaskDetailModel> resoponse2 = controller.Get();
            var result2 = resoponse2.Where(t => t.TaskID == TaskID).FirstOrDefault();
            Assert.That(result2, Is.Null);
        }
    }
}
