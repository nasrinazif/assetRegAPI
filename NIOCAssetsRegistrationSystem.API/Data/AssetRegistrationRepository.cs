using Microsoft.EntityFrameworkCore;
using NIOCAssetsRegistrationSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Data
{
    public class AssetRegistrationRepository : IAssetRegistrationRepository
    {

        private readonly DataContext _context;
        public AssetRegistrationRepository(DataContext context)
        {
            _context = context;
        }

        /*Generic Methods*/
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        /*Async Methods*/

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(c => c.Company).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<CompaniesPropertyInquiry> GetCompaniesPropertyAsync(int id)
        {
            var companyProperty = await _context.CompaniesPropertyInquiries.FirstOrDefaultAsync(p => p.Id == id);

            return companyProperty;
        }

        /* Sync Methods*/

        public Company GetCompany(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            return company;
        }

        public UserType GetUserType(int id)
        {
            var userType = _context.UserTypes.FirstOrDefault(t => t.Id == id);

            return userType;
        }

        public User GetUserSync(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }
        public Province GetProvince(int id)
        {
            var province = _context.Provinces.FirstOrDefault(p => p.Id == id);

            return province;
        }

        public City GetCity(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == id);

            return city;
        }

        public OwnershipDocumentType GetOwnershipDocumentType(int id)
        {
            var ownershipDocType = _context.OwnershipDocumentTypes.FirstOrDefault(o => o.Id == id);

            return ownershipDocType;
        }

        public MapFormat GetMapFormat(int id)
        {
            var mapFormat = _context.MapFormats.FirstOrDefault(m => m.Id == id);

            return mapFormat;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
