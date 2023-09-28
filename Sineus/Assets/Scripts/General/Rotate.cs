using UnityEngine;

namespace SpaceShooter
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private Vector3 _directionRotate; //���������� ��������.

        [SerializeField] private float _speed; //�������� ��������.

        [SerializeField] private Transform _target; //������ ��������.

        void Update()
        {
            _target.Rotate(_directionRotate * _speed * Time.deltaTime);
        }
    }
}
