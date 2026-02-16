using RPGCharacterManager.Models;
using System;
using System.Collections.ObjectModel;

namespace RPGCharacterManager.Services
{
    public class CharacterService
    {
        private ObservableCollection<Character> _characters;

        // Assets for randomization
        private static readonly string[] _availableSprites = {
            "pack://application:,,,/Assets/Characters/hero1.png",
            "pack://application:,,,/Assets/Characters/hero2.png"
        };
        private static readonly Random _random = new Random();

        public CharacterService()
        {
            _characters = new ObservableCollection<Character>
            {
                new Character {
                    Name = "Aragorn",
                    Class = "Ranger",
                    Level = 10,
                    Strength = 18,
                    Intelligence = 12,
                    SpritePath = _availableSprites[0]
                },
                new Character {
                    Name = "Gandalf",
                    Class = "Wizard",
                    Level = 20,
                    Strength = 10,
                    Intelligence = 20,
                    SpritePath = _availableSprites[1]
                }
            };
        }

        public ObservableCollection<Character> GetCharacters() => _characters;

        // Unified AddCharacter method with randomization logic
        public void AddCharacter(Character character)
        {
            if (string.IsNullOrEmpty(character.SpritePath))
            {
                character.SpritePath = _availableSprites[_random.Next(_availableSprites.Length)];
            }
            _characters.Add(character);
        }

        public void DeleteCharacter(Character character) => _characters.Remove(character);

        public void UpdateCharacter(Character original, Character updated)
        {
            int index = _characters.IndexOf(original);
            if (index != -1)
            {
                _characters[index].Name = updated.Name;
                _characters[index].Class = updated.Class;
                _characters[index].Level = updated.Level;
                _characters[index].Strength = updated.Strength;
                _characters[index].Intelligence = updated.Intelligence;
                _characters[index].SpritePath = updated.SpritePath;

                // Sync the 6 equipment slots
                for (int i = 0; i < 6; i++)
                {
                    _characters[index].Equipment[i] = updated.Equipment[i];
                }
            }
        }
    }
}
