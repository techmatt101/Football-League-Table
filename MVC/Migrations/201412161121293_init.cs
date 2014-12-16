namespace FootballLeagueTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        LeagueId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LeagueId);
            
            CreateTable(
                "dbo.MatchHistories",
                c => new
                    {
                        MatchHistoryId = c.Int(nullable: false, identity: true),
                        Played = c.Int(nullable: false),
                        Won = c.Int(nullable: false),
                        Drawn = c.Int(nullable: false),
                        Lost = c.Int(nullable: false),
                        For = c.Int(nullable: false),
                        Against = c.Int(nullable: false),
                        Difference = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchHistoryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        League_LeagueId = c.Int(),
                        MatchHistory_MatchHistoryId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Leagues", t => t.League_LeagueId)
                .ForeignKey("dbo.MatchHistories", t => t.MatchHistory_MatchHistoryId)
                .Index(t => t.League_LeagueId)
                .Index(t => t.MatchHistory_MatchHistoryId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserFollowings",
                c => new
                    {
                        UserFollowingsId = c.Int(nullable: false, identity: true),
                        FollowingTeam_TeamId = c.Int(),
                        RivalTeam_TeamId = c.Int(),
                        UserId_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserFollowingsId)
                .ForeignKey("dbo.Teams", t => t.FollowingTeam_TeamId)
                .ForeignKey("dbo.Teams", t => t.RivalTeam_TeamId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id, cascadeDelete: true)
                .Index(t => t.FollowingTeam_TeamId)
                .Index(t => t.RivalTeam_TeamId)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFollowings", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFollowings", "RivalTeam_TeamId", "dbo.Teams");
            DropForeignKey("dbo.UserFollowings", "FollowingTeam_TeamId", "dbo.Teams");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teams", "MatchHistory_MatchHistoryId", "dbo.MatchHistories");
            DropForeignKey("dbo.Teams", "League_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.UserFollowings", new[] { "UserId_Id" });
            DropIndex("dbo.UserFollowings", new[] { "RivalTeam_TeamId" });
            DropIndex("dbo.UserFollowings", new[] { "FollowingTeam_TeamId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Teams", new[] { "MatchHistory_MatchHistoryId" });
            DropIndex("dbo.Teams", new[] { "League_LeagueId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UserFollowings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Teams");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MatchHistories");
            DropTable("dbo.Leagues");
        }
    }
}
