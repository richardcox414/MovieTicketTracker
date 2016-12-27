namespace Sp16_p3_g__1_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Auditoriums", new[] { "Theater_Id" });
            AddColumn("dbo.Movies", "AdultPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Movies", "SeniorPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Movies", "ChildPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Movies", "MovieSynopsis", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Sales", "ConfirmCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Auditoriums", "Theater_Id", c => c.Int());
            CreateIndex("dbo.Auditoriums", "Theater_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Auditoriums", new[] { "Theater_Id" });
            AlterColumn("dbo.Auditoriums", "Theater_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Sales", "ConfirmCode");
            DropColumn("dbo.Movies", "MovieSynopsis");
            DropColumn("dbo.Movies", "ChildPrice");
            DropColumn("dbo.Movies", "SeniorPrice");
            DropColumn("dbo.Movies", "AdultPrice");
            CreateIndex("dbo.Auditoriums", "Theater_Id");
        }
    }
}
