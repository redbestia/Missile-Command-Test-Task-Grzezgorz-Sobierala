using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class AmmoTextControler : MonoBehaviour
    {
        [SerializeField] private TextMesh textMesh;
        [SerializeField] private TurretBehaviour turretToShowAmmo;

        private void Start()
        {
            turretToShowAmmo.OnTurretShoot += UpdateAmmoText;
            textMesh.text = turretToShowAmmo.CurrentAmmo.ToString();
        }

        private void OnDestroy()
        {
            turretToShowAmmo.OnTurretShoot -= UpdateAmmoText;

        }

        void UpdateAmmoText(int currentAmmo)
        {
            textMesh.text = currentAmmo.ToString();
        }

    }
}