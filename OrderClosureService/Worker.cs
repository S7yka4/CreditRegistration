using CreditRegistrationCommon;

namespace OrderClosureService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOrderCloseService _orderCloseService;

        public Worker(ILogger<Worker> logger,IOrderCloseService orderCloseService)
        {
            _logger = logger;
            _orderCloseService = orderCloseService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _orderCloseService.CloseOrder();
                await Task.Delay(60*2*1000, stoppingToken);
            }
        }
    }
}