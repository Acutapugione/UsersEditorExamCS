using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using UsersModel;

namespace UsersTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = @".\users.json";
            try
            {
                
                //UserManager.Load(filename);

                UserManager.Add("acuta", "pugione", Role.Customer);
                UserManager.Add("acuta", "pugione", Role.Customer);
                UserManager.Add("acuta", "pugione", Role.Customer);
               
                UserManager.Print();
                Console.WriteLine(UserManager.Count);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                UserManager.Save(filename);
                
            }
            
            

           

            
        }
    }
}
