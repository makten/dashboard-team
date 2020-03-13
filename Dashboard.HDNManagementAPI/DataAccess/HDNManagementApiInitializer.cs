using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dashboard.HDNManagementAPI.Model;

namespace Dashboard.HDNManagementAPI.DataAccess
{
    /// <summary>
    /// This class is used for seeding database for the Dashboard application
    /// </summary>
    public class HDNManagementApiInitializer
    {
        public static void Initialize(HDNManagementDbContext context)
        {
            var initializer = new HDNManagementApiInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(HDNManagementDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Hdns.Any())
            {
                SeedHdns(context);
            }

            if (!context.Labels.Any())
            {
                SeedLabels(context);
            }

            if (!context.HdnOptions.Any())
            {
                SeedHndOptions(context);
            }

            if (!context.Omgevings.Any())
            {
                SeedOmgvings(context);
            }
        }

        private void SeedHdns(HDNManagementDbContext context)
        {
            var hdns = new[]
            {
                new HDN
                {
                    BerichtNaam = "test", 
                    BerichtLocatie = "c:\\test.xml",
                    Omgeving = new Omgeving
                    {
                        OmgevingNaam = "Mgsyn-ov-frc01", 
                        Description = "syntrus development environment", 
                        Labels = new List<Label>
                        {
                            new Label
                            {
                                Name = "Syntrus", 
                                Description = "Syntrus whitelabel"
                            }
                        },
                    },
                    HdnOption = new HdnOption
                    {
                        UseNHG = false,
                        UseGivenFirstClient = true,
                        FirstClientName = "Hafiz Abass",
                        UseGivenSecondClient = false,
                        UseGivenTussenPersoon = false,
                        TypeOfHypotheek = SoortHypotheek.EersteHypotheek
                    }
                },
                new HDN
                {
                    BerichtNaam = "test", 
                    BerichtLocatie = "c:\\test.xml",
                    Omgeving = new Omgeving
                    {
                        OmgevingNaam = "Mgsyn-ov-frc01", 
                        Description = "syntrus development environment", 
                        Labels = new List<Label>
                        {
                            new Label
                            {
                                Name = "Syntrus", 
                                Description = "Syntrus whitelabel"
                            }
                        },
                    },
                    HdnOption = new HdnOption
                    {
                        UseNHG = false,
                        UseGivenFirstClient = true,
                        FirstClientName = "Hafiz Abass",
                        UseGivenSecondClient = false,
                        UseGivenTussenPersoon = false,
                        TypeOfHypotheek = SoortHypotheek.EersteHypotheek
                    }
                },

            };

            context.Hdns.AddRange(hdns);
            context.SaveChanges();
        }

        private void SeedOmgvings(HDNManagementDbContext context)
        {
            var omgevings = new[]
            {
                new Omgeving
                {
                    OmgevingNaam = "Mgsyn-ov-frc01",
                    Description = "syntrus development environment",
                    Labels = new List<Label>
                    {
                        new Label
                        {
                            Name = "Syntrus",
                            Description = "Syntrus whitelabel"
                        }
                    },
                },
                new Omgeving
                {
                    OmgevingNaam = "Mgsyn-ov-frc08",
                    Description = "syntrus development environment",
                    Labels = new List<Label>
                    {
                        new Label
                        {
                            Name = "Attens",
                            Description = "Attens whitelabel"
                        },
                        new Label
                        {
                            Name = "Tellius",
                            Description = "Tellius whitelabel"
                        },
                        new Label
                        {
                            Name = "Syntrus",
                            Description = "Syntrus whitelabel"
                        },
                    },
                },
                new Omgeving
                {
                    OmgevingNaam = "Mgsyn-ov-frc01",
                    Description = "syntrus development environment",
                    Labels = new List<Label>
                    {
                        new Label
                        {
                            Name = "Syntrus",
                            Description = "Syntrus whitelabel"
                        }
                    },
                },
            };

            context.Omgevings.AddRange(omgevings);
            context.SaveChanges();
        }

        private void SeedHndOptions(HDNManagementDbContext context)
        {
            var hdnOptions = new[]
            {
                new HdnOption
                {
                    UseNHG = false,
                    UseGivenFirstClient = true,
                    FirstClientName = "Hafiz Abass",
                    UseGivenSecondClient = false,
                    UseGivenTussenPersoon = false,
                    TypeOfHypotheek = SoortHypotheek.EersteHypotheek
                },
                new HdnOption
                {
                    UseNHG = false,
                    UseGivenFirstClient = true,
                    FirstClientName = "Hafiz Abass",
                    UseGivenSecondClient = false,
                    UseGivenTussenPersoon = false,
                    TypeOfHypotheek = SoortHypotheek.EersteHypotheek
                }
            };

            context.HdnOptions.AddRange(hdnOptions);
            context.SaveChanges();
        }

        private void SeedLabels(HDNManagementDbContext context)
        {
            var labels = new[]
            {
                new Label
                {
                    Name = "Attens",
                    Description = "Attens label"
                },
                new Label
                {
                    Name = "Tellius",
                    Description = "Tellius label"
                },
                new Label
                {
                    Name = "Syntrus",
                    Description = "Syntrus label"
                },
            };
        }

        protected string GenerateRandomEmail()
        {
            string SALTCHARS = "abcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder salt = new StringBuilder();
            Random rnd = new Random();

            while (salt.Length < 10)
            { 
                int index = (int)(rnd.NextDouble() * SALTCHARS.Length);
                salt.Append(SALTCHARS.ElementAtOrDefault(index));
            }

            string saltStr = salt.ToString();
            return saltStr;
        }
    }
}
