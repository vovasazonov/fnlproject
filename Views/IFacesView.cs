/*  Файл View (паттерн Model View Presenter).
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
namespace FNL.Views
{
    public interface IFacesView
    {
        string NameMainJudje { get; set; }
        string NameHelperJudje1 { get; set; }
        string NameHelperJudje2 { get; set; }
        string NamePairJudje { get; set; }
        string NameInsepcotor { get; set; }
        string NameDelegat { get; set; }
        string NameCommentator1 { get; set; }
        string NameCommentator2 { get; set; }
        string CityMainJudje { get; set; }
        string CityHelperJudje1 { get; set; }
        string CityHelperJudje2 { get; set; }
        string CityPairJudje { get; set; }
        string CityInsepcotor { get; set; }
        string CityDelegat { get; set; }
        string CityCommentator1 { get; set; }
        string CityCommentator2 { get; set; }

    }
}