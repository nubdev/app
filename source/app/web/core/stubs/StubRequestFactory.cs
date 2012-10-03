﻿using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IEncapsulateRequestDetails create_from(HttpContext raw_request)
    {
      return new StubRequest();
    }

    class StubRequest : IEncapsulateRequestDetails
    {
    }
  }
}