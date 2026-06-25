# movie-platform
Full-stack learning project built with .NET, React, and TypeScript, focused on microservices architecture, Clean Architecture, authentication, testing, and cloud-native development.

## Self Note
1. Using Value objects. Stuff that is identified by Value, not identity ID. Value object is Data + rules + domain behavior, VO or not depends on the business rules, lifecycle, ownership, and consistency requirements. MovieDetails is just descriptive data thus VO here.

2. Factory pattern. There are two kind of factory, Polymorphic Factory that decides which implementation to init. And Creation Factory that Create valid objects, like the one we using here. So we have centralized and controlled creation, all creation is through one enter point.

3. Custom Exception. To better reflect exception part. DomainException, custom error code and msg.

4. Movie, Actor and Review are own aggregates. This avoids to have everything includes in Movie, they can live without Movie.

5. FluentValidation. Tool to run validation in ApiController. It does not replace domain validation cause FluentValidation only triggers if request is coming from Api, ignoring internal creation. Flow: Modelstate -> FluentValidation -> DomainException. Modelstate is on framwork level, coming first
