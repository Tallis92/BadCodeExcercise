namespace InvoiceSender.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var db = new Database();
        var dueDate = new DateTimeProvider();
        var user = new User(){Id = 1, Name = "John Doe", Email = "john@example.com"};
        var invoice = new Invoice();
        invoice.Amount = 100;
        var sut = new SendInvoiceReminder(db, dueDate, user, invoice);

        var expected =
            "Sending email to john@example.com with subject 'Invoice Reminder' and body:\nDear John Doe,\n\n" +
            "Your invoice of 100 is due in den 15 november 2024.\n\nBest regards,\nThe Invoice Team"; 
        var actual = sut.GenerateInvoice();
        
        Assert.Equal(expected, actual);
    }
}