using System.ComponentModel.DataAnnotations;

namespace CroudeDemoMvc.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
       // [Required]
        public string Name { get; set; }
        //[Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
    }
    public enum City
    {
        Surat,
        Pune,
        kolkata,
        Ahemdabad,
        Delhi,
        hyderabad,
        lucknow,
        indor,
    }

}

