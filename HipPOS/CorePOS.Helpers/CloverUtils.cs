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
		return new WebSocketCloverDeviceConfiguration("ws://192.168.2.131:9999/remote_pay", "VDQT4YQP13E2C", enableLogging: false, 1, "HipPOS", "C042UQ83950245", null, OnPairingCode, OnPairingSuccess, OnPairingState);
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
