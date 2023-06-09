﻿namespace DatabaseHandler.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime UserCreationDate { get; set; }
}
