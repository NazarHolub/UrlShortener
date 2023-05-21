using System;
using System.Collections.Generic;

namespace UrlShortenerBackend.Models;

public partial class Url
{
    public int Id { get; set; }

    public string OldUrl { get; set; } = null!;

    public string NewUrl { get; set; } = null!;

    public int UserId { get; set; }
}
