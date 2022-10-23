using System.ComponentModel.DataAnnotations;

namespace MyCash.Api.DTOs;

public class CreateCategoryDTO
{
    [Required]
    [StringLength(160, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 160 caracteres.")]
    public string Name { get; set; }
    [Required]
    public decimal MonthlyBudget { get; set; }
}

public class UpdateCategoryDTO
{
    [Required]
    [StringLength(160, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 160 caracteres.")]
    public string Name { get; set; }
    public decimal MonthlyBudget { get; set; }
}

public class GetCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal MonthlyBudget { get; set; }
}