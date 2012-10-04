using System;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class UserConstrainedQuery<Report> : IFetchAReport<Report>
  {
    IDetermineIfAUserMeetsACondition user_specification;
    GetTheCurrentUser_Behaviour get_the_running_user;
    IFetchAReport<Report> original_query;

    public UserConstrainedQuery(IDetermineIfAUserMeetsACondition user_specification, GetTheCurrentUser_Behaviour get_the_running_user, IFetchAReport<Report> original_query)
    {
      this.user_specification = user_specification;
      this.get_the_running_user = get_the_running_user;
      this.original_query = original_query;
    }

    public Report fetch_using(IEncapsulateRequestDetails request)
    {
      if (user_specification.is_authorized(get_the_running_user()))
        return original_query.fetch_using(request);

      throw new NotImplementedException();
    }
  }
}