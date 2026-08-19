using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
using MovieService.Domain.Money;
using MovieService.Domain.Movie.Details;
using MovieService.Domain.Movies;

namespace MovieService.Infrastructure.Data.Seeders;

public static class MovieSeeder
{
    public static async Task SeedMovies(AppDbContext db)
    {
        if (await db.Movies.AnyAsync())
            return;

        var genres = await db.Genres.ToDictionaryAsync(g => g.Name);
        var languages = await db.Languages.ToDictionaryAsync(l => l.Code);

        if (genres.Count == 0)
        {
            throw new InvalidOperationException(
                "Cannot seed movies because no genres exist. Seed genres first."
            );
        }

        if (languages.Count == 0)
        {
            throw new InvalidOperationException(
                "Cannot seed movies because no languages exist. Seed languages first."
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

        var english = languages["en"];
        var chinese = languages["zh"];
        var swedish = languages["sv"];
        var danish = languages["da"];
        var japanese = languages["ja"];

        var movies = new[]
        {
            // =========================================================
            // ACTION - 6
            // =========================================================

            Movie(
                "The Dark Knight",
                152,
                2008,
                new[] { action, crime, drama, thriller },
                english,
                "Batman faces the Joker, a criminal mastermind who pushes Gotham into chaos while challenging Batman's moral limits.",
                185_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg"
            ),
            Movie(
                "Gladiator",
                155,
                2000,
                new[] { action, adventure, drama },
                english,
                "A Roman general is betrayed and forced into slavery before rising as a gladiator seeking revenge against the emperor who destroyed his family.",
                103_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/ty8TGRuvJLPUmAR1H1nRIsgwvim.jpg"
            ),
            Movie(
                "The Matrix",
                136,
                1999,
                new[] { action, scienceFiction, thriller },
                english,
                "A computer programmer discovers that the world he knows is a simulated reality and joins a rebellion against the machines controlling humanity.",
                63_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg"
            ),
            Movie(
                "Terminator 2: Judgment Day",
                137,
                1991,
                new[] { action, scienceFiction, thriller },
                english,
                "A reprogrammed Terminator protects a young John Connor from a more advanced machine sent from the future to kill him.",
                102_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/original/aMe8mst7RXnvHrhiDRGu0vusb9r.jpg"
            ),
            Movie(
                "Crouching Tiger, Hidden Dragon",
                120,
                2000,
                new[] { action, adventure, drama, romance },
                chinese,
                "Two legendary warriors pursue a stolen sword while a young aristocrat struggles between tradition, freedom and forbidden love.",
                17_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/original/cwHNET03Dh2wKLVbhOs0igixLzP.jpg"
            ),
            Movie(
                "Seven Samurai",
                207,
                1954,
                new[] { action, adventure, drama },
                japanese,
                "A village threatened by bandits hires seven samurai to defend its people and crops despite having almost no resources.",
                500_000m,
                "USD",
                "https://m.media-amazon.com/images/M/MV5BZDg4MTYyYjktZGJiYy00ZGIwLWEzNTMtNTZkMjRhYTViMWE4XkEyXkFqcGc@._V1_.jpg"
            ),
            // =========================================================
            // ADVENTURE - 6
            // =========================================================

            Movie(
                "The Lord of the Rings: The Fellowship of the Ring",
                178,
                2001,
                new[] { adventure, drama, action },
                english,
                "A young hobbit inherits a powerful ring and begins a dangerous journey to prevent it from returning to its dark creator.",
                93_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/6oom5QYQ2yQTMJIbnvbkBL9cHo6.jpg"
            ),
            Movie(
                "Raiders of the Lost Ark",
                115,
                1981,
                new[] { adventure, action },
                english,
                "Archaeologist Indiana Jones races against the Nazis to recover the legendary Ark of the Covenant.",
                18_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/ceG9VzoRAVGwivFU403Wc3AHRys.jpg"
            ),
            Movie(
                "Jurassic Park",
                127,
                1993,
                new[] { adventure, scienceFiction, thriller },
                english,
                "A dinosaur theme park opens to visitors, but a security failure allows the genetically recreated creatures to escape.",
                63_000_000m,
                "USD",
                "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_.jpg"
            ),
            Movie(
                "Spirited Away",
                125,
                2001,
                new[] { adventure, animation },
                japanese,
                "A young girl becomes trapped in a mysterious spirit world and must find the courage to rescue her transformed parents.",
                19_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/39wmItIWsg5sZMyRUHLkWBcuVCM.jpg"
            ),
            Movie(
                "The Revenant",
                156,
                2015,
                new[] { adventure, drama, thriller },
                english,
                "After being left for dead in the wilderness, a fur trapper fights extreme conditions and pursues the man who betrayed him.",
                135_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/ji3ecJphATlVgWNY0B0RVXZizdf.jpg"
            ),
            Movie(
                "The Seventh Seal",
                96,
                1957,
                new[] { adventure, drama },
                swedish,
                "A medieval knight returning from the Crusades encounters Death and challenges him to a game of chess while searching for meaning.",
                150_000m,
                "USD",
                "https://images.savoysystems.co.uk/GCL/500539.jpg"
            ),
            // =========================================================
            // ANIMATION - 6
            // =========================================================

            Movie(
                "Toy Story",
                81,
                1995,
                new[] { animation, comedy, adventure },
                english,
                "A cowboy doll becomes jealous when a new space-themed toy arrives and threatens his place as the favorite toy.",
                30_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/uXDfjJbdP4ijW5hWSBrPrlKpxab.jpg"
            ),
            Movie(
                "The Lion King",
                88,
                1994,
                new[] { animation, drama, adventure },
                english,
                "A young lion prince must overcome tragedy and return to reclaim his place as ruler of the Pride Lands.",
                45_000_000m,
                "USD",
                "https://lumiere-a.akamaihd.net/v1/images/p_thelionking_19752_1_0b9de87b.jpeg?region=0%2C0%2C540%2C810"
            ),
            Movie(
                "Howl's Moving Castle",
                119,
                2004,
                new[] { animation, adventure, romance },
                japanese,
                "A young woman cursed with an old body finds refuge in a magical moving castle belonging to the mysterious wizard Howl.",
                24_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/6pZgH10jhpToPcf0uvyTCPFhWpI.jpg"
            ),
            Movie(
                "My Neighbor Totoro",
                86,
                1988,
                new[] { animation, adventure },
                japanese,
                "Two sisters move to the countryside and discover a magical forest spirit who becomes part of their childhood adventures.",
                3_500_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/rtGDOeG9LzoerkDGZF9dnVeLppL.jpg"
            ),
            Movie(
                "The Incredibles",
                115,
                2004,
                new[] { animation, action, comedy },
                english,
                "A family of former superheroes is forced back into action when a new threat puts the world at risk.",
                92_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShDGwsWfGnCkjrW3y9jvKR3At07yqVzwSxiZy6DV9pig&s=10"
            ),
            Movie(
                "The Secret World of Arrietty",
                94,
                2010,
                new[] { animation, adventure, drama },
                japanese,
                "A tiny family living secretly beneath a house is discovered by a young boy, changing their carefully protected way of life.",
                23_000_000m,
                "USD",
                "https://static.wikia.nocookie.net/studio-ghibli/images/f/f7/The_Secret_World_of_Arrietty.jpg/revision/latest?cb=20210306220734"
            ),
            // =========================================================
            // COMEDY - 6
            // =========================================================

            Movie(
                "The Grand Budapest Hotel",
                100,
                2014,
                new[] { comedy, drama, adventure },
                english,
                "A legendary hotel concierge and his young protégé become involved in a stolen painting, an inheritance dispute and a series of absurd adventures.",
                25_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/eWdyYQreja6JGCzqHWXpWHDrrPo.jpg"
            ),
            Movie(
                "Groundhog Day",
                101,
                1993,
                new[] { comedy, romance },
                english,
                "A cynical television weatherman becomes trapped repeating the same day until he learns to change himself.",
                14_600_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/gCgt1WARPZaXnq523ySQEUKinCs.jpg"
            ),
            Movie(
                "Superbad",
                113,
                2007,
                new[] { comedy },
                english,
                "Two high school friends attempt to make the most of their final days together before graduation.",
                20_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/ek8e8txUyUwd2BNqj6lFEerJfbq.jpg"
            ),
            Movie(
                "Intouchables",
                112,
                2011,
                new[] { comedy, drama },
                english,
                "A wealthy man who has become paralyzed develops an unlikely friendship with the caregiver he hires from a very different background.",
                9_500_000m,
                "EUR",
                "https://image.tmdb.org/t/p/w500/1QU7HKgsQbGpzsJbJK4pAVQV9F5.jpg"
            ),
            Movie(
                "Another Round",
                117,
                2020,
                new[] { comedy, drama },
                danish,
                "Four teachers experiment with maintaining a constant level of alcohol in their bodies, believing it will improve their lives.",
                42_000_000m,
                "DKK",
                "https://m.media-amazon.com/images/M/MV5BNjYxN2EwYjUtNzdiOS00NTgwLTgwNzMtZmE1NGMzYTYxNzBjXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
            ),
            Movie(
                "A Man Called Ove",
                116,
                2015,
                new[] { comedy, drama },
                swedish,
                "A lonely and rigid widower's life changes after a lively young family moves in next door.",
                35_000_000m,
                "SEK",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTm1bmPzBmPXIlnzgVg2SUZEKuyiKTTNKoiW6Lyxh_8DA&s=10"
            ),
            // =========================================================
            // CRIME - 6
            // =========================================================

            Movie(
                "The Godfather",
                175,
                1972,
                new[] { crime, drama },
                english,
                "The aging head of a powerful crime family transfers control of his empire while his reluctant son is gradually drawn into the family business.",
                6_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/3bhkrj58Vtu7enYsRolD1fZdja1.jpg"
            ),
            Movie(
                "Pulp Fiction",
                154,
                1994,
                new[] { crime, drama, thriller },
                english,
                "Several interconnected stories involving criminals, boxers and gangsters unfold across Los Angeles.",
                8_500_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/d5iIlFn5s0ImszYzBPb8JPIfbXD.jpg"
            ),
            Movie(
                "Goodfellas",
                145,
                1990,
                new[] { crime, drama },
                english,
                "A young man rises through the ranks of a New York crime organization while his life becomes increasingly dangerous and unstable.",
                25_000_000m,
                "USD",
                "https://m.media-amazon.com/images/M/MV5BN2E5NzI2ZGMtY2VjNi00YTRjLWI1MDUtZGY5OWU1MWJjZjRjXkEyXkFqcGc@._V1_.jpg"
            ),
            Movie(
                "The Departed",
                151,
                2006,
                new[] { crime, drama, thriller },
                english,
                "An undercover police officer infiltrates a criminal organization while a criminal mole secretly works inside the police department.",
                90_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/nT97ifVT2J1yMQmeq20Qblg61T.jpg"
            ),
            Movie(
                "Memories of Murder",
                132,
                2003,
                new[] { crime, drama, thriller },
                chinese,
                "Two detectives with very different methods investigate a series of murders in a rural Korean community.",
                2_800_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9EhTX1dYWU55U77xjlleiYHKF28ogux_RLllKXRLr9Q&s=10"
            ),
            Movie(
                "Infernal Affairs",
                101,
                2002,
                new[] { crime, drama, thriller },
                chinese,
                "A police officer secretly working for a criminal organization and a criminal secretly working inside the police discover each other's existence.",
                6_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgzXs9erD1p1RBLpaqmyS1HX1tj6T4VY0A92xgdoR1bA&s=10"
            ),
            // =========================================================
            // DRAMA - 6
            // =========================================================

            Movie(
                "The Shawshank Redemption",
                142,
                1994,
                new[] { drama },
                english,
                "A banker sentenced to life in prison forms an enduring friendship and quietly builds a plan for freedom.",
                25_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/q6y0Go1tsGEsmtFryDOJo3dEmqu.jpg"
            ),
            Movie(
                "Forrest Gump",
                142,
                1994,
                new[] { drama, romance },
                english,
                "A kind-hearted man experiences several major moments in American history while remaining devoted to the people he loves.",
                55_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/arw2vcBveWOVZr6pxd9XTd1TdQa.jpg"
            ),
            Movie(
                "Schindler's List",
                195,
                1993,
                new[] { drama },
                english,
                "A German industrialist gradually risks his fortune and safety to protect Jewish workers during the Holocaust.",
                22_000_000m,
                "USD",
                "https://m.media-amazon.com/images/M/MV5BNjM1ZDQxYWUtMzQyZS00MTE1LWJmZGYtNGUyNTdlYjM3ZmVmXkEyXkFqcGc@._V1_.jpg"
            ),
            Movie(
                "Parasite",
                132,
                2019,
                new[] { drama },
                chinese,
                "A poor family schemes to become employed by a wealthy household, but their plan takes an unexpected turn.",
                11_400_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/7IiTTgloJzvGI1TAYymCfbfl3vT.jpg"
            ),
            Movie(
                "A Separation",
                123,
                2011,
                new[] { drama, crime },
                chinese,
                "A married couple facing divorce becomes entangled in a dispute that exposes difficult questions about family, responsibility and truth.",
                500_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyz-0kax4IRsAEEbAgwq46EORIBfeVhUtTIZq88gn1yw&s=10"
            ),
            Movie(
                "The Hunt",
                116,
                2012,
                new[] { drama, thriller },
                danish,
                "A teacher's life is destroyed when a false accusation spreads through the small community where he lives.",
                20_000_000m,
                "DKK",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQo-m36PiAwstFB6AzQ4ZJp1lc8ytHVkcPrhK88Nt1gsg&s=10"
            ),
            // =========================================================
            // HORROR - 6
            // =========================================================

            Movie(
                "The Exorcist",
                122,
                1973,
                new[] { horror, drama, thriller },
                english,
                "A mother seeks help after her young daughter begins exhibiting disturbing behavior that appears to have a supernatural cause.",
                12_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCTW4veubVjoK1IumddChA6z4zGI40OeYXEVqeN8E13g&s=10"
            ),
            Movie(
                "The Shining",
                146,
                1980,
                new[] { horror, drama, thriller },
                english,
                "A writer accepts a winter caretaker position at an isolated hotel where supernatural forces begin affecting his family.",
                19_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxUe2MJt6A4fubG78Lk1dwIg6zoWUIGd5Ysix5d6Pvgw&s=10"
            ),
            Movie(
                "Alien",
                117,
                1979,
                new[] { horror, scienceFiction, thriller },
                english,
                "The crew of a commercial spaceship investigates a mysterious transmission and unknowingly brings a deadly alien creature aboard.",
                11_000_000m,
                "USD",
                "https://m.media-amazon.com/images/M/MV5BZjIyNGJhYzYtN2I1My00OTVhLWEyMzItZTVjNDMzOTVkYWViXkEyXkFqcGc@._V1_.jpg"
            ),
            Movie(
                "Get Out",
                104,
                2017,
                new[] { horror, thriller },
                english,
                "A young man visiting his girlfriend's family becomes increasingly suspicious of the strange behavior surrounding him.",
                4_500_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSomg96pWCfGiKhIqnRWGiovaicVBDGmak6SqfXCfWi4g&s=10"
            ),
            Movie(
                "The Wailing",
                156,
                2016,
                new[] { horror, thriller, drama },
                chinese,
                "A mysterious stranger arrives in a rural village and a police officer investigates a series of disturbing illnesses and deaths.",
                8_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiPs-Qfr2nDxVKj_I5_juGWcoZOyKP5FuSL5IP5HBnlg&s=10"
            ),
            Movie(
                "The Ring",
                115,
                1998,
                new[] { horror, thriller },
                japanese,
                "A journalist investigates a mysterious videotape said to kill anyone who watches it seven days later.",
                1_200_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUsuzToL4_WW0Kp-CZT-TPhpUTR9PSWzVuvGONO0ud6A&s=10"
            ),
            // =========================================================
            // ROMANCE - 6
            // =========================================================

            Movie(
                "Titanic",
                194,
                1997,
                new[] { romance, drama },
                english,
                "A young woman from an upper-class family falls in love with a poor artist aboard the ill-fated Titanic.",
                200_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/9xjZS2rlVxm8SFx8kPC3aIGCOYQ.jpg"
            ),
            Movie(
                "La La Land",
                128,
                2016,
                new[] { romance, comedy, drama },
                english,
                "An aspiring actress and a jazz musician fall in love while pursuing their creative ambitions in Los Angeles.",
                30_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/uDO8zWDhfWwoFdKS4fzkUJt0Rf0.jpg"
            ),
            Movie(
                "Before Sunrise",
                101,
                1995,
                new[] { romance, drama },
                english,
                "Two young travelers meet on a train and decide to spend one night walking through Vienna together.",
                2_500_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTztXljufEU9hJqudHJXH2h6sLKT6VZ_GxXbVoCXhGFNg&s=10"
            ),
            Movie(
                "Your Name",
                106,
                2016,
                new[] { romance, animation, drama },
                japanese,
                "Two teenagers mysteriously begin switching bodies and develop a connection that reaches across time and distance.",
                2_500_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/q719jXXEzOoYaps6babgKnONONX.jpg"
            ),
            Movie(
                "In the Mood for Love",
                98,
                2000,
                new[] { romance, drama },
                chinese,
                "Two neighbors whose spouses are having an affair develop a quiet emotional relationship of their own.",
                1_500_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/iYypPT4bhqXfq1b6EnmxvRt6b2Y.jpg"
            ),
            Movie(
                "A Swedish Love Story",
                119,
                1970,
                new[] { romance, drama },
                swedish,
                "Two teenagers from very different family backgrounds develop a tender relationship while surrounded by adult problems.",
                1_000_000m,
                "SEK",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSWnjtX_NL1VC3odK7t3X3dOX8e_SSMWKZb8AeGeIz1Bw&s=10"
            ),
            // =========================================================
            // SCIENCE FICTION - 6
            // =========================================================

            Movie(
                "Inception",
                148,
                2010,
                new[] { scienceFiction, action, thriller },
                english,
                "A specialist who steals secrets through shared dreams is offered a chance to erase his past by planting an idea inside someone's mind.",
                160_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"
            ),
            Movie(
                "Interstellar",
                169,
                2014,
                new[] { scienceFiction, adventure, drama },
                english,
                "A former pilot joins a mission through a newly discovered wormhole in search of a future home for humanity.",
                165_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRN6MBU9VxzNxqU0gzzOsgDR0Mpxn4_6BDHIzD-Xc8YaQ&s=10"
            ),
            Movie(
                "Blade Runner",
                117,
                1982,
                new[] { scienceFiction, thriller, drama },
                english,
                "A retired police officer is forced back into service to track down artificial humans who have escaped to Earth.",
                28_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/63N9uy8nd9j7Eog2axPQ8lbr3Wj.jpg"
            ),
            Movie(
                "2001: A Space Odyssey",
                149,
                1968,
                new[] { scienceFiction, adventure, drama },
                english,
                "A mysterious object discovered on the Moon leads to a mission toward Jupiter and raises questions about human evolution.",
                10_500_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNkiHOX2HnOtmrgwxSqv6SArYmIs9ykSs13sM8Fo1yAw&s=10"
            ),
            Movie(
                "The Wandering Earth",
                125,
                2019,
                new[] { scienceFiction, action, drama },
                chinese,
                "Humanity attempts to move Earth away from a dying Sun using enormous planetary engines.",
                48_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2T2dnwLgtlBBodUvp7ASrooCXyt8ZKfdaMupCL7m7mQ&s=10"
            ),
            Movie(
                "Akira",
                124,
                1988,
                new[] { scienceFiction, animation, action },
                japanese,
                "A biker gang member gains terrifying psychic abilities after a secret government experiment goes wrong.",
                700_000_000m,
                "JPY",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEdxV0474bJ_0Ob6mvpbK_C6GH31JrFZjeMrAHpBCOUg&s=10"
            ),
            // =========================================================
            // THRILLER - 6
            // =========================================================

            Movie(
                "Se7en",
                127,
                1995,
                new[] { thriller, crime, drama },
                english,
                "Two detectives investigate a series of murders staged around the seven deadly sins.",
                33_000_000m,
                "USD",
                "https://image.tmdb.org/t/p/w500/6yoghtyTpznpBik8EngEmJskVUO.jpg"
            ),
            Movie(
                "The Silence of the Lambs",
                118,
                1991,
                new[] { thriller, crime, drama },
                english,
                "A young FBI trainee seeks the help of an imprisoned serial killer to understand another killer who is still at large.",
                19_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0yip5NdHlNuJFLP5XzuqQUCrscN-mBAG2pfwvi6e1NQ&s=10"
            ),
            Movie(
                "The Prestige",
                130,
                2006,
                new[] { thriller, drama, scienceFiction },
                english,
                "Two rival magicians become obsessed with creating the perfect illusion and gradually destroy their lives through their competition.",
                40_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQokpLObL01KaZVxzXMjhiZXJFOaeRT1h8HU-ZTxlvxOQ&s=10"
            ),
            Movie(
                "Prisoners",
                153,
                2013,
                new[] { thriller },
                english,
                "When two young girls disappear, a desperate father takes matters into his own hands while a detective pursues multiple leads.",
                46_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ8O5vNqMJCYv43AseeUvkJm_s3Kvvjqhaum0hUitd0-A&s=10"
            ),
            Movie(
                "The Girl with the Dragon Tattoo",
                152,
                2009,
                new[] { thriller, crime, drama },
                swedish,
                "A journalist and a young hacker investigate the decades-old disappearance of a wealthy family's daughter.",
                13_000_000m,
                "USD",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcTN3CKQBBont1EJmoV_IiJ5aqm4Nsd3T6R7i2rR_SXg&s=10"
            ),
            Movie(
                "The Guilty",
                2018,
                2018,
                new[] { thriller, crime, drama },
                danish,
                "A suspended police officer working emergency dispatch receives a disturbing call from a kidnapped woman and attempts to rescue her from a distance.",
                4_000_000m,
                "DKK",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTANaFdi-DQg7QbVd2XDu0B4B1kkZ6QZm5uOKZEN3tdtA&s=10"
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
        string currency,
        string posterUrl
    )
    {
        var details = MovieDetailFactory.Create(synopsis, MoneyFactory.Create(budget, currency));

        return MovieFactory.Create(
            title,
            year,
            TimeSpan.FromMinutes(durationMinutes),
            genres.ToArray(),
            details,
            language,
            posterUrl
        );
    }
}
