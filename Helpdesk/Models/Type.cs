﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpdesk.Models
{
    public class Type : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}