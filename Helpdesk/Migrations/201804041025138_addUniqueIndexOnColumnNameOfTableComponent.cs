namespace Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUniqueIndexOnColumnNameOfTableComponent : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Components", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Components", new[] { "Name" });
        }
    }
}
