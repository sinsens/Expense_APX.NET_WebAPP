/**
 * 演示程序当前的 “注册/登录” 等操作，是基于 “本地存储” 完成的
 * 当您要参考这个演示程序进行相关 app 的开发时，
 * 请注意将相关方法调整成 “基于服务端Service” 的实现。
 **/
(function($, owner) {
	/**
	 * 用户登录
	 **/
	owner.login = function(loginInfo, callback) {
		callback = callback || $.noop;
		loginInfo = loginInfo || {};
		loginInfo.username = loginInfo.username || '';
		loginInfo.passwd = loginInfo.passwd || '';
		if(loginInfo.username.length < 5) {
			return callback('账号最短为 5 个字符');
		}
		if(loginInfo.passwd.length < 6) {
			return callback('密码最短为 6 个字符');
		}
		mui.post('/Login.aspx', loginInfo, function(data) {
			var res = mui.parseJSON(data);
			mui.alert(res['Msg'], "温馨提示", function() {
				if(res['Code'] == 200) {
					/// 保存用户信息到本地
					var userInfo = res['Body'];
					localStorage.setItem("fusers_name", userInfo["fusers_name"]);
					localStorage.setItem("fusers_email", userInfo["fusers_email"]);
                    localStorage.setItem("ftoken", userInfo["ftoken"]);
                    document.cookie = "ftoken=" + userInfo["ftoken"];
					location.href='index.html';
				}
			});
		});

	};

	/**
	 * 新用户注册
	 **/
	owner.reg = function(regInfo, callback) {
		callback = callback || $.noop;
		regInfo = regInfo || {};
		regInfo.username = regInfo.username || '';
		regInfo.passwd = regInfo.passwd || '';
		if(regInfo.username.length < 5) {
			return callback('用户名最短需要 5 个字符');
		}
		if(regInfo.passwd.length < 6) {
			return callback('密码最短需要 6 个字符');
		}
		if(!checkEmail(regInfo.email)) {
			return callback('邮箱地址不合法');
		}
		mui.post('/Register.aspx', regInfo, function(data) {
			var res = mui.parseJSON(data);
			mui.alert(res['Msg'], "温馨提示", function() {
				if(res['Code'] == 200) {
					mui.openWindow({
						url: 'login.html',
						id: 'login.html'
					});
				}
			});
		});
	};
	
	/* 注销登录 */
	owner.Logout = function(){
		mui.confirm("是否注销登录？", "温馨提示", ["取消", "注销"], function(e){
			if(e.index==1){
                localStorage.clear(); // 清除所有本地储存
                //document.cookie.clear(); // 清除Cookie
				mui.toast('注销登录成功');
			}
		});
	}
	/**
	 * 获取当前状态
	 **/
	owner.getState = function() {
		var stateText = localStorage.getItem('$state') || "{}";
		return JSON.parse(stateText);
	};

	var checkEmail = function(email) {
		email = email || '';
		return(email.length > 3 && email.indexOf('@') > -1);
	};

	/**
	 * 找回密码
	 **/
	owner.forgetPassword = function(email, callback) {
		callback = callback || $.noop;
		if(!checkEmail(email)) {
			return callback('邮箱地址不合法');
		}
		return callback(null, '新的随机密码已经发送到您的邮箱，请查收邮件。');
	};

	/**
	 * 获取应用本地配置
	 **/
	owner.setSettings = function(settings) {
		settings = settings || {};
		localStorage.setItem('$settings', JSON.stringify(settings));
	}

	/**
	 * 设置应用本地配置
	 **/
	owner.getSettings = function() {
		var settingsText = localStorage.getItem('$settings') || "{}";
		return JSON.parse(settingsText);
	}

	/*
	 获取fuid;
	 * */
	owner.getFuid = function() {
		return localStorage.getItem('ftoken') == null ? false : localStorage.getItem('ftoken');
	}

	/*
	 Tag标签操作
	 2017年11月11日 18点30分，已注销
	*/
	/*
	owner.Tag_Add = function(tag) {
		var data = {
			'ftoken': this.getFuid(),
			'fname': tag.fname,
		}
		this.myPost('/Tags/add.aspx', data);
	}

	owner.Tag_Update = function(tag) {
		var data = {
			'ftoken': this.getFuid(),
			'fid': tag.fid,
			'fname': tag.fname,
		}
		this.myPost('/Tags/update.aspx', data);
	}
	owner.Tag_Delte = function(fid) {
		var data = {
			'ftoken': this.getFuid(),
			'fid': fid,
		}
		this.myPost('/Tags/delete.aspx', data);
	}
	owner.Tag_Get = function() {
		var mydata = {
			'ftoken': this.getFuid()
		}
		mui.getJSON('/Tags/get.aspx', mydata,
			function(data) {
				return data['Body'];
			}
		);
	}
	*/

	/*
	 Categories分类操作
	*/
	owner.Categorie_Add = function(Categorie) {
		var data = {
			'ftoken': this.getFuid(),
			'fname': Categorie.fname,
			'fcolor': Categorie.fcolor
		}
		this.myPost('/Categories/add.aspx', data);
	}

	owner.Categorie_Update = function(Categorie) {
		var data = {
			'ftoken': this.getFuid(),
			'fid': Categorie.fid,
			'fname': Categorie.fname,
			'fcolor': Categorie.fcolor
		}
		this.myPost('/Categories/update.aspx', data);
	}
	owner.Categorie_Delte = function(fid) {
		var data = {
			'ftoken': this.getFuid(),
			'fid': fid,
		}
		this.myPost('/Categories/delete.aspx', data);
	}
	owner.Categorie_Get = function() {
		var data = {
			'ftoken': this.getFuid(),
		}
		return this.getData('/Categories/get.aspx', data);
	}

	/*
     Wallet钱包操作
    */
	owner.Wallet_Add = function(Wallet) {
		var data = {
			'ftoken': this.getFuid(),
			'fname': Wallet.fname,
			'freport': Wallet.freport,
			'fnote': Wallet.fnote,
			'fbalance': Wallet.fbalance
		}
		this.myPost('/Wallets/add.aspx', data);
	}

	owner.Wallet_Update = function(Wallet) {
		var data = {
			'fid': Wallet.fid,
			'ftoken': this.getFuid(),
			'fname': Wallet.fname,
			'freport': Wallet.freport,
			'fnote': Wallet.fnote,
			'fbalance': Wallet.fbalance
		}
		this.myPost('/Wallets/update.aspx', data);
	}
	owner.Wallet_Delete = function(fid) {
		var data = {
			'ftoken': this.getFuid(),
			'fid': fid,
		}
		this.myPost('/Wallets/delete.aspx', data);
	}

	/*
     Trade交易操作
    */
	owner.Trade_Add = function(Trade) {
		this.myPost('/Trades/add.aspx', Trade);
	}

	owner.Trade_Update= function(Trade) {
		/*var data = {
			'fid': Trade.fid,
			'ftoken': this.getFuid(),
			'fcategories_id': Trade.fcategories_id,
			'freport': Trade.freport,
			'fnote': Trade.fnote,
			'fbalance': Trade.fbalance,
			'fconfirm': Trade.fconfirm,
			'fincomee': Trade.fincomee,
			'fdate': Trade.fdate
		}*/
		this.myPost('/Trades/update.aspx', Trade);
	}
	owner.Trade_Delte = function(fid) {
		var data = {
			'ftoken': this.getFuid(),
			'fid': fid,
		}
		this.myPost('/Trades/delete.aspx', data);
	}
	/*
	 通用Post
	 * */
	owner.myPost = function(url, data) {
		try {
			mui.post(url, data,
				function(data) {
					var res = mui.parseJSON(data);
                    mui.toast(res['Msg']);
					return res;
				}
			);
		} catch(err) {
			mui.alert(err, "发生了一点错误！");
		}
	}
	owner.getData = function(url, mydata, callback) {
		mui.getJSON(url, mydata, function(data){
			callback(data);
		});
	}

	/* 获取页面参数 */
	owner.getUrlParam = function(key) {
		var reg = new RegExp(key + '=([^&]*)');
		var results = location.href.match(reg);
		return results ? decodeURI(results[1]) : null;
	}

}(mui, window.app = {}));