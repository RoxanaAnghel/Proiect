namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConversationUpdateMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PetOwnerId = c.Guid(nullable: false),
                        PetOwnerImagineUrl = c.String(),
                        FromID = c.Guid(nullable: false),
                        FromUserImagineUrl = c.String(),
                        PetID = c.Guid(nullable: false),
                        PetImagineUrl = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Messages", "FromId");
            DropColumn("dbo.Messages", "ToId");
            DropColumn("dbo.Messages", "PetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "PetId", c => c.Guid(nullable: false));
            AddColumn("dbo.Messages", "ToId", c => c.Guid(nullable: false));
            AddColumn("dbo.Messages", "FromId", c => c.Guid(nullable: false));
            DropTable("dbo.Conversations");
        }
    }
}
