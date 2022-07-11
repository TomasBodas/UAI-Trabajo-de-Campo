﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Abstractions
{
    public class IProfile : IEntity
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string Desc { get; set; }
        public int Value { get; set; }
    }
}
