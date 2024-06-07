using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS.CustomControls;

public class OrderChit : UserControl
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_0
	{
		public OrderChit _003C_003E4__this;

		public List<Order> orderList;

		public _003C_003Ec__DisplayClass106_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRefreshOrders_003Eb__5()
		{
			_003C_003E4__this.customListViewTelerik_0.Dispose();
			_003C_003E4__this.Dispose();
		}

		internal void _003CRefreshOrders_003Eb__10()
		{
			_003C_003E4__this.transparentLabel_1.Text = Resources.Total + ": " + $"{_003C_003E4__this.TotalTotal:C}";
			Panel panel = _003C_003E4__this.Controls.OfType<Panel>().FirstOrDefault();
			if (panel != null)
			{
				panel.Width = _003C_003E4__this.Width;
			}
			_003C_003E4__this.customListViewTelerik_0.Items.Clear();
			_003C_003E4__this.customListViewTelerik_0.ItemSize = new Size(0, (int)(_003C_003E4__this.FontSize * 2.75f));
		}

		internal bool _003CRefreshOrders_003Eb__13(Order x)
		{
			if (x.StationID != null && x.StationID.Contains(_003C_003E4__this.StationID.ToString()))
			{
				if (x.StationMade != null)
				{
					return !x.StationMade.Contains(_003C_003E4__this.StationID.ToString());
				}
				return true;
			}
			return false;
		}

		internal void _003CRefreshOrders_003Eb__14()
		{
			_003C_003E4__this.customListViewTelerik_0.Dispose();
			_003C_003E4__this.Dispose();
		}

		internal void _003CRefreshOrders_003Eb__28()
		{
			_003C_003E4__this.customListViewTelerik_0.Dispose();
			_003C_003E4__this.Dispose();
		}

		internal void _003CRefreshOrders_003Eb__16()
		{
			_003C_003E4__this.Height = _003C_003E4__this.customListViewTelerik_0.Height + 35;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_1
	{
		public FormHelper formsHelper;

		public int listHeight;

		public int row;

		public List<string> mainItemShowed;

		public Order firstOrder;

		public _003C_003Ec__DisplayClass106_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass106_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRefreshOrders_003Eb__15()
		{
			TransparentLabel transparentLabel_ = CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_0;
			Size size2 = (CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Size = new Size(CS_0024_003C_003E8__locals1._003C_003E4__this.Width, listHeight));
			transparentLabel_.Size = size2;
			if (CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items.Count > 0)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.SelectedIndex = 0;
			}
			CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.SelectedItems.Clear();
			if (firstOrder.OrderType == OrderTypes.Catering)
			{
				List<ProcessorPaymentType> paymentTypes = PaymentTypeMethods.GetPaymentTypes(firstOrder.PaymentMethods);
				decimal num = paymentTypes.Sum((ProcessorPaymentType a) => a.Amount);
				decimal num2 = CS_0024_003C_003E8__locals1._003C_003E4__this.TotalTotal - paymentTypes.Sum((ProcessorPaymentType a) => a.Amount);
				CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2.Text = "DEPOSIT/Paid: $" + num + "\nBALANCE: $" + num2.ToString("0.00");
				CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2.Location = new Point(0, CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Bottom - CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2.Size.Height);
			}
		}

		internal void _003CRefreshOrders_003Eb__17()
		{
			if (CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in && CS_0024_003C_003E8__locals1.orderList.Count > 0)
			{
				Label label_ = CS_0024_003C_003E8__locals1._003C_003E4__this.label_1;
				Color backColor = (CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.BackColor = ColorHelper.smethod_0(Convert.ToInt16(CS_0024_003C_003E8__locals1.orderList.FirstOrDefault().SeatNum)));
				label_.BackColor = backColor;
			}
			else
			{
				Label label_2 = CS_0024_003C_003E8__locals1._003C_003E4__this.label_1;
				Color backColor = (CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.BackColor = ColorHelper.getOrderTypeColor(CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType));
				label_2.BackColor = backColor;
			}
			if (CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DeliveryOnline)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = Resources.Delivery_Online.ToUpper();
			}
			else if (CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.PickUpOnline)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = Resources.Pick_Up_Online.ToUpper();
			}
			else if (CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.PickUpCurbsideOnline)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "Pick-Up Curbside Online".ToUpper();
			}
			else if (CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DineIn)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = Resources.Dine_In.ToUpper();
			}
			else if (CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DineInOnline)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "Dine In Online".ToUpper();
			}
			else
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType.ToUpper();
			}
			if (CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "";
			}
			if (firstOrder.Paid)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "*PAID* " + CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text;
			}
			if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON" && CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.Text = "";
			}
			if (CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.Text = "";
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_2
	{
		public Order order;

		public _003C_003Ec__DisplayClass106_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass106_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRefreshOrders_003Eb__21(Order a)
		{
			if (a.ComboID > 0 && a.ComboID == order.ComboID && a.ItemIdentifier == "MainItem")
			{
				if (a.StationID != null && !a.StationID.Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.StationID.ToString()))
				{
					return true;
				}
				return a.StationID == null;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_3
	{
		public string col1;

		public string col2;

		public _003C_003Ec__DisplayClass106_2 CS_0024_003C_003E8__locals3;

		public _003C_003Ec__DisplayClass106_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRefreshOrders_003Eb__20()
		{
			try
			{
				CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.formsHelper.subAddItemsToStationChitTelerik(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0, "", col1, col2, CS_0024_003C_003E8__locals3.order.Void, CS_0024_003C_003E8__locals3.order.ItemIdentifier, CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.FontSize);
				CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight + CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items[CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row].ActualSize.Height;
			}
			catch
			{
			}
			int row = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row;
			CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row = row + 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_4
	{
		public Order mainItemOrder;

		public _003C_003Ec__DisplayClass106_3 CS_0024_003C_003E8__locals4;

		public _003C_003Ec__DisplayClass106_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_5
	{
		public string c1;

		public string c2;

		public _003C_003Ec__DisplayClass106_4 CS_0024_003C_003E8__locals5;

		public _003C_003Ec__DisplayClass106_5()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRefreshOrders_003Eb__24()
		{
			try
			{
				CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.formsHelper.subAddItemsToStationChitTelerik(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0, "", c1, c2, CS_0024_003C_003E8__locals5.mainItemOrder.Void, CS_0024_003C_003E8__locals5.mainItemOrder.ItemIdentifier, CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.FontSize);
				CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight + CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items[CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row].ActualSize.Height;
				CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.mainItemShowed.Add(CS_0024_003C_003E8__locals5.mainItemOrder.OrderId.ToString());
			}
			catch
			{
			}
			int row = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row;
			CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row = row + 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_6
	{
		public string col1;

		public string col2;

		public string col3;

		public _003C_003Ec__DisplayClass106_2 CS_0024_003C_003E8__locals6;

		public _003C_003Ec__DisplayClass106_6()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRefreshOrders_003Eb__25()
		{
			try
			{
				if (!CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.formsHelper.IsDisposed)
				{
					CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.formsHelper.subAddItemsToTakeoutChitTelerik(CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0, "", col1, col2, col3, CS_0024_003C_003E8__locals6.order.ComboID, CS_0024_003C_003E8__locals6.order.Void, CS_0024_003C_003E8__locals6.order.ItemIdentifier, CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.FontSize);
				}
				if (!CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.IsDisposed)
				{
					CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.listHeight = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.listHeight + CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items[CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.row].ActualSize.Height;
				}
			}
			catch
			{
			}
			int row = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.row;
			CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.row = row + 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_7
	{
		public Order order;

		public _003C_003Ec__DisplayClass106_1 CS_0024_003C_003E8__locals7;

		public _003C_003Ec__DisplayClass106_7()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRefreshOrders_003Eb__29()
		{
			if (order.CustomerNotified && !CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.bool_5)
			{
				CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName + "**NOTIFIED**";
			}
			string text = "";
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName) && !CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType.ToUpper().Contains(Resources.Online.ToUpper()))
			{
				text = "CUST : " + CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName + ", " + CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Customer;
			}
			else
			{
				text = "CUST : ";
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Customer))
				{
					text += CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Customer;
				}
			}
			if (!string.IsNullOrEmpty(order.OrderNotes))
			{
				text = text + "\nNOTES: " + order.OrderNotes;
			}
			if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in)
			{
				CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = Resources.SEAT + order.SeatNum;
			}
			else
			{
				string text2 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.EmployeeName) ? "" : CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.EmployeeName.ToUpper());
				text2 = ((text2.Length > 16) ? (text2.Substring(0, 15) + "...") : text2);
				if (order.OrderType != OrderTypes.DineIn && order.OrderType != OrderTypes.ToGo)
				{
					if (order.FulfillmentAt.HasValue || order.OrderOnHoldTime > 0)
					{
						DateTime dateTime = (order.FulfillmentAt.HasValue ? order.FulfillmentAt.Value : order.DateCreated.Value.AddMinutes(order.OrderOnHoldTime));
						if (dateTime < DateTime.Now)
						{
							CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7 = "";
						}
						else
						{
							string text3 = (order.OrderType.Contains("Delivery") ? "DELIVER " : "PICKUP ");
							if (Screen.PrimaryScreen.Bounds.Width <= 1280)
							{
								text3 = "";
							}
							CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7 = "**" + text3 + ((dateTime.Date == DateTime.Now.Date) ? ("TODAY @ " + dateTime.ToString("hh:mm tt")) : ("ON " + dateTime.ToString("ddd, MMM dd @ hh:mm tt"))) + "**";
						}
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7))
					{
						CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = text.ToUpper() + "\n" + CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7;
					}
					else
					{
						CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = text.ToUpper() + "\nSRVR : " + text2;
					}
				}
				else
				{
					CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = text.ToUpper() + "\nSRVR : " + text2;
				}
			}
			CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.dateTime_0 = order.DateCreated.Value;
			CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.OnlineOrderStatus = order.FlagID;
			if ((order.OrderType == OrderTypes.DeliveryOnline || order.OrderType == OrderTypes.PickUpOnline || order.OrderType == OrderTypes.PickUpCurbsideOnline || order.OrderType == OrderTypes.DineInOnline) && !CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.bool_5)
			{
				if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.OnlineOrderStatus == 1)
				{
					CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.timer_0.Enabled = true;
					CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transLabelMessage = "Confirm Online Order";
				}
				else
				{
					string[] array = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.ClickLabel.Tag.ToString().Split('|');
					array[0] = order.FlagID.ToString();
					CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.ClickLabel.Tag = string.Join("|", array);
				}
			}
			CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Height = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Height + 35 + CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Height;
			if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 != ScreenType.station)
			{
				CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Location = new Point(CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Right - CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Size.Width - 10, CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Top - CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Size.Height + 3);
			}
			else
			{
				CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Visible = false;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass109_0
	{
		public string orderNumber;

		public OrderChit _003C_003E4__this;

		public Label headerlabel;

		public Label lblOrderNum;

		public Label lblCustomer;

		public Label lblTimer;

		public CustomListViewTelerik listView;

		public TransparentLabel lblTotal;

		public TransparentLabel tlbl;

		public _003C_003Ec__DisplayClass109_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CAddBills_003Eb__6(Order x)
		{
			if (x.OrderNumber == orderNumber)
			{
				if (x.OrderOnHoldTime != 0 && x.OrderOnHoldTime != -1 && (x.OrderOnHoldTime == 0 || !(x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime))))
				{
					if (x.OrderOnHoldTime != 0)
					{
						if (!(x.OrderType == OrderTypes.DeliveryOnline) && !(x.OrderType == OrderTypes.PickUpOnline) && !(x.OrderType == OrderTypes.PickUpCurbsideOnline))
						{
							return x.OrderType == OrderTypes.DineInOnline;
						}
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		internal bool _003CAddBills_003Eb__7(Order x)
		{
			if (_003C_003E4__this.OrderNumber.Contains(x.OrderNumber))
			{
				if (x.OrderOnHoldTime != 0 && x.OrderOnHoldTime != -1 && (x.OrderOnHoldTime == 0 || !(x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime))))
				{
					if (x.OrderOnHoldTime != 0)
					{
						if (!(x.OrderType == OrderTypes.DeliveryOnline) && !(x.OrderType == OrderTypes.PickUpOnline) && !(x.OrderType == OrderTypes.PickUpCurbsideOnline))
						{
							return x.OrderType == OrderTypes.DineInOnline;
						}
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		internal void _003CAddBills_003Eb__0()
		{
			_003C_003E4__this.Controls.Add(headerlabel);
			headerlabel.BringToFront();
			_003C_003E4__this.label_1 = headerlabel;
		}

		internal void _003CAddBills_003Eb__1()
		{
			_003C_003E4__this.Controls.Add(lblOrderNum);
			lblOrderNum.BringToFront();
			_003C_003E4__this.label_2 = lblOrderNum;
		}

		internal void _003CAddBills_003Eb__2()
		{
			_003C_003E4__this.Controls.Add(lblCustomer);
			lblCustomer.BringToFront();
			_003C_003E4__this.Controls.Add(lblTimer);
			lblTimer.BringToFront();
			_003C_003E4__this.label_0 = lblCustomer;
			_003C_003E4__this.label_3 = lblTimer;
		}

		internal void _003CAddBills_003Eb__3()
		{
			_003C_003E4__this.Controls.Add(listView);
			listView.BringToFront();
			_003C_003E4__this.customListViewTelerik_0 = listView;
		}

		internal void _003CAddBills_003Eb__4()
		{
			_003C_003E4__this.Controls.Add(lblTotal);
			lblTotal.BringToFront();
			_003C_003E4__this.transparentLabel_1 = lblTotal;
		}

		internal void _003CAddBills_003Eb__5()
		{
			_003C_003E4__this.Controls.Add(tlbl);
			tlbl.BringToFront();
			_003C_003E4__this.transparentLabel_0 = tlbl;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass109_1
	{
		public TransparentLabel lblCateringInfo;

		public _003C_003Ec__DisplayClass109_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass109_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CAddBills_003Eb__8()
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.Controls.Add(lblCateringInfo);
			lblCateringInfo.BringToFront();
			CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2 = lblCateringInfo;
		}
	}

	[CompilerGenerated]
	private List<string> list_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private short short_0;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private string string_5;

	[CompilerGenerated]
	private string string_6;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private float float_0;

	[CompilerGenerated]
	private float float_1;

	[CompilerGenerated]
	private float float_2;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private decimal decimal_1;

	public Thread RefreshThread;

	public string transLabelMessage;

	public byte OnlineOrderStatus;

	private string string_7;

	private int int_2;

	private int int_3;

	private CustomListViewTelerik customListViewTelerik_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private TransparentLabel transparentLabel_0;

	private DateTime dateTime_0;

	private TransparentLabel transparentLabel_1;

	private TransparentLabel transparentLabel_2;

	private System.Windows.Forms.Timer timer_0;

	private bool bool_3;

	public bool onlineOrder_confirmed_click;

	public bool onlineOrder_confirmed;

	private bool bool_4;

	private int int_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	public TransparentLabel ClickLabel;

	private string string_8;

	private IContainer icontainer_0;

	public List<string> OrderNumber
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public string OrderTicket
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string SubSource
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string TableName
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public short StationID
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	public string OrderType
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public string Customer
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string CustomerInfoName
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public string EmployeeName
	{
		[CompilerGenerated]
		get
		{
			return string_6;
		}
		[CompilerGenerated]
		set
		{
			string_6 = value;
		}
	}

	public bool isUpdated
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool isItemCancelled
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool isItemChanged
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public float FontSize
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public float HeaderLabelFontSize
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public float FooterLabelFontSize
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	public int OrderCount
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int VoidCount
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public decimal TotalTotal
	{
		[CompilerGenerated]
		get
		{
			return decimal_0;
		}
		[CompilerGenerated]
		set
		{
			decimal_0 = value;
		}
	}

	public decimal OrderQty
	{
		[CompilerGenerated]
		get
		{
			return decimal_1;
		}
		[CompilerGenerated]
		set
		{
			decimal_1 = value;
		}
	}

	public bool Selected
	{
		get
		{
			return bool_4;
		}
		set
		{
			if (value)
			{
				transparentLabel_0.TransparentBackColor = CorePOS.Business.Enums.ColorPalette.Mariner;
				transparentLabel_0.Opacity = 50;
				bool_4 = true;
			}
			else
			{
				transparentLabel_0.TransparentBackColor = Color.White;
				transparentLabel_0.Opacity = 0;
				bool_4 = false;
			}
		}
	}

	public OrderChit(bool isKitchen = true, int ListViewHeight = 0, bool EnableBlinkingTimer = true, TransparentLabel ClickLabel = null, string CurrentScreenType = "station", bool ShowAllItems = true)
	{
		Class26.Ggkj0JxzN9YmC();
		transLabelMessage = "";
		string_7 = string.Empty;
		int_3 = 4;
		dateTime_0 = DateTime.Now;
		bool_5 = true;
		bool_6 = true;
		bool_7 = true;
		string_8 = ScreenType.station;
		// base._002Ector();
		InitializeComponent();
		base.Width = 320;
		base.Height = (int)((double)base.Width * 0.5);
		isUpdated = false;
		isItemCancelled = false;
		isItemChanged = false;
		bool_7 = ShowAllItems;
		FontSize = 10f;
		HeaderLabelFontSize = 13f;
		FooterLabelFontSize = 10f;
		EmployeeName = "";
		OrderNumber = new List<string>();
		bool_5 = isKitchen;
		bool_6 = EnableBlinkingTimer;
		int_4 = ListViewHeight;
		this.ClickLabel = ClickLabel;
		string_8 = CurrentScreenType;
	}

	private void method_0()
	{
		_003C_003Ec__DisplayClass106_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass106_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (customListViewTelerik_0 == null)
		{
			return;
		}
		bool_3 = ((SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON") ? true : false);
		_ = customListViewTelerik_0.Height;
		isUpdated = false;
		isItemCancelled = false;
		isItemChanged = false;
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.orderList = new List<Order>();
		try
		{
			if (string_8 != ScreenType.station)
			{
				CS_0024_003C_003E8__locals0.orderList = (from x in gClass.Orders.Where((Order a) => OrderNumber.Contains(a.OrderNumber) && a.Void == false).ToList()
					orderby (!x.LastDateModified.HasValue) ? x.DateCreated : x.LastDateModified
					select x).ThenBy((Order a) => a.ComboID).ToList();
			}
			else
			{
				CS_0024_003C_003E8__locals0.orderList = gClass.Orders.Where((Order x) => OrderNumber.Contains(x.OrderNumber) && !x.DateFilled.HasValue && x.StationID.Contains(StationID.ToString()) && (x.StationMade == null || !x.StationMade.Contains(StationID.ToString())) && (x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime > 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime)))).ToList();
			}
			OrderCount = CS_0024_003C_003E8__locals0.orderList.Count();
			VoidCount = CS_0024_003C_003E8__locals0.orderList.Where((Order x) => x.Void).Count();
		}
		catch
		{
			Thread.Sleep(new Random().Next(10, 30) * 125);
			int_2++;
			if (int_2 > int_3)
			{
				int_2 = 0;
			}
			else
			{
				method_0();
			}
			return;
		}
		try
		{
			if (OrderCount == 0)
			{
				if (!base.IsDisposed)
				{
					Invoke((MethodInvoker)delegate
					{
						CS_0024_003C_003E8__locals0._003C_003E4__this.customListViewTelerik_0.Dispose();
						CS_0024_003C_003E8__locals0._003C_003E4__this.Dispose();
					});
				}
			}
			else
			{
				if (customListViewTelerik_0 == null || base.IsDisposed)
				{
					return;
				}
				_003C_003Ec__DisplayClass106_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass106_1();
				CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals4.firstOrder = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.FirstOrDefault();
				OrderQty = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.Sum((Order a) => a.Qty);
				TotalTotal = ((CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.Where((Order x) => !x.Void).Count() > 0) ? CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.Where((Order x) => !x.Void).Sum((Order a) => a.Total) : 0m);
				Invoke((MethodInvoker)delegate
				{
					CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Text = Resources.Total + ": " + $"{CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.TotalTotal:C}";
					Panel panel = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.Controls.OfType<Panel>().FirstOrDefault();
					if (panel != null)
					{
						panel.Width = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.Width;
					}
					CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items.Clear();
					CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.ItemSize = new Size(0, (int)(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.FontSize * 2.75f));
				});
				CS_0024_003C_003E8__locals4.listHeight = 50;
				CS_0024_003C_003E8__locals4.formsHelper = new FormHelper();
				CS_0024_003C_003E8__locals4.row = 0;
				List<Order> source = new List<Order>();
				if (string_8 == ScreenType.station)
				{
					try
					{
						source = gClass.Orders.Where((Order x) => OrderNumber.Contains(x.OrderNumber) && x.ItemName != ConstantItems.Delivery_Fee && (x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime > 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime)))).ToList();
						source = ((!(SettingsHelper.GetSettingValueByKey("course_selection") == "ON")) ? source.OrderBy((Order a) => a.DateCreated).ToList() : source.ToList().OrderByItemCourse().ToList());
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList = source.Where((Order x) => x.StationID != null && x.StationID.Contains(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.StationID.ToString()) && (x.StationMade == null || !x.StationMade.Contains(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.StationID.ToString()))).ToList();
					}
					catch
					{
						Thread.Sleep(new Random().Next(10, 30) * 125);
						int_2++;
						if (int_2 > int_3)
						{
							int_2 = 0;
						}
						else
						{
							method_0();
						}
						return;
					}
				}
				CS_0024_003C_003E8__locals4.mainItemShowed = new List<string>();
				if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.Count > 0)
				{
					IEnumerable<Order> enumerable;
					if (!bool_7)
					{
						enumerable = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.Take(5);
					}
					else
					{
						IEnumerable<Order> orderList = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList;
						enumerable = orderList;
					}
					using IEnumerator<Order> enumerator = enumerable.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass106_2 _003C_003Ec__DisplayClass106_ = new _003C_003Ec__DisplayClass106_2();
						_003C_003Ec__DisplayClass106_.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals4;
						_003C_003Ec__DisplayClass106_.order = enumerator.Current;
						if (string_8 == ScreenType.station)
						{
							_003C_003Ec__DisplayClass106_3 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass106_3();
							CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3 = _003C_003Ec__DisplayClass106_;
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.StationMade) && CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.StationMade.Split(',').Contains(StationID.ToString()))
							{
								continue;
							}
							if (CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.ComboID > 0)
							{
								_003C_003Ec__DisplayClass106_4 _003C_003Ec__DisplayClass106_2 = new _003C_003Ec__DisplayClass106_4();
								_003C_003Ec__DisplayClass106_2.CS_0024_003C_003E8__locals4 = CS_0024_003C_003E8__locals5;
								_003C_003Ec__DisplayClass106_2.mainItemOrder = source.Where((Order a) => a.ComboID > 0 && a.ComboID == _003C_003Ec__DisplayClass106_2.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.order.ComboID && a.ItemIdentifier == "MainItem" && ((a.StationID != null && !a.StationID.Contains(_003C_003Ec__DisplayClass106_2.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.StationID.ToString())) || a.StationID == null)).FirstOrDefault();
								if (_003C_003Ec__DisplayClass106_2.mainItemOrder != null && !_003C_003Ec__DisplayClass106_2.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.mainItemShowed.Contains(_003C_003Ec__DisplayClass106_2.mainItemOrder.OrderId.ToString()))
								{
									_003C_003Ec__DisplayClass106_5 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass106_5();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5 = _003C_003Ec__DisplayClass106_2;
									List<Order> list = (from x in new OrderMethods().GetSubSharedOrders(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.OrderId)
										where x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime))
										select x).ToList();
									decimal num = default(decimal);
									if (list.Count > 0)
									{
										num = list.Sum((Order a) => a.Qty);
									}
									string text = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.Instructions)) ? (" => " + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.Instructions) : string.Empty);
									CS_0024_003C_003E8__locals1.c1 = MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.Qty + num);
									if (CS_0024_003C_003E8__locals1.c1 == "1/1")
									{
										CS_0024_003C_003E8__locals1.c1 = "1";
									}
									CS_0024_003C_003E8__locals1.c2 = (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.ItemName + ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.Options)) ? (" => " + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.Options) : string.Empty) + ((!string.IsNullOrEmpty(text)) ? (" => INSTR: " + text) : string.Empty)).ToUpper();
									Invoke((MethodInvoker)delegate
									{
										try
										{
											CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.formsHelper.subAddItemsToStationChitTelerik(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0, "", CS_0024_003C_003E8__locals1.c1, CS_0024_003C_003E8__locals1.c2, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.Void, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.ItemIdentifier, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.FontSize);
											CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items[CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row].ActualSize.Height;
											CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.mainItemShowed.Add(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.mainItemOrder.OrderId.ToString());
										}
										catch
										{
										}
										int row3 = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row;
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row = row3 + 1;
									});
								}
							}
							List<Order> list2 = (from x in new OrderMethods().GetSubSharedOrders(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.OrderId)
								where x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime))
								select x).ToList();
							decimal num2 = default(decimal);
							if (list2.Count > 0)
							{
								num2 = list2.Sum((Order a) => a.Qty);
							}
							string text2 = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.Instructions)) ? (" => " + CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.Instructions) : string.Empty);
							CS_0024_003C_003E8__locals5.col1 = MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.Qty + num2);
							if (CS_0024_003C_003E8__locals5.col1 == "1/1")
							{
								CS_0024_003C_003E8__locals5.col1 = "1";
							}
							CS_0024_003C_003E8__locals5.col2 = (CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.ItemName + ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.Options)) ? (" => " + CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.Options) : string.Empty) + ((!string.IsNullOrEmpty(text2)) ? (" => INSTR: " + text2) : string.Empty)).ToUpper();
							Invoke((MethodInvoker)delegate
							{
								try
								{
									CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.formsHelper.subAddItemsToStationChitTelerik(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0, "", CS_0024_003C_003E8__locals5.col1, CS_0024_003C_003E8__locals5.col2, CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.Void, CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.order.ItemIdentifier, CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.FontSize);
									CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.listHeight + CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items[CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row].ActualSize.Height;
								}
								catch
								{
								}
								int row2 = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row;
								CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.row = row2 + 1;
							});
						}
						else if (!_003C_003Ec__DisplayClass106_.order.Void)
						{
							_003C_003Ec__DisplayClass106_6 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass106_6();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6 = _003C_003Ec__DisplayClass106_;
							CS_0024_003C_003E8__locals2.col1 = MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.order.Qty);
							CS_0024_003C_003E8__locals2.col2 = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.order.ItemName;
							CS_0024_003C_003E8__locals2.col3 = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.order.SubTotal.ToString("0.00", Thread.CurrentThread.CurrentCulture);
							Invoke((MethodInvoker)delegate
							{
								try
								{
									if (!CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.formsHelper.IsDisposed)
									{
										CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.formsHelper.subAddItemsToTakeoutChitTelerik(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0, "", CS_0024_003C_003E8__locals2.col1, CS_0024_003C_003E8__locals2.col2, CS_0024_003C_003E8__locals2.col3, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.order.ComboID, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.order.Void, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.order.ItemIdentifier, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.FontSize);
									}
									if (!CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.IsDisposed)
									{
										CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.listHeight = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.listHeight + CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items[CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.row].ActualSize.Height;
									}
								}
								catch
								{
								}
								int row = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.row;
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals2.row = row + 1;
							});
						}
						if ((_003C_003Ec__DisplayClass106_.order.StationNotified == null || !_003C_003Ec__DisplayClass106_.order.StationNotified.Contains(StationID.ToString())) && string_8 == ScreenType.station)
						{
							if (_003C_003Ec__DisplayClass106_.order.Void)
							{
								_003C_003Ec__DisplayClass106_.order.IsModified = false;
								isItemCancelled = true;
							}
							else if (!_003C_003Ec__DisplayClass106_.order.Void && _003C_003Ec__DisplayClass106_.order.IsModified)
							{
								_003C_003Ec__DisplayClass106_.order.IsModified = false;
								isItemChanged = true;
							}
							else
							{
								isUpdated = true;
							}
							_003C_003Ec__DisplayClass106_.order.Notified = true;
							Order order = _003C_003Ec__DisplayClass106_.order;
							order.StationNotified = order.StationNotified + StationID + ",";
							Helper.SubmitChangesWithCatch(gClass);
						}
					}
				}
				if (customListViewTelerik_0.Items.Count == 0)
				{
					Invoke((MethodInvoker)delegate
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Dispose();
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.Dispose();
					});
					return;
				}
				CS_0024_003C_003E8__locals4.listHeight = ((CS_0024_003C_003E8__locals4.listHeight > 120) ? CS_0024_003C_003E8__locals4.listHeight : 120);
				if (int_4 > 0)
				{
					CS_0024_003C_003E8__locals4.listHeight = int_4;
				}
				Invoke((MethodInvoker)delegate
				{
					TransparentLabel transparentLabel = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_0;
					Size size2 = (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Size = new Size(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.Width, CS_0024_003C_003E8__locals4.listHeight));
					transparentLabel.Size = size2;
					if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Items.Count > 0)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.SelectedIndex = 0;
					}
					CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.SelectedItems.Clear();
					if (CS_0024_003C_003E8__locals4.firstOrder.OrderType == OrderTypes.Catering)
					{
						List<ProcessorPaymentType> paymentTypes = PaymentTypeMethods.GetPaymentTypes(CS_0024_003C_003E8__locals4.firstOrder.PaymentMethods);
						decimal num3 = paymentTypes.Sum((ProcessorPaymentType a) => a.Amount);
						decimal num4 = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.TotalTotal - paymentTypes.Sum((ProcessorPaymentType a) => a.Amount);
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2.Text = "DEPOSIT/Paid: $" + num3 + "\nBALANCE: $" + num4.ToString("0.00");
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2.Location = new Point(0, CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Bottom - CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2.Size.Height);
					}
				});
				if (label_0 != null)
				{
					_003C_003Ec__DisplayClass106_7 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass106_7();
					CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7 = CS_0024_003C_003E8__locals4;
					CS_0024_003C_003E8__locals3.order = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1.orderList.FirstOrDefault();
					if (CS_0024_003C_003E8__locals3.order == null)
					{
						Invoke((MethodInvoker)delegate
						{
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Dispose();
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Dispose();
						});
						return;
					}
					OrderType = CS_0024_003C_003E8__locals3.order.OrderType;
					if (OrderType.ToUpper().Contains("ONLINE"))
					{
						CustomerInfoName = CS_0024_003C_003E8__locals3.order.CustomerInfoName;
						Customer = CS_0024_003C_003E8__locals3.order.Customer + ", " + CS_0024_003C_003E8__locals3.order.CustomerInfoPhone;
					}
					else
					{
						CustomerInfoName = string.Empty;
						Customer = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.order.CustomerInfoName) ? string.Empty : (CS_0024_003C_003E8__locals3.order.CustomerInfoName + "-")) + CS_0024_003C_003E8__locals3.order.Customer;
					}
					if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.order.Source))
					{
						if (CS_0024_003C_003E8__locals3.order.UserCreated.HasValue)
						{
							Employee employee = gClass.Employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals3.order.UserCreated.Value).FirstOrDefault();
							if (employee != null)
							{
								EmployeeName = employee.FirstName;
							}
						}
					}
					else
					{
						EmployeeName = CS_0024_003C_003E8__locals3.order.Source;
					}
					_ = CS_0024_003C_003E8__locals3.order.CustomerInfo;
					Invoke((MethodInvoker)delegate
					{
						if (CS_0024_003C_003E8__locals3.order.CustomerNotified && !CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.bool_5)
						{
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName + "**NOTIFIED**";
						}
						string text3 = "";
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName) && !CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType.ToUpper().Contains(Resources.Online.ToUpper()))
						{
							text3 = "CUST : " + CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.CustomerInfoName + ", " + CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Customer;
						}
						else
						{
							text3 = "CUST : ";
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Customer))
							{
								text3 += CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Customer;
							}
						}
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.order.OrderNotes))
						{
							text3 = text3 + "\nNOTES: " + CS_0024_003C_003E8__locals3.order.OrderNotes;
						}
						if (CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in)
						{
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = Resources.SEAT + CS_0024_003C_003E8__locals3.order.SeatNum;
						}
						else
						{
							string text4 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.EmployeeName) ? "" : CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.EmployeeName.ToUpper());
							text4 = ((text4.Length > 16) ? (text4.Substring(0, 15) + "...") : text4);
							if (CS_0024_003C_003E8__locals3.order.OrderType != OrderTypes.DineIn && CS_0024_003C_003E8__locals3.order.OrderType != OrderTypes.ToGo)
							{
								if (CS_0024_003C_003E8__locals3.order.FulfillmentAt.HasValue || CS_0024_003C_003E8__locals3.order.OrderOnHoldTime > 0)
								{
									DateTime dateTime = (CS_0024_003C_003E8__locals3.order.FulfillmentAt.HasValue ? CS_0024_003C_003E8__locals3.order.FulfillmentAt.Value : CS_0024_003C_003E8__locals3.order.DateCreated.Value.AddMinutes(CS_0024_003C_003E8__locals3.order.OrderOnHoldTime));
									if (dateTime < DateTime.Now)
									{
										CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7 = "";
									}
									else
									{
										string text5 = (CS_0024_003C_003E8__locals3.order.OrderType.Contains("Delivery") ? "DELIVER " : "PICKUP ");
										if (Screen.PrimaryScreen.Bounds.Width <= 1280)
										{
											text5 = "";
										}
										CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7 = "**" + text5 + ((dateTime.Date == DateTime.Now.Date) ? ("TODAY @ " + dateTime.ToString("hh:mm tt")) : ("ON " + dateTime.ToString("ddd, MMM dd @ hh:mm tt"))) + "**";
									}
								}
								if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7))
								{
									CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = text3.ToUpper() + "\n" + CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_7;
								}
								else
								{
									CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = text3.ToUpper() + "\nSRVR : " + text4;
								}
							}
							else
							{
								CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Text = text3.ToUpper() + "\nSRVR : " + text4;
							}
						}
						CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.dateTime_0 = CS_0024_003C_003E8__locals3.order.DateCreated.Value;
						CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.OnlineOrderStatus = CS_0024_003C_003E8__locals3.order.FlagID;
						if ((CS_0024_003C_003E8__locals3.order.OrderType == OrderTypes.DeliveryOnline || CS_0024_003C_003E8__locals3.order.OrderType == OrderTypes.PickUpOnline || CS_0024_003C_003E8__locals3.order.OrderType == OrderTypes.PickUpCurbsideOnline || CS_0024_003C_003E8__locals3.order.OrderType == OrderTypes.DineInOnline) && !CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.bool_5)
						{
							if (CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.OnlineOrderStatus == 1)
							{
								CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.timer_0.Enabled = true;
								CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transLabelMessage = "Confirm Online Order";
							}
							else
							{
								string[] array = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.ClickLabel.Tag.ToString().Split('|');
								array[0] = CS_0024_003C_003E8__locals3.order.FlagID.ToString();
								CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.ClickLabel.Tag = string.Join("|", array);
							}
						}
						CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.Height = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Height + 35 + CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.label_0.Height;
						if (CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 != ScreenType.station)
						{
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Location = new Point(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Right - CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Size.Width - 10, CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Top - CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Size.Height + 3);
						}
						else
						{
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_1.Visible = false;
						}
					});
				}
				else
				{
					Invoke((MethodInvoker)delegate
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.Height = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.customListViewTelerik_0.Height + 35;
					});
				}
				Invoke((MethodInvoker)delegate
				{
					if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in && CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.Count > 0)
					{
						Label label = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1;
						Color backColor = (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.BackColor = ColorHelper.smethod_0(Convert.ToInt16(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderList.FirstOrDefault().SeatNum)));
						label.BackColor = backColor;
					}
					else
					{
						Label label2 = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1;
						Color backColor = (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.BackColor = ColorHelper.getOrderTypeColor(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType));
						label2.BackColor = backColor;
					}
					if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DeliveryOnline)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = Resources.Delivery_Online.ToUpper();
					}
					else if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.PickUpOnline)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = Resources.Pick_Up_Online.ToUpper();
					}
					else if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.PickUpCurbsideOnline)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "Pick-Up Curbside Online".ToUpper();
					}
					else if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DineIn)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = Resources.Dine_In.ToUpper();
					}
					else if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DineInOnline)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "Dine In Online".ToUpper();
					}
					else
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType.ToUpper();
					}
					if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "";
					}
					if (CS_0024_003C_003E8__locals4.firstOrder.Paid)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text = "*PAID* " + CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_1.Text;
					}
					if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON" && CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.OrderType == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.Text = "";
					}
					if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == ScreenType.dine_in)
					{
						CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.label_2.Text = "";
					}
				});
				Invalidate();
			}
		}
		catch
		{
			Thread.Sleep(new Random().Next(10, 30) * 125);
			int_2++;
			if (int_2 > int_3)
			{
				int_2 = 0;
			}
			else
			{
				method_0();
			}
		}
	}

	public override void Refresh()
	{
		RefreshThread = new Thread(method_0);
		RefreshThread.Start();
	}

	public void UpdateClickLabelTag(string tag)
	{
		if (tag != null && !tag.Split('|')[0].Contains(((byte)1).ToString()))
		{
			ClickLabel.Tag = tag;
			if (timer_0 != null)
			{
				timer_0.Enabled = false;
			}
		}
	}

	private void method_1(string string_9)
	{
		_003C_003Ec__DisplayClass109_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass109_0();
		CS_0024_003C_003E8__locals0.orderNumber = string_9;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		onlineOrder_confirmed_click = false;
		List<Order> list = new List<Order>();
		if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "OFF")
		{
			OrderMethods orderMethods = new OrderMethods();
			IEnumerable<Order> source;
			if (!bool_5)
			{
				IEnumerable<Order> enumerable = orderMethods.Orders(CS_0024_003C_003E8__locals0.orderNumber);
				source = enumerable;
			}
			else
			{
				source = from x in orderMethods.UnfilledOrders(StationID)
					where x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && (x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime)) || (x.OrderOnHoldTime != 0 && (x.OrderType == OrderTypes.DeliveryOnline || x.OrderType == OrderTypes.PickUpOnline || x.OrderType == OrderTypes.PickUpCurbsideOnline || x.OrderType == OrderTypes.DineInOnline)))
					select x;
			}
			list = source.ToList();
		}
		else
		{
			OrderMethods orderMethods2 = new OrderMethods();
			IEnumerable<Order> source2;
			if (!bool_5)
			{
				IEnumerable<Order> enumerable = orderMethods2.Orders(CS_0024_003C_003E8__locals0.orderNumber);
				source2 = enumerable;
			}
			else
			{
				source2 = from x in orderMethods2.UnfilledOrders(StationID)
					where CS_0024_003C_003E8__locals0._003C_003E4__this.OrderNumber.Contains(x.OrderNumber) && (x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime)) || (x.OrderOnHoldTime != 0 && (x.OrderType == OrderTypes.DeliveryOnline || x.OrderType == OrderTypes.PickUpOnline || x.OrderType == OrderTypes.PickUpCurbsideOnline || x.OrderType == OrderTypes.DineInOnline)))
					select x;
			}
			list = source2.ToList();
		}
		int num = list.Count();
		Order order = list.FirstOrDefault();
		if (order == null)
		{
			return;
		}
		OrderType = order.OrderType;
		string text = order.Customer;
		string customerInfoPhone = order.CustomerInfoPhone;
		string customerInfo = order.CustomerInfo;
		string customerInfoName = order.CustomerInfoName;
		if (OrderType.ToUpper().Contains("ONLINE"))
		{
			customerInfoName = order.CustomerInfoName;
		}
		else
		{
			customerInfoName = string.Empty;
			text = (string.IsNullOrEmpty(order.CustomerInfoName) ? string.Empty : (order.CustomerInfoName + "-")) + order.Customer;
		}
		CS_0024_003C_003E8__locals0.listView = new CustomListViewTelerik();
		CS_0024_003C_003E8__locals0.headerlabel = new Label();
		CS_0024_003C_003E8__locals0.lblOrderNum = new Label();
		CS_0024_003C_003E8__locals0.headerlabel.Size = new Size(base.Width, 30);
		CS_0024_003C_003E8__locals0.headerlabel.ForeColor = Color.White;
		CS_0024_003C_003E8__locals0.headerlabel.Location = new Point(0, 0);
		CS_0024_003C_003E8__locals0.headerlabel.TextAlign = ContentAlignment.MiddleLeft;
		CS_0024_003C_003E8__locals0.headerlabel.Font = new Font("Arial", HeaderLabelFontSize, FontStyle.Bold);
		CS_0024_003C_003E8__locals0.headerlabel.Padding = new Padding(10, 0, 0, 0);
		if (string_8 == ScreenType.dine_in)
		{
			Label headerlabel = CS_0024_003C_003E8__locals0.headerlabel;
			Color backColor = (CS_0024_003C_003E8__locals0.lblOrderNum.BackColor = ColorHelper.smethod_0(Convert.ToInt16(order.SeatNum)));
			headerlabel.BackColor = backColor;
		}
		else
		{
			Label headerlabel2 = CS_0024_003C_003E8__locals0.headerlabel;
			Color backColor = (CS_0024_003C_003E8__locals0.lblOrderNum.BackColor = ColorHelper.getOrderTypeColor(OrderType));
			headerlabel2.BackColor = backColor;
		}
		if (OrderType == OrderTypes.DeliveryOnline)
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = Resources.Delivery_Online.ToUpper();
		}
		else if (OrderType == OrderTypes.PickUpOnline)
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = Resources.Pick_Up_Online.ToUpper();
		}
		else if (OrderType == OrderTypes.PickUpCurbsideOnline)
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = "Pick-Up Curbside Online".ToUpper();
		}
		else if (OrderType == OrderTypes.DineIn)
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = Resources.Dine_In.ToUpper();
		}
		else if (OrderType == OrderTypes.DineInOnline)
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = "Dine In Online".ToUpper();
		}
		else
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = OrderType.ToUpper();
		}
		if (string_8 == ScreenType.dine_in)
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = "";
		}
		if (order.Paid)
		{
			CS_0024_003C_003E8__locals0.headerlabel.Text = "*PAID* " + CS_0024_003C_003E8__locals0.headerlabel.Text.ToUpper();
		}
		CS_0024_003C_003E8__locals0.headerlabel.Name = "header" + CS_0024_003C_003E8__locals0.listView.Name.ToUpper();
		Invoke((MethodInvoker)delegate
		{
			CS_0024_003C_003E8__locals0._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals0.headerlabel);
			CS_0024_003C_003E8__locals0.headerlabel.BringToFront();
			CS_0024_003C_003E8__locals0._003C_003E4__this.label_1 = CS_0024_003C_003E8__locals0.headerlabel;
		});
		CS_0024_003C_003E8__locals0.lblOrderNum.Size = new Size(base.Width, 30);
		CS_0024_003C_003E8__locals0.lblOrderNum.Location = new Point(CS_0024_003C_003E8__locals0.headerlabel.Location.X, CS_0024_003C_003E8__locals0.headerlabel.Location.Y + CS_0024_003C_003E8__locals0.headerlabel.Size.Height);
		SubSource = order.SubSource;
		if (!CS_0024_003C_003E8__locals0.orderNumber.Contains("WEB") && !OrderType.ToUpper().Contains("ONLINE"))
		{
			OrderTicket = order.OrderTicketNumber;
			if (SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")
			{
				CS_0024_003C_003E8__locals0.lblOrderNum.Text = ((!string.IsNullOrEmpty(order.OrderTicketNumber)) ? ("TCKT#: " + order.OrderTicketNumber).ToUpper() : ("ORD#: " + CS_0024_003C_003E8__locals0.orderNumber).ToUpper());
			}
			else
			{
				CS_0024_003C_003E8__locals0.lblOrderNum.Text = ("ORD#: " + CS_0024_003C_003E8__locals0.orderNumber).ToUpper();
			}
		}
		else
		{
			CS_0024_003C_003E8__locals0.lblOrderNum.Text = ("ORD#: " + ((CS_0024_003C_003E8__locals0.orderNumber.Length > 15) ? CS_0024_003C_003E8__locals0.orderNumber.Substring(CS_0024_003C_003E8__locals0.orderNumber.Length - 4, 4).ToUpper() : CS_0024_003C_003E8__locals0.orderNumber)).ToUpper();
			if (!string.IsNullOrEmpty(SubSource) && !string.IsNullOrEmpty(order.OrderTicketNumber))
			{
				CS_0024_003C_003E8__locals0.lblOrderNum.Text = ("ORD#: " + order.OrderTicketNumber).ToUpper();
			}
		}
		if ((string_8 == ScreenType.dine_in || (OrderType == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")) && !text.Contains("KIOSK"))
		{
			CS_0024_003C_003E8__locals0.lblOrderNum.Text = "";
		}
		CS_0024_003C_003E8__locals0.lblOrderNum.TextAlign = ContentAlignment.MiddleLeft;
		CS_0024_003C_003E8__locals0.lblOrderNum.ForeColor = Color.White;
		CS_0024_003C_003E8__locals0.lblOrderNum.Name = "lblOrderNum" + CS_0024_003C_003E8__locals0.listView.Name;
		CS_0024_003C_003E8__locals0.lblOrderNum.Padding = new Padding(10, 0, 0, 0);
		CS_0024_003C_003E8__locals0.lblOrderNum.Font = new Font("Arial", HeaderLabelFontSize, FontStyle.Bold);
		Invoke((MethodInvoker)delegate
		{
			CS_0024_003C_003E8__locals0._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals0.lblOrderNum);
			CS_0024_003C_003E8__locals0.lblOrderNum.BringToFront();
			CS_0024_003C_003E8__locals0._003C_003E4__this.label_2 = CS_0024_003C_003E8__locals0.lblOrderNum;
		});
		CS_0024_003C_003E8__locals0.lblCustomer = new Label();
		CS_0024_003C_003E8__locals0.lblCustomer.MinimumSize = new Size(CS_0024_003C_003E8__locals0.headerlabel.Size.Width, 73);
		CS_0024_003C_003E8__locals0.lblCustomer.TextAlign = ContentAlignment.BottomLeft;
		CS_0024_003C_003E8__locals0.lblCustomer.ForeColor = Color.Maroon;
		CS_0024_003C_003E8__locals0.lblCustomer.BackColor = Color.LightGray;
		CS_0024_003C_003E8__locals0.lblCustomer.Font = new Font("Arial", FooterLabelFontSize + 2f, FontStyle.Bold);
		CS_0024_003C_003E8__locals0.lblCustomer.Name = "lblCustomer" + CS_0024_003C_003E8__locals0.listView.Name;
		CS_0024_003C_003E8__locals0.lblCustomer.Padding = new Padding(5, 5, 5, 5);
		if (!bool_5)
		{
			CS_0024_003C_003E8__locals0.lblCustomer.Width += 35;
		}
		CS_0024_003C_003E8__locals0.lblCustomer.AutoSize = true;
		CS_0024_003C_003E8__locals0.lblCustomer.Location = new Point(CS_0024_003C_003E8__locals0.lblOrderNum.Location.X, CS_0024_003C_003E8__locals0.lblOrderNum.Location.Y + CS_0024_003C_003E8__locals0.lblOrderNum.Size.Height);
		CS_0024_003C_003E8__locals0.lblTimer = new Label();
		CS_0024_003C_003E8__locals0.lblTimer.MinimumSize = new Size(100, 48);
		CS_0024_003C_003E8__locals0.lblTimer.Height = CS_0024_003C_003E8__locals0.lblCustomer.Height;
		CS_0024_003C_003E8__locals0.lblTimer.TextAlign = ContentAlignment.TopRight;
		CS_0024_003C_003E8__locals0.lblTimer.ForeColor = Color.Black;
		CS_0024_003C_003E8__locals0.lblTimer.BackColor = Color.LightGray;
		CS_0024_003C_003E8__locals0.lblTimer.Font = new Font("Arial", FooterLabelFontSize, FontStyle.Bold);
		CS_0024_003C_003E8__locals0.lblTimer.Name = "lblTimer" + CS_0024_003C_003E8__locals0.listView.Name;
		CS_0024_003C_003E8__locals0.lblTimer.Padding = new Padding(5, 5, 5, 5);
		CS_0024_003C_003E8__locals0.lblTimer.AutoSize = true;
		CS_0024_003C_003E8__locals0.lblTimer.Location = new Point(CS_0024_003C_003E8__locals0.lblCustomer.Location.X + CS_0024_003C_003E8__locals0.lblCustomer.Size.Width - CS_0024_003C_003E8__locals0.lblTimer.Width, CS_0024_003C_003E8__locals0.lblCustomer.Location.Y);
		timer_0 = new System.Windows.Forms.Timer();
		timer_0.Tick += timer_0_Tick;
		timer_0.Interval = new Random(new Random().Next(0, 1000000)).Next(100, 5000);
		timer_0.Enabled = bool_6;
		Invoke((MethodInvoker)delegate
		{
			CS_0024_003C_003E8__locals0._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals0.lblCustomer);
			CS_0024_003C_003E8__locals0.lblCustomer.BringToFront();
			CS_0024_003C_003E8__locals0._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals0.lblTimer);
			CS_0024_003C_003E8__locals0.lblTimer.BringToFront();
			CS_0024_003C_003E8__locals0._003C_003E4__this.label_0 = CS_0024_003C_003E8__locals0.lblCustomer;
			CS_0024_003C_003E8__locals0._003C_003E4__this.label_3 = CS_0024_003C_003E8__locals0.lblTimer;
		});
		CS_0024_003C_003E8__locals0.listView.Location = new Point(CS_0024_003C_003E8__locals0.lblCustomer.Location.X, CS_0024_003C_003E8__locals0.lblCustomer.Location.Y + CS_0024_003C_003E8__locals0.lblCustomer.Size.Height);
		CS_0024_003C_003E8__locals0.listView.Name = CS_0024_003C_003E8__locals0.orderNumber.ToString();
		CS_0024_003C_003E8__locals0.listView.Tag = OrderType + "|" + text + "|" + customerInfoPhone + "|" + customerInfoName + "|" + customerInfo;
		string items = Resources.Items;
		ListViewDetailColumn item = new ListViewDetailColumn("Qty", "Qty")
		{
			Width = 40f
		};
		CS_0024_003C_003E8__locals0.listView.Columns.Add(item);
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn(items, items);
		listViewDetailColumn.Width = base.Width - 50;
		if (string_8 != ScreenType.station)
		{
			listViewDetailColumn.Width = base.Width - 100;
		}
		CS_0024_003C_003E8__locals0.listView.Columns.Add(listViewDetailColumn);
		CS_0024_003C_003E8__locals0.listView.ItemSize = new Size(0, 50);
		CS_0024_003C_003E8__locals0.listView.AllowArbitraryItemHeight = true;
		if (string_8 != ScreenType.station)
		{
			ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Price", "Price");
			listViewDetailColumn2.Width = 50f;
			CS_0024_003C_003E8__locals0.listView.Columns.Add(listViewDetailColumn2);
		}
		CS_0024_003C_003E8__locals0.listView.ViewType = ListViewType.DetailsView;
		CS_0024_003C_003E8__locals0.listView.AutoScroll = false;
		CS_0024_003C_003E8__locals0.listView.ListViewElement.HorizontalScrollState = ScrollState.AlwaysHide;
		CS_0024_003C_003E8__locals0.listView.AutoScroll = true;
		CS_0024_003C_003E8__locals0.listView.MultiSelect = false;
		CS_0024_003C_003E8__locals0.listView.FullRowSelect = true;
		CS_0024_003C_003E8__locals0.listView.ShowGridLines = true;
		int num2 = num * 35;
		num2 = ((num2 > 140) ? num2 : 140);
		CS_0024_003C_003E8__locals0.listView.Size = new Size(base.Width, num2);
		CS_0024_003C_003E8__locals0.listView.MouseUp += method_4;
		CS_0024_003C_003E8__locals0.listView.Font = new Font(CS_0024_003C_003E8__locals0.listView.Font.FontFamily, FontSize, FontStyle.Regular);
		CS_0024_003C_003E8__locals0.listView.AutoScroll = false;
		CS_0024_003C_003E8__locals0.listView.EnableKineticScrolling = false;
		CS_0024_003C_003E8__locals0.listView.VerticalScrollState = ScrollState.AlwaysHide;
		CS_0024_003C_003E8__locals0.listView.CellFormatting += method_3;
		Invoke((MethodInvoker)delegate
		{
			CS_0024_003C_003E8__locals0._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals0.listView);
			CS_0024_003C_003E8__locals0.listView.BringToFront();
			CS_0024_003C_003E8__locals0._003C_003E4__this.customListViewTelerik_0 = CS_0024_003C_003E8__locals0.listView;
		});
		CS_0024_003C_003E8__locals0.lblTotal = new TransparentLabel();
		CS_0024_003C_003E8__locals0.lblTotal.Size = new Size(base.Size.Width * 3 / 4, 35);
		CS_0024_003C_003E8__locals0.lblTotal.Font = new Font("Arial", FontSize + 2f, FontStyle.Bold);
		CS_0024_003C_003E8__locals0.lblTotal.Location = new Point(customListViewTelerik_0.Right - CS_0024_003C_003E8__locals0.lblTotal.Size.Width - 10, customListViewTelerik_0.Top - CS_0024_003C_003E8__locals0.lblTotal.Size.Height + 3);
		CS_0024_003C_003E8__locals0.lblTotal.TextAlign = ContentAlignment.BottomRight;
		CS_0024_003C_003E8__locals0.lblTotal.textAlign = StringAlignment.Far;
		CS_0024_003C_003E8__locals0.lblTotal.ForeColor = Color.Black;
		CS_0024_003C_003E8__locals0.lblTotal.BackColor = Color.Transparent;
		CS_0024_003C_003E8__locals0.lblTotal.Name = "lblTotals" + CS_0024_003C_003E8__locals0.orderNumber;
		CS_0024_003C_003E8__locals0.lblTotal.Opacity = 0;
		Invoke((MethodInvoker)delegate
		{
			CS_0024_003C_003E8__locals0._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals0.lblTotal);
			CS_0024_003C_003E8__locals0.lblTotal.BringToFront();
			CS_0024_003C_003E8__locals0._003C_003E4__this.transparentLabel_1 = CS_0024_003C_003E8__locals0.lblTotal;
		});
		CS_0024_003C_003E8__locals0.tlbl = new TransparentLabel();
		if (ClickLabel == null)
		{
			CS_0024_003C_003E8__locals0.tlbl.Name = "selected_tlbl" + base.Name;
			CS_0024_003C_003E8__locals0.tlbl.MouseClick += method_4;
			if ((OrderType == OrderTypes.DeliveryOnline || OrderType == OrderTypes.PickUpOnline || OrderType == OrderTypes.PickUpCurbsideOnline || OrderType == OrderTypes.DineInOnline) && OnlineOrderStatus == 1)
			{
				CS_0024_003C_003E8__locals0.tlbl.MouseClick += method_2;
			}
			ClickLabel = CS_0024_003C_003E8__locals0.tlbl;
		}
		else
		{
			CS_0024_003C_003E8__locals0.tlbl = ClickLabel;
			CS_0024_003C_003E8__locals0.tlbl.MouseClick += method_2;
		}
		CS_0024_003C_003E8__locals0.tlbl.TransparentBackColor = Color.White;
		CS_0024_003C_003E8__locals0.tlbl.Opacity = 0;
		CS_0024_003C_003E8__locals0.tlbl.Font = new Font("Arial", 25f, FontStyle.Bold);
		CS_0024_003C_003E8__locals0.tlbl.Size = customListViewTelerik_0.Size;
		TransparentLabel tlbl = CS_0024_003C_003E8__locals0.tlbl;
		Point location2 = (ClickLabel.Location = customListViewTelerik_0.Location);
		tlbl.Location = location2;
		Invoke((MethodInvoker)delegate
		{
			CS_0024_003C_003E8__locals0._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals0.tlbl);
			CS_0024_003C_003E8__locals0.tlbl.BringToFront();
			CS_0024_003C_003E8__locals0._003C_003E4__this.transparentLabel_0 = CS_0024_003C_003E8__locals0.tlbl;
		});
		if (OrderType == OrderTypes.Catering)
		{
			_003C_003Ec__DisplayClass109_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass109_1();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
			CS_0024_003C_003E8__locals1.lblCateringInfo = new TransparentLabel();
			CS_0024_003C_003E8__locals1.lblCateringInfo.Size = new Size(base.Size.Width, 50);
			CS_0024_003C_003E8__locals1.lblCateringInfo.Font = new Font("Arial", FontSize + 2f, FontStyle.Bold);
			CS_0024_003C_003E8__locals1.lblCateringInfo.Location = new Point(0, customListViewTelerik_0.Bottom - CS_0024_003C_003E8__locals1.lblCateringInfo.Size.Height);
			CS_0024_003C_003E8__locals1.lblCateringInfo.TextAlign = ContentAlignment.MiddleLeft;
			CS_0024_003C_003E8__locals1.lblCateringInfo.textAlign = StringAlignment.Near;
			CS_0024_003C_003E8__locals1.lblCateringInfo.ForeColor = Color.Black;
			CS_0024_003C_003E8__locals1.lblCateringInfo.BackColor = Color.Transparent;
			CS_0024_003C_003E8__locals1.lblCateringInfo.Name = "lblCatering" + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.orderNumber;
			CS_0024_003C_003E8__locals1.lblCateringInfo.Opacity = 80;
			Invoke((MethodInvoker)delegate
			{
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.Controls.Add(CS_0024_003C_003E8__locals1.lblCateringInfo);
				CS_0024_003C_003E8__locals1.lblCateringInfo.BringToFront();
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.transparentLabel_2 = CS_0024_003C_003E8__locals1.lblCateringInfo;
			});
		}
	}

	private void method_2(object sender, MouseEventArgs e)
	{
		if (bool_3 && (OrderType == OrderTypes.DeliveryOnline || OrderType == OrderTypes.PickUpOnline || OrderType == OrderTypes.PickUpCurbsideOnline || OrderType == OrderTypes.DineInOnline) && OnlineOrderStatus == 1 && !onlineOrder_confirmed)
		{
			onlineOrder_confirmed_click = true;
			new frmOnlineOrders(OrderNumber.First()).ShowDialog();
			if (base.ParentForm != null)
			{
				MiscHelper.MakeOrderIsModified(base.ParentForm, OrderNumber.First());
			}
		}
	}

	private void method_3(object sender, ListViewCellFormattingEventArgs e)
	{
		if (e.CellElement.Data.HeaderText == "Price" && e.CellElement is DetailListViewDataCellElement)
		{
			e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
		}
	}

	private void method_4(object sender, MouseEventArgs e)
	{
		if (!Selected)
		{
			Selected = true;
		}
		else
		{
			Selected = false;
		}
	}

	private void OrderChit_Load(object sender, EventArgs e)
	{
		if (!(SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "OFF") && bool_5)
		{
			method_1(TableName);
		}
		else
		{
			method_1(OrderNumber.First());
		}
		Refresh();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		((System.Windows.Forms.Timer)sender).Interval = 1500;
		if (label_3 == null || base.IsDisposed)
		{
			return;
		}
		int num = (int)(DateTime.Now - dateTime_0).TotalMinutes;
		if (bool_5)
		{
			label_3.Visible = true;
			label_3.Text = num + "\nmin";
		}
		else
		{
			label_3.Visible = false;
		}
		if (!Selected && string_8 == ScreenType.station)
		{
			if (num >= 10 && num < 15)
			{
				if (transparentLabel_0.TransparentBackColor == Color.Yellow)
				{
					transparentLabel_0.TransparentBackColor = Color.White;
					transparentLabel_0.Opacity = 0;
				}
				else
				{
					transparentLabel_0.TransparentBackColor = Color.Yellow;
					transparentLabel_0.Opacity = 30;
				}
			}
			else if (num >= 15)
			{
				if (transparentLabel_0.TransparentBackColor == Color.Red)
				{
					transparentLabel_0.TransparentBackColor = Color.White;
					transparentLabel_0.Opacity = 0;
				}
				else
				{
					transparentLabel_0.TransparentBackColor = Color.Red;
					transparentLabel_0.Opacity = 30;
				}
			}
		}
		if (string_8 == ScreenType.take_out && (!onlineOrder_confirmed || !(transparentLabel_0.TransparentBackColor == Color.White)) && (OrderType == OrderTypes.DeliveryOnline || OrderType == OrderTypes.PickUpOnline || OrderType == OrderTypes.PickUpCurbsideOnline || OrderType == OrderTypes.DineInOnline) && bool_3)
		{
			if (!(transparentLabel_0.TransparentBackColor == Color.Green) && !onlineOrder_confirmed)
			{
				transparentLabel_0.TransparentBackColor = Color.Green;
				transparentLabel_0.Opacity = 30;
				transparentLabel_0.Text = transLabelMessage;
			}
			else
			{
				transparentLabel_0.TransparentBackColor = Color.White;
				transparentLabel_0.Opacity = 0;
				transparentLabel_0.Text = "";
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Transparent;
		base.Name = "OrderChit";
		base.Padding = new System.Windows.Forms.Padding(10);
		base.Size = new System.Drawing.Size(256, 199);
		base.Load += new System.EventHandler(OrderChit_Load);
		base.ResumeLayout(false);
	}
}
