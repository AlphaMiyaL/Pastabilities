using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
/*    private bool _isSemiShieldActive = false;
    private bool _isFullShieldActive = false;*/

    private GameObject semiShield;
    private GameObject fullShield;

    private void Start()
    {
        semiShield = GameObject.FindGameObjectWithTag("SemiShield");
        fullShield = GameObject.FindGameObjectWithTag("FullShield");
    }

    public void SemiShieldActive(bool state)
    {
        //_isSemiShieldActive = state;
        semiShield.SetActive(state);
    }

    public void FullShieldActive(bool state)
    {
        //_isFullShieldActive = state;
        fullShield.SetActive(state);
    }
}
