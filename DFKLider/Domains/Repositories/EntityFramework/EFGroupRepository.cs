using DFKLider.Domains.Entities;
using DFKLider.Domains.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFKLider.Domains.Repositories.EntityFramework
{
    public class EFGroupRepository : IGroupRepository
    {
        private readonly AppDbContext context;
        public EFGroupRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Group> GetGroups()
        {
            return context.Groups;
        }
        public Group GetGroupById(Guid id)
        {
            return context.Groups.FirstOrDefault(x => x.Id == id);
        }
        public void SaveGroup(Group entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteGroup(Guid id)
        {
            context.Groups.Remove(new Group() { Id = id });
            context.SaveChanges();
        }  
    }
}
