ct is not used in all places


Navigation properties - read more about this
Include - read more about this
Tracking - AsNoTracking() - read later
Query splitting - AsSplitQuery() read more later

# movie-platform
Full-stack learning project built with .NET, React, and TypeScript, focused on Clean Architecture, DDD, authentication, testing, and cloud-native development.

## Self Note
1. Using Value objects. Stuff that is identified by Value, not identity ID. Value object is Data + rules + domain behavior, VO or not depends on the business rules, lifecycle, ownership, and consistency requirements. MovieDetails is just descriptive data thus VO here.

2. Factory pattern. There are two kind of factory, Polymorphic Factory that decides which implementation to init. And Creation Factory that Create valid objects, like the one we using here. So we have centralized and controlled creation, all creation is through one enter point.

3. Custom Exception. To better reflect exception part. DomainException, custom error code and msg.

4. Movie, Actor and Review are own aggregates. This avoids to have everything includes in Movie, they can live without Movie.

5. FluentValidation. Tool to run validation in ApiController. It does not replace domain validation cause FluentValidation only triggers if request is coming from Api, ignoring internal creation. Flow: Modelstate -> FluentValidation -> DomainException. Modelstate is on framwork level, coming first

6. All places that needs custom response: Controller, FluentValidation, Domain exception, ModelstateFilter. Missing JWT, Auth failure, Infrastructure exceptions, Background Tasks 

7. MediatR. Get is query, Delete and Put is command. If Delete has no return type, use IRequest in command and Only sending command in IRequestHandler in command.

8. This is Hybrid of Domain focused or DDD style for Entity AND CQRS. DDD style - Minimal navigation, it's clean domain, scalable, but more complex on queries and repository. CQRS style - WriteModel are simple, Read Model DTO with joins/projections, used in larger system. Full EF model - detailed navigation, easiest but can lead to over-fetching.

9. I'm using direct insert when we handle review. While DDD style wants movie.AddReview as review is based on Movie.


## Flow
HTTP Request
      │
      ▼
Model Binding
      │
      ├── Invalid
      │      ▼
      │ ModelStateFilter
      │
      ▼
Controller
      │
      ▼
Mediator.Send(command/query) Pipeline registered in program.cs
      │
      ▼
ValidationBehavior
      │
      ▼
CreateMovieValidator.ValidateAsync()
      │
      ▼
RuleFor(...)
RuleFor(...)
RuleFor(...)
      │
      ▼
Valid?
      │
      ├── No → throw ValidationException
      │
      ▼
CreateMovieHandler
      │
      ▼
Factory
      │
      ▼
Domain
      │
      ▼
Repository
