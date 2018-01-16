using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RestBuy.Application.Services;
using RestBuy.Application.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Web.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        readonly IRegistrationService registrationService;

        public AccountsController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpGet]
        public IActionResult RegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(
             NewUserViewModel newUserViewModel,
             CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.registrationService.RegisterUser(newUserViewModel, cancellationToken);
                    return View("SuccessfullyRegistered");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(nameof(newUserViewModel.Username), ex.Message);
                    SetSkippedIfValid(nameof(newUserViewModel.Password));
                    SetSkippedIfValid(nameof(newUserViewModel.ConfirmPassword));

                    void SetSkippedIfValid(string key)
                    {
                        if (ModelState.GetFieldValidationState(key) == ModelValidationState.Valid)
                        {
                            ModelState.MarkFieldSkipped(key);
                        }
                    }
                }
            }
            return View(nameof(RegistrationForm));
        }


    }
}
