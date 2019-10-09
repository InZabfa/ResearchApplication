using SharedObjects.Accounts;
using SharedObjects.Response;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class CreateParticipantController : ApiController
    {
        private readonly BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        [ResponseType(typeof(Response))]
        public IHttpActionResult Post([FromBody] CreateParticipantAccount details)
        {
            BusinessObject.User user = model.Users.Create();
            user.Email = details.Email;
            user.Password = details.ConfirmPassword;
            user.MobileNumber = details.MobileNumber;

            BusinessObject.Participant participant = model.Participants.Create();
            participant.ChildName = details.FirstNameChild;
            participant.ParentName = details.FirstNameParent;
            participant.Surname = details.LastName;

            bool hasAccount = model.Users.Any(u => u.Email == details.Email);

            if (!hasAccount)
            {
                model.Users.Add(user);
                model.Participants.Add(participant);
                model.SaveChangesAsync();
                return Ok(new Response("New Participant was successfully added."));
            }
            else
            {
                return BadRequest("Could not complete your request");
            } 
        }
    }
}
