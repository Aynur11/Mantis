using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        private ProjectData toBeRemoved = new ProjectData("NewProject")
        {
            Decriptoin = "newdescr"
        };


        [SetUp]
        public void SetUpProjectRemovalTests()
        {
            app.ProjectManagment.CreateProjectIfNoExists(toBeRemoved);
        }

        [Test]
        public void ProjectRemovalWSTest()
        {
            List<ProjectData> oldProjects = app.API.GetPrjectsListWS();

            app.ProjectManagment.RemoveProject(toBeRemoved);
            List<ProjectData> newProjects = app.API.GetPrjectsListWS();

            oldProjects.RemoveAll(p => p.Name == toBeRemoved.Name);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            Assert.AreEqual(oldProjects.Count, newProjects.Count);
        }
    }
}
