using Domain.Enums;

namespace Application.Utils.SortingPagination;

public interface ISortingModel
{
    public string? SortingField { get; set; }
    public SortingOrder SortingOrder { get; set; }
}