namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagineUrlAddedToUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "ImagineUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "ImagineUrl");
        }
    }
}
