using category.application;
using category.application.Contracts.Request;
using Microsoft.AspNetCore.Mvc;

namespace category.web.api.Controllers;

[ApiController]
[Route("api/v1/category")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    private readonly IWebHostEnvironment _env;

    public CategoryController(
        ICategoryService categoryService, 
        IWebHostEnvironment env)
    {
        _categoryService = categoryService;
        _env = env;
    }

    [HttpPost("create")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] CreateCategory categoryRequest)
    {
        try
        {
            var result = await _categoryService.CreateAsync(categoryRequest, _env);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{categoryId:guid}/image")]
    [Produces("image/jpeg", "image/png", "image/webp", "image/gif")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetImage(Guid categoryId)
    {
        try
        {
            var imageInfo = await _categoryService.GetImagePathAsync(categoryId);
            return PhysicalFile(imageInfo.ImagePath, imageInfo.ContentType);
        }
        catch(ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("gelAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allCategoryInfos = await _categoryService.GetAllCategoryInfos();
            return Ok(allCategoryInfos);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
