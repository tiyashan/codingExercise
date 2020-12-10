using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptialPlatform_Shanttiya.Models
{
    public class Account
    {
        [Key]
        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Enter Account Number")]
        public string AccountNumber { get; set; }
        [Display(Name = "Account Holder")]
        [Required(ErrorMessage = "Enter Account Holder Name")]
        public string AccountHolder { get; set; }
        [Display(Name = "Current Balance")]
        [Required(ErrorMessage = "Enter Current Balance")]
        public Decimal CurrentBalance { get; set; }
        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Enter Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Opening Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OpeningDate { get; set; }
        [Display(Name = "Active")]
        public Boolean IsActive { get; set; }
        public List<Account> ShowallAccount { get; set; }
    }
}