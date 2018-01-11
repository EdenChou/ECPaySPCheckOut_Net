<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="ECPay.Payment.Samples.SPCheckOutSample.CheckOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<script type="text/javascript">
    $(function () {
        window.addEventListener('message', function (e) {
            document.getElementById("Result").innerHTML = "訂單結果資訊：" + e.data;
            document.getElementById("Result").style.display = "block";
        });
    });
   
</script>
<body>
<script src="https://payment-stage.ecpay.com.tw/Scripts/SP/ECPayPayment_1.0.0.js"
 data-MerchantID="<%=_MerchantID%>"
 data-SPToken="<%=_SPToken%>"
 data-PaymentType="CREDIT"
 data-PaymentName="信用卡"
 data-CustomerBtn="0" >
</script><script src="https://payment-stage.ecpay.com.tw/Scripts/SP/ECPayPayment_1.0.0.js"
 data-MerchantID="<%=_MerchantID%>"
 data-SPToken="<%=_SPToken%>"
 data-PaymentType="ATM"
 data-PaymentName="ATM"
 data-CustomerBtn="0" >
</script><script src="https://payment-stage.ecpay.com.tw/Scripts/SP/ECPayPayment_1.0.0.js"
 data-MerchantID="<%=_MerchantID%>"
 data-SPToken="<%=_SPToken%>"
 data-PaymentType="CVS"
 data-PaymentName="CVS"
 data-CustomerBtn="0" >
</script>
 <%--   <div>
        <div id="Result" style="display: none;">
        </div>
        <script src="<<jsSrc>>" data-merchantid="<%=_MerchantID%>"
            data-sptoken="<%=_SPToken%>" data-paymenttype="CREDIT" data-paymentname="信用卡"> 
        </script>
        <script src="<<jsSrc>>" data-merchantid="<%=_MerchantID%>"
            data-sptoken="<%=_SPToken%>" data-paymenttype="ATM" data-paymentname="ATM"> 
        </script>
        <script src="<<jsSrc>>" data-merchantid="<%=_MerchantID%>"
            data-sptoken="<%=_SPToken%>" data-paymenttype="CVS" data-paymentname="CVS">
        </script>

    </div>--%>
</body>
</html>
