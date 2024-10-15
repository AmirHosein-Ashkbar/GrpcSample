using Grpc.Net.Client;
using GrpcSample.Client;

string address = "http://localhost:5070";
var channel = GrpcChannel.ForAddress(address);

var client = new PersonRepository.PersonRepositoryClient(channel);
Console.WriteLine("press any key to start:");
Console.ReadLine();
var response = client.GetPeople(new GetPeopleRequest());
foreach (var person in response.People)
{
    Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age} ");

}
Console.ReadLine();

//bool again = true;
//while (again)
//{
//    Console.WriteLine("Please enter person id?");
//    string id = Console.ReadLine();
//    var response = client.GetPerson(new GetPersonRequest() { Id = int.Parse(id) });
//    Console.WriteLine($"{response.FirstName} {response.LastName} {response.Age} ");
//    Console.WriteLine("Do you want to make another request?(y/n)");
//    again = Console.ReadLine() == "y" ? true : false;
//} ;