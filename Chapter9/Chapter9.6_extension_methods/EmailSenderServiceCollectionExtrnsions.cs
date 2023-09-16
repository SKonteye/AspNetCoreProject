namespace Chapter9._6_extension_methods
{
    public static class EmailSenderServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailSender(
            this IServiceCollection services)
        {
            services.AddScoped<IEmailSender>();
            services.AddScoped<NetworkClient>();
            services.AddScoped<MessageFactory>();
            services.AddSingleton(
                new EmailServerSettings
                (
                    host: "smtp.server.com",
                    port: 25));
            return services;
        }
    }
}
