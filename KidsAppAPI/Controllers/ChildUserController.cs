using BusinessObject;
using SharedObjects.Authentication;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class ChildUserController : ApiController
    {
        private readonly BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        [HttpPost]
        [ResponseType(typeof(SharedObjects.Accounts.ChildUser))]
        public IHttpActionResult PostUserDetails([FromBody] Token token)
        {
            if (token == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AccessToken x = model.AccessTokens.FirstOrDefault(t => t.Token == token.TokenValue);
            if (x != null)
            {
                SharedObjects.Accounts.ChildUser l = new SharedObjects.Accounts.ChildUser(x.User.ID, x.User.Email, x.User.Participants.FirstOrDefault().ParentName, x.User.Participants.FirstOrDefault().ChildName, x.User.Participants.FirstOrDefault().Surname);
                return Ok(l);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
