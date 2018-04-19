using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<ProjectData> GetPrjectsListWS()
        {
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projectData;
            projectData = client.mc_projects_get_user_accessible(ApplicationManager.Account.Name, ApplicationManager.Account.Password);

            for (int i = 0; i < projectData.Length; i++)
            {
                projects.Add(new ProjectData(projectData[i].name)
                {
                    Decriptoin = projectData[i].description
                });
            }
            return projects;
        }
    }
}
