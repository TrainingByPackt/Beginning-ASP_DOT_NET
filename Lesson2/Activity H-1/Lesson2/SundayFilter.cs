using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2
{
    public class SundayFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                context.Result = new ContentResult()
                {
                    Content = "Sorry only on sundays!"
                };

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }

}
