using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpdesk.Models
{
    public class Role : BaseEntity
    {
        //Comment Testing 1
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}