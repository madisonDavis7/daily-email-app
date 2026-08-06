# 📖Daily Digest Email App #

## Summary ##
This was a side project I worked to get a better understanding of RSS feeds, C#, logic apps, and using Microsoft Azure. I started off by mapping what I needed to research and drawing up an idea for the app. The goal was to break it into small pieces and tackle each part individually to better understand what I was doing. 

Once I had a roadmap I began writing a C# console app that created an xml reader to load the feed, get the articles, store and return a list of articles, and print them to the console. I then transformed that into an Azure function that runs when a HTTP request was sent. The LearnDigest function runs, connecting the RSS feed and downloading the XML. Then the XML is converted into C# objects that the Feed Reader creates Article objects from. These are then returned as JSON. After that the resource group is created and all the necessary resources are added, such as the storage account, applications insights, and function app. These are all deployed from the main bicep file. The logic app was created using the designer mode in Azure and was built to run every morning at 9am, returning the top 5 articles from the feed url. 

## Tools ##
- Visual Studio Code --> chosen editor
- Microsoft Azure --> cloud based service
- Microsoft Copilot --> used to provide a general outline for topics to research and the broad steps needed

## Learned ##
This project was taken on with the intention of being a learning opportunity. By creating this app I was able to write my first lines of C#, research RSS feeds (among a bunch of other things found in the learning journal), gain experience designing function + logic apps, and better understand how to utilize AI in my initial project phases. 
- RSS Feeds
- Bicep
- C#
- storage accounts
- Logic Apps

## Challenges ##
1. I had several issues setting up the initial console app and getting it to correctly read the rss feed. I was having errors with my syntax, setting up the feed reader, and figuring out what exactly I needed to do. I solved this by a lot of research and too much time looking up C# specific questions.
2. Because I used the student Azure subscription I had a harder time getting the storage account and other resources set up. Often I would get the bicep file done, try to deploy them, and get errors about my subscription. This was frustrating and I often used Microsoft Copilot as a tool to better understand the error messages and what they meant. Most of these were relatively quick fixes.
3. Once I had the logic app working correctly and could see emails in my inbox I tried to go back and change the format of the email content. This took a few hours to figure out. The logic app was originally using the HTML to Table block for the email format, but to add HTML styling I ended up changing the app's structure. There was a lot of trial and error to get everything styled, showing up in one email, and working consistently. 
