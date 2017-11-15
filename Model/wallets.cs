using System;
namespace Expense.Model
{
	/// <summary>
	/// wallets:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wallets
	{
		public wallets()
		{}
		#region Model
		private string _fwallets_id= "0";
		private string _fwallets_name= "0";
		private string _fuid= "0";
		private int _fbalance=0;
		private int _freport=1;
		private string _fnote= "0";
		private DateTime _fdate;
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
		public string fwallets_name
		{
			set{ _fwallets_name=value;}
			get{return _fwallets_name;}
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
		/// 
		/// </summary>
		public int fbalance
		{
			set{ _fbalance=value;}
			get{return _fbalance;}
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
		#endregion Model

	}
}

