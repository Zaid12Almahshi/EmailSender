namespace EmailSender.Entity;
public class Receiver
{
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Contant { get; set; }

    public IFormFile File { get; set; }

}

