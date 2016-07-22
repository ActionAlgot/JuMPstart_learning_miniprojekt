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
                "dbo.ComposeWordsToSentences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageSrc = c.String(),
                        Headline = c.String(),
                        Hint = c.String(),
                        CorrectAnswer = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.EditPunctuationOfWords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AskedText = c.String(),
                        Headline = c.String(),
                        Hint = c.String(),
                        CorrectAnswer = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.PickColourFromTexts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Colortxtxtxt = c.String(),
                        Headline = c.String(),
                        Hint = c.String(),
                        CorrectAnswer = c.String(),
                        CategoryID = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.WriteWordFromImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageSrc = c.String(),
                        Headline = c.String(),
                        Hint = c.String(),
                        CorrectAnswer = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WriteWordFromImages", "CategoryID", "dbo.QuestionCategories");
            DropForeignKey("dbo.Highscores", "CategoryID", "dbo.QuestionCategories");
            DropForeignKey("dbo.PickColourFromTexts", "CategoryID", "dbo.QuestionCategories");
            DropForeignKey("dbo.EditPunctuationOfWords", "CategoryID", "dbo.QuestionCategories");
            DropForeignKey("dbo.ComposeWordsToSentences", "CategoryID", "dbo.QuestionCategories");
            DropIndex("dbo.WriteWordFromImages", new[] { "CategoryID" });
            DropIndex("dbo.Highscores", new[] { "CategoryID" });
            DropIndex("dbo.PickColourFromTexts", new[] { "CategoryID" });
            DropIndex("dbo.EditPunctuationOfWords", new[] { "CategoryID" });
            DropIndex("dbo.ComposeWordsToSentences", new[] { "CategoryID" });
            DropTable("dbo.WriteWordFromImages");
            DropTable("dbo.Highscores");
            DropTable("dbo.PickColourFromTexts");
            DropTable("dbo.EditPunctuationOfWords");
            DropTable("dbo.ComposeWordsToSentences");
            DropTable("dbo.QuestionCategories");
        }
    }
}
