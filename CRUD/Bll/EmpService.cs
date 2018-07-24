using CRUD.Models;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD.Bll
{
    public class EmpService
    {
        public static string strConnOracle = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        ///<summary>
        ///取得使用者資料
        ///</summary>
        public static ReturnMessage<Emp> GetUser(string sEmp)
        {
            try
            {
                using (var conn = new SqlConnection(strConnOracle))
                {
                    var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                    pg.Predicates.Add(Predicates.Field<Emp>(f => f.No, Operator.Eq, sEmp));
                    var User = conn.GetList<Emp>(pg).SingleOrDefault();
                    if (User == null)
                    {
                        throw new Exception("不存在的使用者資料");
                    }
                    return new ReturnMessage<Emp> { Result = "1", Message = "成功", ReturnList = User };
                }
            }
            catch (Exception ex)
            {
                return new ReturnMessage<Emp> { Result = "0", Message = ex.Message, ReturnList = null };
            }
        }

        ///<summary>
        ///取得所有使用者資料
        ///</summary>
        public static ReturnMessage<List<Emp>> GetAllEmp()
        {
            try
            {
                using (var conn = new SqlConnection(strConnOracle))
                {
                    var User = conn.GetList<Emp>().ToList();

                    return new ReturnMessage<List<Emp>> { Result = "1", Message = "成功", ReturnList = User };
                }
            }
            catch (Exception ex)
            {
                return new ReturnMessage<List<Emp>> { Result = "0", Message = ex.Message, ReturnList = null };
            }
        }

        ///<summary>
        ///新增使用者資料
        ///</summary>
        public static ReturnMessage<string> InsertUser(Emp emp)
        {
            try
            {
                using (var conn = new SqlConnection(strConnOracle))
                {
                    conn.Insert(emp);
                }
                return new ReturnMessage<String> { Result = "1", Message = "成功", ReturnList = null };
            }
            catch (Exception ex)
            {
                return new ReturnMessage<String> { Result = "0", Message = ex.Message, ReturnList = null };
            }
        }

        ///<summary>
        ///更新使用者資料
        ///</summary>
        public static ReturnMessage<string> UpdateUser(Emp emp)
        {
            try
            {
                using (var conn = new SqlConnection(strConnOracle))
                {
                    conn.Update(emp);
                }
                return new ReturnMessage<String> { Result = "1", Message = "成功", ReturnList = null };
            }
            catch (Exception ex)
            {
                return new ReturnMessage<String> { Result = "0", Message = ex.Message, ReturnList = null };
            }
        }

        ///<summary>
        ///刪除使用者資料
        ///</summary>
        public static ReturnMessage<string> DeleteUser(string sEmp)
        {
            try
            {
                using (var conn = new SqlConnection(strConnOracle))
                {
                    var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                    pg.Predicates.Add(Predicates.Field<Emp>(f => f.No, Operator.Eq, sEmp));
                    conn.Delete<Emp>(pg);
                }
                return new ReturnMessage<String> { Result = "1", Message = "成功", ReturnList = null };
            }
            catch (Exception ex)
            {
                return new ReturnMessage<String> { Result = "0", Message = ex.Message, ReturnList = null };
            }
        }
    }
}