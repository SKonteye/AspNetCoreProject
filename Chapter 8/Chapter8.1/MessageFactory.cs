namespace Chapter8._1
{
    public class MessageFactory
    {
        public string Create(string username)
        {
           return $"Username: {username} created";
        }
    }
}
