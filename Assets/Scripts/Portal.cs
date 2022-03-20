using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Transform m_PlayerCameraTrans = null;
    [SerializeField]
    private Transform m_OtherPortalTrans = null;
    private Camera m_PortalCamera = null;
    private GameObject m_PortalCameraObj = null;

    // Start is called before the first frame update
    void Start()
    {
        if(m_PlayerCameraTrans == null)
        {
            Debug.LogError("m_PlayerCameraTrans not set");
            return;
        }

        if(m_OtherPortalTrans == null)
        {
            Debug.LogError("m_OtherPortalTrans not set");
            return;
        }
        m_PortalCameraObj = new GameObject(name + "_Camera");
        m_PortalCamera = m_PortalCameraObj.AddComponent<Camera>();
        m_PortalCamera.targetDisplay = 2;

    }

    // Update is called once per frame
    void Update()
    {
        // Set portal camera to the right position
        Vector3 vecToCamera = m_PlayerCameraTrans.position - transform.position;
        Vector3 vecRotation = m_OtherPortalTrans.rotation.eulerAngles - transform.rotation.eulerAngles;
        Vector3 rotatedVec = Quaternion.Euler(vecRotation) * vecToCamera;
        m_PortalCameraObj.transform.position = m_OtherPortalTrans.position - rotatedVec;

        // Make camera look at portal
        m_PortalCameraObj.transform.LookAt(m_OtherPortalTrans.position);

    }
}
