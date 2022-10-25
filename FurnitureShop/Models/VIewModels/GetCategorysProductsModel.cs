namespace FurnitureShop.Models.VIewModels
{
    public class GetCategorysProductsModel
    {
        public int CategoryId { get; set; } = 1;
        public int CurrPage { get; set; } = 1;
        public List<int?> Companies { get; set; } = new List<int?>();

    }
}
