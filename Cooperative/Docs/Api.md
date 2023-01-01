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