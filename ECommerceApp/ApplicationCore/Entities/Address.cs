using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Address
{
    public int Id { get; set; }
    [MaxLength(150)]
    public string? Street1 { get; set; }
    [MaxLength(150)]
    public string? Street2 { get; set; }
    [MaxLength(50)]
    public string? City { get; set; }
    [MaxLength(50)]
    public string? State { get; set; }
    [MaxLength(50)]
    public string? Country { get; set; }
    [MaxLength(10)]
    public string? ZipCode { get; set; }
    
    public IEnumerable<UserAddress> UserAddresses { get; set; }
}