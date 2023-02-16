# Netflix-Titles
<table>
<tr>
<td>
  A web app for a custom Netflix search dashboard which allows users to browse & find Netflix titles and save them to their account. The titles are imported from a CSV data-set with 6000+ movies/shows, and further details for each title are accessed through OMDB API. This app is a learning project to explore the .NET Core framework, using their MVC approach and adapting it into an SPA with React & Redux. API endpoints are secured through JSON Web Tokens using NuGet bearer-token libraries. 
</td>
</tr>
</table>


## Site

### Dashboard
The user's dashboard shows their profile information, and the titles from the database which they can archive for later use. The search form can filter titles by name and/or cast, with options to order by ascending or descending.

![](/Dashboard.png?raw=true)


Users can also view further information for any title, such as the IMDB rating, runtime, and poster image.

![](/Details.png?raw=true)


## Mobile support
This app uses a responsive grid to cater to different devices & sizes. 


## Built with 
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) v3.1.9
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019) v15.0.0
- [React](https://reactjs.org/) v16.2.0
- [Redux](https://redux.js.org/) v4.0.5


## Contact
Created by Ryan Hsin - please feel free to contact me!
