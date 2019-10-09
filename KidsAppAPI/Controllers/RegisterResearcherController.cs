using SharedObjects.Accounts;
using SharedObjects.Authentication;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class RegisterResearcherController : ApiController
    {
        private readonly BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        [ResponseType(typeof(Token))]
        public IHttpActionResult Post([FromBody] ResearcherAccountDetails details)
        {

            //adds information to the researcher table 
            BusinessObject.Researcher researcher = model.Researchers.Create();
            researcher.Deparment = details.Department;
            researcher.Name = details.FirstName;
            researcher.Surname = details.LastName;

            //adds information to the user table (used fot the log in)
            BusinessObject.User login = model.Users.Create();
            login.Password = details.ConfirmPassword;
            login.Email = details.Email;
            login.MobileNumber = details.MobileNumber;
            researcher.User = login;

            bool hasAccount = model.Users.Any(u => u.Email == details.Email);

            //adds information to the token tabe to log the researcher in as soon as they have created the account
            BusinessObject.AccessToken token = model.AccessTokens.Create();
            token.Token = Guid.NewGuid().ToString();
            token.ExpiryDate = DateTime.Now.AddDays(1);
            login.AccessTokens.Add(token);

            if (!hasAccount)
            {
                model.Researchers.Add(researcher);
                model.AccessTokens.Add(token);
                model.SaveChangesAsync();
            }

            Token t = new Token
            {
                ExpiryDate = token.ExpiryDate,
                TokenValue = token.Token,
                UserID = 0
            };

            return Ok(t);
        }
    }
}
