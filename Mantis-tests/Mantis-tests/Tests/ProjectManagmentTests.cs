using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantis_tests.Tests
{
    [TestFixture]
    class ProjectManagmentTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationWSTest()
        {
            List<ProjectData> oldProjects = app.API.GetPrjectsListWS();


            ProjectData project = new ProjectData("jNewProject4")
            {
                Decriptoin = "aSome description4"
            };

            app.ProjectManagment.CreateProject(project);
            List<ProjectData> newProjects = app.API.GetPrjectsListWS();

            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            Assert.AreEqual(oldProjects.Count, newProjects.Count);
        }

        [Test]
        public void ProjectRemovalWSTest()
        {
            List<ProjectData> oldProjects = app.API.GetPrjectsListWS();
            //ProjectData toBeRemoved = oldProjects[2];
            ProjectData toBeRemoved = new ProjectData("jNewProject4")
            {
                Decriptoin = "newdescr2"
            };

            app.ProjectManagment.RemoveProject(toBeRemoved);
            List<ProjectData> newProjects = app.API.GetPrjectsListWS();

            //oldProjects.RemoveAt(2);
            oldProjects.RemoveAll(p => p.Name == toBeRemoved.Name);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            Assert.AreEqual(oldProjects.Count, newProjects.Count);
        }
    }
}
