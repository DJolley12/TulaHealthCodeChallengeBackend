using System;
using System.Collections.Generic;
using System.Linq;
using TulaHealthCodeChallenge.Domain;
using TulaHealthCodeChallenge.Services;

namespace EFMigrationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TableOne> tableOnes = GetTableOnes();
            foreach (var tableOne in tableOnes)
            {
                Console.WriteLine(tableOne.Name);
            }
        }

        //public static void AddTableOne()
        //{
        //    using (var context = new TablesContext())
        //    {
        //        var tableOne = new TableOne { Name = "Daniel" };
        //        context.TableOnes.Add(tableOne);
        //        context.SaveChanges();
        //    };
        //}

        public static List<TableOne> GetTableOnes()
        {
            //using (var context = new TablesContext())
            //{
            //    var tables = context.TableOnes.ToList();
            //    foreach (var table in tables)
            //    {
            //        Console.WriteLine(table.Name);
            //    }
            //};
            var tableOneService = new TableOneService();
            var tables = tableOneService.GetTableOnes();
            return tables;
        }
    }
}
