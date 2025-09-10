using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// 圖表上傳和刪除

namespace BackEnd.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : DataBaseBaseController {
        public ProjectController(FactoryContext database) : base(database) {
        }

        [HttpGet]
        public IActionResult GetProjectItems() // 回傳資料
        {

            return Ok(Database.project);
        }

        // 上傳檔案
        [HttpPost("{machineID}")]
        public IActionResult UploadCSV(int machineID, IFormFile file) // 機器 ID 和檔案
        {
            // 檢查 CSV 檔案有沒有存在，不存在就顯示錯誤
            if (file == null || file.Length == 0) {
                // 錯誤訊息
                return BadRequest("沒有 CSV 檔案。");
            }
            // 檢查使用者輸入的 Machine ID 在資料庫是不是存在?
            if (Database.machine.FirstOrDefault(c => c.ID == machineID) == null) {
                // 錯誤訊息
                return BadRequest("這個 Machine ID 不存在。");
            }
            int Project_id = 0; // 預設 Project Id 為零
            if (Database.project.Count() != 0) // 不等於零代表使用者上傳了資料
            {
                // Project_id 為"排序好後"，最後一筆"ID 值"
                Project_id = Database.project.OrderBy(c => c.ID).Last().ID;
            }
            Project_id++;

            // 建立一個陣列存 CSV 裡面的資料。
            data[] csvdata = GetDataFromCSV(file, Project_id);

            // 檢查 CSV 資料裡面是不是沒有數值，如果沒有的話就回傳錯誤訊息。
            if (csvdata.Length == 0) {
                return BadRequest("CSV 檔案沒有數值。");
            }

            // 創建一筆新的 Project 資料
            project newProject = new() {
                ID = Project_id,
                MachineID = machineID,
                RecordDateTime = DateTime.Now,
            };

            // 把新的 project 資料給資料庫。
            _ = Database.project.Add(newProject);

            // 把讀取到的 CSV 數據，儲存至資料庫。
            Database.data.AddRange(csvdata);

            // 更新資料庫。
            _ = Database.SaveChanges();

            // 回傳資料庫裡面的 Project 資料。
            return Ok(Database.project);
        }


        // 讀取 CSV 檔案
        private data[] GetDataFromCSV(IFormFile file, int Project_id) {
            // 放 CSV 資料的 List
            List<data> csvdata = [];

            // 讀取 CSV 檔案
            StreamReader reader = new(file.OpenReadStream());

            //不斷執行到全部讀完
            while (!reader.EndOfStream) {
                string line = reader.ReadLine();

                // 空的也直接跳出迴圈
                if (line == null) {
                    break;
                }

                // CSV 用","去切
                string[] values = line.Split(',');

                // 不要讀標題
                if (values[0] == "Speed") {
                    continue; // 跳開。
                } else {

                    // 依照 Data 資料表的格式去儲存，CSV 裡面的資料，儲存至各自區域內。
                    csvdata.Add(new data {
                        ProjectID = Project_id,
                        Speed = double.Parse(values[0]),
                        Feed = double.Parse(values[1]),
                        XRms = double.Parse(values[2]),
                        YRms = double.Parse(values[3]),
                        ZRms = double.Parse(values[4]),
                    });
                }
            }

            // 關閉讀取器
            reader.Close();

            // 回傳容器。
            return csvdata.ToArray();
        }
        [HttpDelete("{Project_id}")]
        public IActionResult Delete(int Project_id) {
            project? item = Database.project.FirstOrDefault(p => p.ID == Project_id);  // 抓出資料庫 ID 和使用者 ID 相同的 item

            if (item == null) {
                // 如果找不到該筆資料，返回 NotFound 錯誤
                return NotFound("找不到該筆資料。");
            }

            // 找到資料後，移除該筆資料
            _ = Database.project.Remove(item);

            // 提交變更到資料庫
            _ = Database.SaveChanges();

            // 回傳剩下的所有 project 資料
            return Ok(Database.project);
        }
    }
}