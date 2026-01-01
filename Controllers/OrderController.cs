using BookManagement.API.DTOs;
using BookManagement.API.Models;
using BookManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto dto)
        {
            var result = await _orderService.CreateOrderAsync(dto);
            return Ok(ApiResponse<OrderResponseDto>.Ok(result, "Order created successfully"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return Ok(ApiResponse<List<OrderResponseDto>>.Ok(result, "Orders listed successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);

            if (result == null)
                return NotFound(ApiResponse<string>.Fail("Order not found"));

            return Ok(ApiResponse<OrderResponseDto>.Ok(result, "Order details fetched successfully"));
        }
    }
}