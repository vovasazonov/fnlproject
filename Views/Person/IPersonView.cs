using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IPersonView
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string PhotoPath { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Role { get; set; }
    }
}
