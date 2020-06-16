/*  Описание класса логгера. С помощью этого класса
 *  можно записывать ошибки в файл.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace FNL
{
    public static class Logger
    {
        private static ILog _log = LogManager.GetLogger("LOGGER");

        static Logger()
        {
            InitLogger();
        }

        public static ILog Log
        {
            get { return _log; }
        }

        private static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

    }
}
