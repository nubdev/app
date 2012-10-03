namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void process(IEncapsulateRequestDetails request);
    bool can_handle(IEncapsulateRequestDetails request);
  }

  public class RequestCommand : IProcessOneRequest
  {
      MatchRequest_Behaviour behaviour;
      public RequestCommand(MatchRequest_Behaviour behavior)
      {
          this.behaviour = behavior;
      }

      public void process(IEncapsulateRequestDetails request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_handle(IEncapsulateRequestDetails request)
    {
        return behaviour(request);
    }
  }
}