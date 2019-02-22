namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPetIDToMessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "PetID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "PetID");
        }
    }
}
