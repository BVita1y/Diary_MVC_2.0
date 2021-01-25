using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Diary_MVC_2._0.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DiaryDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DiaryDbContext>>()))
            {
                
                // false - this will create new data for DB
                // true - There is data in DB
                if (true)
                    return;

                context.Plan.AddRange(
                    new Reminder
                    {
                        Type = Plan.PlanType.Reminder,
                        Subject = "ReminderTest1",
                        StartDateTime = DateTime.Now.AddMonths(6)
                    },

                    new Reminder
                    {
                        IsPerformed = false,
                        Type = Plan.PlanType.Reminder,
                        Subject = "ReminderTest2",
                        StartDateTime = DateTime.Now.AddDays(15)
                    },

                    new Case
                    {
                        IsPerformed = false,
                        Type = Plan.PlanType.Case,
                        Subject = "CaseTest1",
                        StartDateTime = DateTime.Now,
                        FinishDateTime = DateTime.Now.AddDays(7)
                    },

                    new Case
                    {
                        IsPerformed = false,
                        Type = Plan.PlanType.Case,
                        Subject = "CaseTest2",
                        StartDateTime = DateTime.Now.AddMonths(4),
                        FinishDateTime = DateTime.Now.AddMonths(4).AddDays(2)
                    },

                    new Meeting
                    {
                        IsPerformed = false,
                        Type = Plan.PlanType.Meeting,
                        Subject = "MeetingTest1",
                        StartDateTime = DateTime.Now,
                        FinishDateTime = DateTime.Now.AddDays(8),
                        Place = "Moscow"
                    },

                    new Meeting
                    {
                        IsPerformed = false,
                        Type = Plan.PlanType.Meeting,
                        Subject = "MeetingTest2",
                        StartDateTime = DateTime.Now.AddDays(40),
                        FinishDateTime = DateTime.Now.AddDays(40),
                        Place = "Moscow"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}