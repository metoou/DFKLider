using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFKLider.Domains.Entities;

namespace DFKLider.Domains.Repositories.Abstract
{
    public interface IGroupRepository
    {
        IQueryable<Group> GetGroups();
        Group GetGroupById(Guid id);
        void SaveGroup(Group entity);
        void DeleteGroup(Guid id);
    }
}
