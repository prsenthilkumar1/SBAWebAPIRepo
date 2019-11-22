using SBAWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBAWebAPI.Controllers
{
    public class TaskAPIController : ApiController
    {
        //List<TaskModel> l_task1 = new List<TaskModel>()
        //        {
        //            new TaskModel(){ TaskID = 2, ProjectID = 1, TaskName = "Icon Creation", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 15, Status = "InProgress", ParentID = 2 },
        //            new TaskModel(){ TaskID = 1003,ProjectID = 7, TaskName = "Task 1", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 15, Status = "InProgress", ParentID = 2 },
                    
        //        };

        public List<TaskDetailModel> Get()
        {
            List<TaskDetailModel> l_TaskDetailModels = new List<TaskDetailModel>();

            using (masterEntities mstEntities = new masterEntities())
            {
                List<Task> l_task = new List<Task>();
                l_task = mstEntities.Tasks.Select(x => x).ToList();

                //List<TaskModel> l_task = new List<TaskModel>();

                //l_task = l_task1.Select(x => x).ToList();

                if (l_task?.Count > 0)
                {
                    foreach (var task in l_task)
                    {
                        TaskDetailModel taskDetailmodel = new TaskDetailModel();
                        taskDetailmodel.TaskEndDate = task.EndDate;
                        taskDetailmodel.TaskPriority = Convert.ToInt32(task.Priority);
                        taskDetailmodel.TaskProjectID = Convert.ToInt32(task.Project);
                        taskDetailmodel.TaskProjectName = mstEntities.Projects.Where(t => t.Project_ID == task.Project_ID).Select(x => x.ProjectName).FirstOrDefault();
                        taskDetailmodel.TaskStartDate = task.StartDate;
                        taskDetailmodel.TaskStatus = task.Status;
                        taskDetailmodel.TaskID = task.Task_ID;
                        taskDetailmodel.TaskName = task.TaskName;
                        taskDetailmodel.ParentTaskID = Convert.ToInt32(task.Parent_ID);
                        taskDetailmodel.ParentTaskName = mstEntities.Tasks.Where(t => t.Task_ID == task.Parent_ID).Select(x => x.TaskName).FirstOrDefault();

                        l_TaskDetailModels.Add(taskDetailmodel);
                    }
                }
            };

            return l_TaskDetailModels;
        }

        // GET: api/TaskAPI/5 
        public string Get(int id)
        {
            return null;
        }

        // POST: api/TaskAPI 
        public string Post(TaskModel taskModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                Task task = new Task();

                //TaskModel task = new TaskModel();
                task.EndDate = taskModel.EndDate;
                task.Parent_ID = taskModel.ParentID;
                task.Priority = taskModel.Priority;
                task.Project_ID = taskModel.ProjectID;
                task.StartDate = taskModel.StartDate;
                task.Status = taskModel.Status;
                task.TaskName = taskModel.TaskName;
                task.Task_ID = taskModel.TaskID;
                                
                //l_task1.Add(task);

                mstEntities.Tasks.Add(task);
                mstEntities.SaveChanges();
            }

            success = "Project Details successfully saved";

            return success;
        }

        // PUT: api/TaskAPI
        public string Put(TaskModel taskModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                Task task = new Task();
                task = mstEntities.Tasks.Where(t => t.Task_ID == taskModel.TaskID).Select(x => x).FirstOrDefault();

                //TaskModel task = new TaskModel();
                //task = l_task1.Where(t => t.TaskID == taskModel.TaskID).Select(x => x).FirstOrDefault();

                if (task != null)
                {
                    task.EndDate = taskModel.EndDate;
                    task.Parent_ID = taskModel.ParentID;
                    task.Priority = taskModel.Priority;
                    task.Project_ID = taskModel.ProjectID;
                    task.StartDate = taskModel.StartDate;
                    task.Status = taskModel.Status;
                    task.TaskName = taskModel.TaskName;
                    task.Task_ID = taskModel.TaskID;

                    //l_task1.Remove(task);
                    //l_task1.Add(task);

                    mstEntities.Entry(task).State = EntityState.Modified;
                    mstEntities.SaveChanges();
                }
            };

            success = "Task Details successfully Updated";
            return success;
        }

        // DELETE: api/TaskAPI/5 
        public string Delete(TaskModel taskModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                Task task = new Task();
                task = mstEntities.Tasks.Where(t => t.Task_ID == taskModel.TaskID).Select(x => x).FirstOrDefault();

                //TaskModel task = new TaskModel();
                //task = l_task1.Where(t => t.TaskID == taskModel.TaskID).Select(x => x).FirstOrDefault();

                if (task != null)
                {
                    //l_task1.Remove(task);
                    mstEntities.Entry(task).State = EntityState.Deleted;
                    mstEntities.SaveChanges();
                }
            };

            return success;
        }
    }
}
