# movie-platform
Full-stack learning project built with .NET, React, and TypeScript, focused on microservices architecture, Clean Architecture, authentication, testing, and cloud-native development.

## Self Note
1. Using Value objects. Stuff that is identified by Value, not identity ID. Value object is Data + rules + domain behavior
2. Using Factory pattern. There are two kind of factory, Polymorphic Factory that decides which implementation to init. And Creation Factory that Create valid objects, like the one we using here. So we have centralized and controlled creation, all creation is through one enter point.
3. Custom Exception. To better reflect exception part.
4. Movie, Actor and Review are own aggregates. This avoid everything includes in Movie