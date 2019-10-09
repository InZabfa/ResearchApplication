using System;
using System.Web.Http;

namespace KidsAppAPI.Controllers
{
    public class InfoController : ApiController
    {

        private BusinessObject.DefaultModel model = new BusinessObject.DefaultModel();

        public string Get()
        {
            return "API is working successfully.";
        }


        public IHttpActionResult Put(string location)
        {
            BusinessObject.Experiment experiment = model.Experiments.Create();
            //experiment.DateCreated = DateTime.Now;
            //experiment.Location = "London";
            //experiment.ResearcherID = 1;

            //model.Experiments.Add(experiment);
            //model.SaveChanges();
            return Ok();
        }
    }
}
