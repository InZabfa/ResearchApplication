using BusinessObject;
using SharedObjects.Authentication;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();
        
        //This first line tells the Web API what type of HTTP request it accepts.
        [HttpPost]
        //This line, tells the client or your mobile app what the response type is gonna be - either string etc. Here its a loginToken class
        [ResponseType(typeof(SharedObjects.Accounts.User))]
        public IHttpActionResult PostUserDetails([FromBody] Token token)
        {
            //If the post data is nothing, then tell the client/mobile app that it was a bad request.
            if (token == null)
            {
                return BadRequest();
            }


            //If the web api couldn't create the LoginDetails object with the posted data, then it was a bad request.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccessToken x = model.AccessTokens.FirstOrDefault(t => t.Token == token.TokenValue);
            if (x != null)
            {
                SharedObjects.Accounts.User l = new SharedObjects.Accounts.User(x.User.ID, x.User.Email, x.User.Researchers.FirstOrDefault().Name, x.User.Researchers.FirstOrDefault().Surname);
                return Ok(l);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
