# SpeedRunTracker.Web

##What is this?

This a simple educational ASP.Net project with Identity system

##What's the intended use of the app?

Its use is to track and display speed runs of video games.
Users can view leadboards of different games and participate by submitting their own speedruns in different categories.

##What type of users are there?

**Non-registered users** can browse games and their leaderboard

**Registered users** get the ability to submit their own speed runs and request support by sending a support ticket

**Moderators** are users who's resposibility is to verify user's speed runs and responde to support tickets

**Admin** is the application's owner. He has the resposibilities of the moderators, but can also give and take moderation privileges from registered users.

##Other information abot the application

###Database
The application uses as its database a MSSQL server.

In the repo there are migrations for the database and configuration for the entities.

*Should you wish to for it, be sure to add connectionString to your application.json aore secrets.json* 

##Copyright disclaimer
*I don't own any of the images used in this application. All the rights go to their respected owners.*
