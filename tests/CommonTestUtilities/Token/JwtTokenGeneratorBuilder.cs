using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Tokens;
using Moq;

namespace CommonTestUtilities.Token;

public class JwtTokenGeneratorBuilder
{

    public static IAccessTokenGenerator Build()
    {
        var mock = new Mock<IAccessTokenGenerator>();

        mock.Setup(accessTokenGenerator => accessTokenGenerator.Generate(It.IsAny<User>())).Returns("ewogICJ0eXAiOiJKV1QiLAogICJhbGciOiJIUzI1NiIKfQ.ewogICJqdGkiOiI5NjQ5MmQ1OS0wYWQ1LTRjMDAtODkyZC01OTBhZDVhYzAwZjMiLAogICJzdWIiOiIwMTIzNDU2Nzg5IiwKICAibmFtZSI6IkpvaG4gRG9lIiwKICAiaWF0IjoxNjgxMDQwNTE1Cn0.ZXdvZ0lDSjBlWEFpT2lKS1YxUWlMQW9nSUNKaGJHY2lPaUpJVXpJMU5pSUtmUS4uSXFlTmwzbEhTVWZQZkVZbXR0dmxRcDFzSDlMcEFvUEpsVWlTdjRYUERTRQ");

        return mock.Object;
    }
}