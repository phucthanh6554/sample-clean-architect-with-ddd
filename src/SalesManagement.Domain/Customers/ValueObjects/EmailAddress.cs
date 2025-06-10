using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Domain.Customers.ValueObjects;

public class EmailAddress
{
    [Column(TypeName = "nvarchar(255)")]
    public string Value { get; set; } = string.Empty;

    public bool IsValid()
    {
        if(string.IsNullOrWhiteSpace(Value))
            return false;

        var emailAddressAttribute = new EmailAddressAttribute();
        
        return emailAddressAttribute.IsValid(Value);
    }
}