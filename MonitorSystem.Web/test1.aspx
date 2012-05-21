<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="MonitorSystem.Web.test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Silverlight.js"></script>
    <script type="text/javascript" src="fullScreen.js"></script>
    <script type="text/javascript">

        function ShowDoubleCurve() {
            alert("通过这个函数，打开多曲线窗口。");
        }

        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Silverlight 应用程序中未处理的错误 " + appSource + "\n";

            errMsg += "代码: " + iErrorCode + "    \n";
            errMsg += "类别: " + errorType + "       \n";
            errMsg += "消息: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "文件: " + args.xamlFile + "     \n";
                errMsg += "行: " + args.lineNumber + "     \n";
                errMsg += "位置: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "行: " + args.lineNumber + "     \n";
                    errMsg += "位置: " + args.charPosition + "     \n";
                }
                errMsg += "方法名称: " + args.methodName + "     \n";
            }

            alert(errMsg);
        }

        function fullScreen() {
            setFullScreen(document.getElementById("silverlightObject"));
            return 0;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        

        <div id="silverlightControlHost">
        <object id="silverlightObject" data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="600px" height="400px">
		  <param name="source" value="ClientBin/MonitorSystem.xap"/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="background" value="white" />
		  <param name="minRuntimeVersion" value="4.0.50826.0" />
		  <param name="autoUpgrade" value="true" />
		  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50826.0" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="获取 Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object><iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe></div>
    </div>
    <div>
     html支持本Silverlight 的方法:
     <p>1.添加fullScreen.js库(<a href="http://space.silverlightchina.net/jitleewan/fullscreen.zip">下载</a>);</p>
     <p>
        2.添加如下js 代码:     </p>
     <div style='color: rgb(0, 0, 0); font-family: "[object HTMLOptionElement]","Consolas","Lucida Console","Courier New";' class="source"> <span style="color: rgb(0, 0, 0);">&lt;</span><span style="color: rgb(0, 0, 0);">script</span> <span style="color: rgb(0, 0, 0);">type</span><span style="color: rgb(0, 0, 0);">=</span><span style="color: rgb(0, 0, 255);">&quot;text/javascript&quot;</span> <span style="color: rgb(0, 0, 0);">src</span><span style="color: rgb(0, 0, 0);">=</span><span style="color: rgb(0, 0, 255);">&quot;fullScreen.js&quot;</span><span style="color: rgb(0, 0, 0);">&gt;&lt;</span><span style="color: rgb(166, 23, 23); background-color: rgb(227, 210, 210);">/script&gt;</span><br/> <span style="color: rgb(0, 0, 0);">&lt;</span><span style="color: rgb(0, 0, 0);">script</span> <span style="color: rgb(0, 0, 0);">type</span><span style="color: rgb(0, 0, 0);">=</span><span style="color: rgb(0, 0, 255);">&quot;text/javascript&quot;</span><span style="color: rgb(0, 0, 0);">&gt;</span><br/> &nbsp;&nbsp; <span style="color: rgb(0, 136, 0); font-style: italic;">// Silverlight 全屏命令时 触发此事件</span><br/> &nbsp;&nbsp; <span style="color: rgb(0, 0, 128); font-weight: bold;">function</span> <span style="color: rgb(0, 0, 0);">fullScreen</span>() <span style="color: rgb(0, 0, 0);">{</span><br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: rgb(0, 136, 0); font-style: italic;">// &#39;silverlightObject&#39; 为 Silverlight 的 Object 对象ID</span><br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: rgb(0, 0, 0);">setFullScreen</span>(<span style="color: rgb(0, 0, 0);">document</span><span style="color: rgb(0, 0, 0);">.</span><span style="color: rgb(0, 0, 0);">getElementById</span>(<span style="color: rgb(0, 0, 255);">&quot;silverlightObject&quot;</span>));<br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: rgb(0, 0, 128); font-weight: bold;">return</span> <span style="color: rgb(0, 0, 255);">0</span>; <span style="color: rgb(0, 136, 0); font-style: italic;">// 必须的,但可以返回任意不为null的值.</span><br/> &nbsp;&nbsp; <span style="color: rgb(0, 0, 0);">}</span><br/> <span style="color: rgb(0, 0, 0);">&lt;</span><span style="color: rgb(166, 23, 23); background-color: rgb(227, 210, 210);">/script&gt;</span><br/></div>

    </div>
    </form>
</body>
</html>
