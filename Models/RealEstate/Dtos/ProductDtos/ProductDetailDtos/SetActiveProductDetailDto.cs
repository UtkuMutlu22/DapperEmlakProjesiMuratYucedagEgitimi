namespace Models.RealEstate.Dtos.ProductDtos.ProductDetailDtos
{
    public class SetActiveProductDetailDto
    {
        public int ProductDetailID { get; set; }
        public int ProductID { get; set; }
        public int ProductSize { get; set; }
        public int BedroomCount { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        public int GarageSize { get; set; }
        public int BuildYear { get; set; }
        public decimal Price { get; set; }
        public string StructureType { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
