using Soenneker.PayPal.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.PayPal.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PayPalOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IPayPalOpenApiHttpClient _httpclient;

    public PayPalOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IPayPalOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
