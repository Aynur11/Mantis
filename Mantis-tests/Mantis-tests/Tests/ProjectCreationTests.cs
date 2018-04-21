using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectManagmentTests : AuthTestBase
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
        
    }
}
