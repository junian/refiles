namespace CorePOS.Business.Enums;

public class Settings
{
	public static class Layout
	{
		public const string layout_show_drink_icon = "layout_show_drink_icon";

		public const string layout_show_food_icon = "layout_show_food_icon";
	}

	public static class SafeDrop
	{
		public const string setting = "safe_drop_setting";

		public const string bill = "safe_drop_bill";

		public const string til = "safe_drop_til";
	}

	public static class Style
	{
		public const string font_size_second_screen = "font_size_second_screen";

		public const string font_size_item_groups_oe = "font_size_item_groups_oe";

		public const string capitalize_item_group_text = "capitalize_item_group_text";
	}

	public static class Payment
	{
		public const string use_payment_processor = "use_payment_processor";

		public const string patt_server = "patt_server";

		public const string print_merchant_copy = "print_merchant_copy";

		public const string gift_card_payment = "gift_card_payment";

		public const string gift_card_json = "gift_card_json";

		public const string loyalty_card_payment = "loyalty_card_payment";

		public const string loyalty_card_json = "loyalty_card_json";
	}

	public static class DayEndClosingReport
	{
		public const string company_info = "eodreport_company_info";

		public const string tender_summary = "eodreport_tender_summary";

		public const string sales_summary = "eodreport_sales_summary";

		public const string void_summary = "eodreport_void_summary";

		public const string refund_summary = "eodreport_refund_summary";

		public const string other_info = "eodreport_other_info";

		public const string payout = "eodreport_payout_summary";

		public const string employee_summary = "eodreport_employee_summary";

		public const string tipshare_summary = "eodreport_tipshare_summary";
	}

	public static class Scale
	{
		public const string scale_functionality = "scale_functionality";

		public const string scale_uom = "scale_uom";

		public const string scale_make = "scale_make";
	}

	public static class AddOns
	{
		public const string hippos_time = "hippos_time";

		public const string production_mode = "production_mode";
	}

	public const string cloudsync_api_key = "cloudsync_api_key";

	public const string cloudsync_station = "cloudsync_station";

	public const string smtp_server = "smtp_server";

	public const string smtp_port = "smtp_port";

	public const string smtp_username = "smtp_username";

	public const string smtp_password = "smtp_password";

	public const string smtp_use_ssl = "smtp_use_ssl";

	public const string sms_token = "sms_token";

	public const string sms_country_code = "sms_country_code";

	public const string sms_message = "sms_message";

	public const string sms_message_order_ready = "sms_message_order_ready";

	public const string sms_server = "sms_server";

	public const string printer_default = "printer_default";

	public const string cloudsync_time_range = "cloudsync_time_range";

	public const string receipt_footer_message = "receipt_footer_message";

	public const string useful_tip = "useful_tip";

	public const string restaurant_mode = "restaurant_mode";

	public const string print_gratuity_info = "print_gratuity_info";

	public const string auto_print_receipt = "auto_print_receipt";

	public const string second_screen = "second_screen";

	public const string restaurant_capacity = "restaurant_capacity";

	public const string quickservice_screen = "quickservice_screen";

	public const string payfinish_screen = "payfinish_screen";

	public const string payfinish_screen_ifchange = "payfinish_screen_ifchange";

	public const string sms = "sms";

	public const string lock_table_staff = "lock_table_staff";

	public const string auto_lock_layout = "auto_lock_layout";

	public const string now_serving_screen = "now_serving_screen";

	public const string upc_scanning = "upc_scanning";

	public const string auto_clear_table = "auto_clear_table";

	public const string auto_clear_orders = "auto_clear_orders";

	public const string tip_tracking = "tip_tracking";

	public const string auto_gratuity = "auto_gratuity";

	public const string auto_gratuity_count = "auto_gratuity_count";

	public const string auto_gratuity_percentage = "auto_gratuity_percentage";

	public const string stack_options = "stack_options";

	public const string show_placeholder_buttons = "show_placeholder_buttons";

	public const string receipt_language = "receipt_language";

