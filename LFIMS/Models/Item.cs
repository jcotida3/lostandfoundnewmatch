namespace LFsystem.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // Lost / Found
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public string? Status { get; set; } 
        public int ReporterId { get; set; } 
        public string? StudentName { get; set; } 
        public string? StudentEmail { get; set; } 
        public string ImagePath { get; set; }
        public DateTime DateReported { get; set; }

        public string CategoryName { get; set; }
        public string LocationName { get; set; }
        public string DepartmentName { get; set; }
        public string ReporterName { get; set; }
    }
}
