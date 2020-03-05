/*  Файл описывает сущность базы данных в виде класса.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    /// <summary>
    /// Entity.
    /// </summary>
    [ComplexType]
	public class Address
	{
		public string Country { get; set; }
		public string City { get; set; }
	}
}
