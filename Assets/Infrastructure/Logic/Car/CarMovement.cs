using System;
using Services.Inputs;
using UnityEngine;
using Zenject;

namespace Infrastructure.Logic.Car
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _carRB;
        
        [SerializeField] private Rigidbody2D _frontWheelRB;
        [SerializeField] private Rigidbody2D _rearWheelRB;
        [SerializeField] private WheelJoint2D _frontWheelJoint;
        [SerializeField] private WheelJoint2D _rearWheelJoint;

        private float _speed;
        private float _rotationSpeed;
        private float _suspensionDamping;
        private float _carMass;
        private float _moveInput;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Initialize(float speed, float rotationSpeed, float suspensionDamping, float carMass)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _suspensionDamping = suspensionDamping;
            _carMass = carMass;

            SetCarMass();
            SetSuspensionDumping();
        }

        private void SetCarMass() =>
            _carRB.mass = _carMass;

        private void SetSuspensionDumping()
        {
            SetJointDumping(_frontWheelJoint);
            SetJointDumping(_rearWheelJoint);
        }

        private void SetJointDumping(WheelJoint2D wheelJoint)
        {
            wheelJoint.suspension = new JointSuspension2D()
            {
                angle = wheelJoint.suspension.angle,
                dampingRatio = _suspensionDamping,
                frequency = wheelJoint.suspension.frequency,
            };
        }

        private void FixedUpdate()
        {
            RotateWheels();
            RotateBody();
        }

        private void RotateWheels()
        {
            AddTorque(_frontWheelRB);
            AddTorque(_rearWheelRB);
        }

        private void AddTorque(Rigidbody2D wheel) =>
            wheel.AddTorque(-_inputService.GetAxis().x * _speed * Time.deltaTime);

        private void RotateBody() =>
            _carRB.AddTorque(_inputService.GetAxis().x * _rotationSpeed * Time.deltaTime);

        public class Factory : PlaceholderFactory<CarMovement>
        {
        }
    }
}