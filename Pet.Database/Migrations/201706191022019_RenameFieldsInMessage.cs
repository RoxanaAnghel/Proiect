namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFieldsInMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SentDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Messages", "Sent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Sent", c => c.DateTime(nullable: false));
            DropColumn("dbo.Messages", "SentDate");
        }
    }
}
