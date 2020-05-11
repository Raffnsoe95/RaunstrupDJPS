using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Raunstrup.UI.UserManagement
{
    public class UserManagementContext :IdentityDbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {

        }
    }
}
