using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ECPay.Payment.Integration;

namespace ECPay.Payment.Samples.AllInOneSamples
{
    public partial class CheckOutFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             *  接收訂單資料產生完成的範例程式碼。
             */
            List<string> enErrors = new List<string>();
            Hashtable htFeedback = null;

            try
            {
                using (AllInOne oPayment = new AllInOne())
                {
                    oPayment.HashKey = "<<Hash Key>>";
                    oPayment.HashIV = "<<Hash IV>>";
                    /* 取回付款結果 */
                    enErrors.AddRange(oPayment.CheckOutFeedback(ref htFeedback));
                }
                // 取回所有資料
                if (enErrors.Count() == 0)
                {
                    /* 支付後的回傳的基本參數 */
                    string szMerchantID = String.Empty;
                    string szMerchantTradeNo = String.Empty;
                    string szPaymentDate = String.Empty;
                    string szPaymentType = String.Empty;
                    string szPaymentTypeChargeFee = String.Empty;
                    string szRtnCode = String.Empty;
                    string szRtnMsg = String.Empty;
                    string szSimulatePaid = String.Empty;
                    string szTradeAmt = String.Empty;
                    string szTradeDate = String.Empty;
                    string szTradeNo = String.Empty;
                    /* 使用定期定額交易時，回傳的額外參數 */
                    string szPeriodType = String.Empty;
                    string szFrequency = String.Empty;
                    string szExecTimes = String.Empty;
                    string szAmount = String.Empty;
                    string szGwsr = String.Empty;
                    string szProcessDate = String.Empty;
                    string szAuthCode = String.Empty;
                    string szFirstAuthAmount = String.Empty;
                    string szTotalSuccessTimes = String.Empty;
                    /* 使用 ATM、CVS 或 BARCODE 交易時，回傳的額外參數 */
                    string szExpireDate = String.Empty;
                    /* 使用 ATM 交易時，回傳的額外參數 */
                    string szBankCode = String.Empty;
                    string szVirtualAccount = String.Empty;
                    /* 使用 CVS 或 BARCODE 交易時，回傳的額外參數 */
                    string szPaymentNo = String.Empty;
                    string szBarcode1 = String.Empty;
                    string szBarcode2 = String.Empty;
                    string szBarcode3 = String.Empty;
                    // 取得資料於畫面
                    foreach (string szKey in htFeedback.Keys)
                    {
                        switch (szKey)
                        {
                            /* 支付後的回傳的基本參數 */
                            case "MerchantID": szMerchantID = this.Request.Form[szKey]; break;
                            case "MerchantTradeNo": szMerchantTradeNo = this.Request.Form[szKey]; break;
                            case "PaymentDate": szPaymentDate = this.Request.Form[szKey]; break;
                            case "PaymentType": szPaymentType = this.Request.Form[szKey]; break;
                            case "PaymentTypeChargeFee": szPaymentTypeChargeFee = this.Request.Form[szKey]; break;
                            case "RtnCode": szRtnCode = this.Request.Form[szKey]; break;
                            case "RtnMsg": szRtnMsg = this.Request.Form[szKey]; break;
                            case "SimulatePaid": szSimulatePaid = this.Request.Form[szKey]; break;
                            case "TradeAmt": szTradeAmt = this.Request.Form[szKey]; break;
                            case "TradeDate": szTradeDate = this.Request.Form[szKey]; break;
                            case "TradeNo": szTradeNo = this.Request.Form[szKey]; break;

                            /* 使用定期定額交易時回傳的參數 */
                            //case "MerchantID": szMerchantID = this.Request.Form[szKey]; break;
                            //case "MerchantTradeNo": szMerchantTradeNo = this.Request.Form[szKey]; break;
                            //case "RtnCode": szRtnCode = this.Request.Form[szKey]; break;
                            //case "RtnMsg": szRtnMsg = this.Request.Form[szKey]; break;
                            //case "PeriodType": szPeriodType = this.Request.Form[szKey]; break;
                            //case "Frequency": szFrequency = this.Request.Form[szKey]; break;
                            //case "ExecTimes": szExecTimes = this.Request.Form[szKey]; break;
                            //case "Amount": szAmount = this.Request.Form[szKey]; break;
                            //case "Gwsr": szGwsr = this.Request.Form[szKey]; break;
                            //case "ProcessDate": szProcessDate = this.Request.Form[szKey]; break;
                            //case "AuthCode": szAuthCode = this.Request.Form[szKey]; break;
                            //case "FirstAuthAmount": szFirstAuthAmount = this.Request.Form[szKey]; break;
                            //case "TotalSuccessTimes": szTotalSuccessTimes = this.Request.Form[szKey]; break;

                            /* 使用 ATM 交易時回傳的參數 */
                            //case "MerchantID": szMerchantID = this.Request.Form[szKey]; break;
                            //case "MerchantTradeNo": szMerchantTradeNo = this.Request.Form[szKey]; break;
                            //case "RtnCode": szRtnCode = this.Request.Form[szKey]; break;
                            //case "RtnMsg": szRtnMsg = this.Request.Form[szKey]; break;
                            //case "TradeNo": szTradeNo = this.Request.Form[szKey]; break;
                            //case "TradeAmt": szTradeAmt = this.Request.Form[szKey]; break;
                            //case "PaymentType": szPaymentType = this.Request.Form[szKey]; break;
                            //case "TradeDate": szTradeDate = this.Request.Form[szKey]; break;
                            //case "BankCode": szBankCode = this.Request.Form[szKey]; break;
                            //case "vAccount": szVirtualAccount = this.Request.Form[szKey]; break;
                            //case "ExpireDate": szExpireDate = this.Request.Form[szKey]; break;

                            /* 使用 CVS 或 BARCODE 交易時回傳的參數 */
                            //case "MerchantID": szMerchantID = this.Request.Form[szKey]; break;
                            //case "MerchantTradeNo": szMerchantTradeNo = this.Request.Form[szKey]; break;
                            //case "RtnCode": szRtnCode = this.Request.Form[szKey]; break;
                            //case "RtnMsg": szRtnMsg = this.Request.Form[szKey]; break;
                            //case "TradeNo": szTradeNo = this.Request.Form[szKey]; break;
                            //case "TradeAmt": szTradeAmt = this.Request.Form[szKey]; break;
                            //case "PaymentType": szPaymentType = this.Request.Form[szKey]; break;
                            //case "TradeDate": szTradeDate = this.Request.Form[szKey]; break;
                            //case "PaymentNo": szPaymentNo = this.Request.Form[szKey]; break;
                            //case "ExpireDate": szExpireDate = this.Request.Form[szKey]; break;
                            //case "Barcode1": szBarcode1 = this.Request.Form[szKey]; break;
                            //case "Barcode2": szBarcode2 = this.Request.Form[szKey]; break;
                            //case "Barcode3": szBarcode3 = this.Request.Form[szKey]; break;

                            default: break;
                        }
                    }
                    // 其他資料處理。
                }
            }
            catch (Exception ex)
            {
                enErrors.Add(ex.Message);
            }
            finally
            {
                this.Response.Clear();
                // 回覆成功訊息。
                if (enErrors.Count() == 0)
                    this.Response.Write("1|OK");
                // 回覆錯誤訊息。
                else
                    this.Response.Write(String.Format("0|{0}", String.Join("\\r\\n", enErrors)));
                this.Response.Flush();
                this.Response.End();
            }
        }
    }
}