namespace Lab4DbAPI.Models.DTO
{
    public class SupplierCreateDTO
    {
        public string SupplierName { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
