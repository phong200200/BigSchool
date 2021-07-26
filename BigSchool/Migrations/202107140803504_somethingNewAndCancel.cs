namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingNewAndCancel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecture_Id" });
            DropColumn("dbo.Courses", "LectureId");
            RenameColumn(table: "dbo.Courses", name: "Lecture_Id", newName: "LectureId");
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.AttendeeId);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
            AddColumn("dbo.Courses", "IsCanceled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "LectureId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Courses", "LectureId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LectureId");
            AddForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LectureId" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropIndex("dbo.Attendances", new[] { "CourseId" });
            AlterColumn("dbo.Courses", "LectureId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "LectureId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "name");
            DropColumn("dbo.Courses", "IsCanceled");
            DropTable("dbo.Followings");
            DropTable("dbo.Attendances");
            RenameColumn(table: "dbo.Courses", name: "LectureId", newName: "Lecture_Id");
            AddColumn("dbo.Courses", "LectureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Lecture_Id");
            AddForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
