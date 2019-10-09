using SharedObjects.DesignGame;
using SharedObjects.Response;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace KidsAppAPI.Controllers
{
    public class AddWordController : ApiController
    {
        private BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        [ResponseType(typeof(Response))]
        public IHttpActionResult Post([FromBody] AddWordDetails addWordDetails)
        {
            int researcherID = model.Researchers.FirstOrDefault(x => x.UserID == addWordDetails.UserID).ID;

            BusinessObject.InteractiveResource image = model.InteractiveResources.Create();
            BusinessObject.Word wordInfo = model.Words.Create();

            image.Resource = addWordDetails.Contents;
            image.ResearcherID = researcherID;
            image.WordID = wordInfo.ID;

            wordInfo.Word1 = addWordDetails.Word;
            wordInfo.ResearcherID = researcherID;
            wordInfo.DifficultyID = addWordDetails.Difficulty;
            wordInfo.InteractiveResources.Add(image);

            model.InteractiveResources.Add(image);
            model.Words.Add(wordInfo);
            model.SaveChanges();
            return Ok(new Response($"Word '{addWordDetails.Word}' added successfully."));
        }
    }
}
