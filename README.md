# FoodTruckLocator
Application created for Buhler developer challlenge in about 3 hours

## Assignment

### Feature: 
Find Food Trucks Near a Location Based on Preferred Food
### Description:
Develop a solution to help the San Francisco team find food trucks near their location and based on their preferred food.<br>
The solution should return at least the closest food trucks options based on latitude, longitude, and preferred food.

### Acceptance Criteria:
<p>
The solution should accept input for latitude, longitude, amount of results, and preferred food.<br>
The solution should return a configurable amount of food truck options near the given location and based on the preferred food ordered by distance.<br>
The food truck data should be sourced from the San Francisco's open dataset.<br>
The solution should be implemented using ASP.NET Core. However an alternative can be used if required.<br>
Database technology is open to choose, but it is not required for this POC.
</p>

## Example

### Request
```curl
curl -X 'POST' \
  'https://localhost:7044/FoodTruckLocator/Search' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "latitude": 37.773369571615426,
  "longitude": -122.41769774641541,
  "numberOfResults": 5,
  "preferredFood": [
	"Tacos"
  ]
}'
```

### Response
```json
{
  "hasResults": true,
  "foodTrucks": [
    {
      "name": "Bay Area Mobile Catering, Inc. dba. Taqueria Angelica's",
      "foodItems": [
        "tacos",
        "burritos",
        "soda & juice"
      ],
      "latitude": "37.77522830783405",
      "longitude": "-122.41746613186956",
      "distanceinMiles": "0.1"
    },
    {
      "name": "Senor Sisig",
      "foodItems": [
        "senor sisig",
        "filipino fusion food",
        "tacos",
        "burritos",
        "nachos",
        "rice plates. various beverages.chairman bao",
        "vegetable and meat sandwiches filled with asian-flavored meats and vegetables."
      ],
      "latitude": "37.7758255197583",
      "longitude": "-122.41724962664345",
      "distanceinMiles": "0.2"
    },
    {
      "name": "Bay Area Mobile Catering, Inc. dba. Taqueria Angelica's",
      "foodItems": [
        "tacos",
        "burritos",
        "soda & juice"
      ],
      "latitude": "37.771586702670334",
      "longitude": "-122.41400704302406",
      "distanceinMiles": "0.2"
    },
    {
      "name": "CARDONA'S FOOD TRUCK",
      "foodItems": [
        "tacos",
        "burritos",
        "quesadillas",
        "various drinks"
      ],
      "latitude": "37.767817181414145",
      "longitude": "-122.42057533514163",
      "distanceinMiles": "0.4"
    },
    {
      "name": "Street Meet",
      "foodItems": [
        "burritos",
        "tacos",
        "quesadillas",
        "tortas",
        "carne asada fries and various drinks"
      ],
      "latitude": "37.779159119969",
      "longitude": "-122.4158078824267",
      "distanceinMiles": "0.4"
    }
  ]
}
```
