namespace rpg_simulation
{
    public abstract class GameClass
    {
        public string attackLine;
        protected Character character, enemy;
        public bool HasDodged;
        public bool HasParried;
        public bool isFirstEverAttack;
        public void SetIsFirstEverAttack(bool value)
        {
            isFirstEverAttack = value;
        }
        protected GameClass(Character characterIn, Character enemyIn) 
        {
            character = characterIn;
            enemy = enemyIn;
            isFirstEverAttack = true;
        }
    }
}
