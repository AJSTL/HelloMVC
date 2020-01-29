using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        //static int countGreetings;
        //Dictionary<string, int> greetDict = new Dictionary<string, int>();
        
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index() 
        {
                string html = "<form method='post'>" +
                //removed action='/Hello/Display' with additon of [HttpPost] and [HttpGet] route attributes
                "<input type = 'text' name ='name' />" +

                "<select name='lang' style='font-family: Helvetica, Sans-Serif''>" +
                "<option value='French'>French</option>" +
                "<option value='English'>English</option>" +
                "<option value='Spanish'>Spanish</option>" +
                "<option value='German'>German</option>" +
                "<option value='Hawaiian'>Hawaiian</option>" +
                "<option value='Emoji'>Emoji</option>"+
                "</select>"+

                "<input type = 'submit' value='Greet me!'/>" +
                "</form>";

            return Content(html, "text/html");
        }

        [Route("/Hello")] // overrides the default routing
        [HttpPost]
        public IActionResult Display(string name, string lang)
        {
            return Content(CreateMessage(name, lang),"text/html");

        }
        /* Include a new(public static) method, CreateMessage, in HelloController that takes a name string as well as a language string. 
         * Based on the language string, you'll return the proper welcome message to be displayed. 
        */
        public static string CreateMessage(string name, string lang)
        {
            Dictionary<string, string> greetingWord = new Dictionary<string, string>();
            greetingWord.Add("French", "Bonjour");
            greetingWord.Add("English", "Hello");
            greetingWord.Add("Spanish", "Hola");
            greetingWord.Add("German", "Hallo");
            greetingWord.Add("Hawaiian", "Aloha");
            greetingWord.Add("Emoji", "<html>&#x1F44B;</html>");
            
            return string.Format("<h1 style='font-family: Helvetica, Sans-Serif'>{1}, {0}!</h1>", name, greetingWord[lang]);
        }

        // /Hello/Goodbye
        // alter the route to this controller to be /Hello/Aloha
        //[Route("/Hello/Aloha")] // overrides "Goodbye()" listed below



        // Handle requests to /Hello/NAME (URL Segment)
        // [Route("/Hello/{name}")]
        // public IActionResult Index2(string name, string lang)
        //{
        //     return Content(string.Format("<h1>{1}, {0}</h1>", name, lang), "text/html");
        //}
        public IActionResult Goodbye()
        {
            return Content("Goodnight, Moon.");
        }
    }
}
