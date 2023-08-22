using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWork.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerProcessService _customerProcessService;
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerProcessService customerProcessService, ICustomerService customerService)
        {
            _customerProcessService = customerProcessService;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcess customerProcess)
        {
            var valueSender = _customerService.TGetByID(customerProcess.SenderId);
            var valueReceiver = _customerService.TGetByID(customerProcess.ReveiverId);

            valueReceiver.CustomerBalance += customerProcess.Amount;
            valueSender.CustomerBalance -= customerProcess.Amount;

            _customerProcessService.TInsert(customerProcess);

            List<Customer> modified = new List<Customer>
            {
                valueSender,
                valueReceiver
            };

            _customerService.TMultiUpdate(modified);
            return RedirectToAction("CustomerProcessList");
        }

        
    }
}
