using System;
namespace Expense.Model
{
	/// <summary>
	/// trades:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class trades
	{
		public trades()
		{}
		#region Model
		private string _fuid;
		private string _ftrades_id;
		private int _fincome=0;
		private string _fcategories_id;
		private string _ftags;
		private string _fwallets_id;
		private int _fmoney=0;
		private string _fnote;
		private int _fconfirm=1;
		private int _freport=1;
		private DateTime _fdate;
		/// <summary>
		/// 
		/// </summary>
		public string fuid
		{
			set{ _fuid=value;}
			get{return _fuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ftrades_id
		{
			set{ _ftrades_id=value;}
			get{return _ftrades_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fincome
		{
			set{ _fincome=value;}
			get{return _fincome;}
		}
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
		public string ftags
		{
			set{ _ftags=value;}
			get{return _ftags;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fwallets_id
		{
			set{ _fwallets_id=value;}
			get{return _fwallets_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fmoney
		{
			set{ _fmoney=value;}
			get{return _fmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fnote
		{
			set{ _fnote=value;}
			get{return _fnote;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fconfirm
		{
			set{ _fconfirm=value;}
			get{return _fconfirm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int freport
		{
			set{ _freport=value;}
			get{return _freport;}
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

