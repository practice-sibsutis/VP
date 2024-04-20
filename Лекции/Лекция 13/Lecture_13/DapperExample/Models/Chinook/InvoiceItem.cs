using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DapperExample.Models.Chinook;

public class InvoiceItem
{
    public int? InvoiceLineId { get; set; }
    public int? InvoiceId { get; set; }
    public int? TrackId { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? Quantity { get; set; }
}