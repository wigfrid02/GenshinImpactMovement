using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerLandingState : PlayerGoundedState
    {
        public PlayerLandingState(PlayerMovementStateMachine playermovementstateMachine) : base(playermovementstateMachine)
        {
        }

        #region Input Methods
        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {

        }
        #endregion
    }
}
