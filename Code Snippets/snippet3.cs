public List<User> GetUsers()
{
	return Users.ToList();
} 

public User GetUser(int id)
{
	return Users.Where(x => x.Id == id).Select(x => x).First();
}