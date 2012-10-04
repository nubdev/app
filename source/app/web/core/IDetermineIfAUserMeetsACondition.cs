using System.Security.Principal;

namespace app.web.core
{
  public interface IDetermineIfAUserMeetsACondition
  {
    bool is_authorized(IPrincipal principal);
  }
}