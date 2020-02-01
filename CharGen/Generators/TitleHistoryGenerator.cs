﻿using CharGen.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Generators
{
    public class TitleHistoryGenerator : IGenerator<TitleHistory>
    {
        public List<TitleHistory> Items { get; private set; }

        private Random _random;
        private Config _config;

        public TitleHistoryGenerator(Config config)
        {
            Items = new List<TitleHistory>();
            _random = new Random();

            _config = config;
        }

        public void Generate()
        {
            // If there are no characters, there are no title histories either.
            if (_config.Characters.Count == 0) return;

            // Calculate when the first character will succeed and create history for him.
            var firstCharacter = _config.Characters.First();
            var minimumYear = firstCharacter.BirthDate;
            var maximumYear = _config.MaximumSuccessionYear;
            var year = new Range(minimumYear, maximumYear).Random;

            var firstHistory = new TitleHistory(year.ToString())
            {
                Holder = firstCharacter
            };
            Items.Add(firstHistory);

            // Make sure that there are still characters remaining to write.
            if (_config.Characters.Count == 1) return; 

            // Generate the title histories for the other characters.
            var previousHolder = firstCharacter;
            for (int i = 1; i < _config.Characters.Count; i++)
            {
                // Get the character. If the death date of the character is before the death
                // date of the previous holder, no history entry is needed as he will not succeed.
                var character = _config.Characters[i];
                if (character.DeathDate < previousHolder.DeathDate) continue;

                // Add a history entry to the list.
                var history = new TitleHistory(previousHolder.DeathDate.ToString())
                {
                    Holder = character
                };
                Items.Add(history);

                // Set the previous holder to the current one.
                previousHolder = character;
            }
        }

        public void Write(string fileName)
        {
            var builder = new StringBuilder();
            builder.Append("# This file was generated by CharGen.exe, written by Rick Visser. All characters are fictional and randomly generated.");
            foreach (var history in Items)
            {
                builder.Append("\n" + history.ToParadoxSyntax());
            }
            File.WriteAllText(fileName, builder.ToString());
        }

        public class Config
        {
            public List<Character> Characters { get; set; }

            public int MaximumSuccessionYear { get; set; }
        }
    }
}