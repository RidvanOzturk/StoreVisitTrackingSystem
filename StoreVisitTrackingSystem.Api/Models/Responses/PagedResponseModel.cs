namespace StoreVisitTrackingSystem.Api.Models.Responses;

public class PagedResponseModel<T>
{
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public List<T> Data { get; set; }
}
