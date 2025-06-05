using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunController : MonoBehaviour
{
    public AudioSource gunAudio;

    public XRBaseController leftController;
    public XRBaseController rightController;

    [SerializeField]
    private GameObject m_bulletPrefab = null;

    [SerializeField]
    private Transform m_muzzlePos = null;

    public void Activate()
    {
        ShootAmmo();
        TriggerHaptic();
    }

    private void ShootAmmo()
    {
        if (m_bulletPrefab == null || m_muzzlePos == null)
        {
            Debug.Log("Inspector の設定が間違ってる");
            return;
        }

        GameObject bulletObj = Instantiate(m_bulletPrefab);
        bulletObj.transform.position = m_muzzlePos.position;
        bulletObj.transform.rotation = m_muzzlePos.rotation;

        if (gunAudio != null)
        {
            gunAudio.Play();
        }
    }

    private void TriggerHaptic()
    {
        if (leftController != null)
        {
            leftController.SendHapticImpulse(0.7f, 0.2f);
        }

        if (rightController != null)
        {
            rightController.SendHapticImpulse(0.7f, 0.2f);
        }
    }
}
