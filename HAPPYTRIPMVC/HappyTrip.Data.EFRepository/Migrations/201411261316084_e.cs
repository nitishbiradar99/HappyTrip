namespace HappyTrip.Data.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialSchedules",
                c => new
                    {
                        SpecialScheduleId = c.Int(nullable: false, identity: true),
                        FlightID = c.Int(nullable: false),
                        FromCityId = c.Int(nullable: false),
                        ToCityId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                        EcoCost = c.Int(nullable: false),
                        BusinessCost = c.Int(nullable: false),
                        DepartureTime = c.Time(nullable: false),
                        ArrivalTime = c.Time(nullable: false),
                        DurationInMins = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialScheduleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpecialSchedules");
        }
    }
}
