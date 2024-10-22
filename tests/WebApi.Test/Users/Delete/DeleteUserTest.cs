using System.Net;
using FluentAssertions;

namespace WebApi.Test.Users.Delete;

public class DeleteUserTest : CashFlowClassFixture
{
    private const string Method = "api/User";
    private readonly string _token;

    public DeleteUserTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.UserTeamMember.GetToken();
    }
    
    [Fact]
    public async Task Success()
    {
        var response = await DoDelete(Method, _token);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}