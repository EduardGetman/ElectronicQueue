using ElectronicQueue.WebServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicQueue.WebServer.Controllers;

public class QueuesController : Controller
{
    private readonly IQueuesService _queuesService;

    public QueuesController(IQueuesService queuesService)
    {
        _queuesService = queuesService;
    }

    public IActionResult Index()
    {
        return View(_queuesService.CreateQueuesIndexModel());
    }

    // public IActionResult Queue()
    // {
    //     
    // }
}