using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Business.Enums;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class SecurityHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public ModulesAndFeature module;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_1
	{
		public short roleID;

		public _003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass2_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CCheckAndCreateSecurityMatrix_003Eb__0(SecurityMatrix a)
		{
			if (a.ModuleID == CS_0024_003C_003E8__locals1.module.Id)
			{
				return a.RoleID == roleID;
			}
			return false;
		}
	}

	public static List<SecurityObject> SecuritySettings;

	public static void LoadSecuritySettings()
	{
		CheckAndCreateSecurityMatrix();
		GClass6 gClass = new GClass6();
		SecuritySettings = gClass.SecurityMatrixes.Select((SecurityMatrix x) => new SecurityObject
		{
			ModuleId = x.ModuleID,
			FormName = x.ModulesAndFeature.ModuleName,
			ControlName = x.ModulesAndFeature.ControlName,
			RoleID = x.RoleID,
			isAllowed = x.IsAllow,
			AllowAdminCtrlOverride = x.ModulesAndFeature.AllowCtrlOverride
		}).ToList();
		SecuritySettings.Add(new SecurityObject
		{
			FormName = "frmKioskOrderTypeSelection",
			isAllowed = true,
			RoleID = RoleIDs.kiosk
		});
		foreach (Role item in gClass.Roles.Where((Role x) => x.RoleLevel == null).ToList())
		{
			if (item.RoleID == RoleIDs.admin)
			{
				item.RoleLevel = 1;
			}
			else if (item.RoleID == RoleIDs.manager)
			{
				item.RoleLevel = 2;
			}
			else if (item.RoleID == RoleIDs.supervisor)
			{
				item.RoleLevel = 3;
			}
			else if (item.RoleID == RoleIDs.employee)
			{
				item.RoleLevel = 4;
			}
			else if (item.RoleID == RoleIDs.driver)
			{
				item.RoleLevel = 5;
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static void CheckAndCreateSecurityMatrix()
	{
		GClass6 gClass = new GClass6();
		List<ModulesAndFeature> list = gClass.ModulesAndFeatures.ToList();
		List<SecurityMatrix> source = gClass.SecurityMatrixes.ToList();
		using (List<ModulesAndFeature>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
				_003C_003Ec__DisplayClass2_.module = enumerator.Current;
				_003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_1();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass2_;
				CS_0024_003C_003E8__locals0.roleID = 1;
				while (CS_0024_003C_003E8__locals0.roleID <= 7)
				{
					if (CS_0024_003C_003E8__locals0.roleID != 6)
					{
						SecurityMatrix securityMatrix = source.Where((SecurityMatrix a) => a.ModuleID == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.module.Id && a.RoleID == CS_0024_003C_003E8__locals0.roleID).FirstOrDefault();
						if (securityMatrix == null)
						{
							AddSecurityMatrix(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.module.Id, CS_0024_003C_003E8__locals0.roleID, CS_0024_003C_003E8__locals0.roleID <= 3);
							securityMatrix = gClass.SecurityMatrixes.Where((SecurityMatrix a) => a.ModuleID == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.module.Id && a.RoleID == CS_0024_003C_003E8__locals0.roleID).FirstOrDefault();
							if (CS_0024_003C_003E8__locals0.roleID == RoleIDs.driver && securityMatrix != null)
							{
								if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnPay")
								{
									securityMatrix.IsAllow = true;
								}
								if (securityMatrix.ModulesAndFeature.ModuleName == "frmDeliveryManagement")
								{
									securityMatrix.IsAllow = true;
								}
							}
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnClose")
						{
							securityMatrix.ModulesAndFeature.AllowCtrlOverride = true;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnSaveOrder" && !securityMatrix.ModulesAndFeature.AllowCtrlOverride)
						{
							securityMatrix.ModulesAndFeature.AllowCtrlOverride = true;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnSaveOrder" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.kiosk && securityMatrix.IsAllow)
						{
							securityMatrix.IsAllow = false;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnClear" && !securityMatrix.ModulesAndFeature.AllowCtrlOverride)
						{
							securityMatrix.ModulesAndFeature.AllowCtrlOverride = true;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnClear" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.kiosk && !securityMatrix.IsAllow)
						{
							securityMatrix.IsAllow = true;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnChangePrice" && !securityMatrix.ModulesAndFeature.AllowCtrlOverride)
						{
							securityMatrix.ModulesAndFeature.AllowCtrlOverride = true;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnChangePrice" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.kiosk && !securityMatrix.IsAllow)
						{
							securityMatrix.IsAllow = true;
						}
						if (SettingsHelper.CurrentTerminalMode == "Kiosk" && securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnClear" && securityMatrix.ModulesAndFeature.AllowCtrlOverride)
						{
							securityMatrix.ModulesAndFeature.AllowCtrlOverride = false;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnPay" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.kiosk)
						{
							securityMatrix.IsAllow = true;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnPay" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.patron)
						{
							securityMatrix.IsAllow = false;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnSaveClose" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.kiosk)
						{
							securityMatrix.IsAllow = false;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmOrderEntry" && securityMatrix.ModulesAndFeature.ControlName == "btnSaveClose" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.patron)
						{
							securityMatrix.IsAllow = false;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmLayout" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.patron)
						{
							securityMatrix.IsAllow = true;
						}
						if (securityMatrix.ModulesAndFeature.ModuleName == "frmKioskOrderTypeSelection" && CS_0024_003C_003E8__locals0.roleID == RoleIDs.kiosk)
						{
							securityMatrix.IsAllow = true;
						}
						else if (securityMatrix.ModulesAndFeature.ModuleName == "frmKioskOrderTypeSelection" && CS_0024_003C_003E8__locals0.roleID != RoleIDs.kiosk)
						{
							securityMatrix.IsAllow = false;
						}
					}
					CS_0024_003C_003E8__locals0.roleID++;
				}
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void AddSecurityMatrix(int moduleId, short roleId, bool isAllow = true)
	{
		GClass6 gClass = new GClass6();
		SecurityMatrix entity = new SecurityMatrix
		{
			ModuleID = moduleId,
			RoleID = roleId,
			IsAllow = isAllow
		};
		gClass.SecurityMatrixes.InsertOnSubmit(entity);
		Helper.SubmitChangesWithCatch(gClass);
	}

	static SecurityHelper()
	{
		Class2.oOsq41PzvTVMr();
		SecuritySettings = new List<SecurityObject>();
	}
}
