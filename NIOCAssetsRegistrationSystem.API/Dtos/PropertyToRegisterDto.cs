using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class PropertyToRegisterDto
    {
        public int Id { get; set; }
        public string PropertyTitle { get; set; }
        public string UniqueFileCode { get; set; }
        public decimal? ArenaArea { get; set; }
        public bool? OwnershipDocument { get; set; }
        public bool? ExistingMap { get; set; }
        public bool? ExistingBuilding { get; set; }
        public decimal? BuildingArea { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
        public DateTime? LatestChanges { get; set; }        
        public int? CompanyId { get; set; }
        public int? OwnerId { get; set; }
        public int? BeneficiaryId { get; set; }
        public int? UserId { get; set; }
        public int? ProvinceId { get; set; }        
        public int? CityId { get; set; }
        public int? OwnershipDocumentTypeId { get; set; }        
        public int? MapFormatId { get; set; }        
        public int? MapCoordinatesAccuracyId { get; set; }        
        public int? BuildingTypeId { get; set; }
        public byte[] UploadedFile { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
