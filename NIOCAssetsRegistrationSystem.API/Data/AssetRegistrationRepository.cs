﻿using Microsoft.EntityFrameworkCore;
using NIOCAssetsRegistrationSystem.API.Helper;
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

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public void DeleteUploadedFile(FileUpload uploadedFile)
        {
            _context.Remove(uploadedFile);
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
        public async Task<int> GetCompanyRecordCount(int id)
        {
            var recordCount = await _context.CompaniesPropertyInquiries.Where(c => c.CompanyId == id).CountAsync();

            return recordCount;
        }


        public async Task<List<CompaniesPropertyInquiry>> GetCompaniesAllPropertiesAsync()
        {
            var companiesAllProperties = await _context.CompaniesPropertyInquiries.OrderBy(c => c.CompanyId).ToListAsync();

            return companiesAllProperties;
        }

        public async Task<List<CompaniesPropertyInquiry>> GetCompaniesPropertiesByUserAsync(int id)
        {
            var companyId = await _context.Users.Where(u => u.Id == id).Select(c => c.CompanyId).FirstOrDefaultAsync();

            var companyProperties = await _context.CompaniesPropertyInquiries.Where(c => c.CompanyId == companyId).OrderByDescending(d => d.LatestChanges).ToListAsync();

            return companyProperties;
        }

        public async Task<PagedList<CompaniesPropertyInquiry>> GetPagedCompaniesPropertiesByUserAsync(UserParams userParams)
        {
            var companyId = await _context.Users.Where(u => u.Id == userParams.UserId).Select(c => c.CompanyId).FirstOrDefaultAsync();

            var companyProperties = _context.CompaniesPropertyInquiries.Where(c => c.CompanyId == companyId).OrderByDescending(d => d.LatestChanges).AsQueryable();

            return await PagedList<CompaniesPropertyInquiry>.CreateAsync(companyProperties, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<CompaniesPropertyInquiry>> GetPagedPropertiesByCompanyAsync(UserParams userParams, int id)
        { 
            var companyProperties = _context.CompaniesPropertyInquiries.Where(c => c.CompanyId == id).OrderByDescending(d => d.LatestChanges).AsQueryable();

            return await PagedList<CompaniesPropertyInquiry>.CreateAsync(companyProperties, userParams.PageNumber, userParams.PageSize);
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

        public async Task<List<OwnershipDocumentType>> GetOwnershipDocumentsTypesAsync()
        {
            var ownnershipDocTypes = await _context.OwnershipDocumentTypes.ToListAsync();

            return ownnershipDocTypes;
        }

        public async Task<OwnershipDocumentType> GetOwnershipDocumentsTypeByIdAsync(int id)
        {
            var ownnershipDocType = await _context.OwnershipDocumentTypes.FirstOrDefaultAsync(o => o.Id == id);

            return ownnershipDocType;
        }

        public async Task<List<MapFormat>> GetMapFormatsAsync()
        {
            var mapFormats = await _context.MapFormats.ToListAsync();

            return mapFormats;
        }

        public async Task<MapFormat> GetMapFormatByIdAsync(int id)
        {
            var mapFormat = await _context.MapFormats.FirstOrDefaultAsync(m => m.Id == id);

            return mapFormat;
        }

        public async Task<List<MapCoordinatesAccuracy>> GetMapCoordinatesAccuraciesAsync()
        {
            var mapCoordinatesAccuracies = await _context.MapCoordinatesAccuracies.ToListAsync();

            return mapCoordinatesAccuracies;
        }

        public async Task<MapCoordinatesAccuracy> GetMapCoordinatesAccuracyByIdAsync(int id)
        {
            var mapCoordinatesAccuracy = await _context.MapCoordinatesAccuracies.FirstOrDefaultAsync(m => m.Id == id);

            return mapCoordinatesAccuracy;
        }

        public async Task<List<BuildingType>> GetBuildingTypesAsync()
        {
            var buildingTypes = await _context.BuildingTypes.ToListAsync();

            return buildingTypes;
        }

        public async Task<BuildingType> GetBuildingTypeByIdAsync(int id)
        {
            var buildingType = await _context.BuildingTypes.FirstOrDefaultAsync(b => b.Id == id);

            return buildingType;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            var companies = await _context.Companies.ToListAsync();

            return companies;
        }

        public async Task<List<Owner>> GetOwnersAsync()
        {
            var owners = await _context.Owners.ToListAsync();

            return owners;
        }

        public async Task<List<Beneficiary>> GetBeneficiaryAsync()
        {
            var beneficiaries = await _context.Beneficiaries.ToListAsync();

            return beneficiaries;
        }

        public async Task<List<UserType>> GetUserTypesAsync()
        {
            var userTypes = await _context.UserTypes.ToListAsync();

            return userTypes;
        }

        public async Task<List<UserType>> GetUserTypesMinusAdminAsync()
        {
            var userTypes = await _context.UserTypes.Where(u => u.Id != 3).ToListAsync();

            return userTypes;
        }

        public async Task<User> GetUserByName(string username)
        {
            var user = await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<Confirmation>> GetConfirmations()
        {
            var confirmations = await _context.Confirmations.ToListAsync();

            return confirmations;
        }

        public async Task<List<Confirmation>> GetConfirmationByCompanyId(int id)
        {
            var confirmations = await _context.Confirmations.Where(c => c.CompanyId == id).ToListAsync();

            return confirmations;
        }

        public async Task<Confirmation> GetConfirmation(int id)
        {
            var confirmation = await _context.Confirmations.Where(c => c.Id == id).FirstOrDefaultAsync();

            return confirmation;
        }

        public async Task<Confirmation> GetLatestConfirmationByCompany(int id)
        {
            var confirmation = await _context.Confirmations.Where(c => c.CompanyId == id).OrderByDescending(d => d.ConfirmDate).FirstOrDefaultAsync();

            return confirmation;
        }

        public async Task<FileUpload> GetUploadedFileAsync(int id)
        {
            var uploadedFile = await _context.FileUploads.Where(f => f.Id == id).FirstOrDefaultAsync();

            return uploadedFile;
        }

        public async Task<List<FileUpload>> GetUploadedFilesAsync()
        {
            var uploadedFiles = await _context.FileUploads.ToListAsync();

            return uploadedFiles;
        }

        public async Task<List<FileUpload>> GetUploadedFilesByCompanyIdAsync(int id)
        {
            var uploadedFiles = await _context.FileUploads.Where(f => f.CompanyId == id).ToListAsync();

            return uploadedFiles;
        }

        public async Task<List<User>> GetUsersByCompanyAsync(int id)
        {
            var usersByCompany = await _context.Users.Where(c => c.CompanyId == id).ToListAsync();

            return usersByCompany;
        }

        public Task<Dictionary<int?, int>> GetCompaniesPropertiesCount()
        {
            //var companyProperties = await _context.CompaniesPropertyInquiries.GroupBy(x => x.CompanyId).Where(x => x.Count() > 1).ToListAsync();

            // return companyProperties;

            var result = _context.CompaniesPropertyInquiries.GroupBy(e => e.CompanyId).Select(e => new { e.Key, Count = e.Count() }).ToDictionaryAsync(e => e.Key, e => e.Count);

            return result;
        }

        /* Sync Methods*/

        public Company GetCompany(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            return company;
        }

        public Owner GetOwner(int id)
        {
            var owner = _context.Owners.FirstOrDefault(o => o.Id == id);

            return owner;
        }

        public Beneficiary GetBeneficiary(int id)
        {
            var beneficiary = _context.Beneficiaries.FirstOrDefault(b => b.Id == id);

            return beneficiary;
        }

        public UserType GetUsertype(int id)
        {
            var userType = _context.UserTypes.FirstOrDefault(c => c.Id == id);

            return userType;
        }

        public FileUpload GetUploadedFile(int id)
        {
            var uploadedFile = _context.FileUploads.Where(f => f.Id == id).FirstOrDefault();

            return uploadedFile;
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
