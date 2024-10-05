using Dapper;
using DapperCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DapperCRUD.Controllers
{
    public class DapperController : Controller
    {
        private readonly SqlConnection conn;

        public DapperController()
        {
            conn = new SqlConnection("Data Source=DESKTOP-QULO1Q6\\SQLEXPRESS;Initial Catalog=DapperDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }
        public IActionResult Index()
        {
            conn.Open();
            string query = "select * from Product";
            var data = conn.Query<Product>(query).ToList();
            conn.Close();

            return View(data);
            
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddProduct(Product p)
        {
            conn.Open();
            string query = "insert into Product(Name, Category, Price) values(@name, @category, @price)";
            var data = conn.Execute(query, new { name = p.Name, category=p.Category, price=p.Price });
            conn.Close();
            return RedirectToAction("Index");
        }
        public IActionResult EditProduct(int id)
        {
            conn.Open();
            string query = "select * from Product WHERE Id = @Id";
            var data = conn.QueryFirstOrDefault<Product>(query, new { Id = id });
            conn.Close();

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            if (ModelState.IsValid)
            {               
                conn.Open();
                string query = "update Product SET Name = @name, Category = @category, Price = @price  WHERE Id = @Id";
                conn.Execute(query, new { p.Id, p.Name, p.Category, p.Price});
                conn.Close();

                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            conn.Open();
            string query = "delete from Product WHERE Id = @Id";
            conn.Execute(query, new { Id = id });
            conn.Close();
            return RedirectToAction("Index");
        }
    }
}
