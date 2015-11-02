public class UsersController : Controller
{
	private _____ api = new ____(new Uri("http://microsoft-apiapp613d756d6fa04ea0b13863e95e4fd34f.azurewebsites.net"));

	// GET: Users
	public ActionResult Index()
	{
		return View(api.Users.GetUsers());
	}

	// GET: Users/Details/5
	public ActionResult Details(int? id)
	{
		if (id == null)
		{
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
		User user = api.Users.GetUser((int)id);
		if (user == null)
		{
			return HttpNotFound();
		}
		return View(user);
	}

	// GET: Users/Create
	public ActionResult Create()
	{
		return View();
	}

	// POST: Users/Create
	// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
	// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create([Bind(Include = "Id,Email,FirstName,LastName")] User user)
	{
		if (ModelState.IsValid)
		{
			api.Users.PostUser(user);
			//db.SaveChanges();
			return RedirectToAction("Index");
		}

		return View(user);
	}

	// GET: Users/Edit/5
	public ActionResult Edit(int? id)
	{
		if (id == null)
		{
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
		User user = api.Users.GetUser((int)id);
		if (user == null)
		{
			return HttpNotFound();
		}
		return View(user);
	}

	// POST: Users/Edit/5
	// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
	// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit([Bind(Include = "Id,Email,FirstName,LastName")] User user)
	{
		try
		{
			if (ModelState.IsValid)
			{
				if (user.Id == null)
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				api.Users.PutUser((int) user.Id, user);
			}
		} catch (Microsoft.Rest.HttpOperationException e) { }

		return RedirectToAction("Index");
	}

	// GET: Users/Delete/5
	public ActionResult Delete(int? id)
	{
		if (id == null)
		{
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
		User user = api.Users.GetUser((int)id);
		if (user == null)
		{
			return HttpNotFound();
		}
		return View(user);
	}

	// POST: Users/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public ActionResult DeleteConfirmed(int id)
	{
		api.Users.DeleteUser(id);
		return RedirectToAction("Index");
	}
}