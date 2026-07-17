_what are azure functions_ --> azure functions are a serverless solution for building apps. They use cloud infrastructure and provide a set of event-driven triggers and bindings that connect your functions to other services

_how are they different from an app service_ --> App Service is a full web app hosting platform while azure functions is a serverless compute service. App Service is ideal for longer running applications and websites, while functions are best for short-lived tasks or event driven workflows.

_what triggers can start a function_ --> functions can be started by an email, timers, HTTP...

_how will this project use functions_ -->

_what is a workflow_ --> a workflow is a series of actions that define a workload or task. Each workflow starts with a trigger, then must have one or more actions after

_how can logic apps call an api_ --> there are three ways: the built-in HTTP action, the swagger+HTTP way, or custom connectors.

&#x09;built-in: there is a standard built-in action that lets you call any public or network accessible REST api by entering the request details.

&#x09;swagger+http: if your api exposes an openAi or Swagger definition file hosted on a public url you can provide the swagger endpoint url

&#x09;custom: if the api needs to be reused across multiple logic apps or it needs to be easier for non-technical users you can create a custom connector

_how will my logic app interact with my function app_ -->

_what is azure storage_ --> azure storage is a space in azure for your data, with a unique name

_what are blobs_ --> azure blob storage is optimized for storing large amounts of unstructured data

_what are tables_ --> table storage is a service that stores non-relational structured data in the cloud with a schemaless design (easier to adapt data to your needs)

_why do function apps require storage accounts_ -->

_what is infrastructure as code_ -->

_why use bicep instead of the portal_ -->

_what is a modeule_ -->

_what is a parameter_ --> a parameter lets you bring in values from outside the bicep file
