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
