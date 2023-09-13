namespace Chapter8._1
{
    public class NetworkClient
    {
        private readonly EmailServerSettings _settings;
        public NetworkClient(EmailServerSettings settings)
        {
            _settings = settings;
        }

        public void SendMail(object email)
        {
            throw new NotImplementedException();
        }
    }
}
