# Hệ thống đấu giá trực tuyến

Đề tài 10 – Xây dựng hệ thống đấu giá trực tuyến bằng C# và .NET 10 theo kiến trúc Microservices.

## Mục tiêu

Cho phép người dùng tạo phiên đấu giá, theo dõi phiên đấu giá, gửi lượt trả giá và nhận cập nhật theo thời gian thực.

## Kiến trúc dự kiến

- **Auction.Api**: REST API, quản lý phiên đấu giá và kết nối SignalR.
- **BidValidation.Service**: dịch vụ kiểm tra lượt trả giá qua gRPC.
- **Audit.Worker**: worker ghi nhận lịch sử sự kiện.
- **Auction.Contracts**: các hợp đồng/sự kiện dùng chung.
- **PostgreSQL**: lưu dữ liệu nghiệp vụ.
- **RabbitMQ**: truyền sự kiện giữa các dịch vụ.

## Công nghệ

- C# / .NET 10
- ASP.NET Core Minimal API
- Entity Framework Core
- gRPC
- RabbitMQ
- SignalR
- PostgreSQL
- Docker Compose

## Trạng thái

Repository đang được xây dựng theo từng commit chức năng. Các dịch vụ và cấu hình triển khai sẽ được bổ sung ở những commit tiếp theo.
