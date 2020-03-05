/*  Файл View (паттерн Model View Presenter).
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ITablePlayersMainView : IPlayerView
    {
        int N { get; set; }
        new string LastName { get; set; }
        new string FirstName { get; set; }
        string R { get; set; }
        Color K { get; set; }
        string A { get; set; }
    }

    public class ClassTablePlayersMainView : ITablePlayersMainView
    {
        public int PersonId { get; set; }
        public int N { get => Number;set => Number = value; }
        public string LastName { get;set; }
        public string FirstName { get;set; }
        public string R { get => Role; set => Role = value; }
        public Color K { get;set; }
        public string A { get => Amplua; set => Amplua = value; }
        public int Number { get;set; }
        public string Amplua { get;set; }
        public int TeamId { get;set; }
        public int AmpluaId { get;set; }
        public string MiddleName { get;set; }
        public string PhotoPath { get;set; }
        public string Country { get;set; }
        public string City { get;set; }
        public string Role { get;set; }
        public int RoleId { get;set; }
    }
}
