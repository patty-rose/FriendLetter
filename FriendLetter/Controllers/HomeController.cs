using Microsoft.AspNetCore.Mvc;
using FriendLetter.Models;

namespace FriendLetter.Controllers
{
  public class HomeController : Controller //HomeController will inherit or extend functionality from ASP.NET Core's built-in Controller class that we import with our using statement.
  {
    [Route("/hello")]//route decorator- instead of /home/hello we now just need /hello . route decorator defines route. The view does not care about the route decorator. It will follow the method name that invokes it.
    public string Hello() { return "Hello friend!"; }
    //the Hello method represents a route in our App. Creates a special path WEBSITe.com/home/hello. Home comes from the controller -HomeController-. method runs when user navigates to the path.

    [Route("/goodbye")]
    public string Goodbye() { return "Goodbye friend."; }

    [Route("/")] //home page or root path
    public ActionResult Letter()
    { 
      LetterVariable myLetterVariable = new LetterVariable();
      myLetterVariable.Recipient = "Lina";
      myLetterVariable.Sender = "Jasmine";
      return View(myLetterVariable);
    }
    //ActionResult is built in method that handles rendering views in this case Letter() matches Letter.cshtml in the Views/Home folder. return View() when route is invoked it will return a view.

    [Route("/form")]
    public ActionResult Form() 
    { 
      return View(); 
    }

    [Route("/postcard")]
    public ActionResult Postcard(string recipient, string sender)
    {
      LetterVariable myLetterVariable = new LetterVariable();
      myLetterVariable.Recipient = recipient;
      myLetterVariable.Sender = sender;
      return View(myLetterVariable);
    }

    // Because we told our <form> in Form.cshtml to have an action="/postcard", the route matching the /postcard path is automatically invoked. That's our Postcard() route.
    // Our form has two <input>s, one with a name="sender" attribute and another with a name="recipient" attribute. These are the parameters we pass into the route method.
    //This route can automatically access those values via the parameters we pass into the Postcard() route method.
    // application is looking for name attributes, not the id
  }
}