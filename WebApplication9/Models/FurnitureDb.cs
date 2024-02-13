﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class FurnitureItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }

    public class FurnitureDb
    {
        private string _connectionString;

        public FurnitureDb(string connectionString)
        {
            _connectionString = connectionString;    
        }

        public void Add(FurnitureItem item)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Furniture (Name, Color, Price, QuantityInStock) " +
                "VALUES (@name, @color, @price, @qty)";
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@color", item.Color);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@qty", item.QuantityInStock);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public List<FurnitureItem> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Furniture";
            connection.Open();
            List<FurnitureItem> furnitureItems = new List<FurnitureItem>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                furnitureItems.Add(new FurnitureItem
                {
                    Name = (string)reader["Name"],
                    Id = (int)reader["Id"],
                    Color = (string)reader["Color"],
                    Price = (decimal)reader["Price"],
                    QuantityInStock = (int)reader["QuantityInStock"]
                });
            }

            return furnitureItems;
        }
    }

}