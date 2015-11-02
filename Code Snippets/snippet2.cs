public DefaultController()
{
	IGenerationSessionFactory factory = AutoPocoContainer.Configure(x =>
	{
		x.Conventions(c => { c.UseDefaultConventions(); });
		x.AddFromAssemblyContainingType<User>();
		x.Include<User>()
			.Setup(u => u.Id).Use<DefaultIntegerSource>()
			.Setup(u => u.FirstName).Use<FirstNameSource>()
			.Setup(u => u.LastName).Use<LastNameSource>()
			.Setup(u => u.Email).Use<EmailAddressSource>();
	});

	IGenerationSession Session = factory.CreateSession();

	Users = Session.List<User>(50).Get();
}