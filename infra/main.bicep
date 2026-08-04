//deploy resources to same region as the resource group
param location string = resourceGroup().location
param storageAccountName string = 'dailydigest${uniqueString(resourceGroup().id)}'

//creates the storage account
resource storageAccount 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storageAccountName
  location: location
  kind: 'StorageV2'
  sku: {
    name: 'Standard_LRS'
  }
}
output storageAccountName string = storageAccount.name

//creates a log analytics workspace for monitoring
resource logAnalyticsWorkspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: 'law-learning-digest'
  location: location

  properties: {
    sku: {
      name: 'PerGB2018'
    }
  }
}

//gives resourceId so other services can connect later 
output workspaceResourceId string = logAnalyticsWorkspace.id

//application insights stuff
resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: 'app-insights-learning-digest'
  location: location
  kind: 'web'

  properties: {
    //because gonna monitor a web application
    Application_Type: 'web'
    //linking the app insights to the log analytics workspace
    WorkspaceResourceId: logAnalyticsWorkspace.id
  }
}

output appInsightsName string = appInsights.name

output appInsightsConnectionString string = appInsights.properties.ConnectionString

param functionAppName string = 'func-learning-digest-${uniqueString(resourceGroup().id)}'

//create the hosting plan(consumption plan) for the function app
resource hostingPlan 'Microsoft.Web/serverfarms@2023-12-01' = {
  name: 'app-learning-digest'
  location: location
  sku: {
    name: 'Y1'
    tier: 'Dynamic'
  }
  kind: 'functionapp'
}

//create the function app itself

var storageAccountKey = listKeys(storageAccount.id, '2023-01-01').keys[0].value
var storageConnectionString = 'DefaultEndpointsProtocol=https;AccountName=${storageAccount.name};AccountKey=${storageAccountKey};EndpointSuffix=${environment().suffixes.storage}'

resource functionApp 'Microsoft.Web/sites@2023-12-01' = {
  name: functionAppName //parameter nae NOT function app name
  location: location
  kind: 'functionapp'
  properties: {
    serverFarmId: hostingPlan.id
    httpsOnly: true
    siteConfig: {
      appSettings: [
        {
          //function runtime storage
          name: 'AzureWebJobsStorage'
          value: storageConnectionString
        }
        {
          //run the app on the latest version of the function runtime
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: '~4'
        }
        {
          //runtime for the function app
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: 'dotnet-isolated'
        }
        {
          //app insights instrumentation key
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: appInsights.properties.InstrumentationKey
        }
        {
          //app insights connection string
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: appInsights.properties.ConnectionString
        }
        {
          name: 'WEBSITE_RUN_FROM_PACKAGE'
          value: '1'
        }
        {
          name: 'rssFeedUrl'
          value: 'https://techcommunity.microsoft.com/t5/s/gxcuf89792/rss/board?board.id=AzureCompute'
        }
      ]
    }
  }
}
