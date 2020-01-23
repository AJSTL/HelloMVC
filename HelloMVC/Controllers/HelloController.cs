using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index() 
        {

            string html = "<form method='post'>" + 
                //removed action='/Hello/Display' with additon of [HttpPost] and [HttpGet] route attributes
                "<input type = 'text' name ='name' />"+

                "<select name='lang'>" +
                "<option value='French'>French</option>" +
                "<option value='English'>English</option>" +
                "<option value='Spanish'>Spanish</option>" +
                "<option value='German'>German</option>" +
                "<option value='Hawaiian'>Hawaiian</option>" +
                "</select>"+

                "<input type = 'submit' value='Greet me!'/>" +
                "</form>";

            return Content(html, "text/html");
        }

        // Hello
        [Route("/Hello")] // overrides the default routing
        [HttpPost]
        public IActionResult Display(string name, string lang)
        {
            Dictionary<string, string> greetingWord = new Dictionary<string, string>();
            greetingWord.Add("French", "Bonjour");
            greetingWord.Add("English", "Hello");
            greetingWord.Add("Spanish", "Hola");
            greetingWord.Add("German", "Hallo");
            greetingWord.Add("Hawaiian", "Aloha");

            return Content(string.Format("<h1>{1}, {0}</h1>", name, greetingWord[lang]), "text/html");
        }

        // /Hello/Goodbye
        // alter the route to this controller to be /Hello/Aloha
        //[Route("/Hello/Aloha")] // overrides "Goodbye()" listed below
        

        // Handle requests to /Hello/NAME (URL Segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name, string lang)
        {
            return Content(string.Format("<h1>{1}, {0}</h1>", name, lang), "text/html");
        }
        public IActionResult Goodbye()
        {
            return Content("Goodnight, Moon.");
        }
    }
}
