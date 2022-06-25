using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingApp.Models
{

   
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ProjectId")]
        [Required(ErrorMessage = "This field is required.")]
        public int ProjectId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime ExpenseDate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "DECIMAL(19,2)")]
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "This field is required.")]
        public decimal Amount { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Display(Name = "Description")]
        [StringLength(350, ErrorMessage = "Max 350 characters.")]
        public string Description { get; set; }
    }

    public class Customers
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name!")]
        public string Name { get; set; }
    }

    public class Projects
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter project name!")]
        public string Name { get; set; }
    }

    public class ViewData
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Column(TypeName = "DateTime")]
        [DataType(DataType.Date)]
        public string ExpenseDate { get; set; }
        public string Customer { get; set; }
        public string Project { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "DECIMAL(19,2)")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
 