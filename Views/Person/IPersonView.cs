/*  Файл View (паттерн Model View Presenter).
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IPersonView : IPersonIds
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string PhotoPath { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Role { get; set; }
    }

    class CPersonView : IPersonView
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string MiddleName { get;set; }
        public string PhotoPath { get;set; }
        public string Country { get;set; }
        public string City { get;set; }
        public string Role { get;set; }
        public int PersonId { get;set; }  
        public int RoleId { get;set; } 
    }
}
