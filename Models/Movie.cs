using System;
using System.ComponentModel.DataAnnotations;

namespace dwdm_pws2_movies_app.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}
