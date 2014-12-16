namespace FootballLeagueTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingposistiontoMatchHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatchHistories", "Position", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MatchHistories", "Position");
        }
    }
}
