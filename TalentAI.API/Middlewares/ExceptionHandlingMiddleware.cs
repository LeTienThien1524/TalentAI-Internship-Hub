using FluentValidation; // 🌟 1. Nhớ thêm namespace này để nhận diện ValidationException
using System.Net;
using System.Text.Json;

namespace TalentAI.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger; // Nên inject thêm logger để log lỗi hệ thống

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            // 🌟 2. BẮT BÀI: Nếu lỗi sinh ra là do FluentValidation chặn dữ liệu bẩn
            if (ex is ValidationException validationException)
            {
                // Ép mã lỗi về 400 Bad Request
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                // Gom sạch danh sách các ô nhập liệu bị lỗi
                var errors = validationException.Errors
                    .Select(e => new { Field = e.PropertyName, Error = e.ErrorMessage });

                // Trả về cấu hình JSON đồng nhất với định dạng Result của hệ thống
                var errorResponse = new
                {
                    Value = (object?)null,
                    IsSuccess = false,
                    IsFailure = true,
                    Message = "Dữ liệu đầu vào không hợp lệ!",
                    Errors = errors
                };

                // Dùng luôn cấu hình lạc đà (camelCase) mặc định khi Serialize cho Frontend dễ đọc
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
            }
            else
            {
                // 🌟 3. Nếu là các lỗi hệ thống khác (Lỗi SQL, lỗi Logic...) thì giữ nguyên mã 500
                _logger.LogError(ex, "Lỗi hệ thống nội bộ: {Message}", ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    Value = (object?)null,
                    IsSuccess = false,
                    IsFailure = true,
                    Message = "Đã xảy ra lỗi hệ thống nghiêm trọng, vui lòng liên hệ admin!",
                    Errors = Enumerable.Empty<object>() // Trả về mảng rỗng cho đồng nhất cấu trúc
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
            }
        }
    }
}