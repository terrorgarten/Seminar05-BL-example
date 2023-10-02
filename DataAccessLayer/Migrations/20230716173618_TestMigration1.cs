using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FollowerId = table.Column<int>(type: "INTEGER", nullable: false),
                    FolloweeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_Users_FolloweeId",
                        column: x => x.FolloweeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follows_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Updated", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9048), "jack_twitter" },
                    { 2, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9060), "sara_tweet" },
                    { 3, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9099), "mike_tweets" },
                    { 4, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9103), "emily_twitter" },
                    { 5, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9106), "alex_tweeting" }
                });

            migrationBuilder.InsertData(
                table: "Follows",
                columns: new[] { "Id", "Created", "FolloweeId", "FollowerId", "Updated" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9181), 3, 1, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9182) },
                    { 3, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9187), 1, 2, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9188) },
                    { 4, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9190), 1, 3, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9191) },
                    { 5, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9192), 1, 4, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9194) },
                    { 6, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9195), 5, 2, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9196) },
                    { 7, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9199), 4, 3, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9200) },
                    { 8, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9202), 2, 4, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9203) },
                    { 9, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9205), 3, 5, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9206) },
                    { 10, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9207), 1, 5, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9209) }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Created", "Title", "Updated", "UserId" },
                values: new object[,]
                {
                    { 1, "Just joined Twitter. Excited to share my thoughts and connect with others!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9114), "Hello Twitterverse!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9115), 1 },
                    { 2, "Today's thought: 'Be yourself; everyone else is already taken.' #BeYourself #Inspirational", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9120), "Thoughts of the day", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9121), 2 },
                    { 3, "Just booked my tickets for an amazing adventure! Can't wait to explore new places and cultures. #Wanderlust", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9123), "Traveling the world", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9124), 3 },
                    { 4, "Just finished reading an incredible book. Highly recommend it to all book lovers out there! #BookRecommendation", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9126), "Book recommendation", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9128), 4 },
                    { 5, "Setting new fitness goals for myself. Time to get fit and healthy! #FitnessGoals #HealthyLiving", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9130), "Fitness goals", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9131), 5 },
                    { 6, "Sharing my favorite recipes with all the foodies out there. Bon appétit! #Foodie #Recipes", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9133), "Delicious recipes", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9135), 1 },
                    { 7, "Always strive for personal growth and self-improvement. Small steps lead to big changes. #PersonalDevelopment", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9137), "Personal growth", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9138), 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "Created", "PostId", "Updated", "UserId" },
                values: new object[,]
                {
                    { 1, "Great post!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9143), 1, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9145), 2 },
                    { 2, "I agree!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9149), 2, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9151), 1 },
                    { 3, "Nice job!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9152), 1, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9154), 3 },
                    { 4, "Keep it up!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9156), 3, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9157), 4 },
                    { 5, "Interesting insights!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9159), 2, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9160), 5 },
                    { 6, "Well said!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9163), 3, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9164), 1 },
                    { 7, "You've inspired me.", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9166), 4, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9167), 2 },
                    { 8, "Thought-provoking.", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9169), 4, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9170), 3 },
                    { 9, "Great insights!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9172), 5, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9173), 4 },
                    { 10, "Love it!", new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9175), 3, new DateTime(2023, 7, 16, 19, 36, 18, 625, DateTimeKind.Local).AddTicks(9177), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FolloweeId",
                table: "Follows",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowerId",
                table: "Follows",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
