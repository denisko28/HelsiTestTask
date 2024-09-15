using Domain.Enums;

namespace Application.Utils.SortingPagination;

public abstract class SortingPaginationModel : ISortingModel, IPaginationModel
{
    public string? SortingField { get; set; }
    public SortingOrder SortingOrder { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}