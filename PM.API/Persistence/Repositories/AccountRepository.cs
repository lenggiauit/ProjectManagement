using Microsoft.EntityFrameworkCore;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(PMContext context) : base(context) { }
         

        public async Task<ResultCode> CheckEmail(string email)
        {
            var existUser = await _context.User.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
            if (existUser != null)
            { 
                return  ResultCode.Invalid; 
            }
            else
            {
                return  ResultCode.Valid;
            }
        }

        public async Task<ResultCode> CheckUserName(string userName)
        {
            var existUser = await _context.User.Where(u => u.UserName.Equals(userName)).FirstOrDefaultAsync();
            if (existUser != null)
            {
                return  ResultCode.Invalid;
            }
            else
            {
                return ResultCode.Valid;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.User.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.User.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<User> Login(string name, string password)
        {
            return await _context.User.AsQueryable().Where(a => (a.UserName.Equals(name) || a.Email.Equals(name)) && a.Password.Equals(password))
            .Select(acc => new User()
            {
                Id = acc.Id, 
                UserName = acc.UserName, 
                Email = acc.Email,
                Avatar = acc.Avatar,
                RoleId = acc.RoleId,
                Role = _context.Role.Where(r => r.Id == acc.RoleId).FirstOrDefault(),
                //Permissions = _context.PermissionInRole.Where(pir => pir.RoleId == acc.RoleId)
                //            .Join(_context.Permission,
                //            perInRole => perInRole.PermissionId,
                //            per => per.Id,
                //            (perInRole, per) => per).ToList() 
            }).FirstOrDefaultAsync();
        }

        public async Task<User> LoginWithGoogle(string email)
        {
            return await _context.User.AsQueryable().Where(a => a.Email.Equals(email))
            .Select(acc => new User()
            {
                Id = acc.Id,
                UserName = acc.UserName,
                Email = acc.Email,
                Avatar = acc.Avatar,
                RoleId = acc.RoleId,
                Role = _context.Role.Where(r => r.Id == acc.RoleId).FirstOrDefault(),
                //Permissions = _context.PermissionInRole.Where(pir => pir.RoleId == acc.RoleId)
                //            .Join(_context.Permission,
                //            perInRole => perInRole.PermissionId,
                //            per => per.Id,
                //            (perInRole, per) => per).ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<ResultCode> Register(string name, string email, string password)
        {
            var existUser = await _context.User.Where(u => u.UserName.Equals(name) || u.Email.Equals(email)).FirstOrDefaultAsync();
            if (existUser != null)
            {
                if(existUser.Email.Equals(email))
                    return ResultCode.RegisterExistEmail;
                else
                    return ResultCode.RegisterExistUserName;
            }
            else
            {
                User newUser = new User()
                {
                    Id= Guid.NewGuid(),
                    UserName = name,
                    Email = email,
                    IsActive = true,
                    Password = password,
                    CreatedDate = DateTime.Now, 
                    CreatedBy = Guid.Empty, 
                };
                _context.User.Add(newUser);
                await  _context.SaveChangesAsync();
                return ResultCode.Success;
            }

        }

        public async Task UpdateUserPasword(Guid id, string newPassword)
        {
            var user = await _context.User.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
            if(user != null)
            {
                user.Password = newPassword;
                _context.Update(user);
            }
        }
    }
}
