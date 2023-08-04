using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        private Transform target;
        private Mover Mover;

        private void Start()
        {
            Mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (target == null) return;

            bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;

            if (!isInRange)
            {
                Mover.MoveTo(target.position);
            }
            else
            {
                Mover.Stop();
            };
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }

}