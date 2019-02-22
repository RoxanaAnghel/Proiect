namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Description = c.String(),
                        BirthDate = c.DateTime(),
                        ShelterType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetails");
        }
    }
}
