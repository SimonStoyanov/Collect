using System;

public interface ICharacterJob
{
    int HP();
    int MP();
    int PhysAttack();
    int MagAttack();
    int PhysDefense();
    int MagDefense();
    int Agility();
    int Luck();

    void Attack();
}
