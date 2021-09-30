namespace GCD0805AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTodoModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Todoes", "Description", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Todoes", "Description", c => c.String());
        }
    }
}
