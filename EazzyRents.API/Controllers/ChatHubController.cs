//using AutoMapper.Configuration.Annotations;
//using EazzyRents.Application.Chat;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;

//namespace EazzyRents.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ChatHubController : ControllerBase
//    {
//        private readonly IHubContext<ChatHub> chatHubContext;

//        public ChatHubController(IHubContext<ChatHub> chatHubContext)
//        {
//            this.chatHubContext = chatHubContext;
//        }

//        [HttpGet("connect")]
//        public async Task<IActionResult> Connect()
//        {
//            if(!HttpContext.WebSockets.IsWebSocketRequest)
//            {
//                return BadRequest("WebSocket connection requires");
//            }

//            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
//            await this.chatHubContext.Clients.All.SendAsync("UserConnected", "New user connected");

//            return new EmptyResult();
//        }
//    }
//}
