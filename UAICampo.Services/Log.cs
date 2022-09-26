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
        public Log(string code, string description, LogType type, DateTime date, IUser user)
        {
            Code = code;
            Description = description;
            Type = type;
            Date = date;
            User = user;
        }
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
