using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpdesk.Models
{
    public class Issue : BaseEntity
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public int ReporterId { get; set; }
        public User Reporter { get; set; }
        public int? ComponentId { get; set; }
        public Component Component { get; set; }
        public virtual List<Attachment> Attachments { get; set; }
        public string Description { get; set; }
        public int? LinkedIssueId { get; set; }
        public Issue LinkedIssue { get; set; }
        public int? AssigneeId { get; set; }
        public User Assignee { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}