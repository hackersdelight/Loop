
namespace Loop.Interfaces
{
	public interface IUser
	{
		int Id { get; }
		string Login { get; }
		string Password { get; }

		string Name { get; }
		string Surname { get; }
		string Email { get; }
		bool IsActive { get; }
	}
}
