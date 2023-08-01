using Infrastructure.Constants;
using UnityEngine;

namespace Infrastructure.Logic.EndGame
{
    public class EndGameIfCarTriggered : EndGameBase
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (ColliderIsCar(collider) && !_usedBefore)
            {
                _usedBefore = true;
                EndGame();
            }
        }

        private static bool ColliderIsCar(Collider2D collision) =>
            collision.transform.tag == Tags.CAR;
    }
}