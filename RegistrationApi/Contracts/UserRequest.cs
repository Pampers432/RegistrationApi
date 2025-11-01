namespace RegistrationApi.Contracts
{
    public record UserRequest(
        string email,
        string password);

    public record UserUpdateRequest(
        string email,
        string password,
        string newPassword);

    public record UserResponse(
        string email,
        string password,
        string jwt
        );
}
