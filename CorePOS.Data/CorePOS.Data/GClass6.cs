using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace CorePOS.Data;

[Database(Name = "RestaurantPOS-HipPOS")]
public class GClass6 : DataContext
{
	private static MappingSource mappingSource_0;

	public Table<ConfigDetail> ConfigDetails => GetTable<ConfigDetail>();

	public Table<Config> Configs => GetTable<Config>();

	public Table<CustomField> CustomFields => GetTable<CustomField>();

	public Table<ItemCustomFieldValue> ItemCustomFieldValues => GetTable<ItemCustomFieldValue>();

	public Table<ItemsInGroup> ItemsInGroups => GetTable<ItemsInGroup>();

	public Table<ItemsInItem> ItemsInItems => GetTable<ItemsInItem>();

	public Table<TaxRuleRequirement> TaxRuleRequirements => GetTable<TaxRuleRequirement>();

	public Table<TaxRule> TaxRules => GetTable<TaxRule>();

	public Table<Temp> Temps => GetTable<Temp>();

	public Table<ItemType> ItemTypes => GetTable<ItemType>();

	public Table<ItemAuditLog> ItemAuditLogs => GetTable<ItemAuditLog>();

	public Table<BusinessHour> BusinessHours => GetTable<BusinessHour>();

	public Table<Maintenance> Maintenances => GetTable<Maintenance>();

	public Table<Option> Options => GetTable<Option>();

	public Table<Tax> Taxes => GetTable<Tax>();

	public Table<TaxRuleOperation> TaxRuleOperations => GetTable<TaxRuleOperation>();

	public Table<Refund> Refunds => GetTable<Refund>();

	public Table<User> Users => GetTable<User>();

	public Table<GClass7> UOMUnitsConversions => GetTable<GClass7>();

	public Table<SecurityMatrix> SecurityMatrixes => GetTable<SecurityMatrix>();

	public Table<TransactionReceipt> TransactionReceipts => GetTable<TransactionReceipt>();

	public Table<ModulesAndFeature> ModulesAndFeatures => GetTable<ModulesAndFeature>();

	public Table<GroupsInItem> GroupsInItems => GetTable<GroupsInItem>();

	public Table<Appointment> Appointments => GetTable<Appointment>();

	public Table<InventoryBatch> InventoryBatches => GetTable<InventoryBatch>();

	public Table<Reason> Reasons => GetTable<Reason>();

	public Table<ItemImage> ItemImages => GetTable<ItemImage>();

	public Table<UsefulTip> UsefulTips => GetTable<UsefulTip>();

	public Table<ItemsSupplier> ItemsSuppliers => GetTable<ItemsSupplier>();

	public Table<GiftCardTransactionLog> GiftCardTransactionLogs => GetTable<GiftCardTransactionLog>();

	public Table<DiscountCode> DiscountCodes => GetTable<DiscountCode>();

	public Table<SpecialInstruction> SpecialInstructions => GetTable<SpecialInstruction>();

	public Table<ChitPrintQueue> ChitPrintQueues => GetTable<ChitPrintQueue>();

	public Table<Role> Roles => GetTable<Role>();

	public Table<Payout> Payouts => GetTable<Payout>();

	public Table<PaymentType> PaymentTypes => GetTable<PaymentType>();

	public Table<OrderTypeGenKey> OrderTypeGenKeys => GetTable<OrderTypeGenKey>();

	public Table<GenKey> GenKeys => GetTable<GenKey>();

	public Table<Group> Groups => GetTable<Group>();

	public Table<EmployeeClockInOutQueue> EmployeeClockInOutQueues => GetTable<EmployeeClockInOutQueue>();

	public Table<ItemCourse> ItemCourses => GetTable<ItemCourse>();

	public Table<Promotion> Promotions => GetTable<Promotion>();

	public Table<ImageScreen> ImageScreens => GetTable<ImageScreen>();

	public Table<GroupImage> GroupImages => GetTable<GroupImage>();

	public Table<Supplier> Suppliers => GetTable<Supplier>();

	public Table<CustomTipSharing> CustomTipSharings => GetTable<CustomTipSharing>();

	public Table<Setting> Settings => GetTable<Setting>();

	public Table<ItemsWithOption> ItemsWithOptions => GetTable<ItemsWithOption>();

	public Table<MaterialsInItem> MaterialsInItems => GetTable<MaterialsInItem>();

	public Table<Layout> Layouts => GetTable<Layout>();

	public Table<CompanySetup> CompanySetups => GetTable<CompanySetup>();

	public Table<SettingsAuditLog> SettingsAuditLogs => GetTable<SettingsAuditLog>();

	public Table<OrderAuditsLog> OrderAuditsLogs => GetTable<OrderAuditsLog>();

	public Table<Customer> Customers => GetTable<Customer>();

	public Table<PaymentTerminalTransactionLog> PaymentTerminalTransactionLogs => GetTable<PaymentTerminalTransactionLog>();

	public Table<InventoryAudit> InventoryAudits => GetTable<InventoryAudit>();

	public Table<Employee> Employees => GetTable<Employee>();

	public Table<UOM> UOMs => GetTable<UOM>();

	public Table<Order> Orders => GetTable<Order>();

	public Table<OnlineOrderSyncQueue> OnlineOrderSyncQueues => GetTable<OnlineOrderSyncQueue>();

	public Table<Station> Stations => GetTable<Station>();

	public Table<Terminal> Terminals => GetTable<Terminal>();

	public Table<Item> Items => GetTable<Item>();

	public Table<CloudsyncDataArchiver> CloudsyncDataArchivers => GetTable<CloudsyncDataArchiver>();

	public GClass6()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector(Helper.GetConnectionString(), mappingSource_0);
	}

	public GClass6(string connection)
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector(connection, mappingSource_0);
	}

	public GClass6(IDbConnection connection)
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector(connection, mappingSource_0);
	}

	public GClass6(string connection, MappingSource mappingSource)
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector(connection, mappingSource);
	}

	public GClass6(IDbConnection connection, MappingSource mappingSource)
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector(connection, mappingSource);
	}

	[Function(Name = "dbo.usp_TruncateTemp")]
	public int usp_TruncateTemp()
	{
		return (int)ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod()).ReturnValue;
	}

	[Function(Name = "dbo.usp_OccupiedTables")]
	public ISingleResult<usp_OccupiedTablesResult> usp_OccupiedTables()
	{
		return (ISingleResult<usp_OccupiedTablesResult>)ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod()).ReturnValue;
	}

	[Function(Name = "dbo.usp_ClosingTotals")]
	public ISingleResult<usp_ClosingTotalsResult> usp_ClosingTotals()
	{
		return (ISingleResult<usp_ClosingTotalsResult>)ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod()).ReturnValue;
	}

	[Function(Name = "dbo.usp_ItemOptions")]
	public ISingleResult<usp_ItemOptionsResult> usp_ItemOptions()
	{
		return (ISingleResult<usp_ItemOptionsResult>)ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod()).ReturnValue;
	}

	static GClass6()
	{
		Class5.qrSRKAOzgGGAb();
		mappingSource_0 = new AttributeMappingSource();
	}
}
