using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportByButton : MonoBehaviour
{
    public Transform teleportDestination; // テレポート先（空オブジェクト）
    public TeleportationProvider teleportationProvider; // XR Originに付いてる

    void tereport()
    {
            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = teleportDestination.position,
                destinationRotation = teleportDestination.rotation
            };

            teleportationProvider.QueueTeleportRequest(request);
    }
}
