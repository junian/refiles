using com.clover.remotepay.sdk;
using com.clover.remotepay.transport;

namespace CorePOS.Helpers;

public class CloverUtils
{
	private CloverUtils()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
	}

	public static string GetNextId()
	{
		return ExternalIDUtil.GenerateRandomString(13);
	}

	public static CloverDeviceConfiguration GetNetworkConfiguration()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0040: Expected O, but got Unknown
		//IL_0040: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		return (CloverDeviceConfiguration)new WebSocketCloverDeviceConfiguration("ws://192.168.2.131:9999/remote_pay", "VDQT4YQP13E2C", false, 1, "HipPOS", "C042UQ83950245", (string)null, new OnPairingCodeHandler(OnPairingCode), new OnPairingSuccessHandler(OnPairingSuccess), new OnPairingStateHandler(OnPairingState));
	}

	public static void OnPairingCode(string pairingCode)
	{
		frmMessageBox frmMessageBox = new frmMessageBox("Enter this pairing code: " + pairingCode, "PAIRING CODE");
		frmMessageBox.TopMost = true;
		frmMessageBox.TopLevel = true;
		frmMessageBox.Focus();
		frmMessageBox.ShowDialog();
	}

	public static void OnPairingSuccess(string pairingAuthToken)
	{
	}

	public static void OnPairingState(string state, string message)
	{
		new frmMessageBox(message, "MESSAGE FROM DEVICE").ShowDialog();
	}
}
