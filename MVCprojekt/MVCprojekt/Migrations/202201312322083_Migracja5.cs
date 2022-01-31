namespace MVCprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CounterModels",
                c => new
                    {
                        CounterID = c.Int(nullable: false, identity: true),
                        Counter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CounterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CounterModels");
        }
    }
}
