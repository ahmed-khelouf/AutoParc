using AutoParc.Sender.Interfaces;

namespace AutoParc.Sender;

public class MailSender: IMailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        return Task.FromResult(0);
    }
}