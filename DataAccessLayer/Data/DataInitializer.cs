using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = PrepareUserModels();
            var posts = PreparePostModels();
            var comments = PrepareCommentModels();
            var follows = PrepareFollowModels();

            modelBuilder.Entity<User>()
                .HasData(users);

            modelBuilder.Entity<Post>()
                .HasData(posts);

            modelBuilder.Entity<Comment>()
                .HasData(comments);

            modelBuilder.Entity<Follow>()
                .HasData(follows);
        }

        private static List<Comment> PrepareCommentModels()
        {
            var comments = new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Content = "Great post!",
                    UserId = 2,
                    PostId = 1,
                },
                new Comment
                {
                    Id = 2,
                    Content = "I agree!",
                    UserId = 1,
                    PostId = 2,
                },
                new Comment
                {
                    Id = 3,
                    Content = "Nice job!",
                    UserId = 3,
                    PostId = 1,
                },
                new Comment
                {
                    Id = 4,
                    Content = "Keep it up!",
                    UserId = 4,
                    PostId = 3,
                },
                new Comment
                {
                    Id = 5,
                    Content = "Interesting insights!",
                    UserId = 5,
                    PostId = 2,
                },
                new Comment
                {
                    Id = 6,
                    Content = "Well said!",
                    UserId = 1,
                    PostId = 3,
                },
                new Comment
                {
                    Id = 7,
                    Content = "You've inspired me.",
                    UserId = 2,
                    PostId = 4,
                },
                new Comment
                {
                    Id = 8,
                    Content = "Thought-provoking.",
                    UserId = 3,
                    PostId = 4,
                },
                new Comment
                {
                    Id = 9,
                    Content = "Great insights!",
                    UserId = 4,
                    PostId = 5,
                },
                new Comment
                {
                    Id = 10,
                    Content = "Love it!",
                    UserId = 5,
                    PostId = 3,
                }
            };

            return comments;
        }

        private static List<Post> PreparePostModels()
        {
            var posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Hello Twitterverse!",
                    Content = "Just joined Twitter. Excited to share my thoughts and connect with others!",
                    UserId = 1,
                },
                new Post()
                {
                    Id = 2,
                    Title = "Thoughts of the day",
                    Content = "Today's thought: 'Be yourself; everyone else is already taken.' #BeYourself #Inspirational",
                    UserId = 2,
                },
                new Post()
                {
                    Id = 3,
                    Title = "Traveling the world",
                    Content = "Just booked my tickets for an amazing adventure! Can't wait to explore new places and cultures. #Wanderlust",
                    UserId = 3,
                },
                new Post()
                {
                    Id = 4,
                    Title = "Book recommendation",
                    Content = "Just finished reading an incredible book. Highly recommend it to all book lovers out there! #BookRecommendation",
                    UserId = 4,
                },
                new Post()
                {
                    Id = 5,
                    Title = "Fitness goals",
                    Content = "Setting new fitness goals for myself. Time to get fit and healthy! #FitnessGoals #HealthyLiving",
                    UserId = 5,
                },
                new Post()
                {
                    Id = 6,
                    Title = "Delicious recipes",
                    Content = "Sharing my favorite recipes with all the foodies out there. Bon appétit! #Foodie #Recipes",
                    UserId = 1,
                },
                new Post()
                {
                    Id = 7,
                    Title = "Personal growth",
                    Content = "Always strive for personal growth and self-improvement. Small steps lead to big changes. #PersonalDevelopment",
                    UserId = 2,
                }
            };

            return posts;
        }

        private static List<User> PrepareUserModels()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "jack_twitter",
                    Created = new DateTime(2022, 1, 1),
                },
                new User()
                {
                    Id = 2,
                    Username = "sara_tweet",
                    Created = new DateTime(2022, 2, 15),
                },
                new User()
                {
                    Id = 3,
                    Username = "mike_tweets",
                    Created = new DateTime(2022, 3, 10),
                },
                new User()
                {
                    Id = 4,
                    Username = "emily_twitter",
                    Created = new DateTime(2022, 4, 5),
                },
                new User()
                {
                    Id = 5,
                    Username = "alex_tweeting",
                    Created = new DateTime(2022, 5, 20),
                }
            };

            return users;
        }

        private static List<Follow> PrepareFollowModels()
        {
            var follows = new List<Follow>()
            {
                new Follow()
                {
                    Id = 2,
                    FollowerId = 1,
                    FolloweeId = 3,
                },
                new Follow()
                {
                    Id = 3,
                    FollowerId = 2,
                    FolloweeId = 1,
                },
                new Follow()
                {
                    Id = 4,
                    FollowerId = 3,
                    FolloweeId = 1,
                },
                new Follow()
                {
                    Id = 5,
                    FollowerId = 4,
                    FolloweeId = 1,
                },
                new Follow()
                {
                    Id = 6,
                    FollowerId = 2,
                    FolloweeId = 5,
                },
                new Follow()
                {
                    Id = 7,
                    FollowerId = 3,
                    FolloweeId = 4,
                },
                new Follow()
                {
                    Id = 8,
                    FollowerId = 4,
                    FolloweeId = 2,
                },
                new Follow()
                {
                    Id = 9,
                    FollowerId = 5,
                    FolloweeId = 3,
                },
                new Follow()
                {
                    Id = 10,
                    FollowerId = 5,
                    FolloweeId = 1,
                },
            };

            return follows;
        }
    }
}
