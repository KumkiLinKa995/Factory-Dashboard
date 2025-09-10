// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// 顯示圖表資料
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : DataBaseBaseController {
        public DataController(FactoryContext database) : base(database) {
        }

        // 僅需 GET 資料而已
        [HttpGet("{Project_id}")]
        public IActionResult GetData(int Project_id) {
            // 將抓到的資料放入 Data 陣列當中
            data[] feature = Database.data.Where(c => c.ProjectID == Project_id).ToArray();
            // 按照 ID 排序
            _ = feature.OrderBy(c => c.ID);
            return Ok(feature);
        }
    }
}
