namespace web_dev_assignment.Models;
using System.Collections.Generic;

public class Product {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; }  = string.Empty;// Desktop, Web, Mobile, Server
    public string Description { get; set; } = string.Empty ;
    public decimal Price { get; set; } = decimal.Zero ;
    public List<string> Features { get; set; } = new List<string> {};
    public bool HasSupport { get; set; } = false;
    public bool HasCustomization { get; set; } = false;
}
