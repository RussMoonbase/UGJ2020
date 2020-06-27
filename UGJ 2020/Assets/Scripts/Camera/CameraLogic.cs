using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLogic : MonoBehaviour
{
   public string playerTag;

   public CinemachineBrain cineBrain; // loaded in Inspector
   public CinemachineVirtualCamera virtualCam;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void UpdateVirtualCamFollow(Transform target)
   {
      virtualCam.Follow = target;
   }
}
