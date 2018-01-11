using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ECPay.Payment.Integration.SPCheckOut;

namespace ECPay.Payment.Samples.SPCheckOutSample
{
    public partial class CheckOut : System.Web.UI.Page
    {
        public string _MerchantID = "";
        public string _SPToken = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SPCheckOutApi oPayment = new SPCheckOutApi())
            {
                /* 服務參數 */
                oPayment.ServiceURL = "https://payment-stage.ecpay.com.tw/SP/CreateTrade"; //介接網址
                oPayment.HashKey = "5294y06JbISpM5x9";  //HashKey
                oPayment.HashIV = "v77hoKGq4kWxNNIS";   //v77hoKGq4kWxNNIS

                oPayment.Send.ItemName = "可樂";   //商品名稱
                oPayment.Send.ReturnURL = "http://127.0.0.1/01/CheckOutFeedback.php";  //付款完成通知回傳網址
                oPayment.Send.TotalAmount = Convert.ToUInt32("31");  //交易金額
                oPayment.Send.TradeDesc = "test";  //交易描述
                oPayment.Send.MerchantID = "2000132";  //合作特店編號
                oPayment.Send.NeedExtraPaidInfo = "N";  //額外回傳參數






                #region ATM相關參數
                //oPayment.ATM.ExpireDate = Convert.ToInt32("0");  //允許繳費有效天數
                //oPayment.ATM.PaymentInfoURL = "<<PaymentInfoURL>>";  //Server 端回傳付款相關資訊

                #endregion

                #region CVS相關參數
                //oPayment.CVS.StoreExpireDate = Convert.ToInt32("10");  //超商繳費截止時間
                //oPayment.CVS.Desc_1 = "1";  //交易描述 1
                //oPayment.CVS.Desc_2 = "2";  //交易描述 2
                //oPayment.CVS.Desc_3 = "3";  //交易描述 3
                //oPayment.CVS.Desc_4 = "4";  //交易描述 4
                //oPayment.CVS.PaymentInfoURL = "http://127.0.0.1/01/CheckOutFeedback.php";  //Server 端回傳付款相關資訊 
                #endregion

                #region 信用卡相關參數
                /*==Should Know 要先設置 CreditPayType選擇執行的信用卡付款方式==*/
                #region 信用卡一次付清
                oPayment.CreditPayment = CreditPayType.CreditPayOff;
                //oPayment.CreditPayOff.BindingCard = Convert.ToInt32("1");  //記憶卡號
                //oPayment.CreditPayOff.MerchantMemberID = "200013200001";  //記憶卡號識別碼
                //oPayment.CreditPayOff.Redeem = "N";  //是否使用紅利折抵
                #endregion

                #region 信用卡分期付款
                //oPayment.CreditPayment = CreditPayType.CreditInstallment;  
                //oPayment.CreditInstallment.BindingCard = Convert.ToInt32("<<BindingCard>>");  //記憶卡號
                //oPayment.CreditInstallment.MerchantMemberID = "<<MerchantMemberID>>";  //記憶卡號識別碼
                //oPayment.CreditInstallment.CreditInstallment = "3,6,12";  //刷卡分期期數
                #endregion

                #region 信用卡定期定額
                //oPayment.CreditPayment = CreditPayType.CreditRSP;
                ////oPayment.CreditRSP.BindingCard = Convert.ToInt32("<<BindingCard>>");  ////記憶卡號
                ////oPayment.CreditRSP.MerchantMemberID = "<<MerchantMemberID>>";  ////記憶卡號識別碼
                //oPayment.CreditRSP.PeriodAmount = Convert.ToInt32("31");  //每次授權金額
                //oPayment.CreditRSP.PeriodType = "D";  //週期
                //oPayment.CreditRSP.Frequency = Convert.ToInt32("365");  //執行頻率
                //oPayment.CreditRSP.ExecTimes = Convert.ToInt32("50");  //執行次數
                //oPayment.CreditRSP.PeriodReturnURL = "https://www.ecpay.com.tw";  //定期定額的執行結果回應 URL
                #endregion

                #endregion

                //電子發票相關
                oPayment.EivoiceType = EInvoiceType.None;  //是否使用電子發票


                oPayment.Invoice.CustomerID = "";  //客戶代號
                oPayment.Invoice.CustomerIdentifier = "";  //統一編號
                oPayment.Invoice.CustomerName = "客戶名稱";  //客戶名稱
                oPayment.Invoice.CustomerAddr = "客戶地址";  //客戶地址
                oPayment.Invoice.CustomerPhone = "0911111111";  //客戶手機號碼
                oPayment.Invoice.CustomerEmail = "cc@cc.cc";  //客戶信箱
                //oPayment.Invoice.ClearanceMark = "<<ClearanceMark>>"; //通關方式
                oPayment.Invoice.TaxType = "1";  //課稅類別
                //oPayment.Invoice.CarruerType = "<<CarruerType>>";  //載具類別
                //oPayment.Invoice.CarruerNum = "<<CarruerNum>>";  //載具編號
                oPayment.Invoice.Donation = "0";  //捐贈註記
                //oPayment.Invoice.LoveCode = "";  //愛心碼
                oPayment.Invoice.Print = "0";  //是否列印
                oPayment.Invoice.InvoiceItemName = "頻果";  //商品名稱
                oPayment.Invoice.InvoiceItemCount = "1";  //商品數量
                oPayment.Invoice.InvoiceItemWord = "顆";  //商品單位
                oPayment.Invoice.InvoiceItemPrice = "31"; //注意數量*單價 要等於 oPayment.Send.TotalAmount
                oPayment.Invoice.InvoiceItemTaxType = "1";  //商品課稅別
                oPayment.Invoice.DelayDay = Convert.ToInt32("0");  //延遲天數
                oPayment.Invoice.InvType = "07";  //字軌類別

                //執行回傳結果
                string result = oPayment.Excute();

                //使用第三方套件將Json To Model
                TradeSPToken RtnModel = JsonConvert.DeserializeObject<TradeSPToken>(result);

                if (RtnModel.RtnCode != "1")
                {
                    //### 幕後建立訂單失敗，廠商自行撰寫語法
                    Response.Write(result + "<br/>");
                    Response.End();
                }

                //取得的MerchantID 給Js使用
                _MerchantID = RtnModel.MerchantID;
                //取得的SPToken  給Js使用
                _SPToken = RtnModel.SPToken;
            }
        }
    }
}