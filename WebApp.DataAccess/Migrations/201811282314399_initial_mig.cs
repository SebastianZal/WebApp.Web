namespace WebApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        RoomSize = c.Boolean(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        KidsQuantity = c.Int(nullable: false),
                        Comment = c.String(),
                        PackageId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedUser = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedUser = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Type = c.Byte(nullable: false),
                        Topic = c.String(),
                        InvitationQuantity = c.Int(nullable: false),
                        Cake = c.String(),
                        CakeOrder = c.Boolean(nullable: false),
                        Piniata = c.String(),
                        EventId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedUser = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedUser = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "Id", "dbo.Events");
            DropIndex("dbo.Packages", new[] { "Id" });
            DropTable("dbo.Packages");
            DropTable("dbo.Events");
        }
    }
}
