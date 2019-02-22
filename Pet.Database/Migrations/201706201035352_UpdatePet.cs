namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Description", c => c.String());
            AddColumn("dbo.Pets", "Species", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "Breed", c => c.String());
            AddColumn("dbo.Pets", "PureBreed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pets", "MainColour", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "FurType", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "Size", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "Adopted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pets", "BirthDate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "BirthDate");
            DropColumn("dbo.Pets", "Adopted");
            DropColumn("dbo.Pets", "Size");
            DropColumn("dbo.Pets", "FurType");
            DropColumn("dbo.Pets", "MainColour");
            DropColumn("dbo.Pets", "PureBreed");
            DropColumn("dbo.Pets", "Breed");
            DropColumn("dbo.Pets", "Species");
            DropColumn("dbo.Pets", "Description");
        }
    }
}
