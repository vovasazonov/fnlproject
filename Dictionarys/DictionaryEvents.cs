using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using ModelLayer.Models;

namespace FNL
{
    static class DictionaryEvents
    {
        static public readonly Dictionary<Events, string> EventDic = new Dictionary<Events, string>
        {
            {Events.Replacement,"Замена" }
        };

        public static int GetEventId(Events matchEvent)
        {
            using (var db = new DbFnlContext())
            {
                if (!db.Events.Where(t=>t.EventId == (uint)matchEvent).Any())
                {
                    db.Events.Add(new Event() { EventId = (int)matchEvent, Name = EventDic[matchEvent] });
                    db.SaveChanges();
                }
            }

            return (int)matchEvent;
        }
        public enum Events : uint
        {
            Replacement = 32432423
        }
    }
}
