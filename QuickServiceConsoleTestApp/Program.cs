using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickServiceDAL;



namespace QuickServiceConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllStaffMemberDetails();
        }

        static void GetAllStaffMemberDetails()
        {
            QuickServiceRepository dalObj = new QuickServiceRepository();
            var lst = dalObj.GetAllStaffMemberDetails();
            foreach (var item in lst)
            {
                Console.WriteLine(item.StaffId + " " + item.JobAssigned);
            }
        }

    }
}
