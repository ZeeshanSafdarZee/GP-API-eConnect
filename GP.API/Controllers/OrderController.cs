using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GP.API.Models;
using System.Diagnostics;
using GP.API.Services;
using GP.API.Entities;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace GP.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class OrderController : Controller
    {
        private ISOPOrderRepository _orderRepository;
        private ILogger<OrderController> _logger;

        public OrderController(ISOPOrderRepository orderRepository, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetOrders([FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
        {

            _logger.LogInformation(LoggingEvents.GET_STATUS, $"GetOrders request parameters: {Key}, {Timestamp}, {Signature}");

            //if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
            //{
            //    return Unauthorized();
            //}

            var orderEntities = _orderRepository.GetOrders();

            if (orderEntities == null)
            {
                return NotFound();
            }

            var ordersResponse = Mapper.Map<List<SOPWorkHeaderDto>>(orderEntities);
            return Ok(ordersResponse);
        }

        [HttpGet("updated/{updatedSince}")]
        public IActionResult GetUpdatedOrders(DateTime updatedSince, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
        {
            _logger.LogInformation(LoggingEvents.GET_ORDER, $"GetUpdatedOrders request parameters: {Key}, {Timestamp}, {Signature}");

            //if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
            //{
            //    return Unauthorized();
            //}

            var orderEntities = _orderRepository.GetUpdatedOrders(updatedSince);

            if (orderEntities == null)
            {
                return NotFound();
            }

            var ordersResponse = Mapper.Map<List<SOPWorkHeaderDto>>(orderEntities);
            
            return Ok(ordersResponse);
        }

        [HttpGet("{sopnumbe}")]
        public IActionResult GetOrder(string Sopnumbe, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
        {
            _logger.LogInformation(LoggingEvents.GET_STATUS, $"GetOrder request parameters: {Key}, {Timestamp}, {Signature}");

            //if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
            //{
            //    return Unauthorized();
            //}

            var order = _orderRepository.GetOrder(Sopnumbe);

            if (order == null)
            {
                return NotFound();
            }
            
            var orderResponse = Mapper.Map<SOPWorkHeaderDto>(order);

            var orderTracking = _orderRepository.GetOrderTracking(Sopnumbe);

            orderResponse.SOPTrackingNumbers = Mapper.Map<List<SOPTrackingDto>>(orderTracking);
        
            return Ok(orderResponse);
        }

        [HttpPost]
        public IActionResult SaveOrder([FromBody]SalesOrderDto webSalesOrder, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
        {
            var sw = new Stopwatch();
            sw.Start();
            decimal elapsedTime = 0;

            _logger.LogInformation(LoggingEvents.GET_STATUS, $"SaveOrder post parameters: {Key}, {Timestamp}, {Signature}");

            //if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
            //{
            //    return Unauthorized();
            //}

            if (webSalesOrder == null)
            {
                return StatusCode(400);
            }

            SalesOrderResponseDto orderResponse = new SalesOrderResponseDto();

            bool success = APIController.Instance.ImportSalesOrder(webSalesOrder, ref orderResponse);

            var saveOrderResponse = Mapper.Map<SalesOrderResponseDto>(orderResponse);

            if (success == false)
            {
                saveOrderResponse.Success = false;
                saveOrderResponse.OrderNumber = string.Empty;
                saveOrderResponse.ErrorCode = LoggingEvents.INSERT_ORDER_FAILED;
                _logger.LogInformation(LoggingEvents.INSERT_ORDER_FAILED, "SaveOrder failed: " + orderResponse.ErrorMessage);
            }


            sw.Stop();

            elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
            saveOrderResponse.Elapsed = elapsedTime.ToString();

            _logger.LogInformation(LoggingEvents.INSERT_ORDER, "SaveOrder complete: " + saveOrderResponse.Elapsed);

            return Ok(saveOrderResponse);

        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody]SalesOrderDto webSalesOrder, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
        {
            var sw = new Stopwatch();
            sw.Start();
            decimal elapsedTime = 0;

            _logger.LogInformation(LoggingEvents.GET_STATUS, $"UpdateOrder post parameters: {Key}, {Timestamp}, {Signature}");

            //if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
            //{
            //    return Unauthorized();
            //}

            if (webSalesOrder == null)
            {
                _logger.LogInformation(LoggingEvents.INSERT_ORDER_EXCEPTION, $"UpdateOrder: Bad Request: Vendor object was not provided in body (null)");
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                _logger.LogInformation(LoggingEvents.INSERT_ORDER_EXCEPTION, $"UpdateOrder: Invalid Request: Invalid order values were submitted");
                return BadRequest(ModelState);
            }

            SalesOrderResponseDto orderResponse = new SalesOrderResponseDto();

            bool success = APIController.Instance.UpdateSalesOrder(webSalesOrder, ref orderResponse);

            var saveOrderResponse = Mapper.Map<SalesOrderResponseDto>(orderResponse);

            if (success == false)
            {
                saveOrderResponse.Success = false;
                saveOrderResponse.OrderNumber = string.Empty;
                saveOrderResponse.ErrorCode = LoggingEvents.INSERT_ORDER_FAILED;
                _logger.LogInformation(LoggingEvents.INSERT_ORDER_FAILED, "UpdateOrder failed: " + orderResponse.ErrorMessage);
            }


            sw.Stop();

            elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
            saveOrderResponse.Elapsed = elapsedTime.ToString();

            _logger.LogInformation(LoggingEvents.INSERT_ORDER, "UpdateOrder complete: " + saveOrderResponse.Elapsed);

            return Ok(saveOrderResponse);

        }
        [HttpDelete]
        public IActionResult DeleteOrder([FromBody]taSopLineDelete webSalesOrder, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
        {
            var sw = new Stopwatch();
            sw.Start();
            decimal elapsedTime = 0;

            _logger.LogInformation(LoggingEvents.GET_STATUS, $"DeleteOrder post parameters: {Key}, {Timestamp}, {Signature}");

            //if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
            //{
            //    return Unauthorized();
            //}

            if (webSalesOrder == null)
            {
                _logger.LogInformation(LoggingEvents.INSERT_ORDER_EXCEPTION, $"DeleteOrder: Bad Request: Vendor object was not provided in body (null)");
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                _logger.LogInformation(LoggingEvents.INSERT_ORDER_EXCEPTION, $"DeleteOrder: Invalid Request: Invalid order values were submitted");
                return BadRequest(ModelState);
            }

            SalesOrderResponseDto orderResponse = new SalesOrderResponseDto();

            bool success = APIController.Instance.DeleteSalesOrder(webSalesOrder, ref orderResponse);

            var saveOrderResponse = Mapper.Map<SalesOrderResponseDto>(orderResponse);

            if (success == false)
            {
                saveOrderResponse.Success = false;
                saveOrderResponse.OrderNumber = string.Empty;
                saveOrderResponse.ErrorCode = LoggingEvents.INSERT_ORDER_FAILED;
                _logger.LogInformation(LoggingEvents.INSERT_ORDER_FAILED, "UpdateOrder failed: " + orderResponse.ErrorMessage);
            }

            sw.Stop();

            elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
            saveOrderResponse.Elapsed = elapsedTime.ToString();

            _logger.LogInformation(LoggingEvents.INSERT_ORDER, "UpdateOrder complete: " + saveOrderResponse.Elapsed);

            return Ok(saveOrderResponse);
        }
        
    }
}