using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3.ViewComponents
{
    public class SimpleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string additionalData)
        {
            var data = GetSampleData(additionalData);
            return View(data);
        }
        /// <summary>
        /// This is a simple private method to return some dummy data
        /// </summary>
        /// <returns></returns>

        private List<string> GetSampleData(string additionalData)
        {
            List<string> data = new List<string>();
            data.Add("One");
            data.Add("Two");
            data.Add("Three");
            data.Add(additionalData);
            return data;
        }
    }
}
