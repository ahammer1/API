using HoneyRaesAPI.Models;

 
        // Create collections for customers, employees, and service tickets
        List<Customer> customers = new()
        {
            new Customer() { Id = 1, Name = "John Doe", Address = "123 Main St" },
            new Customer() { Id = 2, Name = "Jane Smith", Address = "456 Oak Ave" },
            new Customer() { Id = 3, Name = "Bob Johnson", Address = "789 Pine Rd" }
        };

        List<Employee> employees = new()
        {
            new Employee() { Id = 101, Name = "Alice" },
            new Employee() { Id = 102, Name = "Bob" }
        };

        List<ServiceTicket> serviceTickets = new()
        {
            new ServiceTicket() { Id = 1, CustomerId = 1, EmployeeId = 101, Description = "Issue with printer", Emergency = true, DateCompleted = DateTime.Now },
            new ServiceTicket() { Id = 2, CustomerId = 2, EmployeeId = 108, Description = "Network connectivity problem", Emergency = false },
            new ServiceTicket() { Id = 3, CustomerId = 1, EmployeeId = 103, Description = "Software installation", Emergency = false, DateCompleted = DateTime.Now },
            new ServiceTicket() { Id = 4, CustomerId = 3, EmployeeId = 102, Description = "Hardware replacement", Emergency = true },
            new ServiceTicket() { Id = 5, CustomerId = 2, EmployeeId = 101, Description = "Email configuration", Emergency = false, DateCompleted = DateTime.Now }
        };

    

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapGet("/servicetickets", () =>
{
    return serviceTickets;
});

app.MapGet("/servicetickets/{id}", (int id) =>
{
    return serviceTickets.FirstOrDefault(st => st.Id == id);
});

app.Run();
