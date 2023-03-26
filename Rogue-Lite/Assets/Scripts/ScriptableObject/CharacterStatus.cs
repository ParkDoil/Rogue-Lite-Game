using UnityEngine;

[CreateAssetMenu(fileName ="CharacterStatus", menuName ="ScriptableObject/CharacterStatus", order = int.MaxValue)]
public class CharacterStatus : ScriptableObject
{
    [SerializeField] // ���ǵ�
    private float _speed;
    public float Speed { get { return _speed; } }

    [SerializeField] // ���ݷ�
    private float _attackDamage;
    public float AttackDamage { get { return _attackDamage; } }

    [SerializeField] // ü��
    private int _hp;
    public int HP { get { return _hp; } }
}
