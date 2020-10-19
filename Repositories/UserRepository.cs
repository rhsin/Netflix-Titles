using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTitle.Data;
using MvcTitle.Models;

namespace MvcTitle.Repositories
{
    public interface IUserRepository
    {
        public IQueryable<User> GetUsers();

        public Task<string> AddTitle(int titleId, int userId);

        public Task<string> RemoveTitle(int titleId, int userId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly MvcTitleContext _context;

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

        public async Task<string> AddTitle(int titleId, int userId)
        {
            var titleUser = new TitleUser
            {
                TitleId = titleId,
                UserId = userId
            };

            try
            {
                _context.TitleUser.Add(titleUser);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Title Added To Account!";
        }

        public async Task<string> RemoveTitle(int titleId, int userId)
        {
            try
            {
                var titleUser = await _context.TitleUser
                    .Where(tu => tu.TitleId == titleId && tu.UserId == userId)
                    .SingleAsync();

                _context.TitleUser.Remove(titleUser);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Title Removed From Account!";
        }
    }
}
