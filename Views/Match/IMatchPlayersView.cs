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
    public interface IMatchPlayersView : IPlayerView
    {
        new int Number { get; set; }
        new string FirstName{get;set;}
        new string LastName{get;set;}
        new string MiddleName{get;set;}
        new string Amplua { get; set; }
        bool IsSpare { get; set; }
    }

    public class CMatchPlayersView : IMatchPlayersView
    {
        public int Number { get; set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string MiddleName { get;set; }
        public string Amplua { get;set; }
        public bool IsSpare { get;set; }
        public string PhotoPath { get;set; }
        public string Country { get;set; }
        public string City { get;set; }
        public string Role { get;set; }
        public int PersonId { get;set; }
        public int RoleId { get;set; }
        public int AmpluaId { get;set; }
        public int TeamId { get; set; }
    }
}
