using SharedObjects.EditExistingAccount;
using SharedObjects.Response;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class SaveChangesResearcherController : ApiController
    {
        private readonly BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();


        [ResponseType(typeof(Response))]
        public IHttpActionResult Post([FromBody] ResearcherAccountChanges accountChanges)
        {
            BusinessObject.User user = model.Users.FirstOrDefault(i => i.ID == accountChanges.UserID);
            BusinessObject.AccessToken token = model.AccessTokens.FirstOrDefault(t => t.Token == accountChanges.Token && t.ExpiryDate > DateTime.Now && t.UserID == accountChanges.UserID);
            if (user != null && token != null)
            {
                if (!string.IsNullOrWhiteSpace(accountChanges.Email))
                {
                    user.Email = accountChanges.Email;
                }

                if (!string.IsNullOrWhiteSpace(accountChanges.ConfirmPassword))
                {
                    user.Password = accountChanges.ConfirmPassword;
                }

                model.SaveChanges();
                return Ok(new Response("Account details successfully updated."));
            }
            else
            {
                if (token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return BadRequest("Could not find the specified account to apply the given changes.");
                }
            }
        }
    }
}
