using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Address
{
    public int Id { get; set; }
    [MaxLength(150)]
    public String? Street1 { get; set; }
    [MaxLength(150)]
    public String? Street2 { get; set; }
    [MaxLength(50)]
    public String? City { get; set; }
    [MaxLength(50)]
    public String? State { get; set; }
    [MaxLength(50)]
    public String? Country { get; set; }
    [MaxLength(10)]
    public String? ZipCode { get; set; }
    
    public IEnumerable<UserAddress> UserAddresses { get; set; }
}