namespace GCD0805AppDev.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class AddTeamsTableToDb : DbMigration
  {
    public override void Up()
    {
      CreateTable(
          "dbo.Teams",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false, maxLength: 255),
          })
          .PrimaryKey(t => t.Id);

    }

    public override void Down()
    {
      DropTable("dbo.Teams");
    }
  }
}
