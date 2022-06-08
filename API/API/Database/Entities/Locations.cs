namespace API.Database.Entities
{
    public class Locations
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Postal { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
    }
}
