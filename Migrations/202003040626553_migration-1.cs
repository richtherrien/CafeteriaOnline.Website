namespace CafeteriaOnline.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StreetAddress = c.Int(nullable: false),
                        StreetAddress2 = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Company_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.Company_ID)
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.BaseMealIngredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MealID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .Index(t => t.MealID)
                .Index(t => t.IngredientID);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MealType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActiveStatus = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        Ingredient_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_ID)
                .Index(t => t.Ingredient_ID);
            
            CreateTable(
                "dbo.ConfigMealIngredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MealID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.MealID)
                .Index(t => t.IngredientID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeNumber = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Id = c.String(),
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
                        Company_ID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Company", t => t.Company_ID)
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.Cashier",
                c => new
                    {
                        CashierID = c.Int(nullable: false, identity: true),
                        Id = c.String(),
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
                .PrimaryKey(t => t.CashierID);
            
            CreateTable(
                "dbo.Caterer",
                c => new
                    {
                        CatererID = c.Int(nullable: false, identity: true),
                        Id = c.String(),
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
                .PrimaryKey(t => t.CatererID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Telephone = c.String(),
                        CompanyCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Organizer",
                c => new
                    {
                        OrganizerID = c.Int(nullable: false, identity: true),
                        Id = c.String(),
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
                .PrimaryKey(t => t.OrganizerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Company_ID", "dbo.Company");
            DropForeignKey("dbo.Address", "Company_ID", "dbo.Company");
            DropForeignKey("dbo.BaseMealIngredient", "IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.Meal", "Ingredient_ID", "dbo.Ingredient");
            DropForeignKey("dbo.Order", "MealID", "dbo.Meal");
            DropForeignKey("dbo.Order", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.ConfigMealIngredient", "MealID", "dbo.Meal");
            DropForeignKey("dbo.ConfigMealIngredient", "IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.BaseMealIngredient", "MealID", "dbo.Meal");
            DropIndex("dbo.Employee", new[] { "Company_ID" });
            DropIndex("dbo.Order", new[] { "MealID" });
            DropIndex("dbo.Order", new[] { "EmployeeID" });
            DropIndex("dbo.ConfigMealIngredient", new[] { "IngredientID" });
            DropIndex("dbo.ConfigMealIngredient", new[] { "MealID" });
            DropIndex("dbo.Meal", new[] { "Ingredient_ID" });
            DropIndex("dbo.BaseMealIngredient", new[] { "IngredientID" });
            DropIndex("dbo.BaseMealIngredient", new[] { "MealID" });
            DropIndex("dbo.Address", new[] { "Company_ID" });
            DropTable("dbo.Organizer");
            DropTable("dbo.Company");
            DropTable("dbo.Caterer");
            DropTable("dbo.Cashier");
            DropTable("dbo.Employee");
            DropTable("dbo.Order");
            DropTable("dbo.ConfigMealIngredient");
            DropTable("dbo.Meal");
            DropTable("dbo.Ingredient");
            DropTable("dbo.BaseMealIngredient");
            DropTable("dbo.Address");
        }
    }
}
