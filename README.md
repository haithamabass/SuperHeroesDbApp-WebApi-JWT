### ASP.Net Web Api with security implementation with JWT authentication and authorization.

</br>

## **Technologies:**
- ASP.NET 6 WebApi
- Database: Microsoft SQL server.
- Framework/ library: Entity framework 

- Generated JWS key : https://8gwifi.org/jwsgen.jsp


## **Features:**
- User registration;
- user login
- Password hashing;
- Role-based authorization;
- add roles to users who signed up 
- hide or display different parts of a page based on the user's roles.
- Endpoints request required authorized access.
- Login via access token creation;
- Refresh tokens, to create new access tokens when access tokens expire;
- cookies to store refresh tokens in it. 
- Revoking refresh tokens.
- Secured  CRUD operations(Create (POST) - Read (GET) - Update (PUT) - Delete (DELETE))
 
 


## **Dependencies:**
- Microsoft.AspNetCore.Mvc
- Microsoft.AspNetCore.Authorization
- Microsoft.AspNetCore.Identity
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.IdentityModel.Tokens
- Microsoft.AspNetCore.Mvc.Rendering
- Microsoft.Extensions.Options
- Microsoft.EntityFrameworkCore

</br>

**If you have ideas on how to improve the API or if you want to add a new functionality or fix a bug, please, send a pull request.**
