using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement; 


namespace Com.WordPop.MyGame
{
	public class GameManager : Photon.PunBehaviour {


	


		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public void  OnLeftRoom()
		{
			SceneManager.LoadScene(2);
		}


	

		public void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}

	


		void LoadArena()
		{
			if ( ! PhotonNetwork.isMasterClient ) 
			{
				Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
			}
			Debug.Log( "PhotonNetwork : Loading Level : " + PhotonNetwork.room.playerCount );
			PhotonNetwork.LoadLevel("Room for "+PhotonNetwork.room.playerCount);
		}


		public override void OnPhotonPlayerConnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerConnected() " + other.name ); // not seen if you're the player connecting


			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected


				LoadArena();
			}
		}


		public override void OnPhotonPlayerDisconnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerDisconnected() " + other.name ); // seen when other disconnects


			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected


				LoadArena();
			}
		}


	
	
	}
}