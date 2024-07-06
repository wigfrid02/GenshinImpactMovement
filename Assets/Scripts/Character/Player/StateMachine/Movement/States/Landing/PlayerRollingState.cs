using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerRollingState : PlayerLandingState
    {
        private PlayerRollData rollData;
        public PlayerRollingState(PlayerMovementStateMachine playermovementstateMachine) : base(playermovementstateMachine)
        {
            rollData = movementData.RollData;
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementSpeedModifier = rollData.SpeedModifier;

            stateMachine.ReusableData.ShouldSprint = false;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (stateMachine.ReusableData.MovementInput != Vector2.zero)
            {
                return;
            }

            RotateTowardsTargetRotation();
        }

        public override void OnAnimationTransitionEvent()
        {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.MediumStoppingState);

                return;
            }

            OnMove();
        }
        #endregion

        #region Input Methods
        protected override void OnJumpStarted(InputAction.CallbackContext context)
        {
        }
        #endregion
    }
}