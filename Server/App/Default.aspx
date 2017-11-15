﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Expense</title>
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="css/mui.min.css">
    <style>
        html,
        body {
            background-color: #efeff4;
        }

        p {
            text-indent: 22px;
        }

        span.mui-icon {
            font-size: 14px;
            color: #007aff;
            margin-left: -15px;
            padding-right: 10px;
        }

        .mui-off-canvas-left {
            color: #fff;
        }

        .title {
            margin: 35px 15px 10px;
        }

            .title + .content {
                margin: 10px 15px 35px;
                color: #bbb;
                text-indent: 1em;
                font-size: 14px;
                line-height: 24px;
            }

        input {
            color: #000;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div id="offCanvasWrapper" class="mui-off-canvas-wrap mui-draggable">
            <!--侧滑菜单部分-->
            <aside id="offCanvasSide" class="mui-off-canvas-left">
                <div id="offCanvasSideScroll" class="mui-scroll-wrapper">
                    <div class="mui-scroll" style="background: url(images/mybg.jpg); height: 100%; padding-top: 40%;">
                        <div class="title" style="margin-bottom: 25px; height: 40%">
                            <script>
                                if (localStorage.getItem("fusers_name") != null) {
                                    document.write(localStorage.getItem("fusers_name"));
                                } else {
                                    var body = "<div class='title'>"
                                    body += "<>";
                                    body += '<button id="btnLogin" type="button" class="mui-btn mui-btn-primary mui-btn-block" style="padding: 10px;" onclick="location.href=\'login.html\'">';
                                    body += '登录';
                                    body += '</button>';
                                    body += "</title>";

                                    document.write(body);
                                }
                            </script>
                        </div>
                        <ul class="mui-table-view mui-table-view-chevron mui-table-view-inverted">
                            <li class="mui-table-view-cell">
                                <a class="mui-navigate-right">总览
                                </a>
                            </li>
                            <li class="mui-table-view-cell">
                                <a class="mui-navigate-right">账户
                                </a>
                            </li>
                            <li class="mui-table-view-cell">
                                <a class="mui-navigate-right">交易
                                </a>
                            </li>
                            <li class="mui-table-view-cell">
                                <a class="mui-navigate-right">报表
                                </a>
                            </li>
                            <li class="mui-table-view-cell">
                                <a class="mui-navigate-right">退出
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </aside>
            <!--主界面部分-->
            <div class="mui-inner-wrap">
                <header class="mui-bar mui-bar-nav">
                    <a href="#offCanvasSide" class="mui-icon mui-action-menu mui-icon-bars mui-pull-left"></a>
                    <h1 class="mui-title">Expense</h1>
                </header>
                <div id="offCanvasContentScroll" class="mui-content mui-scroll-wrapper">
                    <div class="mui-scroll">
                        <div class="mui-content-padded">
                            <p>
                                这是可拖动式右滑导航示例，主页面和菜单在一个HTML文件中， 优点是支持拖动手势（跟手），缺点是不支持菜单内容在多页面的复用； 当前页面为主界面，你可以在主界面放置任何内容； 打开侧滑菜单有多种方式： 1、在当前页面向右拖动； 2、点击页面左上角的
								<span class="mui-icon mui-icon-bars"></span>图标； 3、通过JS API触发（例如点击如下蓝色按钮体验）；
								<span class="android-only">4、Android手机按menu键；</span>
                            </p>
                            <p style="padding: 5px 20px; margin-bottom: 5px;">
                                <button id="offCanvasShow" type="button" class="mui-btn mui-btn-primary mui-btn-block" style="padding: 10px;">
                                    显示侧滑菜单
                                </button>
                            </p>
                            <p>侧滑菜单的移动动画，支持多种效果，切换如下选项体验不同动画效果：</p>

                        </div>

                        <form class="mui-input-group" style="margin-bottom: 15px;">
                            <div class="mui-input-row mui-radio">
                                <label>主界面移动、菜单不动</label>
                                <input name="style" type="radio" checked="" value="main-move">
                            </div>
                            <div class="mui-input-row mui-radio">
                                <label>主界面不动、菜单移动</label>
                                <input name="style" type="radio" value="menu-move">
                            </div>
                            <div class="mui-input-row mui-radio mui-hidden" id="move-togger">
                                <label>整体移动</label>
                                <input name="style" type="radio" value="all-move">
                            </div>
                            <div class="mui-input-row mui-radio">
                                <label>缩放式侧滑（类手机QQ）</label>
                                <input name="style" type="radio" value="main-move-scalable">
                            </div>
                        </form>

                    </div>
                </div>
                <!-- off-canvas backdrop -->
                <div class="mui-off-canvas-backdrop"></div>
            </div>
        </div>
        <script src="js/mui.min.js"></script>
        <script>
            mui.init();
            //侧滑容器父节点
            var offCanvasWrapper = mui('#offCanvasWrapper');
            //主界面容器
            var offCanvasInner = offCanvasWrapper[0].querySelector('.mui-inner-wrap');
            //菜单容器
            var offCanvasSide = document.getElementById("offCanvasSide");
            if (!mui.os.android) {
                document.getElementById("move-togger").classList.remove('mui-hidden');
                var spans = document.querySelectorAll('.android-only');
                for (var i = 0, len = spans.length; i < len; i++) {
                    spans[i].style.display = "none";
                }
            }
            //移动效果是否为整体移动
            var moveTogether = false;
            //侧滑容器的class列表，增加.mui-slide-in即可实现菜单移动、主界面不动的效果；
            var classList = offCanvasWrapper[0].classList;
            //变换侧滑动画移动效果；
            mui('.mui-input-group').on('change', 'input', function () {
                if (this.checked) {
                    offCanvasSide.classList.remove('mui-transitioning');
                    offCanvasSide.setAttribute('style', '');
                    classList.remove('mui-slide-in');
                    classList.remove('mui-scalable');
                    switch (this.value) {
                        case 'main-move':
                            if (moveTogether) {
                                //仅主内容滑动时，侧滑菜单在off-canvas-wrap内，和主界面并列
                                offCanvasWrapper[0].insertBefore(offCanvasSide, offCanvasWrapper[0].firstElementChild);
                            }
                            break;
                        case 'main-move-scalable':
                            if (moveTogether) {
                                //仅主内容滑动时，侧滑菜单在off-canvas-wrap内，和主界面并列
                                offCanvasWrapper[0].insertBefore(offCanvasSide, offCanvasWrapper[0].firstElementChild);
                            }
                            classList.add('mui-scalable');
                            break;
                        case 'menu-move':
                            classList.add('mui-slide-in');
                            break;
                        case 'all-move':
                            moveTogether = true;
                            //整体滑动时，侧滑菜单在inner-wrap内
                            offCanvasInner.insertBefore(offCanvasSide, offCanvasInner.firstElementChild);
                            break;
                    }
                    offCanvasWrapper.offCanvas().refresh();
                }
            });
            //主界面‘显示侧滑菜单’按钮的点击事件
            document.getElementById('offCanvasShow').addEventListener('tap', function () {
                offCanvasWrapper.offCanvas('show');
            });
            //菜单界面，‘关闭侧滑菜单’按钮的点击事件
            document.getElementById('offCanvasHide').addEventListener('tap', function () {
                offCanvasWrapper.offCanvas('close');
            });
            //主界面和侧滑菜单界面均支持区域滚动；
            mui('#offCanvasSideScroll').scroll();
            mui('#offCanvasContentScroll').scroll();
            //实现ios平台原生侧滑关闭页面；
            if (mui.os.plus && mui.os.ios) {
                mui.plusReady(function () { //5+ iOS暂时无法屏蔽popGesture时传递touch事件，故该demo直接屏蔽popGesture功能
                    plus.webview.currentWebview().setStyle({
                        'popGesture': 'none'
                    });
                });
            }
        </script>
    </form>
</body>
</html>