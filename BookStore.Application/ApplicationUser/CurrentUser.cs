namespace BookStore.Application.ApplicationUser;

public class CurrentUser
{
    public string Id { get; set; }
    public IEnumerable<string> Roles { get; set; }

    public CurrentUser(string id, IEnumerable<string> roles)
    {
        Id = id;
        Roles = roles;
    }

    public bool IsInRole(string role) => Roles.Contains(role);
}
