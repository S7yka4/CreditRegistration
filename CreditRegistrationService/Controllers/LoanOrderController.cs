using CreditRegistration.DbCommon.Models;
using CreditRegistrationCommon;
using CreditRegistrationService.Bodies;
using Microsoft.AspNetCore.Mvc;

namespace CreditRegistrationService.Controllers
{
    [ApiController]
    public class LoanOrderController : ControllerBase
    {
        ITarrifService _tarrifService;
        ILoanOrderService _loanOrderService;
        ICreditRatingCalculator _creditRatingCalculator;
        ILogger _logger;
        public LoanOrderController(ITarrifService tarrifService, ILoanOrderService loanOrderService, ICreditRatingCalculator creditRatingCalculator, ILogger<LoanOrderController> logger)
        {
            _tarrifService = tarrifService;
            _loanOrderService = loanOrderService;
            _creditRatingCalculator = creditRatingCalculator;
            _logger = logger;
        }

        [HttpGet]
        [Route("getTarrifs")]
        public async Task<IActionResult> GetTarrifs()
        {
            return StatusCode(StatusCodes.Status200OK, await _tarrifService.GetTarrifs());
        }

        [HttpGet]
        [Route("getStatusOrder")]
        public async Task<IActionResult> GetStatusOrder(string orderId)
        {
            var result = await _loanOrderService.GetByOrderId(orderId);
            if (result is null)
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(ErrorCodes.OrderNotFound));
            return StatusCode(StatusCodes.Status200OK, result.Status);
        }
        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest body)
        {
            if (await _tarrifService.GetById(body.tarrifId) is null)
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(ErrorCodes.TarrifNotFound));
            var loanOrders = await _loanOrderService.GetByUserId(body.userId);
            if (loanOrders.FirstOrDefault(_ => _.Status == LoanOrderStatus.InProgress) is not null)
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(ErrorCodes.LoanConsideration));
            if (loanOrders.FirstOrDefault(_ => _.Status == LoanOrderStatus.Approved) is not null)
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(ErrorCodes.LoanApproved));
            if (loanOrders.FirstOrDefault(_ => _.Status == LoanOrderStatus.Refused && _.TimeUpdate.Subtract(_.TimeInsert).TotalMinutes >= 2) is not null)
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(ErrorCodes.TryLater));
            var loanOrder = new LoanOrder()
            {
                OrderId = Guid.NewGuid().ToString(),
                UserId = body.userId,
                TarrifId = body.tarrifId,
                CreditRating = _creditRatingCalculator.Calculate(body.userId),
                Status = LoanOrderStatus.InProgress,
                TimeInsert = DateTime.Now
            };
            await _loanOrderService.CreateLoanOrder(loanOrder);
            return StatusCode(StatusCodes.Status200OK, new CreateOrderSuccessResponse(loanOrder.OrderId));

        }

        [HttpDelete]
        [Route("deleteOrder")]
        public async Task<IActionResult> DeleteOrder(DeleteOrderRequest body)
        {
            var order = await _loanOrderService.GetByOrderAndUserId(body.orderId, body.userId);
            if (order is null)
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(ErrorCodes.OrderNotFound));
            if (order.Status == LoanOrderStatus.InProgress)
            {
                await _loanOrderService.DeleteOrder(order);
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(ErrorCodes.OrderImpossibleToDelete));
        }

    }
}
