namespace UserDeviceManager.Api.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class UserController(IUserService userService, IMapper mapper) : ControllerBase
{
    private readonly IMapper mapper = mapper;
    private readonly IUserService userService = userService;

    #region CRUD
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserCreateDto addUser, CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            UserDomainModel businessAddUser = mapper.Map<UserDomainModel>(addUser);
            await userService.AddAsync(businessAddUser, token);
            return Ok();
        }
        return BadRequest(ModelState);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        UserResponseDto user = mapper.Map<UserResponseDto>(await userService.GetAsync(id, token));
        if (user is not null)
        {
            return Ok(user);
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        IEnumerable<UserDomainModel> userDomainModels = await userService.GetAllAsync(token);

        IEnumerable<UserResponseDto> models = userDomainModels.Select(e => mapper.Map<UserResponseDto>(e));

        if (models.Any())
        {
            return Ok(models);
        }
        return NotFound();
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UserUpdateDto updateUser, CancellationToken token)
    {
        UserDomainModel? user = await userService.GetAsync(id, token);

        if (user is not null)
        {
            UserDomainModel model = new()
            {
                Id = user.Id,
                Devices = user.Devices,
                LastName = updateUser.LastName,
                FirstName = updateUser.FirstName,
                DateOfBirth = updateUser.DateOfBirth,
                Email = user.Email
            };
            await userService.UpdateAsync(model, token);
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        if (await userService.Delete(id, token))
        {
            return Ok();
        }
        return NotFound();
    }
    #endregion CRUD
}
