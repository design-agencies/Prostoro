using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Persistence.TestData
{
    public partial class TestData
    {
        private static Project GetProject21(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "",
                MainImage = images[148 + count / 10],
                Agency = agency
            };
            for (int i = 0; i < 4; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[148 + i],
                        Project = project
                    },
                    OrderNumber = 1 + i,
                });
            }

            return project;
        }
        private static Project GetProject22(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "",
                MainImage = images[152 + count / 10],
                Agency = agency
            };
            for (int i = 0; i < 4; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[152 + i],
                        Project = project
                    },
                    OrderNumber = 1 + i,
                });
            }

            return project;
        }
        private static Project GetProject23(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "",
                MainImage = images[156 + count / 10],
                Agency = agency
            };
            for (int i = 0; i < 4; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[156 + i],
                        Project = project
                    },
                    OrderNumber = 1 + i,
                });
            }

            return project;
        }
        private static Project GetProject24(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Ресторан Терра",
                MainImage = images[160 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "ГОТЕЛЬ ГРАНД ЕМІЛІ / \r\nРесторан Терра\r\n\r\nМісцезнаходження: вул. Хмельницького. Україна, " +
                "Львівська область, м. Винники, 9б\r\nПлоща: 1152 м2\r\nЗавершено: 2022\r\nФото Євгенія Авраменка\r\n\r\n" +
                "Побувати в ресторані «Терра» – це як в тур по Західній Україні. З правого боку видно зелені гірські пагорби. " +
                "Там вночі горять бризки далеких пастуших вогнів. З лівого боку ви бачите тихе озеро. Його водна поверхня " +
                "вкривається брижами, коли вітряно, і ви чуєте\r\nшелестить очерет на його берегах.\r\n\r\nВсе це ми відображаємо " +
                "в інтер'єрі ресторану «Терра». Безмежні простори, насичені кольори, текстури та смаки, щедра природа, жага до життя " +
                "та екзистенційна радість. Він представляє місцеве українське бачення концепції чотирьох стихій. ",
                OrderNumber = 1,
            });
            for (int i = 0; i < 10; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[160 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }
        private static Project GetProject25(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "",
                MainImage = images[170 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "ЦЕ ПИВБАР ПЕЧЕРСЬК\r\nАрхітектори: бюро «Балбек» \\ Слава Бальбек, Юлія Барсук, Віка Дідич, " +
                "Сергій Гаврилов, Наталія Стуконог,\r\nАнтон Сивашенко\r\nКонцепція дизайну: Анастасія Мірзоян\r\n" +
                "Керівники проекту: Катерина Карельштейн\r\n3D художники: Нік Кі, Дмитро Бондаренко\r\nПлоща проекту: 1015 кв\r\n" +
                "Рік проекту: 2021\r\nРозташування: Київ, Україна\r\nФото: Андрій Безуглов, Мар’ян Береш",
                OrderNumber = 1,
            });
            for (int i = 0; i < 8; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[170 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }
    }
}
