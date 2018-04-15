using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class ProjectData : IComparable<ProjectData>, IEquatable<ProjectData>
    {
        public ProjectData(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
        public string Decriptoin { get; set; }

        public int CompareTo(ProjectData project)
        {
            if (Object.ReferenceEquals(null, project))
            {
                return 1;
            }
            return this.Name.CompareTo(project.Name);
        }

        public override string ToString()
        {
            return this.Name + " " + this.Decriptoin;
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(this, other))
                return true;
            if (Object.ReferenceEquals(null, other))
                return false;
            return this.Name == other.Name && this.Decriptoin == other.Decriptoin;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