	public const string primary_language = "primary_language";

	public const string secondary_language = "secondary_language";

	public const string display_option = "display_option";

	public const string display_instruction = "display_instruction";

	public const string receipt_display_child_items = "receipt_display_child_items";

	public const string kitchen_station_view = "kitchen_station_view";

	public const string quick_service_view = "quick_service_view";

	public const string bar_station_view = "bar_station_view";

	public const string encrypted_subs = "encrypted_subs";

	public const string encrypted_prodkey_sub = "encrypted_prodkey_sub";

	public const string receipt_size = "receipt_size";

	public const string receipt_font_size_additional = "receipt_font_size_additional";

	public const string print_kitchen_copy = "print_kitchen_copy";

	public const string print_bar_copy = "print_bar_copy";

	public const string prompt_option_child_item = "prompt_option_child_item";

	public const string add_solo_option_main = "add_solo_option_main";

	public const string delivery_charge = "delivery_charge";

	public const string card_transaction_fee = "card_transaction_fee";

	public const string prompt_void_orders_reason = "prompt_void_orders_reason";

	public const string print_chit_change_cancel = "print_chit_change_cancel";

	public const string tip_kitchen = "tip_kitchen";

	public const string tip_breakage = "tip_breakage";

	public const string auto_tip_cash_back = "auto_tip_cash_back";

	public const string group_chits_per_table = "group_chits_per_table";

	public const string item_button_price = "item_button_price";

	public const string delivery_fee_km = "delivery_fee_km";

	public const string free_delivery_over = "free_delivery_over";

	public const string delivery_fee_settings_json = "delivery_fee_settings_json";

	public const string member_assign = "member_assign";

	public const string workflow_prompt_cashout_pin = "workflow_prompt_cashout_pin";

	public const string print_chit_cashout = "print_chit_cashout";

	public const string confirm_online_orders = "confirm_online_orders";

	public const string print_tax_no = "print_tax_no";

	public const string use_order_ticket = "use_order_ticket";

	public const string enable_http_listener = "enable_http_listener";

	public const string course_selection = "course_selection";

	public const string auto_logout_cashout = "auto_logout_cashout";

	public const string auto_logout_oe = "auto_logout_oe";

	public const string show_instruction_oe = "show_instruction_oe";

	public const string print_clock_out = "print_clock_out";

	public const string print_eod_clock_out = "print_eod_clock_out";

	public const string show_placeholder_options = "show_placeholder_options";

	public const string show_payout_button = "show_payout_button";

	public const string openclose_store = "openclose_store";

	public const string order_type_receipt = "order_type_receipt";

	public const string print_payout = "print_payout";

	public const string delivery_management = "delivery_management";

	public const string auto_settlement = "auto_settlement";

	public const string auto_settlement_time = "auto_settlement_time";

	public const string use_combo_potential = "use_combo_potential";

	public const string enable_custom_discount = "enable_custom_discount";

	public const string pickup_order_time_increment = "pickup_order_time_increment";

	public const string station_settings_changed = "station_settings_changed";

	public const string delivery_distance_uom = "delivery_distance_uom";

	public const string print_orderticket = "print_orderticket";

	public const string fulfillment_threshold = "fulfillment_threshold";

	public const string fulfillment_threshold_time = "fulfillment_threshold_time";

	public const string http_listener_access_token = "http_listener_access_token";

	public const string run_sync_service = "run_sync_service";

	public const string order_tax_fix = "order_tax_fix";

	public const string coin_system = "coin_system";

	public const string http_port_range = "http_port_range";

	public const string online_order_notification_all = "online_order_notification_all";

	public const string online_order_notification_all_audio = "online_order_notification_all_audio";

	public const string online_order_notification_audio_time = "online_order_notification_audio_time";

	public const string show_employee_table = "show_employee_table";

	public const string card_transaction_fee_json = "card_transaction_fee_json";

	public const string is_sql_dependency = "is_sql_dependency";

	public const string online_order_sync = "online_order_sync";

	public Settings()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
