DbContextPerRequest
===================

Microsoft advises that, when working with EF in web applications, one DbContext be used per web request. This means that by the time the HTTP request ends, the context should be disposed. In my example, using the Unity DI framework, the context is contained in a property in a class named DataContext, which is injected whenever it is necessary to use a Context (inside of a controller or of a repository, for instance). I derive that class so its generic parameter is replaced by whatever DbContext I want (in this example, the DbContext is named MyEntities), so this is derived class is the one that gets registered in UnityConfig.cs:

container.RegisterType<IMyEntitiesDataContext, MyEntitiesDataContext>(new PerRequestLifetimeManager());

As you can see, I use the PerRequestLifetimeManager class provided by Unity to certify that the Dispose() method implemented by MyEntitiesDataContext is called upon the end of the request.

It's wise to keep the call to DataContext.Save() as close as possible to the places where you make data changes. (usually just before the context gets disposed) Therefore, I strongly advise against making calls to this method inside of a repository, for instance (I include an example of what looks like one in my code), but I'm not aware of a way to avoid that, since repositories must access the DbContext directly to do their thing. Even worse, as you see, is that inside a repository the user can make a call to DbContext.SaveChanges(), thereby completetly bypassing the abstraction provided by DataContext. Maybe a way to do that would be if BaseRepository received only a copy of a readonly DataContext, but I don't know of a easy way to do that and it's probably not worth the effort on simple projects (those which my example are aimed at).

If you need tighter control over the lifetime of your DbContext, I see no better approach than instantiating it a using block:

using (var context = new MyEntities())
{
  user.Status = UserStatus.Active;
  context.Save();
}

The disadvantage of this approach becomes clear if your code spans across several methods, making it necessary for your to method inject the context (even in methods that won't be making use of it!) so they can reach wherever they will be needed.

The other alternative is to make the DbContext ambient. You can read more about all of this Mehdi El Gueddari's post: http://mehdi.me/ambient-dbcontext-in-ef6/. Even if you settle for one approach, I highly recommend reading the whole thing since it is the most thorough discussion on DbContext lifetime I've seen on the internet. (and I've read a lot of those)

My implementation is based on examples and discussions I've seen on Stack Overflow and the web, and it owes a lot to a particular example I've seen but just can't remember where.
