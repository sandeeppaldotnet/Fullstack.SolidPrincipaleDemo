# SolidPrincipaleDemo

A small ASP.NET Core Web API that demonstrates SOLID design principles through an order-processing example. The application separates order persistence, pricing and discount rules, payment methods, and notification channels behind interfaces and composes them with built-in dependency injection.

> This project is a learning/demo application. Orders are stored in memory, payment providers are simulated, and notification providers write their activity to the console.

## Technology Stack

- .NET 10 (`net10.0`)
- ASP.NET Core Web API
- C# with nullable reference types enabled
- Swagger UI through Swashbuckle
- ASP.NET Core OpenAPI support
- In-memory data storage; no external database is required

## Prerequisites

- .NET 10 SDK
- Visual Studio 2026 or another IDE/editor with .NET 10 support
- PowerShell, Bash, or an equivalent terminal

Verify the SDK installation:

```bash
dotnet --version
```

## Getting Started

From the repository directory:

```bash
dotnet restore
dotnet build
dotnet run
```

The application uses the launch profile configured in `Properties/launchSettings.json`. The sample HTTP file currently uses:

```text
http://localhost:5131
```

When running in the Development environment, Swagger UI is available at:

```text
https://localhost:<https-port>/swagger
```

or:

```text
http://localhost:<http-port>/swagger
```

The exact HTTPS and HTTP ports are displayed by `dotnet run` and can be changed in `Properties/launchSettings.json`.

## API Endpoints

All functional endpoints use the `/api` route prefix.

### Orders

#### List orders

```http
GET /api/Orders
```

Returns all orders currently held by the configured repository.

#### Get an order

```http
GET /api/Orders/{id}
```

Returns an order by numeric ID, or `404 Not Found` when the ID does not exist.

#### Create an order

```http
POST /api/Orders
Content-Type: application/json

{
  "customerName": "Asha",
  "amount": 2000,
  "customerType": "Premium"
}
```

Successful requests return `201 Created` with an order similar to:

```json
{
  "id": 1,
  "customerName": "Asha",
  "amount": 2000,
  "discount": 200,
  "totalAmount": 1800,
  "status": "Pending"
}
```

Validation rules:

- `customerName` must not be empty or whitespace.
- `amount` must be greater than zero.
- `customerType` determines the first matching discount policy. If no policy matches, the discount is zero.

Supported customer types and discounts are:

| Customer type | Discount |
| --- | ---: |
| `Regular` | 0% |
| `Premium` | 10% |
| `Festival` | 20% |
| `Employee` | 30% |
| `Student` | 15% |

Customer type matching in the current policies is case-sensitive. Use the values shown above.

### Payments

#### Process a payment

```http
POST /api/Payments
Content-Type: application/json

{
  "amount": 1800,
  "paymentMethod": "Card"
}
```

Supported payment methods are `Card`, `UPI`, and `Cash`. Payment method selection is case-insensitive.

A successful response contains a generated transaction ID:

```json
{
  "isSuccessful": true,
  "message": "Card payment successful.",
  "transactionId": "<guid>"
}
```

An unsupported payment method or a non-positive amount returns a failed payment result. The payment endpoint returns `400 Bad Request` when the result is unsuccessful.

### Notifications

Notification providers are simulations. They do not send real messages.

#### Send an email

```http
POST /api/Notifications/email
Content-Type: application/json

{
  "recipient": "customer@example.com",
  "message": "Your order is ready."
}
```

#### Send an SMS

```http
POST /api/Notifications/sms
Content-Type: application/json

{
  "recipient": "+15551234567",
  "message": "Your order is ready."
}
```

#### Send a WhatsApp message

```http
POST /api/Notifications/whatsapp
Content-Type: application/json

{
  "recipient": "+15551234567",
  "message": "Your order is ready."
}
```

Each notification endpoint returns `200 OK` with a message indicating that the notification was simulated.

## Project Structure

