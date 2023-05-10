namespace BasicPJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        ParentId = c.Int(nullable: false),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Slug = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Image = c.String(),
                        Status = c.String(),
                        Show = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.OptionProducts",
                c => new
                    {
                        OptionProductId = c.String(nullable: false, maxLength: 128),
                        OptionProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.OptionProductId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.PropertyProducts",
                c => new
                    {
                        PropertyProductId = c.String(nullable: false, maxLength: 128),
                        PropertyProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.PropertyProductId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        PropertyProduct = c.String(),
                        OptionProduct = c.String(),
                        Invoice_InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceDetailId)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Payment = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        Paid = c.Int(nullable: false),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.PropertyProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OptionProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.InvoiceDetails", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.PropertyProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.OptionProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.PropertyProducts");
            DropTable("dbo.OptionProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
