using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCash.Api.Data;
using MyCash.Api.DTOs;
using MyCash.Api.Entities;
using MyCash.Api.Extension;
using MyCash.Api.ViewModel;

namespace MyCash.Api.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetCategoriesAsync([FromServices] AppDbContext context)
    {
        try
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(new ResultViewModel<List<Category>>(categories));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Category>>("00XCT001 - Falha interna no servidor."));
        }
    }

    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetCategoriesByIdAsync([FromRoute] int id,
                                                            [FromServices] AppDbContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new ResultViewModel<Category>($"Não foi encontrada uma categoria com o Id = {id}."));

            return Ok(new ResultViewModel<Category>(category));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Category>("00XCT002 - Falha interna no servidor."));
        }
    }

    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostCategoriesAsync([FromBody] CreateCategoryDTO model,
                                                         [FromServices] AppDbContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors())); 

        try
        {
            var category = new Category
            {
                Id = 0,
                Name = model.Name,
                MonthlyBudget = model.MonthlyBudget,
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, new ResultViewModel<Category>("00XCT003 - Não foi possível incluir a categoria."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Category>("00XCT004 - Falha interna no servidor."));
        }
    }

    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutCategoriesAsync([FromRoute] int id,
                                                        [FromBody] UpdateCategoryDTO model,
                                                        [FromServices] AppDbContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new ResultViewModel<Category>($"Não foi encontrada uma categoria com o Id = {id}."));

            category.Name = model.Name;
            category.MonthlyBudget = model.MonthlyBudget;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Category>(category));
        }
        catch(DbUpdateException e)
        {
            return StatusCode(500, new ResultViewModel<Category>("00XCT005 - Não foi possível alterar a categoria."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Category>("00XCT006 - Falha interna no servidor."));
        }
    }

    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteCategoriesAsync([FromRoute] int id,
                                                           [FromServices] AppDbContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new ResultViewModel<Category>($"Não foi encontrada uma categoria com o Id = {id}."));

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Category>(category));
        }
        catch(DbUpdateException e)
        {
            return StatusCode(500, new ResultViewModel<Category>("00XCT007 - Não foi possível excluir a categoria."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Category>("00XCT008 - Falha interna no servidor."));
        }
    }
}
