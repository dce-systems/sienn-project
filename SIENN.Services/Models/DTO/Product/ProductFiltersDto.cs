﻿using System.Collections.Generic;

namespace SIENN.Services.Models.DTO.Product
{
    public class ProductFiltersDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool? Availability { get; set; }
        public List<int> TypeFilter { get; set; } = new List<int>();
        public List<int> CategoryFilter { get; set; } = new List<int>();
        public List<int> UnitFilter { get; set; } = new List<int>();
        public string SearchCriteria { get; set; }
        public bool OrderById { get; set; } = true;
        public bool OrderByCode { get; set; }
        public bool OrderByCreated { get; set; }
        public bool OrderByUpdated { get; set; }
        public bool OrderByDeliveryDate { get; set; }
        public bool OrderByPrice { get; set; }
        public bool Ascending { get; set; }
    }
}
