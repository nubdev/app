namespace app.web.core.aspnet
{
  public interface IFetchAReport<out Report>
  {
    Report fetch_using(IEncapsulateRequestDetails request); 
  }
}