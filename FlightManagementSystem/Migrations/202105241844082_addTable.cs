namespace FlightManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Adminname = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.TblFlightBooking",
                c => new
                    {
                        BId = c.Int(nullable: false, identity: true),
                        From = c.String(nullable: false, maxLength: 40),
                        To = c.String(nullable: false, maxLength: 40),
                        DDate = c.DateTime(nullable: false),
                        DTime = c.String(maxLength: 15),
                        FlightId = c.Int(nullable: false),
                        SeatType = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.BId)
                .ForeignKey("dbo.TblFlightInfo", t => t.FlightId, cascadeDelete: true)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.TblFlightInfo",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        FlightName = c.String(nullable: false, maxLength: 35),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        ConfirmPassword = c.String(maxLength: 20),
                        Age = c.Int(nullable: false),
                        PhoneNo = c.String(nullable: false, maxLength: 11),
                        NICNo = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblFlightBooking", "FlightId", "dbo.TblFlightInfo");
            DropIndex("dbo.TblFlightBooking", new[] { "FlightId" });
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.TblFlightInfo");
            DropTable("dbo.TblFlightBooking");
            DropTable("dbo.TblAdminLogin");
        }
    }
}
