namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SendByAddedToMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SentBy", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "SentBy");
        }
    }
}
