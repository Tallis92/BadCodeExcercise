// This is NOT how you should be coding!

using InvoiceSender;

var db = new Database();

var user = db.GetUser("john@example.com");
var invoice = db.GetInvoice(user.Id);

var dueDate = new DateTimeProvider();
var emailSender = new SendInvoiceReminder(db, dueDate, user, invoice).GenerateInvoice();
Console.WriteLine(emailSender);

public class SendInvoiceReminder
{
    private readonly IDatabase _db;
    private readonly IEmailSender _emailSender;
    private readonly DateTime _dueDate;
    private readonly User _user;
    private readonly Invoice _invoice;

    public SendInvoiceReminder(IDatabase db, IDateTimeProvider dueDate, User user, Invoice invoice)
    {
        _db = db;
        _dueDate = dueDate.Now.AddDays(7);
        _user = user;
        _invoice = invoice;
        _emailSender = new EmailSender();

    }

    public string GenerateInvoice()
    {
        var message = $"Dear {_user.Name},\n\nYour invoice of {_invoice.Amount} is due in {_dueDate.ToString("D")}.\n\nBest regards,\nThe Invoice Team";
        var completeMessage = _emailSender.SendEmail(_user.Email, "Invoice Reminder", message);
        return completeMessage;
    }
}

public interface IEmailSender
{
    string SendEmail(string to, string subject, string body);
}

public class EmailSender : IEmailSender
{
    public string SendEmail(string to, string subject, string body)
    {
        // Let's pretend this actually sends an email

        return $"Sending email to {to} with subject '{subject}' and body:\n{body}";
    }
}

public interface IDatabase
{
    User GetUser(string email);
    Invoice GetInvoice(int userId);
}

public class Database : IDatabase
{
    // Let's pretend this actually connects to a database
    public User GetUser(string email) => new User { Id = 1, Name = "John Doe", Email = email };

    public Invoice GetInvoice(int userId) => new Invoice
        { UserId = userId, Amount = 100, DueDate = DateTime.Now.AddDays(7) };
}

public interface IDateTimeProvider
{
    DateTime Now { get; }
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}