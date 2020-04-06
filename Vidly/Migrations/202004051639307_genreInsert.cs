namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreInsert : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres(Name) Values('Comedy')");
            Sql("Insert Into Genres(Name) Values('Action')");
            Sql("Insert Into Genres(Name) Values('Romance')");
            Sql("Insert Into Genres(Name) Values('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
