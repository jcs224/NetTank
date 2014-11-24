using UnityEngine;
using System.Collections;

public class ConnectGui : MonoBehaviour
{
    private string connectToIP = "127.0.0.1";
    private int connectPort = 25001;

    public GameObject tank;
    private bool createdTank = false;

    void Start() 
    {
	
	}
	

	void Update () 
    {
	
	}



    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            GUILayout.Label("Connection status: Disconnected");

            connectToIP = GUILayout.TextField(connectToIP, GUILayout.MinWidth(100));
            connectPort = int.Parse(GUILayout.TextField(connectPort.ToString()));

            GUILayout.BeginVertical();
            if (GUILayout.Button("Connect as client"))
            {
                Network.Connect(connectToIP, connectPort);
            }

            if (GUILayout.Button("Start Server"))
            {
                Network.InitializeServer(32, connectPort, false);
            }

            GUILayout.EndVertical();
        }
        else
        {
            if (Network.peerType == NetworkPeerType.Connecting)
            {
                GUILayout.Label("Connection status: Connecting");
            }
            else if (Network.peerType == NetworkPeerType.Client)
            {
                GUILayout.Label("Connection status: Client!");
                GUILayout.Label("Ping to server: " + Network.GetAveragePing(Network.connections[0]));

                if (createdTank == false)
                {
                    Network.Instantiate(tank, Vector3.zero, Quaternion.identity, 0);
                    createdTank = true;
                }
            }
            else if (Network.peerType == NetworkPeerType.Server)
            {
                GUILayout.Label("Connection status: Server!");
                GUILayout.Label("Connections: " + Network.connections.Length);
                if (Network.connections.Length >= 1)
                {
                    GUILayout.Label("Ping to first player: " + Network.GetAveragePing(Network.connections[0]));
                }


                if (createdTank == false)
                {
                    Network.Instantiate(tank, Vector3.zero, Quaternion.identity, 0);
                    createdTank = true;
                }
            }

            if (GUILayout.Button("Disconnect"))
            {
                Network.Disconnect(200);
            }

        }

    }
}
