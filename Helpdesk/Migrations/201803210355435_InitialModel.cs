namespace Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 255),
                        IssueId = c.Int(nullable: false),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.IssueId)
                .Index(t => t.IssueId);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Summary = c.String(maxLength: 255),
                        ReporterId = c.Int(nullable: false),
                        ComponentId = c.Int(),
                        Description = c.String(maxLength: 1000),
                        LinkedIssueId = c.Int(),
                        AssigneeId = c.Int(),
                        PriorityId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssigneeId)
                .ForeignKey("dbo.Components", t => t.ComponentId)
                .ForeignKey("dbo.Issues", t => t.LinkedIssueId)
                .ForeignKey("dbo.Priorities", t => t.PriorityId)
                .ForeignKey("dbo.Users", t => t.ReporterId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Types", t => t.TypeId)
                .Index(t => t.ReporterId)
                .Index(t => t.ComponentId)
                .Index(t => t.LinkedIssueId)
                .Index(t => t.AssigneeId)
                .Index(t => t.PriorityId)
                .Index(t => t.StatusId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 12),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        AddedBy = c.Int(),
                        AddedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.UserID })
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.Issues", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Issues", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Issues", "ReporterId", "dbo.Users");
            DropForeignKey("dbo.Issues", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.Issues", "LinkedIssueId", "dbo.Issues");
            DropForeignKey("dbo.Issues", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.Issues", "AssigneeId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.Issues", new[] { "TypeId" });
            DropIndex("dbo.Issues", new[] { "StatusId" });
            DropIndex("dbo.Issues", new[] { "PriorityId" });
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
            DropIndex("dbo.Issues", new[] { "LinkedIssueId" });
            DropIndex("dbo.Issues", new[] { "ComponentId" });
            DropIndex("dbo.Issues", new[] { "ReporterId" });
            DropIndex("dbo.Attachments", new[] { "IssueId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Types");
            DropTable("dbo.Status");
            DropTable("dbo.Priorities");
            DropTable("dbo.Components");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Issues");
            DropTable("dbo.Attachments");
        }
    }
}
