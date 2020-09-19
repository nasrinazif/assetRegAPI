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
        Task<CompaniesPropertyInquiry> GetCompaniesPropertyAsync(int id);
        Task<List<CompaniesPropertyInquiry>> GetCompaniesPropertiesAsync();
        Task<List<CompaniesPropertyInquiry>> GetCompaniesPropertiesByCompanyAsync(int id);
        Company GetCompany(int id);
        UserType GetUserType(int id);
        User GetUserSync(int id);
        Province GetProvince(int id);
        City GetCity(int id);
        OwnershipDocumentType GetOwnershipDocumentType(int id);
        MapFormat GetMapFormat(int id);
        MapCoordinatesAccuracy GetMapCoordinatesAccuracy(int id);
        BuildingType GetBuildingType(int id);
        Task<int?> GetCompanyCodeForUser(int id);
    }
}
