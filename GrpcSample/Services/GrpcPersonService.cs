using Grpc.Core;
using GrpcSample.Context;
using GrpcSample.Entities;
using GrpcSample.Protos;

namespace GrpcSample.Services;

public class GrpcPersonService : PersonRepository.PersonRepositoryBase
{
    private readonly AppDbContext _context;

    public GrpcPersonService(AppDbContext appContext)
    {
        _context = appContext;
    }
    public override async Task<PersonResponse> GetPerson(GetPersonRequest request, ServerCallContext context)
    {
        var person = await _context.People.FindAsync(request.Id);
        var personResponse = new PersonResponse
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Age = person.Age,
        };
        return personResponse;
    }
}
