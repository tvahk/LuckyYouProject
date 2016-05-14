using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.IdentityModels;

namespace DAL.Repositories
{
    public class DrawRepository : EFRepository<Draw>, IDrawRepository
    {
        public DrawRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Draw> GetUserDrawsByUserId(string userid)
        {
            return
                DbSet.Where(x => x.UserId == userid)
                    .Include(x => x.Product)
                    .Include(y => y.User)
                    .Include(z => z.DrawCategory)
                    .Include(z => z.DrawDuration)
                    .Include(a => a.DrawPriority)
                    .Include(b => b.DrawSize)
                    .ToList();
        }
        public List<Draw> GetAllDraws()
        {
            return DbSet.Include(x => x.Product).Include(y => y.User).Include(z=> z.DrawCategory).Include(z => z.DrawDuration).Include(a => a.DrawPriority).Include(b => b.DrawSize).OrderByDescending(y => y.DrawPriority.DrawPriorityValue).ThenBy(z => z.DrawDuration.DrawDurationValue).ToList();
        }
        public List<Draw> GetAllDrawsByDurationId(int durationId)
        {
            return DbSet.Where(y => y.DrawDurationId == durationId).Include(x => x.Product).Include(y => y.User).Include(z => z.DrawCategory).Include(z => z.DrawDuration).Include(a => a.DrawPriority).Include(b => b.DrawSize).ToList();
        }
        public Draw GetDrawByProductId(int productId)
        {
            return DbSet.FirstOrDefault(x=> x.ProductId == productId);
        }

        public List<Draw> GetDrawsByDrawCategory(int drawCategoryId)
        {
            return DbSet.Where(x => x.DrawCategoryId == drawCategoryId).OrderByDescending(y => y.DrawPriority.DrawPriorityValue).ThenBy(z => z.DrawDuration.DrawDurationValue).
            Include(x => x.Product)
                .Include(y => y.User)
                .Include(z => z.DrawCategory)
                .Include(z => z.DrawDuration)
                .Include(a => a.DrawPriority)
                .Include(b => b.DrawSize)
                .ToList();
        }

        public List<Draw> GetDrawsBySize(int drawSizeId)
        {
            return DbSet.Where(x => x.DrawSizeId == drawSizeId).OrderByDescending(y => y.DrawPriority.DrawPriorityValue).ThenBy(z => z.DrawDuration.DrawDurationValue).
            Include(x => x.Product)
                .Include(y => y.User)
                .Include(z => z.DrawSize)
                .Include(z => z.DrawCategory)
                .Include(a => a.DrawDuration)
                .Include(b => b.DrawPriority)
                .ToList();
        }

        public List<Draw> GetDrawsByDuration(int drawDurationId)
        {
            return DbSet.Where(x => x.DrawDurationId == drawDurationId).OrderByDescending(y => y.DrawPriority.DrawPriorityValue).ThenBy(z => z.DrawDuration.DrawDurationValue).
            Include(x => x.Product)
                .Include(y => y.User)
                .Include(z => z.DrawDurationId)
                .Include(z => z.DrawCategory)
                .Include(a => a.DrawSize)
                .Include(b => b.DrawPriority)
                .ToList();
        }

        public List<Draw> GetDrawsByPriority(int drawPriorityId)
        {
            return DbSet.Where(x => x.DrawPriorityId == drawPriorityId).OrderByDescending(y => y.DrawPriority.DrawPriorityValue).ThenBy(z => z.DrawDuration.DrawDurationValue).
            Include(x => x.Product)
                .Include(y => y.User)
                .Include(z => z.DrawPriorityId)
                .Include(z => z.DrawCategory)
                .Include(a => a.DrawSize)
                .Include(b => b.DrawDuration)
                .ToList();
        }

    }
}