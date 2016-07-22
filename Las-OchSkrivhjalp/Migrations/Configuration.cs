namespace Las_OchSkrivhjalp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Las_OchSkrivhjalp.DataAccess.QuestionsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Las_OchSkrivhjalp.DataAccess.QuestionsContext context)
        {
            
        }
    }
}
