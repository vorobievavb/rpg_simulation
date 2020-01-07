namespace rpg_simulation
{
    public abstract class GameClass
    {
        public string attackLine;
        protected Character character, enemy;

        protected GameClass(Character characterIn, Character enemyIn) 
        {
            character = characterIn;
            enemy = enemyIn;
        }
    }
}
