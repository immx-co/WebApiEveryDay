using category.application;
using category.application.Contracts.Request;
using category.core;
using Microsoft.AspNetCore.Http.HttpResults;
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
        catch(ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        
    }
}
