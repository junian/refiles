using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Business.Enums;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class InventoryMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public Order ord;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Order ord;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public MaterialsInItem materialInItem;

		public _003C_003Ec__DisplayClass8_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_2
	{
		public Item material;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass8_2()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Order ord;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public Order ord;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public MaterialsInItem materialInItem;

		public _003C_003Ec__DisplayClass10_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_2
	{
		public Item material;

		public _003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass10_2()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int? batchId;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int itemID;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CReconcileInventoryAuditLogs_003Eb__2(InventoryAudit x)
		{
			return x.ItemID == itemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public InventoryAudit first_unreconciled_log;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass12_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	private GClass6 gclass6_0;

	public GClass6 DataContext
	{
		get
		{
			return gclass6_0;
		}
		set
		{
			gclass6_0 = value;
		}
	}

	public InventoryMethods()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
		gclass6_0 = new GClass6();
	}

	public InventoryMethods(GClass6 appDataContext)
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
		gclass6_0 = appDataContext;
	}

	public void LogInventoryChange(int itemID, decimal qtyOld, decimal qtyChange, decimal qtyNew, string owner, string comments, int supplierId = 0, string inventoryType = "product")
	{
		if (itemID <= 0)
		{
			return;
		}
		InventoryAudit inventoryAudit = new InventoryAudit();
		inventoryAudit.ItemID = itemID;
		inventoryAudit.QtyNew = qtyNew;
		inventoryAudit.Owner = owner;
		inventoryAudit.Comment = comments;
		inventoryAudit.QtyChange = qtyChange;
		inventoryAudit.QtyStart = qtyOld;
		inventoryAudit.DateCreated = DateTime.Now;
		inventoryAudit.InventoryType = inventoryType;
		inventoryAudit.CloudInventoryAuditID = 0L;
		if (supplierId != 0)
		{
			inventoryAudit.SupplierId = supplierId;
		}
		gclass6_0.InventoryAudits.InsertOnSubmit(inventoryAudit);
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException)
		{
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	public void SubtractItemInventory(Order ord)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.ord = ord;
		if (CS_0024_003C_003E8__locals0.ord.ItemID <= 0)
		{
			return;
		}
		Item item = gclass6_0.Items.Where((Item m) => m.ItemID == CS_0024_003C_003E8__locals0.ord.ItemID).FirstOrDefault();
		if (item == null || !item.TrackInventory)
		{
			return;
		}
		decimal num = item.InventoryCount - Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty);
		decimal num2 = num - item.InventoryCount;
		item.InventoryCount = num;
		string text = "";
		if (CS_0024_003C_003E8__locals0.ord.InventoryBatchId > 0)
		{
			InventoryBatch inventoryBatch = gclass6_0.InventoryBatches.Where((InventoryBatch a) => (int?)a.Id == CS_0024_003C_003E8__locals0.ord.InventoryBatchId).FirstOrDefault();
			if (inventoryBatch != null)
			{
				text = ", Expiry batch updated: " + inventoryBatch.BatchNumber;
			}
		}
		LogInventoryChange(item.ItemID, num - num2, num2, num, CS_0024_003C_003E8__locals0.ord.OrderNumber, "Item Made/Sold" + text, 0, ItemClassifications.Product);
		if (!(num2 != 0m))
		{
			return;
		}
		gclass6_0 = new GClass6();
		foreach (Terminal item2 in gclass6_0.Terminals.ToList())
		{
			item2.ItemsInGroupsRefreshRequired = true;
		}
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException)
		{
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
		MemoryLoadedData.UpdateMemoryItemInventory(item.ItemID, item.InventoryCount);
	}

	public void SubtractMaterialInventory(Order ord)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.ord = ord;
		if (CS_0024_003C_003E8__locals0.ord.ItemID <= 0)
		{
			return;
		}
		List<MaterialsInItem> list = gclass6_0.MaterialsInItems.Where((MaterialsInItem m) => m.ItemID == CS_0024_003C_003E8__locals0.ord.ItemID).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		using List<MaterialsInItem>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
			_003C_003Ec__DisplayClass8_.materialInItem = enumerator.Current;
			_003C_003Ec__DisplayClass8_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_2();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass8_;
			CS_0024_003C_003E8__locals1.material = gclass6_0.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.ItemMaterialID).FirstOrDefault();
			if (CS_0024_003C_003E8__locals1.material == null)
			{
				continue;
			}
			decimal num;
			if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.UOMID == CS_0024_003C_003E8__locals1.material.UOMID)
			{
				num = CS_0024_003C_003E8__locals1.material.InventoryCount - Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty) * CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.Quantity.Value;
			}
			else
			{
				GClass7 gClass = new GClass6().UOMUnitsConversions.Where((GClass7 x) => x.ItemID == (int?)CS_0024_003C_003E8__locals1.material.ItemID && x.ToUnitId == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.UOMID).FirstOrDefault();
				num = ((gClass == null) ? (CS_0024_003C_003E8__locals1.material.InventoryCount - Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty) * CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.Quantity.Value) : (Math.Round(CS_0024_003C_003E8__locals1.material.InventoryCount, 8) - Math.Round(Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty), 8) * MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.Quantity.Value + ((gClass.Operator == "*") ? "/" : "*") + gClass.Factor, 8)));
			}
			decimal num2 = num - CS_0024_003C_003E8__locals1.material.InventoryCount;
			CS_0024_003C_003E8__locals1.material.InventoryCount = num;
			LogInventoryChange(CS_0024_003C_003E8__locals1.material.ItemID, num - num2, num2, num, CS_0024_003C_003E8__locals0.ord.OrderNumber, "Item Made", 0, "material");
			MemoryLoadedData.UpdateMemoryItemInventory(CS_0024_003C_003E8__locals1.material.ItemID, CS_0024_003C_003E8__locals1.material.InventoryCount);
		}
	}

	public void AddItemInventory(Order ord, string comment = "Item Voided")
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.ord = ord;
		if (CS_0024_003C_003E8__locals0.ord.ItemID <= 0)
		{
			return;
		}
		Item item = gclass6_0.Items.Where((Item m) => m.ItemID == CS_0024_003C_003E8__locals0.ord.ItemID).FirstOrDefault();
		if (item == null || !item.TrackInventory)
		{
			return;
		}
		decimal num = item.InventoryCount + Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty);
		decimal num2 = num - item.InventoryCount;
		item.InventoryCount = num;
		LogInventoryChange(item.ItemID, num - num2, num2, num, CS_0024_003C_003E8__locals0.ord.OrderNumber, comment, 0, ItemClassifications.Product);
		if (!(num2 != 0m))
		{
			return;
		}
		gclass6_0 = new GClass6();
		foreach (Terminal item2 in gclass6_0.Terminals.ToList())
		{
			item2.ItemsInGroupsRefreshRequired = true;
		}
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException)
		{
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
		MemoryLoadedData.UpdateMemoryItemInventory(item.ItemID, item.InventoryCount);
	}

	public void AddtMaterialInventory(Order ord)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.ord = ord;
		if (CS_0024_003C_003E8__locals0.ord.ItemID <= 0)
		{
			return;
		}
		List<MaterialsInItem> list = gclass6_0.MaterialsInItems.Where((MaterialsInItem m) => m.ItemID == CS_0024_003C_003E8__locals0.ord.ItemID).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		using List<MaterialsInItem>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
			_003C_003Ec__DisplayClass10_.materialInItem = enumerator.Current;
			_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_2();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
			CS_0024_003C_003E8__locals1.material = gclass6_0.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.ItemMaterialID).FirstOrDefault();
			if (CS_0024_003C_003E8__locals1.material == null)
			{
				continue;
			}
			decimal num;
			if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.UOMID == CS_0024_003C_003E8__locals1.material.UOMID)
			{
				num = CS_0024_003C_003E8__locals1.material.InventoryCount + Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty) * CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.Quantity.Value;
			}
			else
			{
				GClass7 gClass = new GClass6().UOMUnitsConversions.Where((GClass7 x) => x.ItemID == (int?)CS_0024_003C_003E8__locals1.material.ItemID && x.ToUnitId == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.UOMID).FirstOrDefault();
				num = ((gClass == null) ? (CS_0024_003C_003E8__locals1.material.InventoryCount + Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty) * CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.Quantity.Value) : (Math.Round(CS_0024_003C_003E8__locals1.material.InventoryCount, 8) + Math.Round(Convert.ToDecimal(CS_0024_003C_003E8__locals0.ord.Qty), 8) * MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.materialInItem.Quantity.Value + ((gClass.Operator == "*") ? "/" : "*") + gClass.Factor, 8)));
			}
			decimal num2 = num - CS_0024_003C_003E8__locals1.material.InventoryCount;
			CS_0024_003C_003E8__locals1.material.InventoryCount = num;
			LogInventoryChange(CS_0024_003C_003E8__locals1.material.ItemID, num - num2, num2, num, CS_0024_003C_003E8__locals0.ord.OrderNumber, "Item Voided", 0, "material");
			MemoryLoadedData.UpdateMemoryItemInventory(CS_0024_003C_003E8__locals1.material.ItemID, CS_0024_003C_003E8__locals1.material.InventoryCount);
		}
	}

	public void UpdateExpiryItem(int? batchId, decimal qty, bool toSubtract)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.batchId = batchId;
		if (!CS_0024_003C_003E8__locals0.batchId.HasValue || CS_0024_003C_003E8__locals0.batchId.Value == 0)
		{
			return;
		}
		InventoryBatch inventoryBatch = gclass6_0.InventoryBatches.Where((InventoryBatch a) => (int?)a.Id == CS_0024_003C_003E8__locals0.batchId).FirstOrDefault();
		if (inventoryBatch == null)
		{
			return;
		}
		if (toSubtract)
		{
			inventoryBatch.QTYRemaining -= qty;
		}
		else
		{
			inventoryBatch.QTYRemaining += qty;
		}
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException)
		{
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	public void ReconcileInventoryAuditLogs(int? refItemID = null)
	{
		GClass6 gClass = new GClass6();
		List<InventoryAudit> source = gClass.InventoryAudits.Where((InventoryAudit x) => x.isReconciled == false).ToList();
		List<int> list;
		if (!refItemID.HasValue)
		{
			list = source.Select((InventoryAudit x) => x.ItemID).Distinct().ToList();
		}
		else
		{
			list = new List<int>();
			list.Add(refItemID.Value);
		}
		decimal num = default(decimal);
		using List<int>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
			CS_0024_003C_003E8__locals0.itemID = enumerator.Current;
			num = default(decimal);
			gClass.Refresh(RefreshMode.OverwriteCurrentValues);
			List<InventoryAudit> list2 = source.Where((InventoryAudit x) => x.ItemID == CS_0024_003C_003E8__locals0.itemID).ToList();
			if (!list2.Any())
			{
				continue;
			}
			_003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_1();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
			CS_0024_003C_003E8__locals1.first_unreconciled_log = list2.FirstOrDefault();
			List<InventoryAudit> list3 = gClass.InventoryAudits.Where((InventoryAudit x) => x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.itemID && x.isReconciled == true && x.DateCreated > CS_0024_003C_003E8__locals1.first_unreconciled_log.DateCreated).ToList();
			foreach (InventoryAudit item2 in list3)
			{
				item2.isReconciled = false;
			}
			Helper.SubmitChangesWithCatch(gClass);
			gClass.Refresh(RefreshMode.OverwriteCurrentValues);
			list2.AddRange(list3);
			num = (from x in gClass.InventoryAudits
				where x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.itemID && x.isReconciled == true && x.DateCreated < CS_0024_003C_003E8__locals1.first_unreconciled_log.DateCreated
				orderby x.DateCreated descending
				select x).FirstOrDefault()?.QtyNew ?? default(decimal);
			foreach (InventoryAudit item3 in list2.OrderBy((InventoryAudit x) => x.DateCreated).ToList())
			{
				item3.QtyStart = num;
				item3.QtyNew = item3.QtyStart + item3.QtyChange;
				num = item3.QtyNew;
				item3.isReconciled = true;
			}
			Item item = gClass.Items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.itemID).FirstOrDefault();
			if (item != null)
			{
				item.InventoryCount = num;
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
	}
}
