using SharedObjects.Authentication;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class ResearcherLoginController : ApiController
    {
        private BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        //This first line tells the Web API what type of HTTP request it accepts.
        [HttpPost]
        //This line, tells the client or your mobile app what the response type is going to be - either string etc. Here its a loginToken class
        [ResponseType(typeof(Token))]
        public IHttpActionResult Post([FromBody] Credentials Login)
        {
            //If the post data is nothing, then tell the client/mobile app that it was a bad request.
            if (Login == null)
            {
                return BadRequest();
            }


            //If the web api couldn't create the LoginDetails object with the posted data, then it was a bad request.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Check login

            BusinessObject.User user = model.Users.FirstOrDefault(x => x.Email == Login.email && x.Password == Login.password);
            
            bool isResearcher = model.Researchers.Any(x => x.UserID == user.ID);

            if (user != null && isResearcher)
            {

                BusinessObject.AccessToken existingToken = model.AccessTokens.FirstOrDefault(t => t.UserID == user.ID && t.ExpiryDate > DateTime.Now);

                if (existingToken != null)
                {
                    return Ok(new Token(existingToken.Token, existingToken.UserID));
                }
                else
                {
                    BusinessObject.AccessToken token = model.AccessTokens.Create();
                    token.Token = Guid.NewGuid().ToString();
                    token.ExpiryDate = DateTime.Now.AddDays(1);
                    token.User = user;
                    model.AccessTokens.Add(token);

                    string tokenString = token.Token;

                    model.SaveChangesAsync();
                    return Ok(new Token(tokenString, token.UserID, token.ExpiryDate));
                }
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
