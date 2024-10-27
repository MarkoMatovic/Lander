using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Roles.Services.DTOs;

public class RoleDto
{
}

public class GetRolesDto
{
    public int Id { get; set; }
    public Guid RoleGuid { get; set; }
    public string RoleName { get; set; }
    public Guid CreatedByGuid { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid ModifiedByGuid { get; set; }
    public DateTime ModifiedDate { get; set; }
 }

