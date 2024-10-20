﻿using System.Globalization;
using System.Net;
using System.Text.Json;
using CashFlow.Exception;
using FluentAssertions;
using WebApi.Test.InlineData;

namespace WebApi.Test.Expenses.Delete;

public class DeleteExpenseTest : CashFlowClassFixture
{
    private const string Method = "api/Expenses";

    private readonly string _token;
    private readonly long _expenseId;


    public DeleteExpenseTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.UserTeamMember.GetToken();
        _expenseId = webApplicationFactory.ExpenseMemberTeam.GetId();
    }
    
    [Fact]
    public async Task Success()
    {
        var result = await DoDelete(requestUri: $"{Method}/{_expenseId}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        result = await DoGet(requestUri: $"{Method}/{_expenseId}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task Error_Expense_Not_Found(string culture)
    {
        var result = await DoDelete(requestUri: $"{Method}/1000", token: _token, culture: culture);

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        
        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();
        
        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("EXPENSE_NOT_FOUND", new CultureInfo(culture));

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage));

    }
}