namespace BookStore.Application.ApplicationUser;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}
