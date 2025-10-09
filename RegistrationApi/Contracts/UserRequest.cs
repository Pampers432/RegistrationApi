namespace RegistrationApi.Contracts
{
    public record UserRequest(
        string email,
        string password);

    public record UserResponse(
        //int id,???
        string email,
        string password,
        string jwt
        );
}
