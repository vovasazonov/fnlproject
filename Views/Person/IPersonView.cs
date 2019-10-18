using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IPersonView
    {
        int IdPerson { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string PhotoPath { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Role { get; set; }
    }

    class ClassPersonView : IPersonView
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhotoPath { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Role { get; set; }
    }
}
