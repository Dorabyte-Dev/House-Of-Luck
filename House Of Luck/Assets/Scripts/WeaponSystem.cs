using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSystem : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]private GameObject attackTest;
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        AttackControl();
    }

    void AttackControl()
    {
        if (_input.attack)
        {
            Attack();
        }
    }

    void Attack()
    {
        ToggleAttack();
        Invoke("UntoggleAttack", 0.5f);
    }

    void ToggleAttack()
    {
        attackTest.SetActive(true);
    }

    void UntoggleAttack()
    {
        attackTest.SetActive(false);
    }
}
