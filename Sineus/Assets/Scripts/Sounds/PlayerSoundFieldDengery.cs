using UnityEngine;
using Zenject;

public class PlayerSoundFieldDengery : MonoBehaviour
{
    [SerializeField] private AudioClip _clipPlayerFieldDanger;

    [SerializeField] private float distSoundFieldDanger;

    [SerializeField] private KillZoneController m_controllerKillZone;

    private MarkToFinishPoint m_markToFinishPoint;

    private KillZone _killZone;

    [SerializeField] private AudioSource _soundPlayer;

    [Inject]
    public void Construct(KillZone killZone, MarkToFinishPoint markToFinish)
    {
        _killZone = killZone;
        m_markToFinishPoint = markToFinish;
    }

    private void Update()
    {
        OnSoundPlay();
    }

    private void OnSoundPlay()
    {
        m_controllerKillZone.GetKillZone();

        if (m_controllerKillZone != null)
        {
            var colliderMesh = _killZone.GetComponent<CapsuleCollider>();

            var zeroPoint = m_markToFinishPoint.transform.position;
            var distRadius = Vector3.Distance(_killZone.radiusPoint.transform.position, zeroPoint);

            if (Vector3.Distance(transform.position, zeroPoint) > distRadius - distSoundFieldDanger)
            {
                _soundPlayer.PlayOneShot(_clipPlayerFieldDanger);
                _soundPlayer.volume = Vector3.Distance(transform.position, zeroPoint) + distSoundFieldDanger - distRadius;
            }
            else
            {
                _soundPlayer.Stop();
            }
        }
    }
}
