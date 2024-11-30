namespace Lab4DbAPI.Models.DTO
{
    public class ProjectCreateDTO
    {
        public string ProjectName { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal Budget { get; set; }

        public string Address { get; set; } = null!;

        public string ProjectStatus { get; set; } = null!;
    }
}
