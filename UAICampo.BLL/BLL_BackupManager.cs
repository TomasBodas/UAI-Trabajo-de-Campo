using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.DAL;

namespace UAICampo.BLL
{
    public class BLL_BackupManager
    {
        DAL_Backup dalBackup = new DAL_Backup();
        public bool backup(string filename)
        {
            if (dalBackup.Backup(filename))
            {
                return true;
            }
            return false;
        }

        public bool restore(string filename)
        {
            if (dalBackup.Restore(filename))
            {
                return true;
            }
            return false; 
        }
    }
}
