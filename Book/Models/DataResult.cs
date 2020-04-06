using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PYF_Library.Models
{
    /// <summary>
    /// 数据结果返回
    /// </summary>
    public class DataResult {
        public string code {
            get;
            set;
        }

        public int totalPage {
            get; set;
        }

        public string errorMsg {
            get;
            set;
        }


        public dynamic data {
            get;
            set;
        }

        public DataResult() {

        }

        public DataResult(string _code) {
            this.code = _code;
        }

        public DataResult(string _code, string _errorMsg) {
            this.code = _code;
            this.errorMsg = _errorMsg;
        }

        public DataResult(string _code, dynamic data) {
            this.code = _code;
            this.data = data;
        }

        public DataResult(string code, dynamic data, int totalPage) {
            this.code = code;
            this.data = data;
            this.totalPage = totalPage;
        }
    }
}