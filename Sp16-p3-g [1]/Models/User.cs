using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Sp16_p3_g__1_.Models
{
    //
    //
    /// just added the models, no MVC controller or views or auth set up
    /// 
    /// //
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Column(TypeName = "varchar")]
        [DataType(DataType.EmailAddress)]
        [StringLength(512, ErrorMessage = "Email can be no more than 512 characters")]
        public string Email { get; set; }

        [Required]
        [DisplayName("First Name")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "First Name can be no more than 512 characters")]
        public string FName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "Last Name can be no more than 512 characters")]
        public string LName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "Password must be at least 7 characters long")]
        [StringLength(128, ErrorMessage = "Password can be no more than 128 characters")]
        public string Password { get; set; }


    }
}