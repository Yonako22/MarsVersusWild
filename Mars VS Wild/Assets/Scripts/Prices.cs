using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prices : MonoBehaviour
{

    public int turretAuto;
    public int turretCroix;
    public int Barricade;
    public int Infirmerie;
    public TextMeshProUGUI txtTurretAuto;
    public TextMeshProUGUI txtTurretCroix;
    public TextMeshProUGUI txtBarricade;
    public TextMeshProUGUI txtInfirmerie;

    private void Update()
    {
        txtBarricade.text = "" + Barricade;
        txtInfirmerie.text = "" + Infirmerie;
        txtTurretAuto.text = "" + turretAuto;
        txtTurretCroix.text = "" + turretCroix;
    }
}
