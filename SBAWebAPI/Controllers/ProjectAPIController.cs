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
    public class ProjectAPIController : ApiController
    {

        List<ProjectModel> l_project = new List<ProjectModel>()
                {
                    new ProjectModel(){ Project_ID=1, Project = "WB", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 15 , UserID  =1 },
                    new ProjectModel(){ Project_ID=7, Project = "Project2", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 20 , UserID  =2 },
                    new ProjectModel(){ Project_ID=8, Project = "Kores", StartDate = new DateTime(), EndDate = new DateTime(), Priority = 10 , UserID  =3 },
                };


        // GET: api/ProjectAPI/5 
        public string Get(int id)
        {
            return null;
        }

        // POST: api/ProjectAPI 
        public string Post(ProjectModel projectModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                Project project = new Project();

                //ProjectModel project = new ProjectModel();

                project.User_ID = projectModel.UserID;
                project.Priority = projectModel.Priority;
                project.ProjectName = projectModel.Project;
                project.Project_ID = projectModel.Project_ID;
                project.StartDate = projectModel.StartDate;
                project.EndDate = projectModel.EndDate;

                //l_project.Add(project);

                mstEntities.Projects.Add(project);
                mstEntities.SaveChanges();
            }

            success = "Project Details successfully saved";

            return success;
        }

        // PUT: api/ProjectAPI
        public string Put(ProjectModel projectModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                Project project = new Project();
                project = mstEntities.Projects.Where(t => t.Project_ID == projectModel.Project_ID).Select(x => x).FirstOrDefault();

                //ProjectModel project = new ProjectModel();
                //project = l_project.Where(t => t.Project_ID == projectModel.Project_ID).Select(x => x).FirstOrDefault();

                if (project != null)
                {
                    project.User_ID = projectModel.UserID;
                    project.Priority = projectModel.Priority;
                    project.ProjectName = projectModel.Project;
                    project.Project_ID = projectModel.Project_ID;
                    project.StartDate = projectModel.StartDate;

                    //l_project.Remove(project);
                    //l_project.Add(project);

                    mstEntities.Entry(project).State = EntityState.Modified;
                    mstEntities.SaveChanges();
                }
            };

            success = "Project Details successfully Updated";
            return success;
        }

        // DELETE: api/ProjectAPI/5 
        public string Delete(ProjectModel projectModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                Project project = new Project();
                project = mstEntities.Projects.Where(t => t.Project_ID == projectModel.Project_ID).Select(x => x).FirstOrDefault();

                //ProjectModel project = new ProjectModel();
                //project = l_project.Where(t => t.Project_ID == projectModel.Project_ID).Select(x => x).FirstOrDefault();

                if (project != null)
                {
                    //l_project.Remove(project);

                    mstEntities.Entry(project).State = EntityState.Deleted;
                    mstEntities.SaveChanges();
                }
            };

            return success;
        }

        public List<ProjectDetailModel> Get()
        {
            List<ProjectDetailModel> l_ProjectDetailModels = new List<ProjectDetailModel>();

            using (masterEntities mstEntities = new masterEntities())
            {
                List<int> l_ProjectIDs = new List<int>();

                l_ProjectIDs = mstEntities.Projects.Select(x => x.Project_ID).ToList();
                //l_ProjectIDs = l_project.Select(x => x.Project_ID).ToList();
                if (l_ProjectIDs?.Count > 0)
                {
                    foreach (var item in l_ProjectIDs)
                    {
                        Project l_p = new Project();
                        l_p = mstEntities.Projects.Where(t => t.Project_ID == item).Select(x => x).FirstOrDefault();

                        //ProjectModel l_p = new ProjectModel();
                        //l_p = l_project.Where(t => t.Project_ID == item).Select(x => x).FirstOrDefault();

                        ProjectDetailModel PD = new ProjectDetailModel();
                        PD.NoOfTask =  mstEntities.Tasks.Where(t => t.Project_ID == item).Count();
                        PD.PDEndDate = l_p.EndDate;
                        PD.PDPriority = Convert.ToInt32(l_p.Priority);
                        PD.PDProjectID = l_p.Project_ID;
                        PD.PDProjectName = l_p.ProjectName;
                        PD.PDStartDate = l_p.StartDate;
                        PD.UserID = Convert.ToInt32(l_p.User_ID);
                        PD.TaskCompleted = mstEntities.Tasks.Where(t => t.Project_ID == item && t.Status == "Completed").Count();

                        l_ProjectDetailModels.Add(PD);
                    }
                }
            };

            return l_ProjectDetailModels;
        }
    }
}
