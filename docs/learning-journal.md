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
