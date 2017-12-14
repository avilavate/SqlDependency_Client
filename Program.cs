using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotificaionListDB_Client
{
    class Program
    {
        private static string ans;


        static void Main(string[] args)
        {
            ans = "y";
            Console.WriteLine("Welcome...");
            while (ans == "y")
            {
                Console.WriteLine("Enter Notification List Details:");
                NotificationList row = new NotificationList();
                Console.WriteLine("Text ?");
                row.Text = Console.ReadLine();
                Console.WriteLine("User Id ?");
                row.UserId = int.Parse(Console.ReadLine().ToString());
                Console.WriteLine("Create Date");
                row.CreatedDate = DateTime.Parse(Console.ReadLine());
                var insert_task = Task.Factory.StartNew(() =>
                {
                    using (NotificationRepo repo = new NotificationRepo())
                    {
                        repo.Insert(row);
                    }
                });
                Task.Factory.StartNew(() =>
                {
                    insert_task.Wait();
                    if (insert_task.IsCompleted)
                    {
                        Console.WriteLine("Insert operation done!");
                    }
                    else
                        Console.WriteLine("last insert operation failed");
                });

                Console.WriteLine("Continue y/n? ");
                ans = Console.ReadLine();
            }

        }
    }
}
