using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServiceDAL
{
    public class QuickServiceRepository
    {
        public QuickServiceDBContext Context { get; set; }
        public static int staffcounter = 1001;
        public static int customercounter = 1001;

        public QuickServiceRepository()
        {
            Context = new QuickServiceDBContext();
        }

        public string ValidateCredentials(string emailId, string password)
        {
            string roleName = null;
            var objUser = (from usr in Context.AdminDetails
                           where usr.AdminName == emailId && usr.AdminPassword == password
                           select usr).FirstOrDefault<AdminDetail>();
            if (objUser != null)
            {
                roleName = objUser.AdminId;
                return roleName;
            }


            var objUser1 = (from usr in Context.CustomerDetails
                            where usr.CustomerEmailId == emailId && usr.CustomerPassword == password
                            select usr).FirstOrDefault<CustomerDetail>();
            if (objUser1 != null)
            {
                roleName = objUser1.CustomerId;
                return roleName;
            }

            var objUser2 = (from usr in Context.StaffDetails
                            where usr.StaffName == emailId && usr.StaffPassword == password
                            select usr).FirstOrDefault<StaffDetail>();
            if (objUser2 != null)
            {
                roleName = objUser2.StaffId;
                return roleName;
            }
            else
                return roleName;
        }

        public List<StaffDetail> GetAllStaffMemberDetails()
        {
            List<StaffDetail> lstStaff;
            try
            {
                lstStaff = Context.StaffDetails.ToList<StaffDetail>();
            }
            catch (Exception)
            {

                lstStaff = null;
            }
            return lstStaff;
        }
        public string GenerateNewStaffId()
        {
            string id = 'S' + Convert.ToString(staffcounter);
            staffcounter++;
            return id;
        }
        public bool AddStaffMember(string staffName)
        {
            bool status = false;
            try
            {
                StaffDetail stmember = new StaffDetail();
                stmember.StaffId = GenerateNewStaffId();
                stmember.StaffName = staffName;
                stmember.StaffPassword = "Infy@1234";
                stmember.JobAssigned = null;
                Context.StaffDetails.Add(stmember);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public bool UpdateStaffPassword(string staffId, string password)
        {
            bool status = false;
            try
            {
                //using Find()
                StaffDetail stffDeatil = Context.StaffDetails.Find(staffId);
                //using query expression
                //var category = (from ctgry in Context.Categories here ctgry.CategoryId == categoryId select ctgry).FirstOrDefault<Category>();
                //using lambda expression
                //Category category = Context.Categories.Where(e => e.CategoryId == categoryId).FirstOrDefault<Category>();
                if (stffDeatil != null)
                {
                    stffDeatil.StaffPassword = password;
                    Context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }  
        public bool DeleteStaffMember(string staffId)
        {
            bool status = false;
            try
            {
                var staffid = (from stf in Context.StaffDetails
                                where stf.StaffId == staffId
                                select stf).FirstOrDefault<StaffDetail>();
                Context.StaffDetails.Remove(staffid);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public string GenerateNewCustomerId()
        {
            string id = 'C' + Convert.ToString(customercounter);
            customercounter++;
            return id;
        }
        public string AddCustomerDetail(string name, string email, string password)
        {
            string customerid = null;
            try
            {
                CustomerDetail cmember = new CustomerDetail();
                cmember.CustomerId = GenerateNewCustomerId();
                cmember.CustomerName = name;
                cmember.CustomerEmailId = email;
                cmember.CustomerPassword = password;
                Context.CustomerDetails.Add(cmember);
                Context.SaveChanges();
                customerid = cmember.CustomerId;
            }
            catch (Exception)
            {
                customerid=null;
            }
            return customerid;
        }
        public bool CheckValidEmailId(string emailId)
        {
            bool check;
            var checkingEmailId= (from usr in Context.CustomerDetails
                                  where usr.CustomerEmailId == emailId
                                  select usr).FirstOrDefault<CustomerDetail>();
            if (checkingEmailId != null)
                check = true;
            else
                check = false;
            return check;
        }

      
    }
}
