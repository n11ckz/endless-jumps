using System;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(SphereCollider))]
    public class PlatformTriggerArea : TriggerArea<Character>
    {
        public event Action CharacterEntered;

        protected override void Process(Character component) => CharacterEntered?.Invoke();
    }
}
