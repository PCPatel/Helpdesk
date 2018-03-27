namespace Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialMasterData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Users(Name,UserName,Password,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values('PC Patel','Admin','Admin',1,GETDATE(),1,GETDATE())");

            Sql("INSERT INTO dbo.Roles(Name,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values('Admin',1,GETDATE(),1,GETDATE())");
            Sql("INSERT INTO dbo.Roles(Name,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values('User',1,GETDATE(),1,GETDATE())");
            Sql("INSERT INTO dbo.Roles(Name,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values('Developer',1,GETDATE(),1,GETDATE())");
            Sql("INSERT INTO dbo.Roles(Name,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values('Tester',1,GETDATE(),1,GETDATE())");

            Sql("INSERT INTO dbo.UserRoles(UserId,RoleId) values(1,1)");

            Sql("INSERT INTO dbo.Priorities(Name,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values ('Lowest',1,GETDATE(),1,GETDATE()), ('Low',1,GETDATE(),1,GETDATE()), ('Medium',1,GETDATE(),1,GETDATE()), ('High',1,GETDATE(),1,GETDATE()), ('Highest',1,GETDATE(),1,GETDATE())");

            Sql("INSERT INTO dbo.Types(Name,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values('New Feature',1,GETDATE(),1,GETDATE()), ('Incident',1,GETDATE(),1,GETDATE()), ('Suggestion',1,GETDATE(),1,GETDATE()), ('Change Request',1,GETDATE(),1,GETDATE())");

            Sql("INSERT INTO dbo.Status(Name,AddedBy,AddedOn,ModifiedBy,ModifiedOn) values('Unassigned',1,GETDATE(),1,GETDATE()), ('Open',1,GETDATE(),1,GETDATE()), ('Closed',1,GETDATE(),1,GETDATE())");

        }

        public override void Down()
        {
        }
    }
}
