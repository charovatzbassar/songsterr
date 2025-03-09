This app is built using .NET MVC, which further utilises Entity Framework and a PostgreSQL database for storing favourite songs.
Furthermore, it utilises a public API from Genius for fetching and searching songs from their database.

Steps for running the app:

1. Load the database by adding Postgres instance credentials to appsettings.json.
2. Furthermore, run the following:<br>
`dotnet ef database update`<br>
This command will apply the current migration to the database
3. Run the app with the command: `dotnet watch`
