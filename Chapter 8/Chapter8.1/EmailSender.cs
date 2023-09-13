namespace Chapter8._1
{
    public class EmailSender
    {
        private readonly NetworkClient _client;
        private readonly MessageFactory _factory;

        public EmailSender()
        {
        }

        public EmailSender(NetworkClient client, MessageFactory factory)
        {
            _client = client;
            _factory = factory;
        }

        public void SendEmail(string username)
        {
           var email = _factory.Create(username);
           _client.SendMail(email);
           Console.WriteLine($"Email sent to {username}!");
        }
    }
}
