using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Payment_Gateway.Models;

namespace Payment_Gateway.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Information_table> Display = new List<Information_table>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]; using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From Information_table"; SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Information_table it = new Information_table();
                        it.Name = Convert.ToString(dataReader["Name"]);
                        it.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                        it.Address = Convert.ToString(dataReader["Address"]);
                        it.Country = Convert.ToString(dataReader["Country"]);
                        it.City = Convert.ToString(dataReader["City"]);
                        it.Zip = Convert.ToString(dataReader["Zip"]);
                        it.Card = Convert.ToString(dataReader["Card"]);
                        it.Expiry = Convert.ToDateTime(dataReader["Expiry"]);
                        it.Cvv = Convert.ToString(dataReader["Cvv"]);
                        it.Currency = Convert.ToString(dataReader["Currency"]);
                        it.Amount = Convert.ToDecimal(dataReader["Amount"]); Display.Add(it);
                    }
                }
                connection.Close();
            }
            return View(Display);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Information_table it)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into Information_table (Id, Name, PhoneNumber, Address, Country, City, Zip, Card, Expiry, Cvv, Currency, Amount) Values ('{it.Id = Guid.NewGuid()}','{it.Name}','{it.PhoneNumber}','{it.Address}','{it.Country}','{it.City}','{it.Zip}','{it.Card}','{it.Expiry}','{it.Cvv}','{it.Currency}','{it.Amount}')"; using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return RedirectToAction("Index");
                }

            }
            else
                return View();
        }
    }
}