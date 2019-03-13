using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        public SurveySqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString;

        public IList<Survey> GetSurveys()
        {
            throw new NotImplementedException();
        }

        public bool SubmitSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
