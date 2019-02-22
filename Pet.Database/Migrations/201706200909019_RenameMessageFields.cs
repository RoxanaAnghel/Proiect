namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMessageFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FromId", c => c.Guid(nullable: false));
            AddColumn("dbo.Messages", "ToId", c => c.Guid(nullable: false));
            DropColumn("dbo.Messages", "From");
            DropColumn("dbo.Messages", "To");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "To", c => c.Guid(nullable: false));
            AddColumn("dbo.Messages", "From", c => c.Guid(nullable: false));
            DropColumn("dbo.Messages", "ToId");
            DropColumn("dbo.Messages", "FromId");
        }
    }
}
