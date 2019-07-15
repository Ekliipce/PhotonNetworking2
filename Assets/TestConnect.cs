using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestConnect : MonoBehaviourPunCallbacks
{

    private void Start()
    {
        Debug.Log("Connecting to Photon...", this);
        AuthenticationValues authValues = new AuthenticationValues("0");
        PhotonNetwork.AuthValues = authValues;
        PhotonNetwork.SendRate = 20; //20.
        PhotonNetwork.SerializationRate = 5; //10.
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon.", this);
        Debug.Log("My nickname is " + PhotonNetwork.LocalPlayer.NickName, this);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Failed to connect to Photon: " + cause.ToString(), this);
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby");
        PhotonNetwork.FindFriends(new string[] { "1" });
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        base.OnFriendListUpdate(friendList);

        foreach (FriendInfo info in friendList)
        {
            Debug.Log("Friend info received " + info.UserId + " is online? " + info.IsOnline);
        }
    }
}
