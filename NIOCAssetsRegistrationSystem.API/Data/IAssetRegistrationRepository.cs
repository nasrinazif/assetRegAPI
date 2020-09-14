using NIOCAssetsRegistrationSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Data
{
    public interface IAssetRegistrationRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();        
        Task<User> GetUser(int id);
        Company GetCompany(int id);
        UserType GetUserType(int id);
    }
}
