using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message
{
    public class Message
    {
        /// <summary>
        /// 状态代码0成功,1失败
        /// </summary>
        public int Code {
            set;get;
        }

        /// <summary>
        /// 返回提示信息
        /// </summary>
        public string Msg {
            set;get;
        }
        
        /// <summary>
        /// 主体内容
        /// </summary>
        public object Body {
            get;set;
        }
    }
}
