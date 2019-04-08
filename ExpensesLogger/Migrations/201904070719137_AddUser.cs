namespace ExpensesLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'cda0e6c9-2ac6-496c-8290-f479cd744a48', N'admin@elog.com', 0, N'AF0I6TlAcnjZxSrxzAEh5KvoGU4xd/GyT79ceqGd5jV/rhGPiYvbh+nS1oOqQeg5XA==', N'ae1dde30-4b2d-4280-a34f-a3784ee4df8e', NULL, 0, 0, NULL, 1, 0, N'admin@elog.com')"
                );
        }
        
        public override void Down()
        {
        }
    }
}
