using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomDataAnnotation.Models;

public class Booking
{
    [Required]
    [Display(Name = "Customer Name")]
    public string Name { get; set; }
    
    [Display(Name = "CheckIn Date")]
    public DateTime CheckIn { get; set; }
    
    [Display(Name = "Checkout Date")]
    [DateIsGreaterThan("CheckIn")]
    public DateTime CheckOut { get; set; }
    
    public int Days
    {
        get
        {
            return (CheckOut - CheckIn).Days;
        }
    }

    [Display(Name = "Hotel Location")]
    public string LocationCode { get; set; }
    
    
}