namespace ExpensesLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterExpenseId : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Expenses ADD UserId nvarchar (128)");
        }
        
        public override void Down()
        {
        }
    }
}
