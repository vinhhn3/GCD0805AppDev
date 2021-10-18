namespace GCD0805AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Education", c => c.String());
            AddColumn("dbo.AspNetUsers", "DoB", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "DoB");
            DropColumn("dbo.AspNetUsers", "Education");
        }
    }
}
