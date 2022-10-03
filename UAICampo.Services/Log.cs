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
        public Log()
        {

        }

        public Log(object[] itemArray)
        {
            this.Code = (string)itemArray[0];
            this.Description = (string)itemArray[1];
            var type = (string)itemArray[2];
            this.Type = (LogType)Enum.Parse(typeof(LogType), type);
            this.Date = (DateTime)itemArray[3];
            this.User = (int?)itemArray[4];
        }

        public Log(string code, string description, LogType type, DateTime date, int user)
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
        public int? User;
    }

    public enum LogType
    {
        Info,
        Error,
        Warning,
        Control
    }
}
