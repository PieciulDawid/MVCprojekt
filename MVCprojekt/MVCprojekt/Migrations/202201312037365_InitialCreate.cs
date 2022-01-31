namespace MVCprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        FinalizationDate = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        Client_Id = c.String(maxLength: 128),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_Id)
                .ForeignKey("dbo.EmployeeModels", t => t.Employee_EmployeeID)
                .Index(t => t.Client_Id)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Position_PositionID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.PositionModels", t => t.Position_PositionID)
                .Index(t => t.Position_PositionID);
            
            CreateTable(
                "dbo.PositionModels",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccesLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.OrderProductModels",
                c => new
                    {
                        OrderProductID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderProductID)
                .ForeignKey("dbo.OrderModels", t => t.Order_OrderID)
                .ForeignKey("dbo.ProductModels", t => t.Product_ProductID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.CategoryModels", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryModel_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryModel_CategoryID)
                .Index(t => t.CategoryModel_CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderProductModels", "Product_ProductID", "dbo.ProductModels");
            DropForeignKey("dbo.ProductModels", "Category_CategoryID", "dbo.CategoryModels");
            DropForeignKey("dbo.CategoryModels", "CategoryModel_CategoryID", "dbo.CategoryModels");
            DropForeignKey("dbo.OrderProductModels", "Order_OrderID", "dbo.OrderModels");
            DropForeignKey("dbo.EmployeeModels", "Position_PositionID", "dbo.PositionModels");
            DropForeignKey("dbo.OrderModels", "Employee_EmployeeID", "dbo.EmployeeModels");
            DropForeignKey("dbo.OrderModels", "Client_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.CategoryModels", new[] { "CategoryModel_CategoryID" });
            DropIndex("dbo.ProductModels", new[] { "Category_CategoryID" });
            DropIndex("dbo.OrderProductModels", new[] { "Product_ProductID" });
            DropIndex("dbo.OrderProductModels", new[] { "Order_OrderID" });
            DropIndex("dbo.EmployeeModels", new[] { "Position_PositionID" });
            DropIndex("dbo.OrderModels", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.OrderModels", new[] { "Client_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.OrderProductModels");
            DropTable("dbo.PositionModels");
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
