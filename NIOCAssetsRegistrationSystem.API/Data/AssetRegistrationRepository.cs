﻿using Microsoft.EntityFrameworkCore;
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

        public void DeleteCompanyPropertyInquiry(CompaniesPropertyInquiry companiesPropertyInquiry)
        {
            _context.Remove(companiesPropertyInquiry);
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

        public async Task<List<CompaniesPropertyInquiry>> GetCompaniesPropertiesAsync()
        {
            var companyProperties = await _context.CompaniesPropertyInquiries.ToListAsync();

            return companyProperties;
        }

        public async Task<List<CompaniesPropertyInquiry>> GetCompaniesPropertiesByCompanyAsync(int id)
        {
            var companyProperties = await _context.CompaniesPropertyInquiries.Where(c => c.CompanyId == id).ToListAsync();

            return companyProperties;
        }

        public async Task<List<CompaniesPropertyInquiry>> GetCompaniesPropertiesByUserAsync(int id)
        {
            var companyId = await _context.Users.Where(u => u.Id == id).Select(c => c.CompanyId).FirstOrDefaultAsync();

            var companyProperties = await _context.CompaniesPropertyInquiries.Where(c => c.CompanyId == companyId).ToListAsync();

            return companyProperties;
        }

        public async Task<int?> GetCompanyCodeForUser(int id)
        {
            var companyCode = await _context.Users.Where(c => c.Id == id).Select(c => c.CompanyId).FirstOrDefaultAsync();

            return companyCode;
        }

        public async Task<List<Province>> GetProvincesAsync()
        {
            var provinces = await _context.Provinces.ToListAsync();

            return provinces;
        }

        public async Task<Province> GetProvinceByIdAsync(int id)
        {
            var province = await _context.Provinces.FirstOrDefaultAsync(p => p.Id == id);

            return province;
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            var cities = await _context.Cities.ToListAsync();

            return cities;
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);

            return city;
        }

        public async Task<List<City>> GetCitiesByProvinceIdAsync(int id)
        {
            var cities = await _context.Cities.Where(p => p.ProvinceId == id).ToListAsync();

            return cities;
        }

        /* Sync Methods*/

        public Company GetCompany(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            return company;
        }

        public CompaniesPropertyInquiry GetCompaniesProperty(int id)
        {
            var companyProperty = _context.CompaniesPropertyInquiries.FirstOrDefault(p => p.Id == id);

            return companyProperty;
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

        public MapCoordinatesAccuracy GetMapCoordinatesAccuracy(int id)
        {
            var mapCoordinatesAccuracy = _context.MapCoordinatesAccuracies.FirstOrDefault(m => m.Id == id);

            return mapCoordinatesAccuracy;
        }

        public BuildingType GetBuildingType(int id)
        {
            var buildingType = _context.BuildingTypes.FirstOrDefault(b => b.Id == id);

            return buildingType;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
