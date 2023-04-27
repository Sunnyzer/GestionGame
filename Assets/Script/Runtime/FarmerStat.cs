using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FarmerStat
{
    [SerializeField] float speedMultiplicateur = 1.0f;
    [SerializeField] float productionMultiplicateur = 1.0f;
    public float SpeedMultiplicateur => speedMultiplicateur;
    public float ProductionMultiplicateur => productionMultiplicateur;
}
