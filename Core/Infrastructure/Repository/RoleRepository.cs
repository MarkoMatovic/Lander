using LandLander.Core.Domain.Aggregates.RolesAggregate;
using LandLander.Core.Domain.IRepository;
using LandLander.Core.Infrastructure.Entity;
using LandLander.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLander.Core.Infrastructure.Repository;

public class RoleRepository(RentalbaseContext context) : IRoleRepository
{
    private readonly RentalbaseContext _context = context ?? throw new ArgumentNullException(nameof(context));
    public IUnitOfWork UnitOfWork => _context;

    public Role Add(Role entity)
    {
        return _context.Roles.Add(entity).Entity;
    }

    public async Task<Role?> GetAsync(Guid roleGuid)
    {
        return await _context.Roles.SingleOrDefaultAsync(role => role.RoleGuid == roleGuid);
    }
}
