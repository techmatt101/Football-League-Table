namespace FootballLeagueTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indexingpos : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MatchHistories", "Position");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MatchHistories", new[] { "Position" });
        }
    }
}
