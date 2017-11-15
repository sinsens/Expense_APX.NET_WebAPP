using System;
namespace Expense.Model
{
	/// <summary>
	/// users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class users
	{
		public users()
		{}
		#region Model
		private string _fuid;
		private string _fusers_name;
		private string _fusers_email;
		private string _fusers_passwd;
		private int _fusers_stat=1;
		private string _fnote;
		private DateTime _fdate;
		private string _ftoken;
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
		public string fusers_name
		{
			set{ _fusers_name=value;}
			get{return _fusers_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fusers_email
		{
			set{ _fusers_email=value;}
			get{return _fusers_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fusers_passwd
		{
			set{ _fusers_passwd=value;}
			get{return _fusers_passwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fusers_stat
		{
			set{ _fusers_stat=value;}
			get{return _fusers_stat;}
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
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime fdate
		{
			set{ _fdate=value;}
			get{return _fdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ftoken
		{
			set{ _ftoken=value;}
			get{return _ftoken;}
		}
		#endregion Model

	}
}

