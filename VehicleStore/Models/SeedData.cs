using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleStore.Common;
using VehicleStore.Models;

namespace VehicleStore.Models
{
    public static class DatabaseMigrator
    {
        public static void StartMigration()
        {
            using (var dbContext = new VSDBContext())
            {
                try
                {
                    if (dbContext.Database.EnsureCreated())
                    {
                        var customers = new List<Customer>
                                                        {
                                                            new Customer
                                                            {
                                                                Name = "Kalles Grustransporter AB", Address="Cementvägen 8, 111 11 Södertälje",
                                                                Vehicles = new List<Vehicle>
                                                                {
                                                                    new Vehicle { Id=1, VIN="YS2R4X20005399401",RegNo="ABC123",IsConnected=true},
                                                                    new Vehicle { Id=2, VIN="VLUR4X20009093588",RegNo="DEF456",IsConnected=false},
                                                                    new Vehicle { Id=3, VIN="VLUR4X20009048066",RegNo="GHI789",IsConnected=true},
                                                                }
                                                            },
                                                            new Customer
                                                            {
                                                                Name = "Johans Bulk AB", Address="Balkvägen 12, 222 22 Stockholm ",
                                                                Vehicles = new List<Vehicle>
                                                                {
                                                                    new Vehicle { Id=4, VIN="YS2R4X20005388011",RegNo="JKL012",IsConnected=true},
                                                                    new Vehicle { Id=5, VIN="YS2R4X20005387949",RegNo="MNO345",IsConnected=false}
                                                                }
                                                            },
                                                            new Customer
                                                            {
                                                                Name = "Haralds Värdetransporter AB", Address="Budgetvägen 1, 333 33 Uppsala",
                                                                Vehicles = new List<Vehicle>
                                                                {
                                                                    new Vehicle { Id=6, VIN="PQR678",RegNo="VLUR4X20009048066",IsConnected=true},
                                                                    new Vehicle { Id=7, VIN="STU901",RegNo="YS2R4X20005387055",IsConnected=false}
                                                                }
                                                            },

                                                        };

                        dbContext.Customers.AddRange(customers);

                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    ex.LogException();
                }
            }

        }
    }
}
