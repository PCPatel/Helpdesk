using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Helpdesk.Models.Configuration
{
    public class IssueConfiguration : EntityTypeConfiguration<Issue>
    {
        public IssueConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Summary).HasMaxLength(255);

            Property(x => x.Description).HasMaxLength(1000);

            HasOptional(c => c.Component);

            HasOptional(i => i.LinkedIssue)
                .WithMany()
                .HasForeignKey(x => x.LinkedIssueId)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Priority)
                .WithMany()
                .HasForeignKey(x => x.PriorityId)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Type)
                 .WithMany()
                 .HasForeignKey(x => x.TypeId)
                 .WillCascadeOnDelete(false);

            HasRequired(u => u.Reporter)
                .WithMany()
                .HasForeignKey(x => x.ReporterId)
                .WillCascadeOnDelete(false);

            //public List<Component> Components;
            //public List<Attachment> Attachments;

            //public int IssueId;
            //public Issue LinkedIssue;
            //public int AssigneeId;
            //public User Assignee;
            //public int PriorityId;
            //public Priority Priority;
        }
    }
}