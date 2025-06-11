// using SalesManagement.Domain.Customers;
// using SalesManagement.Domain.Customers.ValueObjects;
//
// namespace SalesManagement.Domain.Test.Customers;
//
// public class CustomerTest
// {
//     [Fact]
//     public void IsValid_ValidCustomer_Successfully()
//     {
//         var validCustomer = new Customer
//         {
//             FirstName = "John",
//             LastName = "Doe",
//             Email = new EmailAddress
//             {
//                 Value = "johndoe@gmail.com"
//             },
//             DateOfBirth = new DateTime(1980, 01, 01),
//             DeliveryAddress = new DeliveryAddress
//             {
//                 Address = "123 Main Street",
//                 City = "London",
//                 Country = "England",
//             }
//         };
//         
//         var actualResult = validCustomer.IsValid();
//         
//         Assert.True(actualResult);
//     }
//     
//     [Fact]
//     public void IsValid_EmptyFirstName_ReturnFalse()
//     {
//         var validCustomer = new Customer
//         {
//             FirstName = string.Empty,
//             LastName = "Doe",
//             Email = new EmailAddress
//             {
//                 Value = "johndoe@gmail.com"
//             },
//             DateOfBirth = new DateTime(1980, 01, 01),
//             DeliveryAddress = new DeliveryAddress
//             {
//                 Address = "123 Main Street",
//                 City = "London",
//                 Country = "England",
//             }
//         };
//         
//         var actualResult = validCustomer.IsValid();
//         
//         Assert.False(actualResult);
//     }
//     
//     [Fact]
//     public void IsValid_EmptyLastName_ReturnFalse()
//     {
//         var validCustomer = new Customer
//         {
//             FirstName = "John",
//             LastName = string.Empty,
//             Email = new EmailAddress
//             {
//                 Value = "johndoe@gmail.com"
//             },
//             DateOfBirth = new DateTime(1980, 01, 01),
//             DeliveryAddress = new DeliveryAddress
//             {
//                 Address = "123 Main Street",
//                 City = "London",
//                 Country = "England",
//             }
//         };
//         
//         var actualResult = validCustomer.IsValid();
//         
//         Assert.False(actualResult);
//     }
//     
//     [Fact]
//     public void IsValid_InvalidEmail_ReturnFalse()
//     {
//         var validCustomer = new Customer
//         {
//             FirstName = "John",
//             LastName = string.Empty,
//             Email = new EmailAddress
//             {
//                 Value = "john"
//             },
//             DateOfBirth = new DateTime(1980, 01, 01),
//             DeliveryAddress = new DeliveryAddress
//             {
//                 Address = "123 Main Street",
//                 City = "London",
//                 Country = "England",
//             }
//         };
//         
//         var actualResult = validCustomer.IsValid();
//         
//         Assert.False(actualResult);
//     }
//     
//     [Fact]
//     public void IsValid_InvalidAddress_ReturnFalse()
//     {
//         var validCustomer = new Customer
//         {
//             FirstName = "John",
//             LastName = string.Empty,
//             Email = new EmailAddress
//             {
//                 Value = "john@gmail.com"
//             },
//             DateOfBirth = new DateTime(1980, 01, 01),
//             DeliveryAddress = new DeliveryAddress
//             {
//                 Address = string.Empty,
//                 City = "London",
//                 Country = "England",
//             }
//         };
//         
//         var actualResult = validCustomer.IsValid();
//         
//         Assert.False(actualResult);
//     }
//     
//     [Fact]
//     public void IsValid_InvalidCity_ReturnFalse()
//     {
//         var validCustomer = new Customer
//         {
//             FirstName = "John",
//             LastName = string.Empty,
//             Email = new EmailAddress
//             {
//                 Value = "john@gmail.com"
//             },
//             DateOfBirth = new DateTime(1980, 01, 01),
//             DeliveryAddress = new DeliveryAddress
//             {
//                 Address = "123 Main Street",
//                 City = string.Empty,
//                 Country = "England",
//             }
//         };
//         
//         var actualResult = validCustomer.IsValid();
//         
//         Assert.False(actualResult);
//     }
//     
//     [Fact]
//     public void IsValid_InvalidCountry_ReturnFalse()
//     {
//         var validCustomer = new Customer
//         {
//             FirstName = "John",
//             LastName = string.Empty,
//             Email = new EmailAddress
//             {
//                 Value = "john@gmail.com"
//             },
//             DateOfBirth = new DateTime(1980, 01, 01),
//             DeliveryAddress = new DeliveryAddress
//             {
//                 Address = "123 Main Street",
//                 City = "London",
//                 Country = string.Empty,
//             }
//         };
//         
//         var actualResult = validCustomer.IsValid();
//         
//         Assert.False(actualResult);
//     }
// }