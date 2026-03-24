using Soenneker.PayPal.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.PayPal.HttpClients.Tests;

[Collection("Collection")]
public sealed class PayPalOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IPayPalOpenApiHttpClient _httpclient;

    public PayPalOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IPayPalOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
