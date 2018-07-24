using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class ReturnMessage<T>
    {
        /// <summary>
        /// 結果 0.成功 1.失敗
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 說明/錯誤
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 泛型List
        /// </summary>
        public T ReturnList { get; set; }
    }
}