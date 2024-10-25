using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI ammoText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateWaveUI(int wave)
    {
        waveText.SetText("Wave: " + wave);
    }

    public void UpdateAmmoUI(int ammo)
    {
        ammoText.SetText("Ammo: " + ammo);
    }
}
