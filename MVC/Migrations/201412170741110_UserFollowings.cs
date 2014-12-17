namespace FootballLeagueTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFollowings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserFollowingsId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserFollowingsId");
            AddForeignKey("dbo.AspNetUsers", "UserFollowingsId", "dbo.UserFollowings", "UserFollowingsId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserFollowingsId", "dbo.UserFollowings");
            DropIndex("dbo.AspNetUsers", new[] { "UserFollowingsId" });
            DropColumn("dbo.AspNetUsers", "UserFollowingsId");
        }
    }
}
