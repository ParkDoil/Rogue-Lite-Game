using UnityEngine;

[CreateAssetMenu(fileName ="CharacterStatus", menuName ="ScriptableObject/CharacterStatus", order = int.MaxValue)]
public class CharacterStatus : ScriptableObject
{
    [SerializeField] // 스피드
    private float _speed;
    public float Speed { get { return _speed; } }

    [SerializeField] // 공격력
    private float _attackDamage;
    public float AttackDamage { get { return _attackDamage; } }

    [SerializeField] // 체력
    private int _hp;
    public int HP { get { return _hp; } }
}
