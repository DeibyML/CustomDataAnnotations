using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomDataAnnotation.Models;

namespace CustomDataAnnotation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult Index(Booking booking)
    {
        // if (ModelState.IsValid && ValidateBookingModel(booking))
        if (ModelState.IsValid)
        {
            return RedirectToAction("Confirm", booking);
        }
        return View(booking);
    }

    public ActionResult Confirm()
    {
        ViewBag.Message = "Your booking is confirmed";
        return View();
    }

    public bool ValidateBookingModel(Booking booking)
    {
        bool isValid = true;

        if (booking.CheckIn < DateTime.Now)
        {
            ModelState.AddModelError("", "Checkin can not be in the past");
            isValid = false;
        }
        
        if (!IsValidDate(booking.CheckIn))
        {
            ModelState.AddModelError("Checkin","CheckIn Date cannot be in the past");
            isValid = false;
        }
        
        if (!IsValidDate(booking.CheckIn))
        {
            ModelState.AddModelError("Checkout","CheckOut Date cannot be in the past");
            isValid = false;
        }

        if (booking.CheckIn > booking.CheckOut)
        {
            ModelState.AddModelError("compare", "The CheckOut date must be greater than CheckIn date");
            isValid = false;
        }

        return isValid;
    }
    
    public bool IsValidDate(DateTime dt)
    {
        bool isValid = false;

        if (dt > DateTime.Now)
        {
            return true;
        }
        
        return isValid;
    }

    public bool CompareDates(DateTime initDate, DateTime finalDate)
    {
        bool isValid = false;

        if (finalDate > initDate)
            return true;

        return isValid;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}