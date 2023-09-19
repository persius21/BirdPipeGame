using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using TMPro;
using System.Net;
using System.Net.Sockets;
using UnityEditor.MemoryProfiler;
using System.Data;
using Unity.VisualScripting;

public class DisplayHostIPAddress  : MonoBehaviour
{
	private bool pcAssigned;

	[SerializeField] TextMeshProUGUI ipAddressText;
	

	[SerializeField] string ipAddress;
	[SerializeField] UnityTransport transport;

void Update(){
	GetLocalIPAddress();
}
	public string GetLocalIPAddress() {
		var host = Dns.GetHostEntry(Dns.GetHostName());
		foreach (var ip in host.AddressList) {
			if (ip.AddressFamily == AddressFamily.InterNetwork) {
				ipAddressText.text = ip.ToString();
				ipAddress = ip.ToString();
				return ip.ToString();
			}
		}
		throw new System.Exception("No network adapters with an IPv4 address in the system!");
	}

	/* Sets the Ip Address of the Connection Data in Unity Transport
	to the Ip Address which was input in the Input Field */
	// ONLY FOR CLIENT SIDE
	public void SetIpAddress() {
		transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
		transport.ConnectionData.Address = ipAddress;
	}

	}