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

            if (!GetIsInRange())
            {
                Mover.MoveTo(target.position);
            }
            else
            {
                Mover.Stop();
            };
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }

}