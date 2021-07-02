namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecture_Id" });
            DropColumn("dbo.Courses", "LectureId");
            RenameColumn(table: "dbo.Courses", name: "Lecture_Id", newName: "LectureId");
            AlterColumn("dbo.Courses", "LectureId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Courses", "LectureId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LectureId");
            AddForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LectureId" });
            AlterColumn("dbo.Courses", "LectureId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "LectureId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Courses", name: "LectureId", newName: "Lecture_Id");
            AddColumn("dbo.Courses", "LectureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Lecture_Id");
            AddForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
