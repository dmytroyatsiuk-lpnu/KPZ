namespace Lab4DbAPI.Models.DTO
{
    public class MaterialCreateDTO
    {
        public string MaterialName { get; set; } = null!;

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int SupplierId { get; set; }

        public int ProjectId { get; set; }
    }
}
