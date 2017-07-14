namespace ImageSharing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Commentary = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        Post_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Post_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FriendID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "User_ID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_ID" });
            DropIndex("dbo.Comments", new[] { "User_ID" });
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            DropTable("dbo.UserFriends");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
