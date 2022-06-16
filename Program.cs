using System;
using BCPTest;
using HotChocolate.AspNetCore;
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
                .SetPagingOptions(
                    new PagingOptions
                    {
                        IncludeTotalCount = true,
                        MaxPageSize = 200
                    })
                .ModifyRequestOptions(requestExecutorOptions =>
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        requestExecutorOptions.ExecutionTimeout = TimeSpan.FromMinutes(1);
                    }

                    requestExecutorOptions.IncludeExceptionDetails = true;
                })

                .ModifyOptions(options =>
                {
                    options.UseXmlDocumentation = true;

                    options.SortFieldsByName = true;

                    options.RemoveUnreachableTypes = true;

                })

                .AddQueryType<QueryType>()
                    .AddTypeExtension<SystemQueries>()
                .AddMutationType<MutationType>()
                    .AddTypeExtension<DumyMutations>()
                .UseDefaultPipeline();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL()
    .WithOptions(new GraphQLServerOptions
    {
        EnableSchemaRequests = true,
        Tool = {
            Enable = true
        }
    });

app.Run();