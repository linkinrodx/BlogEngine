# Blog Engine v1

Welcome to Blog Engine project, in this project to will have the opportunity of manage the flow of some posts and finally publish a post.

If you want to load the project here, to will have to do some task:

## First let's see the prerequisites

- Visual Studio with net core 5
- Sql Server 2012+

And now we are going to do:

### Create the database

Execute the Scripts/script1.sql in your SQL Server

### Change Connection String in appsettings (for BlogEngine and BlogEngine.Security)

Example:       Data Source=(servername);Initial Catalog=BlogEngine;Integrated Security=True;

And now you will have the opportunity to load the projects (BlogEngine and BlogEngine.Security)

## What can you do with the project? let's see!

Inside, you can see 2 solutions with some endpoints

- BlogEngine 
- BlogEngine.Security

### Security Endpoints

Here you can login and generate a security token 

[Post] GetToken

### BlogEngine Endpoints

These are all the endpoints, to use these you must add the authorization header request (add the token created before)

```
- All Roles
[Get]   GetListPost

- Writer Role
[Get]   GetListPostByAuthorId
[Post]  AddPost
[Put]   EditPost
[Put]   SubmitPost

- Editor Role
[Get]   GetListPostSubmmited
[Put]   ApprovePost
[Put]   RejectPost
```

## Test Users

With these users you can request for all the endpoints (use the users in security endpoints)

- Public1     :     Public123
- Writer1     :     Writer123
- Editor1     :     Editor123

## An aditional point (Post Flow)

All the posts follow a flow state (depending of the post state, you can use some endpoints)

1. Created
2. Submitted
3. Approved
4. Rejected
5. Published
5. Deleted

If you have any question, remember to contact me sending me a message

*Created by Rodrigo Saraya - 2021*
