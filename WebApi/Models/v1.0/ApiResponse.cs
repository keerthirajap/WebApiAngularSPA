using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Models.v1._0
{
    public interface IResponse
    {
        string Message { get; set; }

        bool DidError { get; set; }

        bool DidValidationError { get; set; }

        string ErrorMessage { get; set; }
    }

    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }

    public interface ISingleCreatedResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }

    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }

    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }

        double PageCount { get; }
    }

    public class Response : IResponse
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public bool DidValidationError { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public bool DidValidationError { get; set; }

        public string ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }

    public class SingleCreatedResponse<TModel> : ISingleCreatedResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public bool DidValidationError { get; set; }

        public string ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }

    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public bool DidValidationError { get; set; }

        public string ErrorMessage { get; set; }

        public string RequestId { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }

    public class PagedResponse<TModel> : IPagedResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public bool DidValidationError { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<TModel> Model { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int ItemsCount { get; set; }

        public double PageCount
            => this.ItemsCount < this.PageSize ? 1 : (int)(((double)this.ItemsCount / this.PageSize) + 1);
    }

    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse(this IResponse response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.DidValidationError)
            {
                status = HttpStatusCode.BadRequest;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.DidValidationError)
            {
                status = HttpStatusCode.BadRequest;

                response.Model = response.Model;
            }
            else if (response.Model == null)
            {
                response.ErrorMessage = "Result not found";
                status = HttpStatusCode.NotFound;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this SingleCreatedResponse<TModel> response)
        {
            var status = HttpStatusCode.Created;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.DidValidationError)
            {
                status = HttpStatusCode.BadRequest;

                response.Model = response.Model;
            }
            else if (response.Model == null)
            {
                response.ErrorMessage = "Result not found";
                status = HttpStatusCode.NotFound;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.DidValidationError)
            {
                status = HttpStatusCode.BadRequest;
            }
            else if (response.Model == null)
            {
                response.ErrorMessage = "Result set not found";
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}