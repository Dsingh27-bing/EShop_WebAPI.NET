using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ApplicationCore.Entities;

public class UserAddress
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public int? AddressId { get; set; }
    [MaxLength (250)]
    public string? IsDefaultAddress { get; set; }

    public Customer? Customer { get; set; }
    public Address? Address { get; set; }
}