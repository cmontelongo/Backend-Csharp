using Backend.Controllers;

namespace Backend.Services
{
    public class PeopleService : IPeopleService
    {
        bool IPeopleService.Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) ||
                people.Name.Length > 100) {
                return false;
            }

            return true;
        }
    }
}
