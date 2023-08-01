using Infrastructure.Constants;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure.Logic.EndGame
{
    public class EndGameWhenCollidedGround : EndGameBase
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (CollisionIsGround(collision) && !_usedBefore)
            {
                _usedBefore = true;
                EndGame();
            }
        }
        
        private static bool CollisionIsGround(Collision2D collision) =>
            collision.transform.tag == Tags.GROUND_TAG;
    }
}