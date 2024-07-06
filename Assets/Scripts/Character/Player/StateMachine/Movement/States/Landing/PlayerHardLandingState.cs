using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerHardLandingState : PlayerLandingState
    {
        public PlayerHardLandingState(PlayerMovementStateMachine playermovementstateMachine) : base(playermovementstateMachine)
        {
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            stateMachine.Player.Input.PlayerActions.Movement.Disable();

            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            ResetVelocity();
        }

        public override void Exit()
        {
            base.Exit();

            stateMachine.Player.Input.PlayerActions.Movement.Enable();
        }

        public override void OnAnimationExitEvent()
        {
            stateMachine.Player.Input.PlayerActions.Movement.Enable();
        }

        public override void OnAnimationTransitionEvent()
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }
        #endregion

        #region Resuable Methods

        protected override void AddInputActionsCallBacks()
        {
            base.AddInputActionsCallBacks();

            stateMachine.Player.Input.PlayerActions.Movement.started += OnMovementStarted;
        }

        protected override void RemoveInputActionsCallBacks()
        {
            base.RemoveInputActionsCallBacks();

            stateMachine.Player.Input.PlayerActions.Movement.started -= OnMovementStarted;
        }

        protected override void OnMove()
        {
            if (stateMachine.ReusableData.ShouldWalk)
            {
                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }
        #endregion

        #region Input Methods
        protected override void OnJumpStarted(InputAction.CallbackContext context)
        {
        }

        private void OnMovementStarted(InputAction.CallbackContext context)
        {
            OnMove();
        }
        #endregion
    }
}
