using System;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    [Serializable]
    public class CapsuleColliderUtility
    {
        public CapsuleColliderData CapsuleColliderData { get; private set; }

        [field: SerializeField] public DefaultColliderData DefaultColliderData { get; private set; }

        [field: SerializeField] public SlopeData SlopeData { get; private set; }

        public void Initialize(GameObject gameObject)
        {   
            if (CapsuleColliderData != null)
            {
                return;
            }

            CapsuleColliderData = new CapsuleColliderData();

            CapsuleColliderData.Intialize(gameObject);
        }

        public void CalculateCapsuleColliderDimensions()
        {
            SetCapsuleColliderRadius(DefaultColliderData.Radius);

            SetCapsuleColliderHeight(DefaultColliderData.Height * (1f - SlopeData.StepHeightPercentage));

            RecalulateCapsuleColliderCenter();

            float halfColliderHeight = CapsuleColliderData.Collider.height / 2f;

            if (halfColliderHeight < CapsuleColliderData.Collider.radius)
            {
                SetCapsuleColliderRadius(halfColliderHeight);
            }

            CapsuleColliderData.UpdateColliderData();
        }

        private void SetCapsuleColliderRadius(float radius)
        {
            CapsuleColliderData.Collider.radius = radius;
        }

        private void SetCapsuleColliderHeight(float height)
        {
            CapsuleColliderData.Collider.height = height;
        }

        public void RecalulateCapsuleColliderCenter()
        {
            float colliderHeightDifference = DefaultColliderData.Height - CapsuleColliderData.Collider.height;

            Vector3 newColliderCenter = new Vector3(0f, DefaultColliderData.CenterY + (colliderHeightDifference / 2f), 0f);

            CapsuleColliderData.Collider.center = newColliderCenter;

        }
    }
}
