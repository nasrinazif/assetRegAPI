using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class PropertiesAllFieldsForAdminToReturnDto
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string UniqueFileCode { get; set; }
        public string PropertyTitle { get; set; }        
        public string OwnerName { get; set; }        
        public string BeneficiaryName { get; set; }
        public decimal? ArenaArea { get; set; }
        public string Usage { get; set; }
        public bool? OwnershipDocument { get; set; }         
        public string OwnershipDocumentTypeName { get; set; }
        public bool? ExistingMap { get; set; }        
        public string MapFormatName { get; set; }        
        public string MapCoordinatesAccuracyName { get; set; }
        public bool? ExistingBuilding { get; set; }        
        public string BuildingTypeName { get; set; }
        public decimal? BuildingArea { get; set; }        
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string Description { get; set; }
        public DateTime? LatestChanges { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
    }
}
