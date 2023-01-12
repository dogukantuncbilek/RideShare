# RideShare

## Examples

### Add City 
( /api/city/add-city - **POST** )
```
{
    "Name": ** City Name ** *(string)*,
    "Longitude": ** City Long ** *(int)*,
    "Latitude": ** City Lat ** *(int)*
}
```

### Add Travel 
( /api/travel/add-travel - **POST** )
```
{
    "AvailableSeats": ** Avaiable seats ** *(int)*,
    "Description": ** Description ** *(string)*,
    "IsPublished": ** Publish status ** *(boolean)*,
    "StartDate": ** Travel Start Date ** *(datetime)*,
    "roadPath":{ 
        "StartCity":{
            "Name": City Name (string),
            "Longitude": City Long (int),
            "Latitude": City Lat (int)
        },
        "EndCity":{
            "Name": City Name (string),
            "Longitude": City Long (int),
            "Latitude": City Lat (int)
        }
    }
}
```

### Search Travel 
( api/travel/search-travels-names - **POST** ) 
OR 
( api/travel/search-travels-coords - **POST**)
```
{
    "AvailableSeats": Avaiable seats (int),
    "Description": Description (string),
    "IsPublished": Publish status (boolean),
    "StartDate": Travel Start Date (datetime),
    "roadPath":{ 
        "StartCity":{
            "Name": City Name (string),
            "Longitude": City Long (int),
            "Latitude": City Lat (int)
        },
        "EndCity":{
            "Name": City Name (string),
            "Longitude": City Long (int),
            "Latitude": City Lat (int)
        }
    }
}
```

### User

#### For Sign Up
( /api/user/sign-up - **POST** ) 
#### For Sign In
( /api/user/sign-in - **POST**)
```
{
    "Email": Email Address (string),
    "password": Password (string)
}
```
