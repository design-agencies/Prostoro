using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Persistence.TestData
{
    public partial class TestData
    {
        private static Project GetProject16(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "",
                MainImage = images[116 + count / 10],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Дизайн: Аліна Дроздюк\r\nВізуалізація: Аліна Дроздюк\r\n" +
                "Локація: місто Київ, Україна\r\nСтиль: Сучасна класика\r\nРік: 2020",
                OrderNumber = 1,
            });
            for (int i = 0; i < 3; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[116 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }
        private static Project GetProject17(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "",
                MainImage = images[119 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "ТИП: КВАРТИРА\r\nМІСЦЕ: КИЇВ\r\nПЛОЩА: 84 кв\r\nРІК: 2020\r\nДИЗАЙНЕР ІНТЕР'ЄРУ: СЄДОВА ОЛЕНА\r\n" +
                "ТВОРИ МИСТЕЦТВА: ЮЛІЯ МЕТЕЛІНА\r\nФОТО: ОЛЕКС НЕБОРАЧКО",
                OrderNumber = 1,
            });
            for (int i = 0; i < 10; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[119 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }
        private static Project GetProject18(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Квартира в Стокгольмі",
                MainImage = images[129 + count / 5],
                Agency = agency
            };
            for (int i = 0; i < 6; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[129 + i],
                        Project = project
                    },
                    OrderNumber = 1 + i,
                });
            }

            return project;
        }
        private static Project GetProject19(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Дитяча спальня",
                MainImage = images[135 + count / 10],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Дитяча спальня на віллі Майорка, Іспанія\r\n\r\nДизайн інтер'єру розкішної головної спальні на " +
                "віллі Майорка, Іспанія. В інтер'єрі простору спальні переважають світлі відтінки, в якості акцентів були " +
                "взяті темно-синій і чорний, а у ванній кімнаті ми працювали з темно-синьою палітрою відтінків. Концептуально " +
                "ми вирішили зупинитися на темі космосу і всіляко її обігрували завдяки дизайнерським деталям і експериментам " +
                "з формами. Завдяки цікавій грі на тему, яка подобається дитині, це місце буде для неї дуже затишним і надихаючим.\r\n",
                OrderNumber = 1,
            });
            for (int i = 0; i < 4; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[135 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }
        private static Project GetProject20(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "",
                MainImage = images[139 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Квартира Зелена вул. \r\n\r\nКонцепція дизайну інтер'єру нової квартири.\r\nрозташування | Львів\r\n" +
                "площа | 48 кв.м.\r\nстатус | в процесі\r\n\r\nдизайнер Ростислав Сороковий\r\n" +
                "візуалізації Софія Свидницька\r\nтехнічні проекти Петро Бучок\r\n2022 рік",
                OrderNumber = 1,
            });
            for (int i = 0; i < 9; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[139 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }
    }
}
