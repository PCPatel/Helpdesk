namespace Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUniqueIndexOnColumnNameOfAllMasterTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "Name", unique: true);
            CreateIndex("dbo.Users", "UserName", unique: true);
            CreateIndex("dbo.Roles", "Name", unique: true);
            CreateIndex("dbo.Components", "Name", unique: true);
            CreateIndex("dbo.Priorities", "Name", unique: true);
            CreateIndex("dbo.Status", "Name", unique: true);
            CreateIndex("dbo.Types", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Types", new[] { "Name" });
            DropIndex("dbo.Status", new[] { "Name" });
            DropIndex("dbo.Priorities", new[] { "Name" });
            DropIndex("dbo.Components", new[] { "Name" });
            DropIndex("dbo.Roles", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "Name" });
        }
    }
}
