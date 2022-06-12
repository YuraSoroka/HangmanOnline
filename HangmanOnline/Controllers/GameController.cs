using HangmanOnline.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using HangmanOnline.Services.Contracts;
using HangmanOnline.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using HangmanOnline.Hubs;

namespace HangmanOnline.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> logger;
        private readonly IRoomService roomService;
        private readonly ICoreService coreService;
        private readonly IHubContext<HangmanHub> hubContext;

        public GameController(
            ILogger<GameController> logger, 
            IRoomService roomService,
            ICoreService coreService,
            IHubContext<HangmanHub> hubContext
            )
        {
            this.logger = logger;
            this.roomService = roomService;
            this.coreService = coreService;
            this.hubContext = hubContext;
        }

        // game/room
        [Route("game/{roomid:Guid}")]
        public IActionResult CreatePlayer([FromRoute]Guid roomId)
        {
            logger.LogInformation("Redirected to CreatePlayer action");
            return View();
        }

        [HttpPost]
        [Route("game/{roomid:Guid}")]
        public IActionResult CreatePlayer([FromRoute] Guid roomId, string name)
        {
            logger.LogInformation("Redirected to CreatePlayer action Post");
            return RedirectToAction("RenderScene", new { roomId, name});
        }

        [Route("game/{roomid:Guid}/play")]
        public async Task<IActionResult> RenderScene([FromRoute] Guid roomId, string name)
        {
            logger.LogInformation("Redirected to RenderScene action");

            if(!roomService.AddRoom(roomId, name))
            {
                logger.LogInformation("The room is full. Create another");
                return RedirectToAction("Index", "Home");
            }
            GameSession gameSession = coreService.GetSession(roomId.ToString());

            await hubContext.Clients.All.SendAsync("RenderScene", gameSession);

            return View("MainScene", gameSession);
        }

        public async Task<IActionResult> CreateRoomId()
        {
            Guid roomId = new CreateRoomIdHelper().CreateRoomID();
            return RedirectToAction("CreatePlayer", new { roomId });
        }

        [HttpGet]
        //[Route("game/update/{letter}")]
        [Route("game/{roomid:Guid}/update/{letter}")]
        public async Task<IActionResult> CheckLetter([FromRoute] Guid roomId, [FromRoute] string letter)
        {
            logger.LogInformation(letter + " " + roomId);
            GameSession gameSession = coreService.UpdateSession(roomId.ToString(), letter);
            await hubContext.Clients.All.SendAsync("RenderScene", gameSession);
            return Json(gameSession);
        }
    }
}