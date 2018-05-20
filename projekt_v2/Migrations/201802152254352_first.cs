namespace projekt_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QAnswer = c.String(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QText = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                        QuizID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizID, cascadeDelete: true)
                .Index(t => t.QuizID);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        QuizID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        AnswerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerID, cascadeDelete: true)
                .ForeignKey("dbo.Quizs", t => t.QuizID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.QuizID)
                .Index(t => t.AnswerID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EMail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        City = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResultsQuestions",
                c => new
                    {
                        Results_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Results_Id, t.Question_Id })
                .ForeignKey("dbo.Results", t => t.Results_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Results_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "UserID", "dbo.Users");
            DropForeignKey("dbo.Results", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.ResultsQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.ResultsQuestions", "Results_Id", "dbo.Results");
            DropForeignKey("dbo.Results", "AnswerID", "dbo.Answers");
            DropForeignKey("dbo.Questions", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.ResultsQuestions", new[] { "Question_Id" });
            DropIndex("dbo.ResultsQuestions", new[] { "Results_Id" });
            DropIndex("dbo.Results", new[] { "AnswerID" });
            DropIndex("dbo.Results", new[] { "QuizID" });
            DropIndex("dbo.Results", new[] { "UserID" });
            DropIndex("dbo.Questions", new[] { "QuizID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.ResultsQuestions");
            DropTable("dbo.Users");
            DropTable("dbo.Results");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
