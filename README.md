**Setup Project**
---

### 🛠 1. **server ASP .NET**
Di chuyển vào thư mục server
```powershell
cd server
```
Cài đặt lại các package của dự án ASP .NET
```powershell
dotnet restore
```
Cài đặt **dotnet ef** của Entity Framework Tool
```powershell
dotnet tool install --global dotnet-ef
```
Chạy server **Chạy default ở port 5000 5001**
```powershell
dotnet run
```

### 🛠 2. **client React - Ant Design**
Di chuyển vào thư mục client
```powershell
cd client 
```
Cài đặt lại các package của dự án React
```powershell
npm install 
```
Chạy client **Chạy default ở port 3000**
```powershell
npm start 
```
