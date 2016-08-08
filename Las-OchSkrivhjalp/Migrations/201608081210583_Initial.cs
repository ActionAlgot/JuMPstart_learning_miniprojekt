namespace Las_OchSkrivhjalp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageSrc = c.String(),
                        Headline = c.String(),
                        Hint = c.String(),
                        CorrectAnswer = c.String(),
                        CategoryID = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Highscores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.Int(nullable: false),
                        DateWhatever = c.DateTime(nullable: false),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionCategories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Highscores", "CategoryID", "dbo.QuestionCategories");
            DropForeignKey("dbo.Questions", "CategoryID", "dbo.QuestionCategories");
            DropIndex("dbo.Highscores", new[] { "CategoryID" });
            DropIndex("dbo.Questions", new[] { "CategoryID" });
            DropTable("dbo.Highscores");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionCategories");
        }
    }
}
