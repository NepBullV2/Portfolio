namespace API.DTO.Request
{
    public class Request_Locations
    {
        [Required]
        [Range(1, 9999, ErrorMessage = "Invalid Postal")]
        public int Postal { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Must be less than 50 char")]
        [MinLength(1, ErrorMessage = "Must have at least one char")]
        public string City { get; set; }
    }
}
