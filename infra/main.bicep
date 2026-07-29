//deploy resources to same region as the resource group
param location string = resourceGroup().location
param storageAccountName string = 'dailydigest${uniqueString(resourceGroup().id)}'

//creates the storage account
resource storageAccount 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
}
output storageAccountName string = storageAccount.name
