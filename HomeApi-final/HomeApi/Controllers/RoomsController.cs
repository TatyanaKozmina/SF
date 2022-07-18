using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;
using HomeApi.Data.Queries;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _repository;
        private IMapper _mapper;
        
        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //TODO: Задание - добавить метод на получение всех существующих комнат
        
        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost] 
        [Route("")] 
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена!");
            }
            
            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }

        /// <summary>
        /// Перенастраиваем существующую комнату, перезаписывая все или часть её свойств
        /// </summary>
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] UpdateRoomRequest request)
        {
            var room = await _repository.GetRoomByName(request.Name);
            if (room == null)
                return StatusCode(400, $"Ошибка: Комната {request.Name} не подключена. Сначала подключите комнату!");

            await _repository.UpdateRoom(room,
                                         new UpdateRoomQuery(request.Area, request.GasConnected, request.Voltage)
            );

            return StatusCode(200, $"Свойства комнаты {request.Name} перезаписаны.");
        }
    }
}