using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using DAL.EFConfiguration;
using DAL.Interfaces;
using Domain;
using DomainLogic.IdentityModels;

namespace DAL
{
    public class LuckyYouDbContext : DbContext, IDbContext, IDisposable
    {
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly string _instanceId = Guid.NewGuid().ToString();

        public LuckyYouDbContext()
            : base("DataBaseConnectionStr")
        {
            _logger.Info("_instanceId: " + _instanceId);
            Database.SetInitializer(new  DatabaseInitializer());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<DrawCategory> DrawCategories { get; set; }
        public DbSet<DrawDuration> DrawDurations { get; set; }
        public DbSet<DrawPriority> DrawPriorities { get; set; }
        public DbSet<DrawSize> DrawSizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserInDraw> UserInDraws { get; set; }
        public DbSet<Winning> Winnings { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
        }

        public class DatabaseInitializer : DropCreateDatabaseAlways<LuckyYouDbContext>
        {
            protected override void Seed(LuckyYouDbContext context)
            {

                Role admin = new Role("Admin");
                context.Roles.Add(admin);
                Role user = new Role("User");
                context.Roles.Add(user);
                Role client = new Role("Client");
                context.Roles.Add(client);


                //Adding this admin user every time DB is created to get higher level access
                User super = new User("stuff@stuffer.com")
                {
                    Email = "stuff@stuffer.com",
                    //Pwd: Alohamora.123
                    FirstName = "Pekki",
                    LastName = "Küll",
                    Score = 0,
                    PasswordHash = "AOgh3Bnko7XnGrPOKJ70Mfn8Buk2bFw/dFTCaAaj/VJ9jiGInb4gY/m2RiCjc/LSjg==",
                    SecurityStamp = "6a562683-3ae4-40de-ac44-fcf79fb385d7",
                };
                User use = new User("use@use.com")
                {
                    Email = "use@use.com",
                    //Pwd: Alohamora.123
                    FirstName = "Use",
                    LastName = "Case",
                    Score = 15,
                    PasswordHash = "SLÖJSöejöfjdskfds2398489jadsl",
                    SecurityStamp = "2378943294jldjlad2390sdfdsfkl-32dd",
                };
                User veel = new User("veel@veel.com")
                {
                    Email = "veel@use.com",
                    //Pwd: Alohamora.123
                    FirstName = "Veel",
                    LastName = "JaVeel",
                    Score = 24,
                    PasswordHash = "SLÖJSöejöfjdskfds2398489asdasdadasdjadsl",
                    SecurityStamp = "2378943294jldjlad239asdadasdasd0sdfdsfkl-32dd",
                };

                context.Users.Add(super);
                context.Users.Add(use);
                context.Users.Add(veel);

                context.UserRoles.Add(new UserRole()
                {
                    UserId = super.Id,
                    RoleId = admin.Id
                });
                context.UserRoles.Add(new UserRole()
                {
                    UserId = use.Id,
                    RoleId = admin.Id
                });
                context.UserRoles.Add(new UserRole()
                {
                    UserId = veel.Id,
                    RoleId = client.Id
                });




                var productType1 = new ProductType { ProductTypeValue = "mobiil" };
                var productType2 = new ProductType { ProductTypeValue = "jalgratas" };
                var productType3 = new ProductType { ProductTypeValue = "kinkekaart" };
                context.ProductTypes.AddOrUpdate(productType1);
                context.ProductTypes.AddOrUpdate(productType2);
                context.ProductTypes.AddOrUpdate(productType3);

                var product1 = new Product
                {
                    UserId = use.Id,
                    ProductId = 1,
                    ProductType = productType1,
                    ProductTypeId = 1,
                    ProductValue = "Apple IPhone 6S 32GB"
                };
                var product2 = new Product
                {
                    UserId = use.Id,
                    ProductId = 1,
                    ProductType = productType2,
                    ProductTypeId = 1,
                    ProductValue = "Reis Riiga"
                };
                var product3 = new Product
                {
                    UserId = use.Id,
                    ProductId = 1,
                    ProductType = productType3,
                    ProductTypeId = 2,
                    ProductValue = "Reis Filipiinidele"
                };
                context.Products.AddOrUpdate(product1);
                context.Products.AddOrUpdate(product2);
                context.Products.AddOrUpdate(product3);

                var drawCategory1 = new DrawCategory { DrawCategoryValue = "elektroonika" };
                context.DrawCategories.AddOrUpdate(drawCategory1);
                var drawCategory2 = new DrawCategory { DrawCategoryValue = "reis" };
                context.DrawCategories.AddOrUpdate(drawCategory2);
                var drawCategory3 = new DrawCategory { DrawCategoryValue = "lõõgastus" };
                context.DrawCategories.AddOrUpdate(drawCategory3);



                var drawDuration1 = new DrawDuration { DrawDurationValue = 2, DrawDurationPrice = 50 };
                var drawDuration2 = new DrawDuration { DrawDurationValue = 5, DrawDurationPrice = 75 };
                var drawDuration3 = new DrawDuration { DrawDurationValue = 10, DrawDurationPrice = 100 };
                context.DrawDurations.AddOrUpdate(drawDuration1);
                context.DrawDurations.AddOrUpdate(drawDuration2);
                context.DrawDurations.AddOrUpdate(drawDuration3);

                var drawPriority1 = new DrawPriority { DrawPriorityValue = 1 };
                var drawPriority2 = new DrawPriority { DrawPriorityValue = 2 };
                var drawPriority3 = new DrawPriority { DrawPriorityValue = 3 };
                context.DrawPriorities.AddOrUpdate(drawPriority1);
                context.DrawPriorities.AddOrUpdate(drawPriority2);
                context.DrawPriorities.AddOrUpdate(drawPriority3);

                var drawSize1 = new DrawSize { DrawSizeValue = 1, DrawSizePrice = 550 };
                var drawSize2 = new DrawSize { DrawSizeValue = 2, DrawSizePrice = 750 };
                var drawSize3 = new DrawSize { DrawSizeValue = 3, DrawSizePrice = 1000 };
                context.DrawSizes.AddOrUpdate(drawSize1);
                context.DrawSizes.AddOrUpdate(drawSize2);
                context.DrawSizes.AddOrUpdate(drawSize3);


                var draw = new Draw
                {
                    AgeGroup = "kuni 16-aasted",
                    DrawCategory = drawCategory1,
                    DrawCategoryId = drawCategory1.DrawCategoryId,
                    DrawDuration = drawDuration1,
                    DrawDurationId = drawDuration1.DrawDurationId,
                    DrawName = "Rademari suurloos",
                    DrawPriority = drawPriority1,
                    DrawPriorityId = drawPriority1.DrawPriorityId,
                    DrawStartDate = Convert.ToDateTime("10/04/2016"),
                    DrawFaceBookAddress = "www.facebook.ee/172836123913",
                    UserId = use.Id,
                    ProductId = product1.ProductId,
                    Product = product1,
                    DrawSize = drawSize1,
                    DrawSizeId = drawSize1.DrawSizeId
                };
                context.Draws.AddOrUpdate(draw);

                var draw2 = new Draw
                {
                    AgeGroup = "20-50",
                    DrawCategory = drawCategory2,
                    DrawCategoryId = drawCategory2.DrawCategoryId,
                    DrawDuration = drawDuration2,
                    DrawDurationId = drawDuration2.DrawDurationId,
                    DrawName = "Rademari suurloos",
                    DrawFaceBookAddress = "www.facebook.ee/4525245245243",
                    DrawPriority = drawPriority2,
                    DrawPriorityId = drawPriority2.DrawPriorityId,
                    DrawStartDate = Convert.ToDateTime("10/02/2016"),
                    UserId = use.Id,
                    ProductId = product2.ProductId,
                    Product = product2,
                    DrawSize = drawSize2,
                    DrawSizeId = drawSize2.DrawSizeId
                };
                context.Draws.AddOrUpdate(draw2);

                var draw3 = new Draw
                {
                    AgeGroup = "10-50",
                    DrawCategory = drawCategory2,
                    DrawCategoryId = drawCategory2.DrawCategoryId,
                    DrawDuration = drawDuration3,
                    DrawDurationId = drawDuration3.DrawDurationId,
                    DrawName = "NovaTours suvekampaania ja jagamismäng",
                    DrawFaceBookAddress = "www.facebook.ee/432625666534",
                    DrawPriority = drawPriority3,
                    DrawPriorityId = drawPriority3.DrawPriorityId,
                    DrawStartDate = Convert.ToDateTime("10/06/2016"),
                    UserId = use.Id,
                    ProductId = product3.ProductId,
                    Product = product3,
                    DrawSize = drawSize3,
                    DrawSizeId = drawSize3.DrawSizeId
                };
                context.Draws.AddOrUpdate(draw3);


                var bill = new Bill
                {
                    BillDeadline = Convert.ToDateTime("07/04/2017"),
                    Draw = draw,
                    DrawId = 1,

                };
                context.Bills.AddOrUpdate(bill);

                var userInDraw = new UserInDraw
                {
                    Draw = draw,
                    DrawId = 1,
                    UserId = use.Id,
                    UserInDrawDate = Convert.ToDateTime("08/04/2017")
                };
                context.UserInDraws.AddOrUpdate(userInDraw);

                var winning = new Winning
                {
                    Draw = draw,
                    DrawId = 1,
                    UserId = use.Id,
                    WinningComment = "Palju õnne, olete võitja!",
                    WinningDate = Convert.ToDateTime("04/04/2016")
                };
                context.Winnings.AddOrUpdate(winning);


                context.SaveChanges();
                base.Seed(context);
            }
        }

    }
}



