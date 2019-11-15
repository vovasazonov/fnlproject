using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using ModelLayer.Models;
using FNL.Enums;

namespace FNL.Dictionarys
{
    /// <summary>
    /// Dictionary that key is the uniq id of elemnt and value is string name of element.
    /// </summary>
    static public class DictionaryEvents
    {
        static internal readonly Dictionary<EventMatchType, string> Dic = new Dictionary<EventMatchType, string>
        {
            {EventMatchType.Replacement,"Замена" },
            {EventMatchType.YellowCard,"Желтая карточка" },
            {EventMatchType.RedCard,"Красная карточка" },
            {EventMatchType.Goal,"Гол" },
        };

        /// <summary>
        /// Return uniq id of element type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static public int GetEventId(EventMatchType matchEvent)
        {
            using (var db = new DbFnlContext())
            {
                if (!db.Events.Where(t => t.EventId == (uint)matchEvent).Any())
                {
                    db.Events.Add(new Event() { EventId = (int)matchEvent, Name = Dic[matchEvent] });
                    db.SaveChanges();
                }
            }

            return (int)matchEvent;
        }
    }
}
