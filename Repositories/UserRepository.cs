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

        public void AddTitle(int titleId, int userId);

        public void RemoveTitle(int titleId, int userId);
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

        public void AddTitle(int titleId, int userId)
        {
            var titleUser = new TitleUser
            {
                TitleId = titleId,
                UserId = userId
            };

            _context.TitleUser.Add(titleUser);

            _context.SaveChanges();
        }

        public void RemoveTitle(int titleId, int userId)
        {
            var titleUser = _context.TitleUser
                .Where(tu => tu.TitleId == titleId && tu.UserId == userId)
                .Single();

            _context.TitleUser.Remove(titleUser);

            _context.SaveChanges();
        }
    }
}
