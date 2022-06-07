# Hexagonal and Clean Architecture
The simplest demo on how to implement a Web Api using .NET Core and MongoDb that protects the business rules from framework dependencies by following the Clean Architecture Principles.

### Running Application
Bring up the latest MongoDB database as well as a nice admin panel that You’ll be able to use to see what is actually happening. To get started, run:

    $ docker-compose up -d

The Port configured for MongoDb is 27018 avoiding any conflicts

Running migrations to populate the DEMO database with Test profiles

    $ \source\As.Posterr.Repositories.MongoDB.Migrations> dotnet run

There are two basic profiles that can be used as logged user to test follow and unfollow features. They are in appsettigs.json

    $ "UserId": "E9F03E73-F8DA-4807-B744-88D21CBEE311" //alexsimoes

    $ "UserId": "8E955438-E33E-45FF-BDEE-54E7AA74464A" //testUser1

There are a Postman Collection inside the folder that can help with all requests.

    $ \source\> Posterr.postman_collection

# Planning
## Reply a post
How the reply post should be work?

The character to identify the reply in test is "@"?

Should we create an autocomplete to load profiles when start writting @ in the text?

How many @ users can be linked to the post?

Should user receive any notification or something like that when is tagged in a Post?

## Design of solution
When post is send to the API and there is a Value object, TextPost. 

The value object was created to manipulate and extract tags, keywords and postReply.

A new List<Username> should be added in TextPost and using Regex extract all postReply that start with @ something like this '/@\w+/'

In domain service when post is created, there is an event called PostCreated that will trigger a new EventHandler that will handle the new feature Reply Post.

The event handler PostReplyEventHandler will get a list of UserName validate that all username exists in database and enrich the Post entity with the List of ProfileIds in a new Property LinkedProfiles.

A new flag in Post to identify if the Post is a reply might be good to improve performance.

### Changes in Post entity.
New flag added to identify that the Post is a Reply.
New List of the Profile Ids.

### Changes in ProfileRepository
New method to find profile by username.

### Change in Post service.
New method to enrich the Post with the liked profile ids.

### Changes in Application layer.
New event handler will be added in cascade flow for the event PostCreatedEvent

### Api 
Add new endpoint in profile route to allow filter profiles by username.

# Critique
This project was designed to be a scalable solution using a non relational database.

There are queries and filters that should be improved, the pagging in some search was added to prevent slow responses.

The list of posts getting by the followed users might get slow response if the user follow a million of people.

The search algorithm should be improved.

The responses might optimized to return the necessary to the UI.

Indexes in database might be a solution.

# Architecture
## Motivation

Build an architecture where the Application and domain layers are free of
frameworks following the design of hexagonal architecture aligned with the practices of Clean architecture

## Application Layer
The application layer is responsible for connecting the inputs and outputs to the outside world.
This connection is made through the ports (Request and Response).
Use Cases are the ones who orchestrate the business rules within the application layer.

### Use Case
Use Case is responsible for orchestrating the business rules defined for application.
The use case receives Request it executes the business rules triggering the domain.
After the domain is returned, the Use Case provides the return the response to the caller.


## Domain Layer (DDD)
The domain layer follows the DDD Standard using rich entities, Value Objects, Event Sourcing and Domain Service.
This layer is responsible for handling all rules regarding the domain.

### Events (Event Sourcing)
Each entity may have events and event handling that will be used by it.
When an action is performed on an entity, the event must be triggered for that action to be applied to the entity using the Handler subscribed to that event.
This allows domain rules to be decoupled from the entity and can be shared and organized in separate files.

Example. A post was written by a user.

Text posted -> validate the post -> update the user post count -> commit post in database

The sequence of events that have occurred can be published to an infrastructure through the Application layer, making it possible to redo the entire price update process perfectly.

### Domain Service
Communication between the Application and the Domain is through a service provided by the domain.

The application must not be able to manipulate entities in written mode without going through a domain service.
This allows decoupling of domain rules by encapsulating calls into domain services, which tend to be more complex.

### Domain Exceptions
Domain exceptions are the domain's way of informing the upper tier that something is wrong, be it data entry or some domain rule that has been broken.

## References
Evans, Eric - Domain Driven Design

Martin C. Robert - Clean Architecture
