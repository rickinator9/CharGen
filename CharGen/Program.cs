using CharGen.Generators;
using CharGen.Loaders;
using CharGen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Execute the program, but catch any exceptions to display messages to the user.
            try
            {
                Execute();
            }
            catch (CharGenException cge)
            {
                Console.WriteLine("ERROR: " + cge.Message);
                Console.ReadLine();
            }
            catch (Exception e) {
                Console.WriteLine(@"UNEXPECTED ERROR: Please report the error below to rickinator9 in the Diadochi Kings Discord server (https://discord.gg/sm2HHad).\n");
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                Console.ReadLine();
            }
        }

        private static void Execute()
        {
            // Set up the configuration and generator.
            Config config = null;
            try
            {
                var configJson = File.ReadAllText("config.json");
                config = JsonConvert.DeserializeObject<Config>(configJson);
            }
            catch (FileNotFoundException) { throw new CharGenException("config.json could not be found. Please restart the program with this file present."); }
            catch (JsonReaderException jrex)
            {
                bool isPathError = jrex.Message.Contains("ckii_folder_path") || jrex.Message.Contains("mod_folder_path");

                if (isPathError) throw new CharGenException("config.json was not readable due to a malformed path. Please make sure to escape the paths by using \\\\ instead of a single \\.");
                throw new CharGenException("config.json was not readable due to \"" + jrex.Message + "\".");
            }

            // Parse the cultures.
            var cultureLoader = new CultureLoader();
            cultureLoader.Load(cultureLoader.GetDirectory(config.ModPath));
            var culture = cultureLoader[config.Culture];

            // Make sure that the culture was correct.
            if (culture == null) throw new CharGenException("Culture \'" + config.Culture + "\' was not found. Did you make a typo?");

            var dynastyLoader = new DynastyLoader();
            dynastyLoader.Load(dynastyLoader.GetDirectory(config.ModPath));
            var dynasty = dynastyLoader[config.DynastyId.ToString()];

            // Generate some characters.
            var characterGenerator = new CharacterGenerator(new CharacterGenerator.Config() {
                Culture = culture,
                Dynasty = dynasty,
                Year = new Range(config.MinimumYear, config.MaximumYear),
                FertileAge = new Range(config.MinimumFertileAge, config.MaximumFertileAge),
                Age = new Range(config.MinimumAge, config.MaximumAge),
                FirstCharId = config.FirstCharId.ToString(),
                ReligionId = config.Religion
            });
            characterGenerator.Generate();

            // Write the characters to a file.
            var filename = dynasty.Culture.ToLower() + "_" + dynasty.Id + "_" + dynasty.Name.ToLower() + ".txt";
            characterGenerator.Write(filename);

            // Generate title history.
            var titleHistoryGenerator = new TitleHistoryGenerator(new TitleHistoryGenerator.Config()
            {
                MaximumSuccessionYear = config.MaximumSuccessionYear,
                Characters = characterGenerator.Items
            });
            titleHistoryGenerator.Generate();
            titleHistoryGenerator.Write("titles.txt");
        }
    }
}
