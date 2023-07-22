using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyOnlineLibrary.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace MyOnlineLibrary.Infrastructure.Data
{
    public class MyOnlineLibraryDbContext : IdentityDbContext<LibraryUser, IdentityRole, string>
    {
        public MyOnlineLibraryDbContext()
        {
        }

        public MyOnlineLibraryDbContext(DbContextOptions<MyOnlineLibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UploadFiles> Files { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UploadFiles>()
            .HasOne(f => f.Book) // BookAttachment belongs to one Book
            .WithMany(b => b.UploadFiles) // One Book can have multiple attachments
            .HasForeignKey(f => f.BookId); // The foreign key pro

            builder
                .Entity<Book>()
                .HasData(new Book()
                {
                    Id = 5,
                    Title = "Lorem Ipsum",
                    Author = "Oli Hazzard",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1618913266i/57801373.jpg",
                    Description = "Lorem Ipsum consists of a single, 60,000-word sentence. An epistolary fiction to an unidentified email recipient, the novel is modelled after the Japanese prose genre of the zuihitsu, an unfolding sentence in which resolution and closure are endlessly deferred. Our relationships with time and the environment have been radically altered by our awareness of global warming and the experience of being on the internet, and this shape-shifting novel is written out of and towards this moment of crisis in the ordinary, in which the experience of attention has changed entirely. Playful, disruptive and digressive, it reflects the associative movements of our minds. Lorem Ipsum is also an intimate, singular exploration of being a parent, a child, dreams, work, fantasies, happiness, memory, protest, repetition, intergenerational conflict, and the forms of community which appear or disappear based on how we conceive of 'shared time'. It is a book about the foundations upon which we build our lives: in John Ashbery’s words: ‘a chronicle of its own creation’.",
                    CategoryId = 1,
                    Rating = 3.4m

                }, new Book()
                {
                    Id = 8,
                    Title = "The Happiest Man on Earth",
                    Author = "Eddie Jaku",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1595373758i/53239311.jpg",
                    Description = "Eddie Jaku always considered himself a German first, a Jew second. He was proud of his country. But all of that changed in November 1938, when he was beaten, arrested and taken to a concentration camp.Over the next seven years, Eddie faced unimaginable horrors every day, first in Buchenwald, then in Auschwitz, then on a Nazi death march. He lost family, friends, his country. Because he survived, Eddie made the vow to smile every day. He pays tribute to those who were lost by telling his story, sharing his wisdom and living his best possible life. He now believes he is the 'happiest man on earth'. Published as Eddie turns 100, this is a powerful, heartbreaking and ultimately hopeful memoir of how happiness can be found even in the darkest of times.",
                    CategoryId = 2,
                    Rating = 4.64m

                }, new Book()
                {
                    Id = 9,
                    Title = "Choosing to Run: A Memoir",
                    Author = "Des Linden,Bonnie D. Ford",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1673265751i/61420096.jpg",
                    Description = "Featuring both the story of an historic, unforgettable win and insight into the life of an indelible champion, Choosing to Run is a truly inspirational memoir from Boston Marathon winner and Olympian Des Linden, sharing her personal story and what motivates her to keep showing up. When Des woke up on April 16, 2018, the morning of the Boston Marathon, it was 39 degrees and raining, with high, gusty winds. The weather didn’t bother her. In fact, she thought it might be a blessing. She was far from peak form—recovering from illness and questioning her running future—and didn’t expect much of herself that day. But as she ticked off mile after mile in the brutal conditions, passing familiar landmarks on the course she knew by heart, something shifted. Opportunity unexpectedly presented itself. Des tapped into her inner strength and remembered all of the reasons she loved to race. Coming off Heartbreak Hill at Mile 22, Des took the lead and never relinquished it, becoming the 2018 Boston Marathon champion and the first American woman to win the race in thirty-three years. Her career has always been defined by tenacity and an independent spirit, stretching back to her first competitive race in San Diego, when she beat better-outfitted, more experienced kids. Des was a two-time All-American at Arizona State University, and as her collegiate years wound down, she decided she wasn’t done with the sport. Des gambled on herself and moved to Michigan to give professional running a try. As she rose through the elite ranks, she became increasingly determined to do things her way in an industry often bound by the status quo. In her first book, readers will learn the story behind that the way Des trains, the way she thinks, her relationships with other great runners of her generation, and how much she values her family and friends. They’ll read about her deep connection to the most famous marathon in the world, her two very different Olympic experiences, and how she defined new goals and set a world record at the 50-kilometer distance. Most of all, they’ll learn what makes her get up and run every day.",
                    CategoryId = 2,
                    Rating = 4.41m
                }, new Book()
                {
                    Id = 10,
                    Title = "Waybound",
                    Author = "Will Wight",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1685927627i/173338910.jpg",
                    Description = "Years ago, Lindon left his home as a powerless Unsouled. Now, he goes to war with the most powerful beings in the world over the future of Cradle itself. The Weeping Dragon has a grudge to settle, and Lindon intends to take out the Dreadgod with his friends by his side. But rival Monarchs know his plans, and they won’t let things end so easily. If Lindon does win, he will ascend to the heavens. But he may not find a safe haven there either. In the worlds above, Suriel and Ozriel face off against the Mad King to determine the new shape of the cosmos. The victor will decide the fate of countless universes. Whether he wins or dies, Lindon will soon leave this life behind. The time has come to say goodbye to Cradle.",
                    CategoryId = 1,
                    Rating = 4.7m
                }, new Book()
                {
                    Id = 11,
                    Title = "Next in Line",
                    Author = "Jeffrey Archer",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1650843351i/59227743.jpg",
                    Description = "Which means for Scotland Yard, the focus is on the elite Royalty Protection Command, and its commanding officer. Entrusted with protecting the most famous family on earth, they quite simply have to be the best. A weak link could spell disaster. Detective Chief Inspector William Warwick and his Scotland Yard squad are sent in to investigate the team. Maverick ex-undercover operative Ross Hogan is charged with a very sensitive―and unique―responsibility. But it soon becomes clear the problems in Royalty Protection are just the beginning. A renegade organization has the security of the country―and the Crown―in its sights. The only question is which target is next in line…",
                    CategoryId = 1,
                    Rating = 4.21m
                }, new Book()
                {
                    Id = 12,
                    Title = "The Spell Thief",
                    Author = "Tom Percival",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1459002916i/29623561.jpg",
                    Description = "Meet Jack and his talking chicken Betsy, Red, Rapunzel, Hansel and Gretel, and a host of other Little Legends as they have fantastic new adventures! Get to know your favorite fairytale characters like never before in this magical new book series. Life for Jack is great ― he's got a magical talking hen named Betsy, he lives in a town where stories literally grow on trees, and all his best friends live there with him. That is, until Anansi, the new kid in town, arrives..." +
                    "When Jack sees Anansi having a secret meeting with a troll ― everything changes. Trolls mean trouble and Jack will stop at nothing to prove that Tale Town is in danger. Even if that means using stolen magic!",
                    CategoryId = 3,
                    Rating = 3.82m
                }, new Book()
                {
                    Id = 13,
                    Title = "Sherlock Bones and the Case of the Crown Jewels",
                    Author = "Tim Collins",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1655563065i/57385351.jpg",
                    Description = "When the crown jewels go missing from Buckingham Kennel, it’s up to super-sleuth Sherlock Bones and his trusty sidekick Dr Catson to solve the crime.",
                    CategoryId = 3,
                    Rating = 4.33m
                }, new Book()
                {
                    Id = 14,
                    Title = "The Perfect Marriage",
                    Author = "Jeneva Rose",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1593388297i/53450790.jpg",
                    Description = "Would you defend your husband if he was accused of killing his mistress? " +
                    "Sarah Morgan is a successful and powerful defense attorney in Washington D.C. At 33 years old, she is a named partner at her firm and life is going exactly how she planned." +
                    "The same cannot be said for her husband, Adam. He is a struggling writer who has had little success in his career. He begins to tire of his and Sarah’s relationship as she is constantly working." +
                    "Out in the secluded woods, at Adam and Sarah’s second home, Adam engages in a passionate affair with Kelly Summers." +
                    "Then, one morning everything changes. Adam is arrested for Kelly’s murder. She had been found stabbed to death in Adam and Sarah’s second home." +
                    "Sarah soon finds herself playing the defender for her own husband, a man accused of murdering his mistress." +
                    "But is Adam guilty or is he innocent?",
                    CategoryId = 4,
                    Rating = 4.00m
                },
                new Book()
                {
                    Id = 15,
                    Title = "Night Will Find You",
                    Author = "Julia Heaberlin",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1675082747i/61884843.jpg",
                    Description = "A scientist with a special gift riles a wasp's nest of conspiracy theories while investigating a cold case in this riveting novel from the acclaimed and bestselling author of Black-Eyed Susans and We Are All the Same in the Dark.",
                    CategoryId = 4,
                    Rating = 4.15m
                }, new Book()
                {
                    Id = 16,
                    Title = "The Way of Kings",
                    Author = "Brandon Sanderson",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1659905828i/7235533.jpg",
                    Description = "Roshar is a world of stone and storms. Uncanny tempests of incredible power sweep across the rocky terrain so frequently that they have shaped ecology and civilization alike. Animals hide in shells, trees pull in branches, and grass retracts into the soilless ground. Cities are built only where the topography offers shelter." +
                    "It has been centuries since the fall of the ten consecrated orders known as the Knights Radiant, but their Shardblades and Shardplate remain: mystical swords and suits of armor that transform ordinary men into near-invincible warriors. Men trade kingdoms for Shardblades. Wars were fought for them, and won by them." +
                    "One such war rages on a ruined landscape called the Shattered Plains. There, Kaladin, who traded his medical apprenticeship for a spear to protect his little brother, has been reduced to slavery. In a war that makes no sense, where ten armies fight separately against a single foe, he struggles to save his men and to fathom the leaders who consider them expendable." +
                    "Brightlord Dalinar Kholin commands one of those other armies. Like his brother, the late king, he is fascinated by an ancient text called The Way of Kings. Troubled by over-powering visions of ancient times and the Knights Radiant, he has begun to doubt his own sanity." +
                    "Across the ocean, an untried young woman named Shallan seeks to train under an eminent scholar and notorious heretic, Dalinar's niece, Jasnah. Though she genuinely loves learning, Shallan's motives are less than pure. As she plans a daring theft, her research for Jasnah hints at secrets of the Knights Radiant and the true cause of the war." +
                    "The result of over ten years of planning, writing, and world-building, The Way of Kings is but the opening movement of the Stormlight Archive, a bold masterpiece in the making.",
                    CategoryId = 5,
                    Rating = 4.65m

                }, new Book()
                {
                    Id = 17,
                    Title = "The Name of the Wind",
                    Author = "Patrick Rothfuss",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1270352123i/186074.jpg",
                    Description = "Told in Kvothe's own voice, this is the tale of the magically gifted young man who grows to be the most notorious wizard his world has ever seen." +
                    "The intimate narrative of his childhood in a troupe of traveling players, his years spent as a near-feral orphan in a crime-ridden city, his daringly brazen yet successful bid to enter a legendary school of magic, and his life as a fugitive after the murder of a king form a gripping coming-of-age story unrivaled in recent literature." +
                    "A high-action story written with a poet's hand, The Name of the Wind is a masterpiece that will transport readers into the body and mind of a wizard.",
                    CategoryId = 5,
                    Rating = 4.52m

                }
                );


            builder
           .Entity<Category>()
           .HasData(new Category()
           {
               Id = 1,
               Name = "Action"
           },
           new Category()
           {
               Id = 2,
               Name = "Biography"
           },
           new Category()
           {
               Id = 3,
               Name = "Children"
           },
           new Category()
           {
               Id = 4,
               Name = "Crime"
           },
           new Category()
           {
               Id = 5,
               Name = "Fantasy"
           });


            base.OnModelCreating(builder);
        }
    }
}