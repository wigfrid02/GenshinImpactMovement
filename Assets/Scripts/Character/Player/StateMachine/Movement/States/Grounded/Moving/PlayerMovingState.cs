using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerMovingState : PlayerGoundedState
    {
        public PlayerMovingState(PlayerMovementStateMachine playermovementstateMachine) : base(playermovementstateMachine)
        {
        }
    }
}
