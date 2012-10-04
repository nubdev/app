using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using System.Security.Permissions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(Authenticator))]
    class AuthenticatorSpecs
    {
        //Write a test to authenticate a user
        //Test authentication code
        //test passing authentication to viewing reports

        //Query: Will only users with certain roles be allowed to view certain data
        //Query: Will I need to use a PrinciplePermission object

        public abstract class concern : Observes<IValidateAUser<>,
                                      ViewAReport<ViewAReportSpecs.AReport>>
        {
        }

   
    }
}
