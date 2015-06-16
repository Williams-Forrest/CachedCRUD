# CachedCRUD

## Overview

CachedCrudLib is a .Net library that handles the caching logic for create, read, update, and delete (CRUD) operations.  It only handles the caching logic.  The data store and cache implementations are abstracted behind interfaces (ICrud and ICache).  Implementations of the cache interface that use the default .Net MemoryCache are provided, but other cache implementations can be used if desired.  The implementation of the data store interface must be provided by the user, but it is generally a thin layer.

The caching logic can be summarized as follows:

- On create, simply pass the request through to the data store.  No caching operations occur at this point, since the cached object could include calculated fields (Id, CreateDate, etc.) that are implemented in the data store.
- On read, return a cached object if it exists in the cache.  Otherwise, request it from the data store and add it to the cache.
- On update, update the object in the data store and remove the (old) object, if it exists, from the cache.  As with the create operation, the updated object is not added to the cache at this point.
- On delete, remove the object from the data store and the cache.

The logic is simple, but often needs to be applied to many objects within an application.  Using CachedCrudLib avoids repeating the logic.

## How to use it

1. Write an "object-manager" class that implements the ICrud interface for the object to be cached.  This class describes how to create, read, update, and delete objects in the data store. (See DataItemManager in the sample app.)
2. Choose whether to use the FixedExpirationCache, or SlidingCache, cache implementation.  Or, implement the ICache interface to use another cache.
3. Write a "cached-object-manager" class derived from the generic CachedCrud class, for your particular data object.  This is just a few lines of boilerplate code.  (See CachedDataItemManager in the sample app.)
4. In your app, use the "cached-object-manager" class to perform all operations between the app and data store for the object.  (See Program.cs in the sample app.)

## Notes

Object keys – With many data stores, the key is defined by the data store on the create operation.  An auto-incrementing Id column in a relational database is an example.  To handle a create operation where the app defines the key, store the key value within the object prior to calling Create, and implement the ICrud.Create method to use the key value from the object.

Cache keys – Cache keys are generated automatically by concatenating the object's type-name and the object's key.  The compound cache key allows duplicate object-keys across different types to be stored in the same cache (for example, User:1 and Image:1).  Cache key generation can be modified by overriding CachedCrud.GetCacheKey.

Error handling – When errors occur in the data store during CRUD operations, they need to be handled as required by the application in the object-manager class.  To pass error details from the object-manager class to the application, the object-manager could throw an exception that is caught in the application.  There is no mechanism for returning error information through the CachedCrud class.

Null values – A null value can be returned from the Read method.  Null values are not cached.

## To do

- A read-only interface for caching static data
- Options to cache-on-create and cache-on-update