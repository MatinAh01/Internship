using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Log_With_MediatR
{
    public class GetUserQuery : IRequest<string>
{
    public int UserId { get; set; }
}
    public class GetUserHandler : IRequestHandler<GetUserQuery, string>
    {
        private readonly ILogger<GetUserHandler> _logger;

        public GetUserHandler(ILogger<GetUserHandler> logger)
        {
            _logger = logger;
        }

        public async Task<string> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Fetching user {request.UserId}");
            await Task.Delay(500);
            return $"User_{request.UserId}";
        }
    }
}