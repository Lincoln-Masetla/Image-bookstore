

# Introduction
### Imagine bookstore
This system allows book lovers to subscribe to their favourite books and enjoy them. Simply register on the application and subscribe to the books you love.


### Summary
1. API was done in Asp.Net 6.0  
2. The Web UI was done in the angular version of angular: Angular CLI version 12.2.8.
3. Please see swagger documentation for endpoints ie Swagger is showed when API is ran.
4. The API uses sqllite and the database is found on the Assessment.API root directory.

### Third party Resellers
1. Users have to register on the portal but with an API role (Assuming third party will consume the API)
2. Then they will have the hit the login endpoint to obtain token
3. Use the token the access the other authorized endpoints

## Build Instructions
### Imagine.BookStore.BE
1. Run the following on the root of Imagine.BookStore.BE to create and seed the database
In visual studio open Package Manager Console set Imagine.BookStore.Persistence as Default project then run
```
update-database
```
### Imagine.BookStore.FE
1. Run the following on the root of Imagine.BookStore.BE to create and seed the database
```
cd Imagine.BookStore.FE
npm i 
npm start
```

Enjoy!!!

