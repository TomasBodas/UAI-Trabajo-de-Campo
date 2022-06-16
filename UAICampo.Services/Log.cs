using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class Log : ILog
    {
        public DateTime Date;
        public string Code;
        public string Description;
        public LogType Type;
        public IUser User;
    }

    public enum LogType
    {
        Info,
        Error,
        Warning,
        Control
    }
}
