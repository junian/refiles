namespace CorePOS.Business.Methods.PaymentProcessors;

public static class GClass3
{
	public static class CommonCodes
	{
		public static string transaction_type;

		public static string transaction_status;

		public static string settlement_date;

		public static string settlement_time;

		public static string transaction_amount;

		public static string tip_amount;

		public static string cashback_amount;

		public static string surcharge_amount;

		public static string total_amount;

		public static string invoice_number;

		public static string reference_number;

		public static string transaction_sequence;

		public static string seq_num;

		public static string table_no;

		public static string clerk_id;

		public static string tender_type;

		public static string card_name;

		public static string account_number;

		public static string customer_language;

		public static string cardholder_name;

		public static string card_account_type;

		public static string card_mode;

		public static string card_cust_num;

		public static string emv_aid;

		public static string emv_tvr;

		public static string emv_tsi;

		public static string emv_label;

		public static string cvm_result;

		public static string emv_arqc;

		public static string emv_final_crypto;

		public static string cvm_indicator;

		public static string cvm_tc;

		public static string cvm_ttq;

		public static string authorization_number;

		public static string host_response_code;

		public static string host_response_text;

		public static string host_response_iso_code;

		public static string rrn;

		public static string trace;

		public static string gift_royalty_ref;

		public static string terminal_id;

		public static string receipt_footer1;

		public static string receipt_footer2;

		public static string receipt_footer3;

		public static string receipt_footer4;

		public static string receipt_footer5;

		public static string receipt_footer6;

		public static string receipt_footer7;

		public static string receipt_endorsement1;

		public static string receipt_endorsement2;

		public static string receipt_endorsement3;

		public static string receipt_endorsement4;

		public static string receipt_endorsement5;

		public static string receipt_endorsement6;

		public static string emv_response;

		public static string rcpt_transaction_status;

		static CommonCodes()
		{
			Class2.oOsq41PzvTVMr();
			transaction_type = "100";
			transaction_status = "101";
			settlement_date = "102";
			settlement_time = "103";
			transaction_amount = "104";
			tip_amount = "105";
			cashback_amount = "106";
			surcharge_amount = "107";
			total_amount = "109";
			invoice_number = "110";
			reference_number = "111";
			transaction_sequence = "112";
			seq_num = "113";
			table_no = "114";
			clerk_id = "118";
			tender_type = "300";
			card_name = "301";
			account_number = "302";
			customer_language = "303";
			cardholder_name = "304";
			card_account_type = "305";
			card_mode = "306";
			card_cust_num = "307";
			emv_aid = "308";
			emv_tvr = "309";
			emv_tsi = "310";
			emv_label = "311";
			cvm_result = "312";
			emv_arqc = "313";
			emv_final_crypto = "314";
			cvm_indicator = "315";
			cvm_tc = "316";
			cvm_ttq = "318";
			authorization_number = "400";
			host_response_code = "401";
			host_response_text = "402";
			host_response_iso_code = "403";
			rrn = "404";
			trace = "406";
			gift_royalty_ref = "414";
			terminal_id = "601";
			receipt_footer1 = "707";
			receipt_footer2 = "708";
			receipt_footer3 = "709";
			receipt_footer4 = "710";
			receipt_footer5 = "711";
			receipt_footer6 = "712";
			receipt_footer7 = "713";
			receipt_endorsement1 = "714";
			receipt_endorsement2 = "715";
			receipt_endorsement3 = "716";
			receipt_endorsement4 = "717";
			receipt_endorsement5 = "718";
			receipt_endorsement6 = "719";
			emv_response = "730";
			rcpt_transaction_status = "733";
		}
	}

	public static class Moneris
	{
		public static string account_type;

		public static string emv_aid;

		public static string emv_tvr_first;

		public static string emv_tvr_second;

		public static string emv_tsi_first;

		public static string emv_tsi_second;

		public static string emv_preferred_name;

		public static string cvm_indicator;

		public static string terminal_id;

		public static string merchant_name;

		public static string merchant_address1;

		public static string merchant_address2;

		static Moneris()
		{
			Class2.oOsq41PzvTVMr();
			account_type = "304";
			emv_aid = "306";
			emv_tvr_first = "307";
			emv_tvr_second = "308";
			emv_tsi_first = "309";
			emv_tsi_second = "310";
			emv_preferred_name = "312";
			cvm_indicator = "315";
			terminal_id = "601";
			merchant_name = "602";
			merchant_address1 = "603";
			merchant_address2 = "604";
		}
	}

	public static class Other
	{
		public static string terminal_id;

		public static string merchant_id;

		public static string currency_code;

		public static string receipt_merchant_name;

		public static string receipt_merchant_address1;

		public static string receipt_merchant_address2;

		public static string receipt_merchant_header4;

		public static string receipt_merchant_header5;

		public static string receipt_merchant_header6;

		public static string receipt_merchant_header7;

		static Other()
		{
			Class2.oOsq41PzvTVMr();
			terminal_id = "601";
			merchant_id = "602";
			currency_code = "603";
			receipt_merchant_name = "700";
			receipt_merchant_address1 = "701";
			receipt_merchant_address2 = "702";
			receipt_merchant_header4 = "703";
			receipt_merchant_header5 = "704";
			receipt_merchant_header6 = "705";
			receipt_merchant_header7 = "706";
		}
	}
}
