using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Models
{
    public class CompaniesPropertyInquiry
    {
        public int Id { get; set; }
        public string PropertyTitle { get; set; }
        public decimal? ArenaArea { get; set; }
        public bool? OwnershipDocument { get; set; }
        public bool? ExistingMap { get; set; }
        public bool? ExistingBuilding { get; set; }
        public decimal? BuildingArea { get; set; }
        public string Description { get; set; }
        public DateTime? LatestChanges { get; set; }
    }
}
