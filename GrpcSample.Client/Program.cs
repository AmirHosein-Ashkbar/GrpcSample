using Grpc.Net.Client;
using GrpcSample.Client;

string address = "https://localhost:7154";
var channel = GrpcChannel.ForAddress(address);

var client = new PersonRepository.PersonRepositoryClient(channel);

Console.WriteLine("Please enter person id?");
string name = Console.ReadLine();
var response = client.GetPerson(new GetPersonRequest() { Id = 1 });
Console.WriteLine($"{response.FirstName} {response.LastName} {response.Age} ");