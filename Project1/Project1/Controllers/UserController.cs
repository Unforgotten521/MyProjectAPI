using Azure.Core;
using BackendApi.Contracts.User;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        /// GET /api/UsersController
        /// </remarks>
        /// <returns>Список всех пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Получение пользователя по ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        /// GET /api/UsersController/1
        /// </remarks>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь с указанным ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                RoleId = result.RoleId,
                GroupId = result.GroupId,
                CreatedAt = result.CreatedAt
            };
            return Ok(await _userService.GetById(id));
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        /// POST /api/UsersController
        /// {
        ///   "login": "A4Tech Bloody B188",
        ///   "password": "!Pa$$word123@",
        ///   "firstname": "Иван",
        ///   "lastname": "Иванов",
        ///   "middlename": "Иванович"
        /// }
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns>Результат операции: Ok() при успехе</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                RoleId = request.RoleId,
                GroupId = request.GroupId,
                CreatedAt = request.CreatedAt,
            };
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        /// PUT /api/UsersController
        /// {
        ///   "id": 1,
        ///   "login": "NewLogin123",
        ///   "password": "NewPass456!",
        ///   "firstname": "Петр",
        ///   "lastname": "Петров",
        ///   "middlename": "Петрович"
        /// }
        /// </remarks>
        /// <param name="user">Модель пользователя с обновлёнными данными</param>
        /// <returns>Результат операции: Ok() при успехе</returns>
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя по ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        /// DELETE /api/UsersController/1
        /// </remarks>
        /// <param name="id">Идентификатор пользователя для удаления</param>
        /// <returns>Результат операции: Ok() при успехе</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
