using Grpc.Core;
using GrpcSample.Context;
using GrpcSample.Entities;
using GrpcSample.Protos;
using Microsoft.EntityFrameworkCore;

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




    public override async Task<PeopleResponse> GetPeople(GetPeopleRequest request, ServerCallContext context)
    {
        var people = await _context.People.ToListAsync();
        var ppl = people.Select(p => new PersonResponse
        {
            FirstName = p.FirstName,
            LastName = p.LastName,
            Age = p.Age,
        });
        var peopleResponse = new PeopleResponse();
        peopleResponse.People.AddRange(ppl);
        return peopleResponse;
    }
}
