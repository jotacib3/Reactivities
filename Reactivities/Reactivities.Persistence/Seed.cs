using Microsoft.AspNetCore.Identity;
using Reactivities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reactivities.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = GetUsers();

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            if (!context.Activities.Any())
            {
                var activities = GetActivities();

                context.Activities.AddRange(activities);
                context.SaveChanges();
            }
        }

        private static List<AppUser> GetUsers() => new List<AppUser>
        {
            new AppUser
            {
                Id="a",
                DisplayName = "Bob",
                UserName = "bob",
                Email = "bob@test.com"
            },
            new AppUser
            {
                Id="c",
                DisplayName = "Tom",
                UserName = "tom",
                Email = "tob@test.com"
            },
            new AppUser
            {
                Id="b",
                DisplayName = "Jane",
                UserName = "jane",
                Email = "jane@test.com"
            }
        };
        private static List<Activity> GetActivities() => new List<Activity>
        {
            new Activity
            {
                Title = "Future Activity 1",
                Date = DateTime.Now.AddMonths(-2),
                Description = "Activity 2 months ago",
                Category = "Drinks",
                City = "London",
                Venue = "Pub",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(-2)
                    }
                }
            },
            new Activity
            {
                Title = "Past Activity 2",
                Date = DateTime.Now.AddMonths(-1),
                Description = "Activity 1 month ago",
                Category = "Culture",
                City = "Paris",
                Venue = "The Louvre",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "b",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(-1)
                    },
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(-1)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 1",
                Date = DateTime.Now.AddMonths(1),
                Description = "Activity 1 month in future",
                Category = "Music",
                City = "London",
                Venue = "Wembly Stadium",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "b",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(1)
                    },
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(1)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 2",
                Date = DateTime.Now.AddMonths(2),
                Description = "Activity 2 month in future",
                Category = "Food",
                City = "London",
                Venue = "02 Arena",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "c",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(2)
                    },
                    new UserActivity
                    {
                        AppUserId = "b",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(1)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 3",
                Date = DateTime.Now.AddMonths(3),
                Description = "Activity 3 month in future",
                Category = "Drinks",
                City = "London",
                Venue = "Another pub",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "c",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(3)
                    },
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(2)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 4",
                Date = DateTime.Now.AddMonths(4),
                Description = "Activity 4 month in future",
                Category = "drinks",
                City = "London",
                Venue = "Yet another pub",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "b",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(4)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 5",
                Date = DateTime.Now.AddMonths(5),
                Description = "Activity 5 month in future",
                Category = "drinks",
                City = "London",
                Venue = "Just anhother pub",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(5)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 6",
                Date = DateTime.Now.AddMonths(6),
                Description = "Activity 6 month in future",
                Category = "music",
                City = "London",
                Venue = "Roundhouse Camden",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "b",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(6)
                    },
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(6)
                    },
                    new UserActivity
                    {
                        AppUserId = "c",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(6)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 7",
                Date = DateTime.Now.AddMonths(7),
                Description = "Activity 7 month in future",
                Category = "travel",
                City = "London",
                Venue = "Somewhere on the Thames",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(7)
                    },
                    new UserActivity
                    {
                        AppUserId = "b",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(6)
                    },
                    new UserActivity
                    {
                        AppUserId = "c",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(5)
                    }
                }
            },
            new Activity
            {
                Title = "Future Activity 8",
                Date = DateTime.Now.AddMonths(8),
                Description = "Activity 8 month in future",
                Category = "film",
                City = "London",
                Venue = "Cinema",
                UserActivities = new List<UserActivity>
                {
                    new UserActivity
                    {
                        AppUserId = "c",
                        IsHost=true,
                        DateJoined = DateTime.Now.AddMonths(8)
                    },
                    new UserActivity
                    {
                        AppUserId = "a",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(7)
                    },
                    new UserActivity
                    {
                        AppUserId = "b",
                        IsHost=false,
                        DateJoined = DateTime.Now.AddMonths(5)
                    }
                }
            }
        };
    }
}
