using AutoParc.Senders.Interfaces;

namespace AutoParc.Senders;

public class MailSender: IMailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        return Task.FromResult(0);
    }
}