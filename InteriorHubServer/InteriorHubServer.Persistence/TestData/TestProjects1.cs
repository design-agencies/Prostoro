using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Persistence.TestData
{
    public partial class TestData
    {
        private static Project GetProject1(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Дизайн Спальні",
                MainImage = images[count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Рік проекту: 2022.\r\nЛокація: Варшава, Польща.\r\nДизайн Ярослава Грищука.\r\n\r\n\r\nДизайн головної спальні в квартирі.",
                OrderNumber = 1,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[0],
                    Project = project
                },
                OrderNumber = 2,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[1],
                    Project = project
                },
                OrderNumber = 3,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[2],
                    Project = project
                },
                OrderNumber = 4,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[3],
                    Project = project
                },
                OrderNumber = 5,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[4],
                    Project = project
                },
                OrderNumber = 6,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[5],
                    Project = project
                },
                OrderNumber = 6,
            });

            return project;
        }

        private static Project GetProject2(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Хурма",
                MainImage = images[6 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Дизайн: Оксана Долгопятова (  https://www.instagram.com/dolgopiatova_interiordesign/ )\r\n" +
                "Розташування: Київ, Україна\r\nПлоща: 84 м2 \r\nРік: 2022\r\nФото  Андрій Безуглов\r\n\r\n\r\nКвартира" +
                " знаходиться в історичному центрі Києва, новобудова.\r\nЯ не вперше працюю з такими клієнтами. 10 років" +
                " тому ми робили для них проект заміського будинку. Через кілька років клієнти знову звернулися до мене." +
                " Однак цього разу з ще більшою впевненістю.\r\n\r\nЦей проект квартири, який я називаю «Хурма», ми робили" +
                " у 2017 році, а будівництво розпочалося лише у 2019 році. Потім епідемія зупинила роботи, і лише наприкінці" +
                " 2021 року ця квартира була готова.",
                OrderNumber = 1,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[6],
                    Project = project
                },
                OrderNumber = 2,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Ця квартира - подарунок для підростаючої дочки моїх клієнтів. Тому на роботу ніхто не поспішав. " +
                "Замовникам було важливо зробити все максимально якісно та якісно. Ми обрали найякісніші та екологічно чисті" +
                " матеріали. Тому, коли не вдавалося замовити необхідне, процес ставили на паузу і чекали слушного моменту.",
                OrderNumber = 3,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[7],
                    Project = project
                },
                OrderNumber = 4,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Основною проблемою квартири була орієнтовна висота стелі - всього 3000. Для моїх клієнтів, які звикли" +
                " жити в будинку з досить високими стелями, цей факт був важливим. При цьому ставилося завдання зробити квартиру" +
                " теплою за атмосферою, а стиль – більш легким і сучасним, але при цьому виключити мінімалізм. Решта - повна довіра.",
                OrderNumber = 5,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[8],
                    Project = project
                },
                OrderNumber = 6,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[9],
                    Project = project
                },
                OrderNumber = 7,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Спочатку в квартирі було два балкони, які були непотрібними, тому ми об’єднали ці приміщення із суміжними" +
                " приміщеннями. Але щоб відвернути увагу від сегментної форми лоджії і перетворити недолік в гідність, отвори" +
                " перетворили в арки з обробкою деревом.",
                OrderNumber = 8,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[10],
                    Project = project
                },
                OrderNumber = 9,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Трохи складніше було зі стелями. Клієнти дуже хотіли, щоб вони були цікавими, але боялися, що вони досить" +
                " низькі.\r\nТому в більшості приміщень стелі мають таке ж покриття, як і на стінах - це декоративна штукатурка з " +
                "легким світло-бежевим відтінком і ефектом вологої стіни. Такий прийом позбавляє контрасту між поверхнями, тим більше," +
                " що по периметру стель використовуються гіпсові карнизи, які роблять перехід від стелі до стіни плавним. Такі карнизи" +
                " використовуються у всіх приміщеннях, але в різних колірних варіантах.\r\n\r\nНаприклад, у вітальні, головній кімнаті," +
                " з найбільшим вікном, найсвітлішою стелею. Цей колір змінює свою інтенсивність залежно від освітлення та ракурсу. Цей" +
                " колір дає рефлекс тепла всім поверхням і самій людині, настільки, що фізично ви відчуваєте себе краще. Крім того, цю " +
                "стелю підкреслює чорна молдингова планка, що робить її ще більш акцентованою. А також ця стрічка є тумбою для" +
                " освітлення, при включенні якої стеля знову змінює свою інтенсивність і теж буквально «злітає».",
                OrderNumber = 10,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[11],
                    Project = project
                },
                OrderNumber = 11,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[12],
                    Project = project
                },
                OrderNumber = 12,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[13],
                    Project = project
                },
                OrderNumber = 13,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[14],
                    Project = project
                },
                OrderNumber = 14,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[15],
                    Project = project
                },
                OrderNumber = 15,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Я назвала свій проект не тільки тому, що використовувала в ньому відтінки цієї ягоди. Я ще пізніше так назвав" +
                " свій проект, що його вдалося зняти лише влітку 2022 року. Під час війни.\r\nВлітку плоди хурми ще стиглі. Хурма у різних " +
                "народів є символом мудрості, миру і щастя в родині.\r\n Зараз осінь 2022 року, дозрівають плоди хурми. Світу дуже потрібна " +
                "мудрість, моїй зірці дуже потрібна перемога, моїм клієнтам, як і всім людям моєї країни, дуже потрібне щастя у їхніх родинах.",
                OrderNumber = 16,
            });

            return project;
        }

        private static Project GetProject3(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Сучасна квартира-студія в сірих тонах",
                MainImage = images[16 + count / 5],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Площа : 50 кв.м.\r\nРік: 2022\r\nРозташування: Київ",
                OrderNumber = 1,
            });
            for(int i = 0; i < 9; i++)
            {
                project.Elements.Add(new ProjectElement
                {
                    Type = "image",
                    ProjectImage = new ProjectImage
                    {
                        Image = images[16 + i],
                        Project = project
                    },
                    OrderNumber = 2 + i,
                });
            }

            return project;
        }

        private static Project GetProject4(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Дитяча кімната",
                MainImage = images[25 + count / 10],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Про проект:\r\nСвітла мінімалістична кімната в скандинавському стилі для дитини. Загальна площа 15 кв." +
                "\r\n\r\nВикористовувала меблі українських і скандинавських брендів, багато натурального дерева. \r\nНезважаючи на те," +
                " що ця кімната невелика, в ній можна було розмістити зону для сну, ігрову, навчальну та спортивну зону.\r\n\r\n" +
                "На створення цієї кімнати мене надихнув мій син.",
                OrderNumber = 1,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[25],
                    Project = project
                },
                OrderNumber = 2,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[26],
                    Project = project
                },
                OrderNumber = 3,
            });
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[27],
                    Project = project
                },
                OrderNumber = 4,
            });

            return project;
        }

        private static Project GetProject5(Agency agency, List<Image> images, int count)
        {
            var project = new Project
            {
                Name = "Візуалізація інтер'єру ванної кімнати",
                MainImage = images[28],
                Agency = agency
            };
            project.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = images[29],
                    Project = project
                },
                OrderNumber = 1,
            });

            return project;
        }
    }
}
