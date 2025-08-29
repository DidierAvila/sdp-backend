using Microsoft.AspNetCore.Mvc;
using SDP.Domain.Common;
using System.Text.Json;

namespace SDP.API.Controllers
{
    public static class PaginationHelpers
    {
        public static IActionResult CreatePagedResponse<T>(this ControllerBase controller, PagedList<T> pagedList)
        {
            var metadata = new
            {
                pagedList.TotalCount,
                pagedList.PageSize,
                pagedList.PageNumber,
                pagedList.TotalPages,
                pagedList.HasPrevious,
                pagedList.HasNext
            };

            controller.Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metadata));

            return controller.Ok(pagedList.Items);
        }
    }
}
