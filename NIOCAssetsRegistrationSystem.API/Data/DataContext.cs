using Microsoft.EntityFrameworkCore;
using NIOCAssetsRegistrationSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<OwnershipDocumentType> OwnershipDocumentTypes { get; set; }
        public DbSet<MapFormat> MapFormats { get; set; }
        public DbSet<MapCoordinatesAccuracy> MapCoordinatesAccuracies { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<CompaniesPropertyInquiry> CompaniesPropertyInquiries { get; set; }
        public DbSet<Confirmation> Confirmations { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
    }
}
