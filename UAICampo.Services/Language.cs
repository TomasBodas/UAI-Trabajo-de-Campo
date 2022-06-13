﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions.Observer;

namespace UAICampo.Services.Observer
{
   
     public class Language : ILanguage
     {
        
        public Dictionary<string, string> words = new Dictionary<string, string>();
        public Language()
        {

        }
        public Language(object[] itemArray) 
        {
            this.Id = (int)itemArray[0];
            this.Name = (string)itemArray[1];   
        }

        public string Name { get; set; }
       
    }
}
