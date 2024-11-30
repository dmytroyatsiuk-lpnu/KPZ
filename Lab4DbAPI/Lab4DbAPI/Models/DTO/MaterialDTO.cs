namespace Lab4DbAPI.Models.DTO
{
    public class MaterialDTO
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; } = null!;

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int SupplierId { get; set; }

        public int ProjectId { get; set; }

        public decimal? MaterialCost { get; set; }
    }
}
