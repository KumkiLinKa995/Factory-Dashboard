# 🏭 工廠管理系統 (Factory Management System)

以 **C# .NET API** 開發的工廠管理系統，透過 API 與伺服器進行互動。  
系統提供機台管理、數據視覺化與 CSV 檔案分析等功能，並內建 **深色模式** 以提升使用體驗。

## ✨ 功能特色

- **機台管理**
  - 新增 / 修改 / 刪除 機台資訊
  - 自訂機台名稱與屬性設定

- **資料管理**
  - 上傳並解析 **CSV 檔案**
  - 支援機台測量數據：
    - 馬達轉速 (RPM)
    - 磨耗狀態
    - 笛卡爾座標 (X, Y, Z)

- **數據可視化**
  - 將 CSV 內容轉換為直觀的圖表與統計數據
  - 圖表支援 **深色模式** 與互動操作

- **介面設計**
  - 現代化網頁 UI
  - 支援深色 / 淺色模式切換
  - 響應式設計，適用桌面與行動裝置

## 🛠 技術架構

- **後端 (API)**
  - C# .NET 8/9 (Web API)
  - RESTful API 設計
  - Entity Framework Core (資料庫存取)
  - Swagger (API 文件)

- **前端 (Web)**
  - HTML / CSS / JavaScript
  - 前端框架 (Bootstrap / SweetAlert)
  - 圖表繪製 (Chart.js)

- **資料儲存**
  - 支援關聯式資料庫 (SQL Server)
  - CSV 檔案上傳與解析

## 🚀 安裝與使用

### 1. 環境需求
- .NET 8 或以上版本
- 資料庫伺服器 (SQL Server / PostgreSQL)

### 2. 建置專案
```bash
git clone https://github.com/KumkiLinKa995/Factory-Dashboard.git
cd Factory-Dashboard
dotnet restore
dotnet build
dotnet run
```
### 3. 瀏覽器存取
* http://localhost:5153
* https://localhost:7243

## 🔍 本專案亮點

- **完整系統設計能力**
  具備從後端 API、資料庫設計，到前端視覺化的全流程開發能力，展示跨領域整合實力。  

- **資料處理與分析**
  支援 CSV 檔案上傳與解析，並將原始測試數據轉換為結構化資料與互動式圖表，模擬智慧工廠場景。  

- **現代化 API 開發**
  採用 .NET 8/9 與 RESTful API 設計，並結合 Swagger 提供文件化的介面，利於維護與團隊協作。  

- **使用者體驗導向**
  前端支援深色/淺色模式切換與響應式設計，兼顧桌面與行動裝置的使用體驗。  

- **跨平台與可維護性**
  不依賴 Visual Studio，僅需安裝 .NET SDK 即可建置與啟動伺服器，展現專案的可攜性與延展性。  

