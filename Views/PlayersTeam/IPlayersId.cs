﻿/*  Файл View (паттерн Model View Presenter).
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
namespace FNL.Views
{
    public interface IPlayerId
    {
        int TeamId { get; set; }
        int AmpluaId { get; set; }
    }
}