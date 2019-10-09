using SharedObjects.EditExistingAccount;
using SharedObjects.Response;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class SaveChangesChildAccountController : ApiController
    {
        private readonly BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        [ResponseType(typeof(Response))]
        public IHttpActionResult Post([FromBody] ChildAccountChanges childAccountChanges)
        {
            BusinessObject.User user = model.Users.FirstOrDefault(i => i.ID == childAccountChanges.UserID);
            BusinessObject.AccessToken token = model.AccessTokens.FirstOrDefault(t => t.Token == childAccountChanges.Token);

            if (user != null && token != null)
            {
                if (!string.IsNullOrWhiteSpace(childAccountChanges.Email))
                {
                    user.Email = childAccountChanges.Email;
                }

                if (!string.IsNullOrWhiteSpace(childAccountChanges.ConfirmPassword))
                {
                    user.Password = childAccountChanges.ConfirmPassword;
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
