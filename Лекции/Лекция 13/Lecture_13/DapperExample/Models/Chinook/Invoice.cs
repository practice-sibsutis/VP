using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DapperExample.Models.Chinook;

public class Invoice
{
    public int? InvoiceId { get; set; }
    public int? CustomerId { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public string? BillingAddress { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingState { get; set; }
    public string? BillingCountry { get; set; }
    public string? BillingPostalCode { get; set; }
    public decimal? Total { get; set; }
}