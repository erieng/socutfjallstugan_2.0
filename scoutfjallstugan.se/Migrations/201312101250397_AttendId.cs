namespace scoutfjallstugan.se.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendId : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Members", newName: "Member");
            RenameTable(name: "dbo.Attends", newName: "Attend");
            RenameTable(name: "dbo.Activities", newName: "Activity");
            AddColumn("dbo.Attend", "AttendId", c => c.Int(nullable: false));
            AlterColumn("dbo.Activity", "Responsibility", c => c.String());
            AddForeignKey("dbo.Attend", "MemberId", "dbo.Member", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attend", "ActivityId", "dbo.Activity", "Id", cascadeDelete: true);
            CreateIndex("dbo.Attend", "MemberId");
            CreateIndex("dbo.Attend", "ActivityId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Attend", new[] { "ActivityId" });
            DropIndex("dbo.Attend", new[] { "MemberId" });
            DropForeignKey("dbo.Attend", "ActivityId", "dbo.Activity");
            DropForeignKey("dbo.Attend", "MemberId", "dbo.Member");
            AlterColumn("dbo.Activity", "Responsibility", c => c.Boolean(nullable: false));
            DropColumn("dbo.Attend", "AttendId");
            RenameTable(name: "dbo.Activity", newName: "Activities");
            RenameTable(name: "dbo.Attend", newName: "Attends");
            RenameTable(name: "dbo.Member", newName: "Members");
        }
    }
}
