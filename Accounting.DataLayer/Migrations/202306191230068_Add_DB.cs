namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        Description = c.String(maxLength: 800),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.AccountingTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        CustomerImage = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.AccountingTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeTitle = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accountings", "TypeID", "dbo.AccountingTypes");
            DropForeignKey("dbo.Accountings", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Accountings", new[] { "TypeID" });
            DropIndex("dbo.Accountings", new[] { "CustomerID" });
            DropTable("dbo.AccountingTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Accountings");
        }
    }
}
