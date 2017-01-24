namespace TimeLogDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Description = c.String(),
                        Hours = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        StartTime = c.Int(nullable: false),
                        EndTime = c.Int(nullable: false),
                        DecimalHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoggedBy = c.Int(nullable: false),
                        IsBilled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeLogs", "UserId", "dbo.Users");
            DropIndex("dbo.TimeLogs", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.TimeLogs");
        }
    }
}
