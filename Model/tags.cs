using System;
namespace Expense.Model
{
	/// <summary>
	/// tags:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tags
	{
		public tags()
		{}
		#region Model
		private string _ftags_id= "0";
		private string _ftags_name= "0";
		private string _fuid= "0";
		private DateTime _fdate;
		/// <summary>
		/// 
		/// </summary>
		public string ftags_id
		{
			set{ _ftags_id=value;}
			get{return _ftags_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ftags_name
		{
			set{ _ftags_name=value;}
			get{return _ftags_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fuid
		{
			set{ _fuid=value;}
			get{return _fuid;}
		}
		/// <summary>
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime fdate
		{
			set{ _fdate=value;}
			get{return _fdate;}
		}
		#endregion Model

	}
}

