/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : expense

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2017-11-15 10:31:55
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_categories
-- ----------------------------
DROP TABLE IF EXISTS `t_categories`;
CREATE TABLE `t_categories` (
  `fcategories_id` varchar(40) NOT NULL,
  `fcategories_name` varchar(20) NOT NULL,
  `fcategories_color` varchar(6) DEFAULT NULL COMMENT '分类颜色',
  `fuid` varchar(40) NOT NULL,
  `fdate` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`fcategories_id`),
  UNIQUE KEY `fcategorie_id` (`fcategories_id`),
  KEY `FK_t_type_t_user` (`fuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_log
-- ----------------------------
DROP TABLE IF EXISTS `t_log`;
CREATE TABLE `t_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fuser_id` varchar(40) NOT NULL,
  `fmsg` varchar(128) DEFAULT NULL,
  `fdate` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fuser_id` (`fuser_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_trades
-- ----------------------------
DROP TABLE IF EXISTS `t_trades`;
CREATE TABLE `t_trades` (
  `fuid` varchar(40) NOT NULL COMMENT '用户id',
  `ftrades_id` varchar(40) NOT NULL COMMENT '随机散列主键',
  `fincome` int(1) NOT NULL DEFAULT '0' COMMENT '收入/支出标注',
  `fcategories_id` varchar(40) NOT NULL COMMENT '分类',
  `ftags` varchar(40) DEFAULT NULL COMMENT '输入标签用","分割，最多支持8个标签',
  `fwallets_id` varchar(40) NOT NULL COMMENT '钱包',
  `fmoney` int(11) NOT NULL DEFAULT '0' COMMENT '金额',
  `fnote` varchar(128) DEFAULT '' COMMENT '备注信息',
  `fconfirm` int(1) NOT NULL DEFAULT '1' COMMENT '交易确认标注',
  `freport` int(1) NOT NULL DEFAULT '1' COMMENT '包含在报表中',
  `fdate` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '日期',
  PRIMARY KEY (`ftrades_id`),
  UNIQUE KEY `ftrades_id` (`ftrades_id`),
  KEY `FK_t_trade_t_user` (`fuid`),
  KEY `fcategorie` (`fcategories_id`),
  KEY `fwallet` (`fwallets_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_users
-- ----------------------------
DROP TABLE IF EXISTS `t_users`;
CREATE TABLE `t_users` (
  `fuid` varchar(40) NOT NULL,
  `fusers_name` varchar(40) NOT NULL COMMENT '用户名',
  `fusers_email` varchar(40) NOT NULL COMMENT 'Email',
  `fusers_passwd` varchar(60) NOT NULL COMMENT '密码',
  `fusers_stat` int(1) NOT NULL DEFAULT '1' COMMENT '状态',
  `fnote` varchar(128) DEFAULT NULL COMMENT '备注信息',
  `fdate` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '注册日期',
  `ftoken` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`fusers_name`),
  UNIQUE KEY `fname` (`fusers_name`),
  UNIQUE KEY `fuid` (`fuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_wallets
-- ----------------------------
DROP TABLE IF EXISTS `t_wallets`;
CREATE TABLE `t_wallets` (
  `fwallets_id` varchar(40) NOT NULL,
  `fwallets_name` varchar(32) NOT NULL COMMENT '钱包名称',
  `fuid` varchar(40) NOT NULL COMMENT '用户编号',
  `fbalance` int(11) NOT NULL DEFAULT '0' COMMENT '钱包余额',
  `freport` int(1) NOT NULL DEFAULT '1' COMMENT '包含在总计中',
  `fnote` varchar(128) NOT NULL COMMENT '备注',
  `fdate` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`fwallets_id`),
  UNIQUE KEY `fwallets_id` (`fwallets_id`),
  KEY `FK__t_user` (`fuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='钱包信息表';

-- ----------------------------
-- View structure for v_trades
-- ----------------------------
DROP VIEW IF EXISTS `v_trades`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER  VIEW `v_trades` AS SELECT
t_trades.fuid,
t_trades.ftrades_id,
t_trades.fincome,
t_trades.fcategories_id,
t_trades.ftags,
t_trades.fwallets_id,
t_trades.fmoney,
t_trades.fnote,
t_trades.fconfirm,
t_trades.freport,
t_trades.fdate,
t_categories.fcategories_name,
t_wallets.fwallets_name,
t_categories.fcategories_color
FROM
t_categories ,
t_trades ,
t_users ,
t_wallets
WHERE
t_categories.fcategories_id = t_trades.fcategories_id AND
t_trades.fuid = t_users.fuid AND
t_trades.fwallets_id = t_wallets.fwallets_id ;
