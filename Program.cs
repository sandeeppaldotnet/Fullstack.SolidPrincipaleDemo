using SolidPrincipaleDemo.Data;
using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Notification;
using SolidPrincipaleDemo.Services;
using SolidPrincipaleDemo.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Dependency registrations
//builder.Services.AddSingleton<IOrderRepository,
    //InMemoryOrderRepository>();

builder.Services.AddSingleton<IOrderRepository,
    AlternativeOrderRepository>();


builder.Services.AddScoped<OrderService>();


builder.Services.AddScoped<IDiscountPolicy,
    RegularDiscountPolicy>();

builder.Services.AddScoped<IDiscountPolicy,
    PremiumDiscountPolicy>();

builder.Services.AddScoped<IDiscountPolicy,
    FestivalDiscountPolicy>();

builder.Services.AddScoped<IDiscountPolicy,
    EmployeeDiscountPolicy>();

builder.Services.AddScoped<PricingService>();
builder.Services.AddScoped<IDiscountPolicy,
    StudentDiscountPolicy>();


builder.Services.AddScoped<IPaymentMethod, CardPayment>();

builder.Services.AddScoped<IPaymentMethod, UpiPayment>();

builder.Services.AddScoped<IPaymentMethod, CashPayment>();

builder.Services.AddScoped<PaymentService>();

builder.Services.AddScoped<IEmailSender,
    EmailNotificationService>();

builder.Services.AddScoped<ISmsSender,
    SmsNotificationService>();

builder.Services.AddScoped<IWhatsAppSender,
    WhatsAppNotificationService>();

builder.Services.AddScoped<OrderEmailService>();



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
