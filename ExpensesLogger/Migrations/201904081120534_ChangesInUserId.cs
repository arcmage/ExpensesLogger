namespace ExpensesLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "UserId", c => c.String(false, 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "UserId");
        }
    }
}
