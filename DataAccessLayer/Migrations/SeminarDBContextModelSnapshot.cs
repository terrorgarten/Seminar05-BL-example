﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(SeminarDBContext))]
    partial class SeminarDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("DataAccessLayer.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Great post!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9143),
                            PostId = 1,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9145),
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Content = "I agree!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9149),
                            PostId = 2,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9151),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "Nice job!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9152),
                            PostId = 1,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9154),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Content = "Keep it up!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9156),
                            PostId = 3,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9157),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Content = "Interesting insights!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9159),
                            PostId = 2,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9160),
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Content = "Well said!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9163),
                            PostId = 3,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9164),
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            Content = "You've inspired me.",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9166),
                            PostId = 4,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9167),
                            UserId = 2
                        },
                        new
                        {
                            Id = 8,
                            Content = "Thought-provoking.",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9169),
                            PostId = 4,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9170),
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Content = "Great insights!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9172),
                            PostId = 5,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9173),
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            Content = "Love it!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9175),
                            PostId = 3,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9177),
                            UserId = 5
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("FolloweeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FollowerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FolloweeId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Follows");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9181),
                            FolloweeId = 3,
                            FollowerId = 1,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9182)
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9187),
                            FolloweeId = 1,
                            FollowerId = 2,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9188)
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9190),
                            FolloweeId = 1,
                            FollowerId = 3,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9191)
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9192),
                            FolloweeId = 1,
                            FollowerId = 4,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9194)
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9195),
                            FolloweeId = 5,
                            FollowerId = 2,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9196)
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9199),
                            FolloweeId = 4,
                            FollowerId = 3,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9200)
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9202),
                            FolloweeId = 2,
                            FollowerId = 4,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9203)
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9205),
                            FolloweeId = 3,
                            FollowerId = 5,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9206)
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9207),
                            FolloweeId = 1,
                            FollowerId = 5,
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9209)
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Just joined Twitter. Excited to share my thoughts and connect with others!",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9114),
                            Title = "Hello Twitterverse!",
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9115),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Today's thought: 'Be yourself; everyone else is already taken.' #BeYourself #Inspirational",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9120),
                            Title = "Thoughts of the day",
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9121),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "Just booked my tickets for an amazing adventure! Can't wait to explore new places and cultures. #Wanderlust",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9123),
                            Title = "Traveling the world",
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9124),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Content = "Just finished reading an incredible book. Highly recommend it to all book lovers out there! #BookRecommendation",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9126),
                            Title = "Book recommendation",
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9128),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Content = "Setting new fitness goals for myself. Time to get fit and healthy! #FitnessGoals #HealthyLiving",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9130),
                            Title = "Fitness goals",
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9131),
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Content = "Sharing my favorite recipes with all the foodies out there. Bon appétit! #Foodie #Recipes",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9133),
                            Title = "Delicious recipes",
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9135),
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            Content = "Always strive for personal growth and self-improvement. Small steps lead to big changes. #PersonalDevelopment",
                            Created = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9137),
                            Title = "Personal growth",
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9138),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9048),
                            Username = "jack_twitter"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9060),
                            Username = "sara_tweet"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9099),
                            Username = "mike_tweets"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9103),
                            Username = "emily_twitter"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updated = new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9106),
                            Username = "alex_tweeting"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.Comment", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.User", "Commenter")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commenter");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Follow", b =>
                {
                    b.HasOne("DataAccessLayer.Models.User", "Followee")
                        .WithMany("Followers")
                        .HasForeignKey("FolloweeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.User", "Follower")
                        .WithMany("Follows")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Followee");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Post", b =>
                {
                    b.HasOne("DataAccessLayer.Models.User", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Followers");

                    b.Navigation("Follows");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
