// This CODES are pissing me off.
// I'm the ORIGINAL DATABASE.

using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers {
    public class DataBaseBaseController : ControllerBase {
        protected FactoryContext Database { get; set; }

        public DataBaseBaseController(FactoryContext database) {
            Database = database;
        }
    }
}