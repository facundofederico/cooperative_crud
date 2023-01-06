# Cooperative API

- [Cooperative API](#buber-item-api)
  - [Create Item](#create-item)
    - [Create Item Request](#create-item-request)
    - [Create Item Response](#create-item-response)
  - [Get Item](#get-item)
    - [Get Item Request](#get-item-request)
    - [Get Item Response](#get-item-response)
  - [Update Item](#update-item)
    - [Update Item Request](#update-item-request)
    - [Update Item Response](#update-item-response)
  - [Delete Item](#delete-item)
    - [Delete Item Request](#delete-item-request)
    - [Delete Item Response](#delete-item-response)
  - [Get Budget](#get-budget)
    - [Get Budget Request](#get-budget-request)
    - [Get Budget Response](#get-budget-response)

## Create Item

### Create Item Request

```js
POST /items
```

```json
{
    "name": "Chest radiography",
    "description": "X-ray radiography that goes from the base of the...",
    "price": 2316.33
}
```

### Create Item Response

```js
201 Created
```

```yml
Location: {{host}}/items/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Chest radiography",
    "description": "X-ray radiography that goes from the base of the...",
    "price": 2316.33
}
```

## Get Item

### Get Item Request

```js
GET /items/{{id}}
```

### Get Item Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Chest radiography",
    "description": "X-ray radiography that goes from the base of the...",
    "price": 2316.33
}
```

## Update Item

### Update Item Request

```js
PUT /items/{{id}}
```

```json
{
    "name": "Chest radiography",
    "description": "X-ray radiography that goes from the base of the...",
    "price": 2316.33
}
```

### Update Item Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/items/{{id}}
```

## Delete Item

### Delete Item Request

```js
DELETE /items/{{id}}
```

### Delete Item Response

```js
204 No Content
```

## Get Budget

### Get Budget Request

```js
GET /budgets
```

```json
{
    "discount": 0.15,
    "items":
    {[
        {
            "itemId": "70b2ca29-deaf-48e6-9485-88ef496b5202",
            "quantity": 3,
            "discount": 0.1
        },
        {
            "itemId": "0f167b41-21f1-4987-94ea-67b986ab813b",
            "quantity": 1,
            "discount": 0.0
        }
    ]}
}
```

### Get Budget Response

```js
200 Ok
```

```json
{
    "date": "2023-01-05T23:44:44.8123876Z",
    "discount": 0.15,
    "total": 3920.84685,
    "items":
    {[
        {
            "item": 
            {
                "id": "70b2ca29-deaf-48e6-9485-88ef496b5202",
                "name": "Blood test",
                "description": "Blood extraction to test...",
                "price": 850.53
            },
            "quantity": 3,
            "discount": 0.1,
            "total": 2296.431
        },
        {
            "item": 
            {
                "id": "0f167b41-21f1-4987-94ea-67b986ab813b",
                "name": "Chest radiography",
                "description": "X-ray radiography that goes from the base of the...",
                "price": 2316.33
            },
            "quantity": 1,
            "discount": 0.0,
            "total": 2316.33
        }
    ]}
}
```