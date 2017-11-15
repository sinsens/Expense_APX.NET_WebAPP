using System;
namespace Expense.Model
{
	/// <summary>
	/// categories:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class categories
	{
		public categories()
		{}
		#region Model
		private string _fcategories_id;
		private string _fcategories_name= "0";
		private string _fcategories_color;
		private string _fuid= "0";
		private DateTime _fdate;
		/// <summary>
		/// 
		/// </summary>
		public string fcategories_id
		{
			set{ _fcategories_id=value;}
			get{return _fcategories_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fcategories_name
		{
			set{ _fcategories_name=value;}
			get{return _fcategories_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fcategories_color
		{
			set{ _fcategories_color=value;}
			get{return _fcategories_color;}
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

