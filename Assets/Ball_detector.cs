using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_detector : MonoBehaviour {
    public int nb_case;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void attribuer_numero(GameObject other)
    {
        if (nb_case == 1)
        {
            other.GetComponentInParent<Ball_script>().Reset();
            other.GetComponentInParent<Ball_script>().Set_numero(int.MaxValue);
        }
        else
            other.GetComponentInParent<Ball_script>().Set_numero(nb_case);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
            attribuer_numero(other.gameObject);
    }
}
