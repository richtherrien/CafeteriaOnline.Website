namespace CafeteriaOnline.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFullMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CafeteriaAddress",
                c => new
                    {
                        CafeteriaAddressID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        CashierID = c.Int(nullable: false),
                        StreetAddress = c.String(),
                        StreetAddress2 = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Cashier_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CafeteriaAddressID)
                .ForeignKey("dbo.Cashier", t => t.Cashier_Id)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID)
                .Index(t => t.Cashier_Id);
            
            CreateTable(
                "dbo.CafeteriaFood",
                c => new
                    {
                        CafeteriaFoodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MealType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CafeteriaFoodID);
            
            CreateTable(
                "dbo.Cashier",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CashierID = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        UserName = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephone = c.String(),
                        CompanyCode = c.String(),
                        OrganizerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmployeeID = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CafeteriaAddressID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        UserName = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        OrganizerID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        HeadOf_CompanyID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CafeteriaAddress", t => t.CafeteriaAddressID, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: false)
                .ForeignKey("dbo.Company", t => t.HeadOf_CompanyID)
                .Index(t => t.CafeteriaAddressID)
                .Index(t => t.CompanyID)
                .Index(t => t.HeadOf_CompanyID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        MealConfigurationID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ForDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PaidStatus = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        Employee_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .ForeignKey("dbo.MealConfiguration", t => t.MealConfigurationID, cascadeDelete: true)
                .Index(t => t.MealConfigurationID)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.MealConfiguration",
                c => new
                    {
                        MealConfigurationID = c.Int(nullable: false, identity: true),
                        MealID = c.Int(nullable: false),
                        Ingredients = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MealConfigurationID)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        MealID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MealType = c.Int(nullable: false),
                        Description = c.String(),
                        ValidUntil = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        CatererID = c.Int(nullable: false),
                        Caterer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MealID)
                .ForeignKey("dbo.Caterer", t => t.Caterer_Id)
                .Index(t => t.Caterer_Id);
            
            CreateTable(
                "dbo.Caterer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CatererID = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        UserName = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CafeteriaFoodCafeteriaAddress",
                c => new
                    {
                        CafeteriaFood_CafeteriaFoodID = c.Int(nullable: false),
                        CafeteriaAddress_CafeteriaAddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CafeteriaFood_CafeteriaFoodID, t.CafeteriaAddress_CafeteriaAddressID })
                .ForeignKey("dbo.CafeteriaFood", t => t.CafeteriaFood_CafeteriaFoodID, cascadeDelete: true)
                .ForeignKey("dbo.CafeteriaAddress", t => t.CafeteriaAddress_CafeteriaAddressID, cascadeDelete: true)
                .Index(t => t.CafeteriaFood_CafeteriaFoodID)
                .Index(t => t.CafeteriaAddress_CafeteriaAddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "HeadOf_CompanyID", "dbo.Company");
            DropForeignKey("dbo.Order", "MealConfigurationID", "dbo.MealConfiguration");
            DropForeignKey("dbo.MealConfiguration", "MealID", "dbo.Meal");
            DropForeignKey("dbo.Meal", "Caterer_Id", "dbo.Caterer");
            DropForeignKey("dbo.Order", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Employee", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Employee", "CafeteriaAddressID", "dbo.CafeteriaAddress");
            DropForeignKey("dbo.CafeteriaAddress", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.CafeteriaAddress", "Cashier_Id", "dbo.Cashier");
            DropForeignKey("dbo.CafeteriaFoodCafeteriaAddress", "CafeteriaAddress_CafeteriaAddressID", "dbo.CafeteriaAddress");
            DropForeignKey("dbo.CafeteriaFoodCafeteriaAddress", "CafeteriaFood_CafeteriaFoodID", "dbo.CafeteriaFood");
            DropIndex("dbo.CafeteriaFoodCafeteriaAddress", new[] { "CafeteriaAddress_CafeteriaAddressID" });
            DropIndex("dbo.CafeteriaFoodCafeteriaAddress", new[] { "CafeteriaFood_CafeteriaFoodID" });
            DropIndex("dbo.Meal", new[] { "Caterer_Id" });
            DropIndex("dbo.MealConfiguration", new[] { "MealID" });
            DropIndex("dbo.Order", new[] { "Employee_Id" });
            DropIndex("dbo.Order", new[] { "MealConfigurationID" });
            DropIndex("dbo.Employee", new[] { "HeadOf_CompanyID" });
            DropIndex("dbo.Employee", new[] { "CompanyID" });
            DropIndex("dbo.Employee", new[] { "CafeteriaAddressID" });
            DropIndex("dbo.CafeteriaAddress", new[] { "Cashier_Id" });
            DropIndex("dbo.CafeteriaAddress", new[] { "CompanyID" });
            DropTable("dbo.CafeteriaFoodCafeteriaAddress");
            DropTable("dbo.Caterer");
            DropTable("dbo.Meal");
            DropTable("dbo.MealConfiguration");
            DropTable("dbo.Order");
            DropTable("dbo.Employee");
            DropTable("dbo.Company");
            DropTable("dbo.Cashier");
            DropTable("dbo.CafeteriaFood");
            DropTable("dbo.CafeteriaAddress");
        }
    }
}
