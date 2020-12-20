using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StonksWeb
{
    public class DBConnector
    {
        static DBConnector()
        {
            using (var db = new DatabaseContext())
            {
                if (db.DBUsers.Count() == 0)
                {
                    var user = new DBUser { FirstName = "firstname", LastName = "lastname", Email = "email@mail.com", Password = "password" };
                    db.DBUsers.Add(user);
                    db.SaveChanges();
                }
            }
        }

        internal static List<FinancialPlan> GetFinancialPlanList(int userId)
        {
            var finPlanList = new List<FinancialPlan>();

            using (var db = new DatabaseContext())
            {
                var query = db.DBFinancialPlans.Where(x => x.UserId == userId).GroupBy(x => x.UserId).ToList();

                var json = new JavaScriptSerializer();

                foreach (var group in query)
                {
                    foreach (var item in group)
                    {
                        finPlanList.Add(json.Deserialize<FinancialPlan>(item.FinancialPlan));
                    }
                }
            }

            return finPlanList;
        }

        internal static List<FinancialPlan> GetFinancialPlanList()
        {
            using (var db = new DatabaseContext())
            {
                var userId = db.DBUsers.Where(x => x.Email == FinancialPlanController.ActiveUser.Email).FirstOrDefault().Id;
                return GetFinancialPlanList(userId);
            }
        }

        internal static void SaveFinancialPlans(List<FinancialPlan> financialPlanList, int userId)
        {
            using (var db = new DatabaseContext())
            {
                foreach (FinancialPlan financialPlan in financialPlanList)
                {
                    var json = new JavaScriptSerializer();

                    var modelObject = new DBFinancialPlan();
                    modelObject.FinancialPlan = json.Serialize(financialPlan);
                    modelObject.UserId = userId;
                    modelObject.Id = financialPlanList.IndexOf(financialPlan);
                    modelObject.DateCreated = financialPlan.DateCreated;
                    var objToRemove = db.DBFinancialPlans.Where(x => x.Id == modelObject.Id);
                    if (objToRemove.Count() > 0)
                    {
                        db.DBFinancialPlans.Remove(objToRemove.FirstOrDefault());
                    }
                    db.DBFinancialPlans.Add(modelObject);
                }
                db.SaveChanges();
            }
        }

        internal static void SaveFinancialPlans(List<FinancialPlan> financialPlanList)
        {
            using (var db = new DatabaseContext())
            {
                var userId = db.DBUsers.Where(x => x.Email == FinancialPlanController.ActiveUser.Email).FirstOrDefault().Id;
                SaveFinancialPlans(financialPlanList, userId);
            }
        }

        internal static void AddUser(User user)
        {
            using (var db = new DatabaseContext())
            {
                var modelObject = new DBUser();
                modelObject.FirstName = user.FirstName;
                modelObject.LastName = user.LastName;
                modelObject.Email = user.Email;
                modelObject.Password = user.Password;
                db.DBUsers.Add(modelObject);
                db.SaveChanges();
            }
        }

        internal static bool LoggedInUser(User user)
        {
            using (var db = new DatabaseContext())
            {
                var dbUser = db.DBUsers.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if (dbUser != null)
                {
                    user.FirstName = dbUser.FirstName;
                    user.LastName = dbUser.LastName;
                    FinancialPlanController.ActiveUser = user;
                    try
                    {
                        FinancialPlanController.FinancialPlans = GetFinancialPlanList(dbUser.Id);
                        FinancialPlanController.UpdateActive();
                    }
                    catch
                    {
                        FinancialPlanController.AddNewPlan();
                    }
                    return true;
                }
                return false;
            }
        }
    }
}