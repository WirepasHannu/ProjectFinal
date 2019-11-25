﻿using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace ProjectFinal
{
    class SqlQuery
    {
        // Connection to Database
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "rc86ezm5";
        private const string DB = "Computer";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;

        static private NpgsqlConnection connection;
        static private NpgsqlCommand GetAllLaptops = null;
        static private NpgsqlCommand GetAllDesktops = null;
        static private NpgsqlCommand addComputer = null;
        static private NpgsqlCommand searchComputer = null;

        //Connecting to database
        public static void Connection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        //Lisääminen tietokantaan
        public static void StoreToSql(Laptop computer)
        {
            using (addComputer = new NpgsqlCommand("INSERT INTO computer(name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity)" + "VALUES (@name, @price, @storagesize, @storagetypeid, @operatingsystemid, @useid, @batterycapacity)", connection))
            {
                addComputer.Parameters.AddWithValue("name", computer.Name);
                addComputer.Parameters.AddWithValue("price", computer.Price);
                addComputer.Parameters.AddWithValue("storagesize", computer.StorageSize);
                addComputer.Parameters.AddWithValue("storagetypeid", computer.StorageType);
                addComputer.Parameters.AddWithValue("operatingsystemid", computer.OperatingSystem);
                addComputer.Parameters.AddWithValue("useid", computer.ComputerUse);
                addComputer.Parameters.AddWithValue("batterycapacity", computer.BatteryCapacity);
                addComputer.ExecuteNonQuery();
            }
        }
        //Tietokannasta laptopin hakeminen
        public static void GetFromSqlLaptop(int use, int budget)
        {
            List<ComputersFromSQL> searchedcomputers = new List<ComputersFromSQL>();
            using (searchComputer = new NpgsqlCommand($"SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM computer LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE price < {budget}  AND computer.useid = '{use}' AND batterycapacity > 0;", connection))
            {
                searchComputer.Prepare();
                using (NpgsqlDataReader searchresult = searchComputer.ExecuteReader())

                     while (searchresult.Read())
                     { 
                        searchedcomputers.Add(new ComputersFromSQL(searchresult.GetInt16(0), searchresult.GetString(1), searchresult.GetInt32(2), searchresult.GetInt32(3), searchresult.GetInt32(4), searchresult.GetString(5), searchresult.GetString(6), searchresult.GetString(7)));
                        Console.WriteLine($" {searchresult.GetInt16(0)} {searchresult.GetString(1)} {searchresult.GetInt32(2)} {searchresult.GetInt32(3)} {searchresult.GetInt32(4)} {searchresult.GetString(5)} {searchresult.GetString(6)} {searchresult.GetString(7)}");
                     }
            }
        }

        //Tietokannasta desktopin hakeminen
            public static void GetFromsqlDesktop(int Use, int Budget)
        {
            List<ComputersFromSQL> searchedcomputers = new List<ComputersFromSQL>();
            using (searchComputer = new NpgsqlCommand($"SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM computer LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE price < {Budget}  AND computer.useid = '{Use}' AND batterycapacity = 0 OR NULL;", connection))
            {
                searchComputer.Prepare();
                using (NpgsqlDataReader searchresult = searchComputer.ExecuteReader())

                    while (searchresult.Read())
                    {
                        searchedcomputers.Add(new ComputersFromSQL(searchresult.GetInt16(0), searchresult.GetString(1), searchresult.GetInt32(2), searchresult.GetInt32(3), searchresult.GetInt32(4), searchresult.GetString(5), searchresult.GetString(6), searchresult.GetString(7)));
                        Console.WriteLine($" {searchresult.GetInt16(0)} {searchresult.GetString(1)} {searchresult.GetInt32(2)} {searchresult.GetInt32(3)} {searchresult.GetInt32(4)} {searchresult.GetString(5)} {searchresult.GetString(6)} {searchresult.GetString(7)}");
                    }
            }
        }

        //Kannettavien palauttamien db:sta
        //Käytetään luokkaa ComputersFromSQL palauttamiseen
        static public List<ComputersFromSQL> GetLaptops()
        {
            List<ComputersFromSQL> listLaptop = new List<ComputersFromSQL>();
            using (GetAllLaptops = new NpgsqlCommand("SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM \"computer\" LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE batterycapacity > 0;", connection))
            {
                GetAllLaptops.Prepare();
                using (NpgsqlDataReader computers = GetAllLaptops.ExecuteReader())

                    while (computers.Read())
                    {
                        listLaptop.Add(new ComputersFromSQL( computers.GetInt16(0), computers.GetString(1), computers.GetInt32(2), computers.GetInt32(3), computers.GetInt32(4), computers.GetString(5), computers.GetString(6), computers.GetString(7)));
                        Console.WriteLine($" {computers.GetInt16(0)} {computers.GetString(1)} {computers.GetInt32(2)} {computers.GetInt32(3)} {computers.GetInt32(4)} {computers.GetString(5)} {computers.GetString(6)} {computers.GetString(7)}");
                    }
                return listLaptop;
            }
        }
        //Desktopien palauttaminen db:sta
        //Käytetään luokkaa ComputersFromSQL palauttamiseen
        static public List<ComputersFromSQL> GetDesktops()
        {
            List<ComputersFromSQL> listDesktop = new List<ComputersFromSQL>();
            
            using (GetAllDesktops = new NpgsqlCommand("SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM \"computer\" LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE batterycapacity = 0;", connection))
            {
                GetAllDesktops.Prepare();

                using (NpgsqlDataReader computers = GetAllDesktops.ExecuteReader())

                    while (computers.Read())
                    {
                        listDesktop.Add(new ComputersFromSQL(computers.GetInt16(0), computers.GetString(1), computers.GetInt32(2), computers.GetInt32(3), computers.GetInt32(4), computers.GetString(5), computers.GetString(6), computers.GetString(7)));
                        Console.WriteLine($" {computers.GetInt16(0)} {computers.GetString(1)} {computers.GetInt32(2)} {computers.GetInt32(3)} {computers.GetInt32(4)} {computers.GetString(5)} {computers.GetString(6)} {computers.GetString(7)}");
                    }
                return listDesktop;
            }
        }
        
    }
}