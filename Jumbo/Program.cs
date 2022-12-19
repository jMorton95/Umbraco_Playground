namespace Jumbo
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var inMemoryCacheSettings = new Dictionary<string, string>()
            {
                { "Smidge:version", Environment.GetEnvironmentVariable("BUILD_ID") ?? DateTime.UtcNow.ToString("yyyyMMddHHmm") },
                { "Smidge:dataFolder", null },
            };

            return Host.CreateDefaultBuilder(args)
                .ConfigureUmbracoDefaults()
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    builder.AddInMemoryCollection(inMemoryCacheSettings);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                });
        }
            
    }
}
