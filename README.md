# SKU Parser for Team Fortress 2 Items

This C# library provides functionality to **parse Team Fortress 2 item SKUs into `ItemElement` objects and vice versa**. It was inspired by [Niclason's node-tf2-sku](https://github.com/Nicklason/node-tf2-sku) for Node.js. The library offers a convenient way to decode item attributes encoded in SKU strings and transform `ItemElement` objects back into SKU strings.

The SKU parsing logic supports various item attributes such as `defindex`, `quality`, `australium`, `craftable`, `festive`, `strange`, etc.

## Features
- Parse SKU string to `ItemElement` object
- Convert `ItemElement` object to SKU string
- Supports various TF2 item attributes
- Extendable and customizable

## Usage examples
```csharp
using Sku.Enums;
using Sku.Models;
using TF2.Sku;

// Converting item attributes from sku to C# object
ItemElement item = TF2Sku.FromString(30743;5;u117);

// Converting C# object to its string equivalent
string sku = TF2Sku.FromObject(ItemElement item);
```
## Tests
The library is equipped with a basic unit tests to easily test output values.

## Use Cases
Whether you're building a trading bot, an inventory management system, or a game statistics analyzer, this SKU parser could be an invaluable tool for handling Team Fortress 2 item data.

## Acknowledgements
This project was inspired by [Niclason's node-tf2-sku](https://github.com/Nicklason/node-tf2-sku) for Node.js.
