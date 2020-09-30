namespace HotelManagement.DAL.Repositorys.Validation
{
    public interface IValidationRepository<T>
    {
        T Validate(string username, string password);
    }
}