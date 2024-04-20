using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperExample;

public class User
{
    public int? _id { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }

    public override string ToString()
    {
        return $"{_id} {Name} {Age}";
    }
}