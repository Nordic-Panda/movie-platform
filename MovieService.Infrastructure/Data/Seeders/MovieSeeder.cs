using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
using MovieService.Domain.Money;
using MovieService.Domain.Movie.Details;
using MovieService.Domain.Movies;

namespace MovieService.Infrastructure.Data.Seeders
{
    public static class MovieSeeder
    {
        public static async Task SeedMovies(AppDbContext db)
        {
            if (await db.Movies.AnyAsync())
                return;

            var genres = await db.Genres.ToDictionaryAsync(g => g.Name);

            if (genres.Count == 0)
            {
                throw new InvalidOperationException(
                    "Cannot seed movies because no genres exist. Seed genres first."
                );
            }

            var action = genres["Action"];
            var adventure = genres["Adventure"];
            var animation = genres["Animation"];
            var comedy = genres["Comedy"];
            var crime = genres["Crime"];
            var drama = genres["Drama"];
            var horror = genres["Horror"];
            var romance = genres["Romance"];
            var scienceFiction = genres["Science Fiction"];
            var thriller = genres["Thriller"];

            var movies = new[]
            {
                // =========================================================
                // ACTION - 6
                // =========================================================

                Movie(
                    "Iron Divide",
                    128,
                    2024,
                    new[] { action, thriller },
                    "English",
                    "A former special forces operative is forced back into action when a heavily protected convoy carrying classified technology is attacked. As the mission unfolds, he discovers that the people behind the attack are connected to his own past.",
                    95_000_000m,
                    "USD"
                ),
                Movie(
                    "Black Horizon",
                    117,
                    2023,
                    new[] { action, scienceFiction },
                    "English",
                    "After a spacecraft crashes in a remote desert, a military rescue team discovers technology that could change the balance of power between nations. They must protect it while escaping forces determined to claim it first.",
                    120_000_000m,
                    "USD"
                ),
                Movie(
                    "The Last Run",
                    109,
                    2022,
                    new[] { action, crime, thriller },
                    "English",
                    "A retired getaway driver is given one final job after his brother disappears. What begins as a simple extraction quickly becomes a dangerous race through the city's criminal underworld.",
                    58_000_000m,
                    "USD"
                ),
                Movie(
                    "Redline",
                    103,
                    2021,
                    new[] { action, crime },
                    "English",
                    "A street racer becomes an unwilling courier after witnessing a violent robbery. With both the police and criminals searching for him, he has only one night to deliver the evidence that could expose an entire organization.",
                    42_000_000m,
                    "USD"
                ),
                Movie(
                    "Storm Command",
                    134,
                    2020,
                    new[] { action, adventure },
                    "English",
                    "When a powerful storm destroys communications across the Pacific, a rescue commander leads a small team into dangerous waters to locate a missing research vessel before it disappears forever.",
                    110_000_000m,
                    "USD"
                ),
                Movie(
                    "Final Strike",
                    121,
                    2019,
                    new[] { action, thriller, drama },
                    "English",
                    "An intelligence officer uncovers a planned attack that has been hidden inside a decades-old operation. With only a few hours remaining, she must decide who she can trust before the final strike begins.",
                    88_000_000m,
                    "USD"
                ),
                // =========================================================
                // ADVENTURE - 6
                // =========================================================

                Movie(
                    "Beyond the Map",
                    126,
                    2024,
                    new[] { adventure, drama },
                    "English",
                    "A young cartographer discovers a forgotten map describing an unexplored valley hidden beyond the world's most dangerous mountain range. She joins an expedition that soon realizes the map contains more secrets than expected.",
                    72_000_000m,
                    "USD"
                ),
                Movie(
                    "The Lost Kingdom",
                    138,
                    2022,
                    new[] { adventure, action },
                    "English",
                    "An archaeologist and a former soldier travel deep into the jungle searching for a legendary kingdom believed to have disappeared centuries ago. Their discovery attracts a rival expedition willing to destroy everything to reach it first.",
                    105_000_000m,
                    "USD"
                ),
                Movie(
                    "Ocean's Edge",
                    114,
                    2021,
                    new[] { adventure, thriller },
                    "English",
                    "A marine biologist joins a private expedition to investigate a mysterious signal coming from the deepest part of the ocean. The team soon discovers something that was never meant to be found.",
                    80_000_000m,
                    "USD"
                ),
                Movie(
                    "Desert Crown",
                    119,
                    2020,
                    new[] { adventure, romance, drama },
                    "English",
                    "Two explorers searching for an ancient crown become stranded in the desert after their expedition is sabotaged. As they struggle to survive, their rivalry slowly turns into something neither expected.",
                    55_000_000m,
                    "USD"
                ),
                Movie(
                    "The Northern Passage",
                    132,
                    2019,
                    new[] { adventure, drama },
                    "Swedish",
                    "A group of researchers attempts to cross a remote Arctic passage before winter closes the route. When their equipment fails, they must rely on one another to survive the harsh landscape.",
                    48_000_000m,
                    "USD"
                ),
                Movie(
                    "Island of Ash",
                    111,
                    2018,
                    new[] { adventure, horror, thriller },
                    "English",
                    "A group of students travels to a volcanic island to document its unusual wildlife. After an unexpected eruption cuts them off from the outside world, they discover that something else is living beneath the island.",
                    38_000_000m,
                    "USD"
                ),
                // =========================================================
                // ANIMATION - 6
                // =========================================================

                Movie(
                    "The Little Fox",
                    89,
                    2023,
                    new[] { animation, adventure },
                    "English",
                    "A young fox leaves the safety of his forest home after hearing stories about a distant city. Along the journey he meets unusual friends who teach him that courage does not always mean being fearless.",
                    45_000_000m,
                    "USD"
                ),
                Movie(
                    "Cloud Kingdom",
                    96,
                    2022,
                    new[] { animation, adventure, comedy },
                    "English",
                    "A curious girl discovers a hidden kingdom floating above the clouds. With the help of a nervous dragon and an overly confident inventor, she must stop the kingdom from falling back to Earth.",
                    70_000_000m,
                    "USD"
                ),
                Movie(
                    "Moonlight Mouse",
                    84,
                    2021,
                    new[] { animation, comedy, romance },
                    "English",
                    "A small mouse living inside an old theatre dreams of becoming a musician. When the theatre is threatened with closure, he discovers that even the smallest performer can bring an entire community together.",
                    32_000_000m,
                    "USD"
                ),
                Movie(
                    "Robot's Day Off",
                    91,
                    2020,
                    new[] { animation, comedy, scienceFiction },
                    "English",
                    "A household robot secretly takes a day away from its owners to discover what life outside its programming looks like. What follows is an unexpected journey through a city full of machines and humans.",
                    62_000_000m,
                    "USD"
                ),
                Movie(
                    "The Paper Dragon",
                    102,
                    2019,
                    new[] { animation, drama, adventure },
                    "English",
                    "A lonely child discovers that drawings in an old notebook can come to life. Together with a paper dragon, she sets out to repair a magical world that is slowly disappearing.",
                    52_000_000m,
                    "USD"
                ),
                Movie(
                    "Stars Above Us",
                    88,
                    2018,
                    new[] { animation, scienceFiction, drama },
                    "English",
                    "Two children living on a distant space station discover a forgotten message from Earth. Their attempt to answer it takes them on a journey that changes how their entire community sees the universe.",
                    58_000_000m,
                    "USD"
                ),
                // =========================================================
                // COMEDY - 6
                // =========================================================

                Movie(
                    "Laughing Matters",
                    97,
                    2024,
                    new[] { comedy, drama },
                    "English",
                    "A struggling comedian gets one unexpected opportunity to perform at the city's biggest comedy festival. Unfortunately, everything that can go wrong during the week seems determined to happen at exactly the wrong time.",
                    18_000_000m,
                    "USD"
                ),
                Movie(
                    "Wrong Address",
                    94,
                    2023,
                    new[] { comedy, romance },
                    "English",
                    "After a delivery driver accidentally brings a package to the wrong apartment, he meets the person living there and becomes involved in a series of increasingly ridiculous misunderstandings.",
                    14_000_000m,
                    "USD"
                ),
                Movie(
                    "The Weekend Plan",
                    101,
                    2022,
                    new[] { comedy, romance },
                    "English",
                    "Three friends plan a quiet weekend at a countryside house, but an unexpected wedding, a missing car and a very confused neighbor turn their relaxing trip into complete chaos.",
                    20_000_000m,
                    "USD"
                ),
                Movie(
                    "Office Escape",
                    106,
                    2021,
                    new[] { comedy },
                    "English",
                    "A group of employees decides to finally stand up to their impossible boss. Their carefully planned protest quickly turns into a ridiculous office adventure involving secret meetings and accidental sabotage.",
                    16_000_000m,
                    "USD"
                ),
                Movie(
                    "Almost Famous",
                    112,
                    2020,
                    new[] { comedy, drama },
                    "English",
                    "A small-town musician accidentally becomes an internet celebrity overnight. While trying to understand his sudden fame, he discovers that being famous is much more complicated than he imagined.",
                    24_000_000m,
                    "USD"
                ),
                Movie(
                    "Dinner for Eight",
                    99,
                    2019,
                    new[] { comedy, romance },
                    "French",
                    "Eight strangers arrive at the same restaurant expecting completely different dinners. A series of misunderstandings brings their stories together and turns an ordinary evening into an unforgettable night.",
                    12_000_000m,
                    "EUR"
                ),
                // =========================================================
                // CRIME - 6
                // =========================================================

                Movie(
                    "City of Thieves",
                    119,
                    2024,
                    new[] { crime, action, drama },
                    "English",
                    "Two rival thieves are forced to work together after a carefully planned robbery goes wrong. Their uneasy partnership becomes even more dangerous when they realize one of them has been betrayed.",
                    60_000_000m,
                    "USD"
                ),
                Movie(
                    "The Silent Witness",
                    108,
                    2023,
                    new[] { crime, thriller, drama },
                    "English",
                    "A witness to a high-profile murder refuses to speak to the police. A determined detective slowly discovers why the witness is silent and uncovers a conspiracy reaching far beyond the original crime.",
                    35_000_000m,
                    "USD"
                ),
                Movie(
                    "Cold Evidence",
                    115,
                    2022,
                    new[] { crime, thriller },
                    "English",
                    "A forensic investigator finds a piece of evidence that contradicts every conclusion from a decade-old case. Reopening the investigation puts her career and her life at risk.",
                    40_000_000m,
                    "USD"
                ),
                Movie(
                    "The Last Heist",
                    124,
                    2021,
                    new[] { crime, action, thriller },
                    "English",
                    "A professional thief assembles one final crew for the largest robbery of his career. As the plan unfolds, it becomes clear that someone inside the group has a completely different agenda.",
                    68_000_000m,
                    "USD"
                ),
                Movie(
                    "Under the Bridge",
                    102,
                    2020,
                    new[] { crime, drama },
                    "Swedish",
                    "A detective investigating a disappearance discovers a connection to a series of unsolved crimes from the previous decade. The deeper she looks, the more the city's secrets begin to surface.",
                    22_000_000m,
                    "USD"
                ),
                Movie(
                    "Broken Deal",
                    110,
                    2019,
                    new[] { crime, romance, drama },
                    "English",
                    "A financial criminal plans to disappear after completing one final deal, but his former partner returns with information that threatens everything he has built.",
                    31_000_000m,
                    "USD"
                ),
                // =========================================================
                // DRAMA - 6
                // =========================================================

                Movie(
                    "The Forgotten Letter",
                    104,
                    2024,
                    new[] { drama, romance },
                    "English",
                    "An unexpected letter arrives decades after it was written, bringing two families together and forcing them to confront a secret that has shaped their lives for generations.",
                    25_000_000m,
                    "USD"
                ),
                Movie(
                    "Broken Roads",
                    116,
                    2023,
                    new[] { drama, crime },
                    "English",
                    "A former criminal returns home after years away and tries to rebuild his relationship with his family. His past, however, refuses to stay buried for long.",
                    30_000_000m,
                    "USD"
                ),
                Movie(
                    "Winter Silence",
                    123,
                    2022,
                    new[] { drama },
                    "Swedish",
                    "A woman returns to her childhood village after many years away to settle her father's estate. The visit forces her to confront memories and relationships she thought she had left behind.",
                    18_000_000m,
                    "USD"
                ),
                Movie(
                    "The Long Way Home",
                    118,
                    2021,
                    new[] { drama, adventure },
                    "English",
                    "After losing his job and his home, a middle-aged teacher begins a journey across the country to reconnect with the daughter he has not seen in years.",
                    21_000_000m,
                    "USD"
                ),
                Movie(
                    "A Second Chance",
                    107,
                    2020,
                    new[] { drama, romance },
                    "English",
                    "Two former classmates meet again after twenty years. Both have changed, but neither has completely forgotten the choices that separated them in the first place.",
                    17_000_000m,
                    "USD"
                ),
                Movie(
                    "The Last Photograph",
                    129,
                    2019,
                    new[] { drama, thriller },
                    "English",
                    "A photographer discovers a mysterious image among her late father's belongings. Investigating its origin leads her into a story that her family spent decades trying to hide.",
                    27_000_000m,
                    "USD"
                ),
                // =========================================================
                // HORROR - 6
                // =========================================================

                Movie(
                    "Shadow House",
                    109,
                    2024,
                    new[] { horror, thriller },
                    "English",
                    "A family moves into an abandoned house hoping to start a new life. Strange sounds and unexplained events soon convince them that something in the house remembers the people who lived there before.",
                    22_000_000m,
                    "USD"
                ),
                Movie(
                    "The Empty Room",
                    101,
                    2023,
                    new[] { horror, drama },
                    "English",
                    "A hotel manager discovers that one room has appeared on the building's original plans but does not exist in the actual hotel. Guests who claim to have entered it never return the same.",
                    19_000_000m,
                    "USD"
                ),
                Movie(
                    "Whisper Lake",
                    113,
                    2022,
                    new[] { horror, drama },
                    "English",
                    "A group of friends returns to a remote lake where one of their friends disappeared years earlier. On their first night, they begin hearing his voice coming from the water.",
                    24_000_000m,
                    "USD"
                ),
                Movie(
                    "Night Harvest",
                    106,
                    2021,
                    new[] { horror, thriller },
                    "English",
                    "A farming community celebrates its annual harvest festival while a series of disappearances begins to attract the attention of a local journalist.",
                    28_000_000m,
                    "USD"
                ),
                Movie(
                    "The Old Hospital",
                    118,
                    2020,
                    new[] { horror, thriller },
                    "English",
                    "Five urban explorers enter an abandoned hospital searching for footage that could make them famous. They soon discover that the building is not as empty as everyone believed.",
                    34_000_000m,
                    "USD"
                ),
                Movie(
                    "Crimson Night",
                    111,
                    2019,
                    new[] { horror, adventure, thriller },
                    "English",
                    "A scientific expedition arrives on a remote volcanic island to study unusual seismic activity. When the volcano begins to awaken, the team discovers something far more dangerous beneath the surface.",
                    38_000_000m,
                    "USD"
                ),
                // =========================================================
                // ROMANCE - 6
                // =========================================================

                Movie(
                    "Summer in Paris",
                    101,
                    2024,
                    new[] { romance, comedy },
                    "French",
                    "Two strangers meet during a summer trip through Paris and agree to spend one evening together. Neither expects the short encounter to change the direction of their lives.",
                    15_000_000m,
                    "EUR"
                ),
                Movie(
                    "Sands of Promise",
                    119,
                    2023,
                    new[] { romance, adventure, drama },
                    "English",
                    "Two explorers searching for an ancient treasure become stranded together in the desert. As they struggle to survive, their professional rivalry slowly becomes something more personal.",
                    55_000_000m,
                    "USD"
                ),
                Movie(
                    "Echoes of Love",
                    104,
                    2022,
                    new[] { romance, drama },
                    "English",
                    "A letter written many years ago brings two people together and reveals a love story that was interrupted by circumstances neither of them could control.",
                    25_000_000m,
                    "USD"
                ),
                Movie(
                    "Accidental Hearts",
                    94,
                    2021,
                    new[] { romance, comedy },
                    "English",
                    "A package delivered to the wrong apartment introduces two strangers who could not be more different. What begins as an awkward misunderstanding gradually becomes an unexpected relationship.",
                    14_000_000m,
                    "USD"
                ),
                Movie(
                    "When We Meet Again",
                    107,
                    2020,
                    new[] { romance, drama },
                    "English",
                    "Two former classmates meet again after twenty years and discover that their feelings from the past never completely disappeared.",
                    17_000_000m,
                    "USD"
                ),
                Movie(
                    "Letters from Rome",
                    113,
                    2019,
                    new[] { romance, drama },
                    "Italian",
                    "A writer travels to Rome to finish a novel and unexpectedly meets someone who inspires her to reconsider the story she has been trying to tell.",
                    19_000_000m,
                    "EUR"
                ),
                // =========================================================
                // SCIENCE FICTION - 6
                // =========================================================

                Movie(
                    "Beyond the Stars",
                    141,
                    2024,
                    new[] { scienceFiction, drama },
                    "English",
                    "Humanity sends its first generation ship toward a distant habitable planet. Decades into the journey, the passengers discover that the mission's original purpose was not what they were told.",
                    210_000_000m,
                    "USD"
                ),
                Movie(
                    "Final Protocol",
                    133,
                    2023,
                    new[] { scienceFiction, action, thriller },
                    "English",
                    "A security engineer discovers a hidden protocol capable of controlling every connected system on Earth. Powerful organizations immediately begin competing to control the technology.",
                    130_000_000m,
                    "USD"
                ),
                Movie(
                    "Dark Frontier",
                    117,
                    2022,
                    new[] { scienceFiction, action },
                    "English",
                    "After a spacecraft crashes in a remote desert, scientists discover technology that appears to have been designed by an unknown civilization.",
                    120_000_000m,
                    "USD"
                ),
                Movie(
                    "Beyond the Circuit",
                    91,
                    2021,
                    new[] { scienceFiction, animation, comedy },
                    "English",
                    "A household robot secretly leaves its owner's home for one day to discover what life is like outside its programming.",
                    62_000_000m,
                    "USD"
                ),
                Movie(
                    "Signals from Orion",
                    88,
                    2020,
                    new[] { scienceFiction, animation, drama },
                    "English",
                    "Two children living on a distant space station discover an ancient message from Earth and decide to answer it despite the enormous risks.",
                    58_000_000m,
                    "USD"
                ),
                Movie(
                    "The Silent Planet",
                    127,
                    2019,
                    new[] { scienceFiction, thriller, adventure },
                    "English",
                    "A research team lands on a seemingly lifeless planet and discovers that every previous expedition disappeared without leaving a trace.",
                    145_000_000m,
                    "USD"
                ),
                // =========================================================
                // THRILLER - 6
                // =========================================================

                Movie(
                    "Silent Justice",
                    108,
                    2024,
                    new[] { thriller, crime, drama },
                    "English",
                    "A witness to a high-profile murder refuses to speak to investigators. A detective slowly uncovers the reason for the silence and discovers a conspiracy much larger than the original crime.",
                    35_000_000m,
                    "USD"
                ),
                Movie(
                    "Frozen Clues",
                    115,
                    2023,
                    new[] { thriller, crime },
                    "English",
                    "A forensic investigator discovers evidence that contradicts every conclusion from a decade-old case. Reopening the investigation puts her career and her life in danger.",
                    40_000_000m,
                    "USD"
                ),
                Movie(
                    "Final Escape",
                    109,
                    2022,
                    new[] { thriller, action, crime },
                    "English",
                    "A retired getaway driver accepts one final job to rescue his missing brother. The mission quickly turns into a race against the city's most dangerous criminals.",
                    58_000_000m,
                    "USD"
                ),
                Movie(
                    "Countdown Protocol",
                    121,
                    2021,
                    new[] { thriller, action, drama },
                    "English",
                    "An intelligence officer discovers that a planned attack is connected to a secret operation from decades earlier. With only hours remaining, she must determine who can be trusted.",
                    88_000_000m,
                    "USD"
                ),
                Movie(
                    "The Hidden Image",
                    129,
                    2020,
                    new[] { thriller, drama },
                    "English",
                    "A photographer finds a mysterious image among her late father's possessions and begins investigating its origin, uncovering a secret that her family has protected for decades.",
                    27_000_000m,
                    "USD"
                ),
                Movie(
                    "The Forgotten World",
                    127,
                    2019,
                    new[] { thriller, scienceFiction, adventure },
                    "English",
                    "A research team lands on an apparently lifeless planet where every previous expedition has disappeared. As night approaches, they realize they may not be the first visitors.",
                    145_000_000m,
                    "USD"
                ),
            };

            db.Movies.AddRange(movies);

            await db.SaveChangesAsync();
        }

        private static Movie Movie(
            string title,
            int durationMinutes,
            int year,
            IEnumerable<Genre> genres,
            Language language,
            string synopsis,
            decimal budget,
            string currency
        )
        {
            var details = MovieDetailFactory.Create(
                synopsis,
                MoneyFactory.Create(budget, currency)
            );

            return MovieFactory.Create(
                title,
                year,
                TimeSpan.FromMinutes(durationMinutes),
                genres.ToArray(),
                details,
                language
            );
        }
    }
}
