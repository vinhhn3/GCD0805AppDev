namespace GCD0805AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersTeamsTableToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTeams",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.TeamId })
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTeams", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserTeams", "TeamId", "dbo.Teams");
            DropIndex("dbo.UserTeams", new[] { "TeamId" });
            DropIndex("dbo.UserTeams", new[] { "UserId" });
            DropTable("dbo.UserTeams");
        }
    }
}
