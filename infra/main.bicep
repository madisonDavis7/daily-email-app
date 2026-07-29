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
    retentionInDays: 10
  }
}

//gives resourceId so other services can connect later 
output workspaceResourceId string = logAnalyticsWorkspace.id
