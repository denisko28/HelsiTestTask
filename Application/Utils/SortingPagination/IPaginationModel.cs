namespace Application.Utils.SortingPagination;

public interface IPaginationModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}