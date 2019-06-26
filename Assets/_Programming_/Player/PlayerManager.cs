using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager {

    //please use this instead of assigning player scripts in the editor
    //that causes problems with prefabs
    //these values should be set in PlayerManagerSetup

    public static GameObject player;
    public static Camera camera;

    public static PlayerController playerController;
    public static CamMouseLook camMouseLook;
    public static PlayerAnimations playerAnimations;

    public static Vector3 respawnPoint;
}
