using Supabase;

namespace AppointmentREST.Extension
{
    public static class SupabaseConfiguration
    {
        public static IServiceCollection AddSupabaseConnection(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("Supabase:Url");
            var key = configuration.GetValue<string>("Supabase:Key");
            
            var options = new SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            
            var supabaseClient = new Client(url, key, options);
            services.AddSingleton(supabaseClient);
            return services;
        }
    }
}