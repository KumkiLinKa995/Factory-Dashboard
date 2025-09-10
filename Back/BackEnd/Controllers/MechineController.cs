using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// 主畫面刪除和上傳資料

namespace BackEnd.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MechineController : DataBaseBaseController {
        public MechineController(FactoryContext database) : base(database) {
        }
        private IActionResult SaveAndReturnAllMachines() // 儲存變更並回傳的副程式
        {
            try {
                _ = Database.SaveChanges();
                return Ok(Database.machine);
            } catch (DbUpdateException ex) {
                return StatusCode(500, new {
                    message = "Cannot Connect Database!!",
                    detail = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpGet] // Get 查看
        public IActionResult Get() // 抓全部資料
        {
            return Ok(Database.machine);
        }
        [HttpPost] // Post 新增
        public IActionResult Post([FromBody] machine newMachine) // 寫一筆資料
        {
            // 新增時間
            newMachine.CreateDateTime = DateTime.Now;

            // 新增資料
            _ = Database.machine.Add(newMachine);

            return SaveAndReturnAllMachines();
        }
        [HttpPut] // Put 修改
        public IActionResult Put([FromBody] machine value) // 改一筆資料
        {
            machine? item = Database.machine.FirstOrDefault(m => m.ID == value.ID);  // 抓出資料庫 ID 和使用者 ID 相同的 item

            if (item == null) // item 為空就跳錯誤
            {
                return NotFound(new { message = "Machine Not Found!!", id = value.ID });
            }
            item.Name = value.Name;
            item.Place = value.Place;

            return SaveAndReturnAllMachines();
        }

        [HttpDelete("{id}")] // Delect 刪除
        public IActionResult Delect(string id) // 刪除一筆資料
        {
            machine? item = Database.machine.FirstOrDefault(m => m.ID == int.Parse(id));  // 抓出資料庫 ID 和使用者 ID 相同的 item

            if (item == null) // item 為空就跳錯誤
            {
                return NotFound(new { message = "Machine Not Found!!", id = int.Parse(id) });
            }
            _ = Database.Remove(item);

            return SaveAndReturnAllMachines();
        }
    }
}
