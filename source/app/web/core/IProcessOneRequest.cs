namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void process(IEncapsulateRequestDetails request);
    bool can_handle(IEncapsulateRequestDetails request);
  }

  public class RequestCommand : IProcessOneRequest
  {
    MatchRequest_Behaviour request_specification;
    ISupportAUserFeature feature;

    public RequestCommand(MatchRequest_Behaviour behavior, ISupportAUserFeature feature)
    {
      this.request_specification = behavior;
      this.feature = feature;
    }

    public void process(IEncapsulateRequestDetails request)
    {
      feature.process(request);
    }

    public bool can_handle(IEncapsulateRequestDetails request)
    {
      return request_specification(request);
    }
  }
}