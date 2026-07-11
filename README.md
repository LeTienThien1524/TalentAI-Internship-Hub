# TalentAI Internship Hub

TalentAI Internship Hub là nền tảng tuyển dụng thực tập ứng dụng trí tuệ nhân tạo (AI), giúp kết nối ứng viên và doanh nghiệp thông qua phân tích CV tự động và hệ thống đánh giá mức độ phù hợp giữa ứng viên và vị trí tuyển dụng.

## Tính năng chính

### Xác thực và phân quyền

* Đăng ký tài khoản
* Đăng nhập bằng JWT Authentication
* Refresh Token
* Quên mật khẩu và đặt lại mật khẩu
* Phân quyền theo vai trò (Admin, Candidate, Company)
* Quản lý người dùng

### Chức năng dành cho ứng viên

* Tạo và cập nhật hồ sơ cá nhân
* Quản lý học vấn, chứng chỉ và kinh nghiệm làm việc
* Tải lên nhiều CV
* Xem kết quả phân tích CV bằng AI
* Ứng tuyển vị trí thực tập
* Theo dõi trạng thái ứng tuyển
* Nhận thông báo từ hệ thống

### Chức năng dành cho doanh nghiệp

* Tạo và cập nhật hồ sơ công ty
* Đăng tin tuyển dụng thực tập
* Quản lý bài đăng tuyển dụng
* Xem danh sách ứng viên ứng tuyển
* Lên lịch phỏng vấn
* Đánh giá mức độ phù hợp của ứng viên bằng AI

### Tính năng AI

* Phân tích CV tự động
* Tóm tắt nội dung CV
* Trích xuất kỹ năng
* Trích xuất học vấn
* Trích xuất kinh nghiệm làm việc
* Tính toán điểm phù hợp giữa ứng viên và công việc
* Gợi ý công việc phù hợp cho ứng viên

## Công nghệ sử dụng

### Backend

* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQL Server
* MediatR
* AutoMapper
* FluentValidation
* JWT Authentication
* Clean Architecture
* Repository Pattern
* Unit Of Work Pattern

### Frontend

* React
* TypeScript
* Vite
* Tailwind CSS
* React Query
* React Router DOM

### Công cụ phát triển

* Visual Studio 2026
* Visual Studio Code
* Git và GitHub
* Swagger
* Postman
* Docker (Cơ bản)

## Thiết kế cơ sở dữ liệu

Hệ thống hiện tại bao gồm 23 bảng dữ liệu chính:

* Users
* Roles
* UserRoles
* Provinces
* JobCategories
* Skills
* Candidates
* CandidateSkills
* Educations
* Certificates
* Experiences
* Companies
* JobPostings
* JobSkills
* Resumes
* AIParsedResumes
* JobApplications
* ApplicationHistories
* Interviews
* AIMatchScores
* Notifications
* RefreshTokens
* PasswordResetTokens

## Kiến trúc dự án

### Backend

```text
TalentAI.API
TalentAI.Application
TalentAI.Domain
TalentAI.Infrastructure
```

### Frontend

```text
talentai-web
├── app
├── api
├── assets
├── features
├── layouts
├── routes
└── shared
```

## Tài liệu API

Swagger:

```text
https://localhost:7184/swagger
```

## Hướng dẫn chạy dự án

### Backend

```bash
git clone https://github.com/LeTienThien1524/TalentAI.git

cd TalentAI

dotnet restore

dotnet ef database update

dotnet run --project TalentAI.API
```

### Frontend

```bash
cd talentai-web

npm install

npm run dev
```

## Định hướng phát triển trong tương lai

* Tích hợp trợ lý phỏng vấn AI
* Xếp hạng CV theo mức độ phù hợp
* Gửi email thông báo tự động
* Thông báo thời gian thực bằng SignalR
* Dashboard phân tích dữ liệu nâng cao
* Cải thiện thuật toán gợi ý công việc

## Tác giả

**Lê Tiến Thiên**

* GitHub: https://github.com/LeTienThien1524
* LinkedIn: https://www.linkedin.com/in/ltthien1524/

## Giấy phép

Dự án được phát triển nhằm mục đích học tập, nghiên cứu và xây dựng hồ sơ năng lực cá nhân.
