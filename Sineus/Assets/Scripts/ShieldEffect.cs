using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    private float _lifeTime = 100;
    private float _timer;
    private float _stopTime;
    /*
    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }*/

    private void Update()
    {
        if (_timer < _lifeTime)
        {
            _timer += Time.deltaTime;
            _stopTime = _lifeTime - _timer;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLifeTime(float time)
    {
        _lifeTime = time;
    }

    private void OnTriggerEnter(Collider other)
    {
        var killZone = other.transform.root.GetComponent<KillZone>();

        if (killZone != null)
        {
            //_collider.enabled = false;

            killZone.StopMove(_stopTime);
        }
    }
}
