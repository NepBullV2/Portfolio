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
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
    }
}
