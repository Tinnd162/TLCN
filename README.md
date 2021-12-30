# Tiểu luận chuyên ngành Kỹ thuật dữ liệu (khoa CNTT)
## Tên đề tài: Tìm hiểu về Microservices để xây dựng website bán hàng.
### GVHD: TS. Huỳnh Xuân Phụng
### Nhóm SVTH:
- Nguyễn Đăng Phước Tín   18133056
- Lâm Hoàng Việt 	        18133062
### Công nghệ sử dụng:
- C#, .NET 5, ASP.NET MVC(web application)
- CSDL: SQL Server, MongoDB, Redis.
### Hướng dẫn cài đặt:
#### Yêu cầu
- cài đặt Docker Desktop. tải ở đây **https://www.docker.com/products/docker-desktop**

#### Cài đặt
1. Git clone repository: **https://github.com/Tinnd162/TLCN_Microservices.git**

2. Khởi chạy app cùng docker với lệnh **docker-compose up -d**

3. Host Microservice:

- `Database`:
  - `Redis`              -> **http://localhost:6379**
  - `Mongo`              -> **http://localhost:27017**
  - `Sql Server`         -> **http://localhost:1433**
    + `User`    : **sa**
    + `Password`: **TCLN@181330**

- `Service`:
  - `Basket API`         -> **http://localhost:8000/swagger/index.html** 
  - `Product API`        -> **http://localhost:8000/swagger/index.html**
  - `Ordering API`       -> **http://localhost:8000/swagger/index.html**
  - `Inventory API`      -> **http://localhost:8000/swagger/index.html**
  - `Identity Server`    -> **http://localhost:8000/swagger/index.html** 
  - `Identity Service`   -> **http://localhost:8000/swagger/index.html**
  - `Aggregator API`     -> **http://localhost:8005**
  - `Ocelot API Gateway` -> **http://localhost:8010**
  - `RabbitMQ`           -> **http://localhost:15672**
    + `User`    : **guest**
    + `Password`: **guest**

- `UI`:
  - `Admin`              ->  **http://localhost:8015**
  - `Client`             ->  **http://localhost:8006**

4. Để dừng app dùng lệnh **docker-compose down** hoặc **docker-compose down -v** để xóa volumes khi dừng app.