using DFKLider.Domains.Entities;
using DFKLider.Domains.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFKLider.Domains.Repositories.EntityFramework
{
    public class EFCoachRepository : ICoachRepository
    {
        private readonly AppDbContext context;
        public EFCoachRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Coach> GetCoaches()
        {
            return context.Coaches;
        }

        public ICollection<Coach> GetCoachesGroups()
        {
            return context.Coaches.Include(c => c.Groups).ToList();
        }

        public Coach GetCoachById(Guid id)
        {
            return context.Coaches.FirstOrDefault(x => x.Id == id);
        }

        public void SaveCoach(Coach entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCoach(Guid id)
        {
            context.Coaches.Remove(new Coach() { Id = id });
            context.SaveChanges();
        }

    }
}
