using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantis_tests.Tests
{
    [TestFixture]
    class ProjectManagmentTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldProjects = app.ProjectManagment.GetProjectsList();
            ProjectData project = new ProjectData("511ryNewProject4")
            {
                Decriptoin = "aSome description4"
            };
            

            app.ProjectManagment.CreateProject(project);
            List<ProjectData> newProjects = app.ProjectManagment.GetProjectsList();
            
            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            Assert.AreEqual(oldProjects.Count, newProjects.Count);
        }

        [Test]
        public void ProjectRemovalTests()
        {
            List<ProjectData> oldProjects = app.ProjectManagment.GetProjectsList();
            ProjectData toBeRemoved = oldProjects[2];
            app.ProjectManagment.RemoveProject(toBeRemoved);
            List<ProjectData> newProjects = app.ProjectManagment.GetProjectsList();

            oldProjects.RemoveAt(2);

            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            Assert.AreEqual(oldProjects.Count, newProjects.Count);

        }
    }
}