```text
SolidPrincipaleDemo/
├── Controllers/
│   ├── NotificationsController.cs  # Email, SMS, and WhatsApp endpoints
│   ├── OrdersController.cs         # Main order CRUD-style endpoints
│   ├── OrderController.cs          # Simple legacy/demo flow
│   └── PaymentsController.cs       # Payment endpoint
├── Data/
│   ├── AlternativeOrderRepository.cs
│   └── InMemoryOrderRepository.cs
├── Interfaces/                     # Abstractions used by application services
├── Models/                         # Request, response, and domain models
├── Notification/                   # Notification channel implementations
├── Services/                       # Application services and orchestration
├── Strategies/                     # Discount and payment strategies
├── Program.cs                      # Dependency injection and HTTP pipeline
├── SolidPrincipaleDemo.csproj      # .NET 10 project configuration
└── SolidPrincipaleDemo.http        # HTTP client request examples
```

## SOLID Principles Demonstrated

### Single Responsibility Principle

Responsibilities are separated across focused types:

- `OrderService` validates and creates orders.
- `PricingService` selects and applies discount policies.
- `PaymentService` selects a payment strategy.
- Notification services handle individual communication channels.
- Repository implementations handle order storage.

### Open/Closed Principle

New discount policies and payment methods can be added by implementing `IDiscountPolicy` or `IPaymentMethod` and registering the implementation. Existing services do not need to be rewritten.

### Liskov Substitution Principle

`OrderService` depends on `IOrderRepository`, so `AlternativeOrderRepository` and `InMemoryOrderRepository` can provide the storage behavior without changing the service API.

### Interface Segregation Principle

Communication channels use focused interfaces: `IEmailSender`, `ISmsSender`, and `IWhatsAppSender`. A consumer does not need to depend on unrelated notification operations.

### Dependency Inversion Principle

Controllers and services depend on abstractions such as `IOrderRepository`, `IDiscountPolicy`, `IPaymentMethod`, and notification sender interfaces. Implementations are supplied through dependency injection in `Program.cs`.

## Dependency Injection Configuration

The active order repository is `AlternativeOrderRepository`, registered as a singleton. It starts empty and keeps orders in process memory:

```csharp
builder.Services.AddSingleton<IOrderRepository,
	AlternativeOrderRepository>();
```

`InMemoryOrderRepository` is also available and contains two sample orders, but its registration is currently commented out. To use it instead, replace the active repository registration with the `InMemoryOrderRepository` registration.

Discount policies, payment methods, and notification services are registered as scoped services. `PricingService`, `PaymentService`, and `OrderEmailService` compose those implementations through `IEnumerable<T>` injection.

## Data and Runtime Behavior

- No database or external service is required.
- Data is lost when the application stops.
- `AlternativeOrderRepository` starts with no orders and assigns IDs beginning at `1`.
- Payment transaction IDs are generated with `Guid.NewGuid()`.
- Payment and notification operations print simulated activity to the application console.
- Swagger is enabled only when the application environment is `Development`.
- HTTPS redirection is enabled by the application pipeline.

## Testing the API

You can use Swagger UI, the Visual Studio `.http` editor, `curl`, or any API client such as Postman.

Example with `curl`:

```bash
curl -k -X POST "https://localhost:<https-port>/api/Orders" \
  -H "Content-Type: application/json" \
  -d '{"customerName":"Asha","amount":2000,"customerType":"Premium"}'
```

For PowerShell, use `Invoke-RestMethod`:

```powershell
$body = @{
	customerName = "Asha"
	amount = 2000
	customerType = "Premium"
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:<https-port>/api/Orders" -Method Post -ContentType "application/json" -Body $body
```

Replace `<https-port>` with the HTTPS port shown when the application starts. For local development certificates, `curl -k` bypasses certificate validation; do not use that option for production traffic.

## Development Notes

- Add a new discount rule by implementing `IDiscountPolicy` and registering it in `Program.cs`.
- Add a new payment option by implementing `IPaymentMethod` and registering it in `Program.cs`.
- Add a new notification channel with a focused interface and implementation, then expose it through a controller action if needed.
- Replace the repository with a database-backed implementation by implementing `IOrderRepository` and changing one DI registration.
- The `OrderController` endpoint is a basic illustrative flow and is separate from the primary `OrdersController` implementation.
- `SolidPrincipaleDemo.http` still contains the default weather-forecast request; use Swagger or the endpoint examples above for the implemented API.

## License

No license file is currently included in this repository. Add a license before distributing the project outside its intended learning or internal use.