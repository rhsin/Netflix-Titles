using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MvcTitle.Data;
using MvcTitle.Models;

namespace MvcTitle.Repositories
{
    public interface IUserRepository
    {
        public IQueryable<User> GetUsers();
    }

    public class UserRepository : IUserRepository
    {
        private MvcTitleContext _context;

        public UserRepository(MvcTitleContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsers()
        {
            return _context.User
                .Include(u => u.TitleUsers)
                .ThenInclude(tu => tu.Title);
        }
    }
}
