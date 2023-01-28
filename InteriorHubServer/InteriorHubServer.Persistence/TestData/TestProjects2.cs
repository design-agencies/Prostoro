using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Persistence.TestData
{
    public partial class TestData
    {
        private static Project GetProject6(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Мінімалістична кухня",
                MainImage = images[30 + count / 5],
                Agency = agency
            };
            for (int i = 0; i < 6; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[30 + i],
                        Project = project
                    },
                    OrderNumber = 1 + i,
                });
            }

            return project;
        }

        private static Project GetProject7(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "coffee with blood",
                MainImage = images[36 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Подібної концепції в дизайні інтер'єру ще не було\r\nНасолоджуйтесь результатом",
                OrderNumber = 1,
            });
            for (int i = 0; i < 6; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[36 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }

        private static Project GetProject8(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Living room",
                MainImage = images[42 + count / 10],
                Agency = agency
            };
            for (int i = 0; i < 4; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[42 + i],
                        Project = project
                    },
                    OrderNumber = 1 + i,
                });
            }

            return project;
        }

        private static Project GetProject9(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "КВАРТИРА a2C1R",
                MainImage = images[46 + count / 6], //?
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Площа :  64,84 м2 \r\nРік :  2022 \r\n" +
                "Розташування :  Вінниця\r\nАрхітектура | Дизайн | Візуалізація",
                OrderNumber = 1,
            });
            for (int i = 0; i < 5; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[46 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }

        private static Project GetProject10(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Апартаменти",
                MainImage = images[51 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Функціонально апартаменти поділені на три зони: кухня-вітальня, спальня та передпокій/гардероб. " +
                "Візуально ж це один простір з трьома великими вікнами. Спальня відокремлена від вітальні скляною перегородкою: " +
                "таким чином вийшло ізольоване місце для відпочинку із збереженням загального простору апартаментів.\r\n\r\n" +
                "Основними умовами проекту були невеликий бюджет, а також обробка, що легко відновлюється. Стіни апартаментів не " +
                "вирівнювалися, щоб максимально заощадити матеріали та витрати на послуги оздоблювальників. Вони покриті лише тонким " +
                "шаром шпаклівки під фарбування. Таке покриття легко локально відновити при необхідності, без перефарбування стіни цілком. " +
                "За таким же принципом зроблено покриття підлоги – бетонна стяжка неідеально відшліфована та пофарбована напівглянсовою " +
                "фарбою для бетонної підлоги. Бетонна стеля від забудовника пофарбована також без вирівнювання. Таким чином вдалося отримати " +
                "легко відновлювану оболонку з індустріальним нальотом.\r\n\r\nНиз стіни апартаментів пофарбований у колір підлоги, щоб " +
                "отримати ефект візуального розширення простору за рахунок переходу кольору з горизонтальної поверхні на вертикальну. " +
                "Також це відсилання до класичних буазер, але виконаним більш економічним способом за допомогою молдингів та фарбування. " +
                "Ці своєрідні настінні панелі, з вертикальним ритмом у зоні вітальні та їдальні, спрощуються в зоні спальні, перетворюючись " +
                "на довгу мінімалістичну панель з горизонтальним відбиттям біля підлоги та над узголів'ям ліжка. У зоні передпокою панелі " +
                "зовсім зникають, продовжуючи лінію панелей простим фарбуванням стіни в два кольори і переходячи в пофарбований високий " +
                "плінтус у зоні санвузла та кухні.\r\n\r\nВ інтер'єрі використані меблі та деталі різних стилістичних напрямків: предмети у " +
                "стилі mid-century у поєднанні з індустріальними та класичними елементами.",
                OrderNumber = 1,
            });
            for (int i = 0; i < 16; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[51 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }
    }
}
