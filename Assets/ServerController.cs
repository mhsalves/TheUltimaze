using UnityEngine;
using System.Collections;

public class ServerController : MonoBehaviour {
	public string ipToConnect;
	public int portToConnect;
	public int numberPlayers;
	public GameObject objectControl;
	public player playeR;
	
	// Use this for initialization
	void Start () {

		ipToConnect = Network.player.ipAddress;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void StartServer(){
		if(Network.peerType == NetworkPeerType.Disconnected){
			Debug.Log(Network.InitializeServer(numberPlayers, portToConnect, false));
			OnConnectedToServer();
		}
	}
	
	void ConnectToServer(){
		if(Network.peerType == NetworkPeerType.Disconnected){
			Debug.Log(Network.Connect(ipToConnect, portToConnect));
		}
	}
	
	void OnGUI(){
		if(Network.peerType == NetworkPeerType.Disconnected){
			if(GUI.Button(new Rect(Screen.width/2-100, 10, 200, 30), "Inicializar Servidor")){
				StartServer();
			}
			ipToConnect = GUI.TextField(new Rect(Screen.width/2-100, 40, 200, 30), ipToConnect);
			if(GUI.Button(new Rect(Screen.width/2-100, 70, 200, 30), "Conectar ao Servidor")){
				ConnectToServer();
				
			}
			
		}
		
		
	}
	
	void OnConnectedToServer(){
		GameObject player = Network.Instantiate(objectControl,new Vector3 (23.5f, 1.8f, 12.8f), transform.rotation, 0) as GameObject;
		playeR.payer = player;
		//player.GetComponent<PlayerBehaviour>().GetCamera();
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = playeR.payer.GetComponent<Rigidbody>().transform.position;
			stream.Serialize(ref syncPosition);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			playeR.payer.GetComponent<Rigidbody>().transform.position = syncPosition;
		}
	}
	
	
	
	
}
