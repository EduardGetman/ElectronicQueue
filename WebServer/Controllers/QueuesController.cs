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
        var viewModel = _queuesService.CreateQueuesIndexModel();
        return View(viewModel);
    }
    public IActionResult Queue(long providerId)
    {
        return View(_queuesService.CreateQueuesQueueModel(providerId));
    }
}