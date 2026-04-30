using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;

        }


        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> Post([FromBody]OrdersDto orderdto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var orderData = await _orderService.AddOrder(orderdto);
                    return StatusCode(StatusCodes.Status201Created, orderData);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not Found");
            }
        }

        [HttpDelete]
        [Route("DeleteOrderByOrderid/{orderid}")]
       
        public async Task<IActionResult> delete(int orderid)
        {
            if(orderid<0)
            {
                // If input parametes are wrongly sent or empty, we will get 400 bad request status code 
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var orderData = await _orderService.DeleteOrderById(orderid);

                if(orderData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "orderDataf not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                var orderdata = await _orderService.GetOrders();
                if (orderdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, orderdata);
                }
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

        [HttpGet]
        [Route("GetOrderByOrderid/{orderid}")]
        public async Task<IActionResult> Get(int orderid)
        {
            if(orderid<0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var orderdata = await _orderService.GetOrderById(orderid);
                return StatusCode(StatusCodes.Status200OK, orderdata);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server error");
            }
        }


        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> put([FromBody] OrdersDto orderdto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var orderData = await _orderService.UpdateOrder(orderdto);
                    return StatusCode(StatusCodes.Status200OK, orderData);
                }

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }



    }
}
