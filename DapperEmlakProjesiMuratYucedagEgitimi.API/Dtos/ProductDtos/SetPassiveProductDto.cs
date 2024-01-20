﻿namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.ProductDtos
{
    public class SetPassiveProductDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Decimal Price { get; set; }
        public string CoverImage { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int ProductCategory { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int EmployeeId { get; set; }
    }
}
