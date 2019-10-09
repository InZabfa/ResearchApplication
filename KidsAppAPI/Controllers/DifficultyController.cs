using BusinessObject;
using SharedObjects.Authentication;
using SharedObjects.DesignGame;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class DifficultyController : ApiController
    {
        private readonly BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        [HttpPost]
        [ResponseType(typeof(SharedObjects.DesignGame.Difficulties))]
        public IHttpActionResult PostLevelDifficulty([FromBody] Token token)
        {
            if (token == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            AccessToken x = model.AccessTokens.FirstOrDefault(t => t.Token == token.TokenValue && t.ExpiryDate > DateTime.Now);

            Difficulties p = new Difficulties();

            if (x != null)
            {
                 model.Difficulties.ToList().ForEach(i => p.Values.Add(i.ID, i.Name));
                 return Ok(p);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
