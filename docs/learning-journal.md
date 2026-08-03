Date: 7/20/26

Title: RSS feed stuffs

Why:
This app is going to use RSS feeds to give me content for the daily emails.

Questions/Learned:
What is RSS and what does it look like? How will I use it in this app?

RSS stands for really simple syndication. An rss feed is a syndicated news feed in XML format that you can subscribe to. RSS alerts allow users to feed results from EBSCO search alerts
into their rss readers. This app will use Microsoft Tech Community posts because they provide a rss feed already.

Feed Name: Microsoft Tech Community

Feed URL: https://techcommunity.microsoft.com/t5/s/gxcuf89792/rss/board?board.id=AzureCompute

Information I want for my email:

- title
- link
- description
- date (for sorting)

Notes:

- need to make each individual article into an Article object that is added to a list
- make the date a string, was having issues using it as type DateTime

---

Date: 7/21/26

Questions:
What is LINQ?

LINQ stands for language-integrated query and its the name for a set of technologies based on the integration of query capabilities directly inot c#. A query is a first-class language construct, just like classes or methods. LINQ is a structured query syntax built to retrieve data from different types of data sources.

Every LINQ query must query to some sort of data source (array, collection, XML or other database) and must be executed to get a result.

---

Date: 7/28/26

Questions:

What is azure functions configuration and what does it entail?
This just means making the app ready to be an azure function. It means the collection of env variables, settings and meta data that manage how an azure app behaves and connects to other services. There are 3 main parts: application settings, global host config, function-specific configs

application settings --> global key-value paits used by entire app - cloud behavior - local development - common keys
global host configurations --> the host.json file at the root of the project.

- global logging - health monitoring
  function specific configurations --> defines individual functions, their input triggers, and their output bindings

What is IConfiguration?
This is a built-in interface that provides a way to read application settings from jey-valud pairs

What are environment variables?
These are named values stored outside of a program that tell the application how to behave. They are written as key-value pairs.

---

Date: 8/03/26

I got the app finished and styled for emails. I originally was tring to take the JSON output and style it directly in the body of the email but that meant I was sending an email for each article itself, which is not what I wanted. I worked on a few ideas and ended up creating an emailBody string variable that I would hold the output in. I looped through the JSON output and styled the title, link and date with HTML. Then I appended that to the variable. Outside of the loop I created an HTML wrapper and inserted the variable. Then I created my email and used the wrapper output as the body. This was the email was sent only once and neatly contained all the necessary information. Figuring out the looping and how to format the JSON output was a bit challenging but fun to work on.
