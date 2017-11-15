using System;
namespace Expense.Model
{
	/// <summary>
	/// log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class log
	{
		public log()
		{}
		#region Model
		private int _id;
		private string _fuser_id;
		private string _fmsg;
		private DateTime? _fdate;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fuser_id
		{
			set{ _fuser_id=value;}
			get{return _fuser_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fmsg
		{
			set{ _fmsg=value;}
			get{return _fmsg;}
		}
		/// <summary>
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime? fdate
		{
			set{ _fdate=value;}
			get{return _fdate;}
		}
		#endregion Model

	}
}

