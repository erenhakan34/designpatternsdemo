using System;

namespace DesignPatternPlayGround.Patterns
{
    public static class MementoPattern
    {
        public static void Run()
        {
            Console.WriteLine("Memento Pattern\n-----------------");

            Game game = new Game() { Level = GameLevel.Beginner, EpisodeNumber = 1 };
            Console.WriteLine(game.ToString());

            GameCareTaker gameCareTaker = new GameCareTaker();
            gameCareTaker.GameMemento = game.Save();

            game.EpisodeNumber = 2;
            game.Level = GameLevel.Intermediate;
            Console.WriteLine(game.ToString());

            game.LoadPrevious(gameCareTaker.GameMemento);
            Console.WriteLine(game.ToString());
        }
    }

    public class Game
    {
        public GameLevel Level { get; set; }
        public int EpisodeNumber { get; set; }

        public GameMemento Save()
        {
            return new GameMemento()
            {
                Level = Level,
                EpisodeNumber = EpisodeNumber
            };
        }

        public void LoadPrevious(GameMemento gameMemento)
        {
            Level = gameMemento.Level;
            EpisodeNumber = gameMemento.EpisodeNumber;
        }

        public override string ToString()
        {
            return $"Game Information: Level = {Level}, Episode = { EpisodeNumber}";
        }
    }

    public enum GameLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public class GameMemento
    {
        public GameLevel Level { get; set; }
        public int EpisodeNumber { get; set; }
    }

    public class GameCareTaker
    {
        public GameMemento GameMemento { get; set; }
    }
}
