using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    public class register
    {
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public string Date
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Time is required")]
        [DataType(DataType.Time)]
        public string ConfirmPassword
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Employee name is required")]
        public string EmpName
        {
            get;
            set;
        }
    }
}