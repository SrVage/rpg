using Code.Extensions;
using Code.Model;
using UnityEngine;

namespace Code.Controller
{
    public class CreateEnemy
    {
        public CreateEnemy()
        {
            var skeletonWarrior = Enemy.CreateSkeleton(100, 10, new Vector3(-1087, 60, -552));
            Enemy skeleton = skeletonWarrior.DeepCopy();
            Debug.Log(skeleton);
            skeleton.transform.Translate(5, 0, 0);
            Enemy skeleton2 = skeleton.DeepCopy();
            skeleton2.transform.Translate(0, 0, -10);
        }
    }
}