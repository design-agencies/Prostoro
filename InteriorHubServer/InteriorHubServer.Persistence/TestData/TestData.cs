using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace InteriorHubServer.Persistence.TestData
{
    public partial class TestData
    {
        public static void Initialize(DataContext context)
        {
            #region Roles

            var adminRole = new IdentityRole<long>
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            var userRole = new IdentityRole<long>
            {
                Name = "User",
                NormalizedName = "USER"
            };
            var proRole = new IdentityRole<long>
            {
                Name = "Pro",
                NormalizedName = "PRO"
            };

            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);
            context.Roles.Add(proRole);

            #endregion Roles

            #region Users

            var admin1 = new User
            {
                UserName = "admin001@gmail.com",
                NormalizedUserName = "ADMIN001@GMAIL.COM",
                Email = "admin001@gmail.com",
                NormalizedEmail = "ADMIN001@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEC0wboFql1srGjHszTiqm3InN9wF7Pfr2kuWMB1Oj26eCWAM5isLhq9q7VdlbDOqYg==",
                SecurityStamp = "YOTYFOKCMFTXHBRLSNZKIUC5FLQMJWBK",
                ConcurrencyStamp = "685782e1-520c-4368-b135-c89ba75606ed",
                LockoutEnabled = true
            };

            var user1 = new User
            {
                UserName = "user001@gmail.com",
                NormalizedUserName = "USER001@GMAIL.COM",
                Email = "user001@gmail.com",
                NormalizedEmail = "USER001@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEC0wboFql1srGjHszTiqm3InN9wF7Pfr2kuWMB1Oj26eCWAM5isLhq9q7VdlbDOqYg==",
                SecurityStamp = "YOTYFOKCMFTXHBRLSNZKIUC5FLQMJWBK",
                ConcurrencyStamp = "685782e1-520c-4368-b135-c89ba75606ed",
                LockoutEnabled = true
            };

            var user2 = new User
            {
                UserName = "user002@gmail.com",
                NormalizedUserName = "USER002@GMAIL.COM",
                Email = "user002@gmail.com",
                NormalizedEmail = "USER002@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEC0wboFql1srGjHszTiqm3InN9wF7Pfr2kuWMB1Oj26eCWAM5isLhq9q7VdlbDOqYg==",
                SecurityStamp = "YOTYFOKCMFTXHBRLSNZKIUC5FLQMJWBK",
                ConcurrencyStamp = "685782e1-520c-4368-b135-c89ba75606ed",
                LockoutEnabled = true
            };

            var user3 = new User
            {
                UserName = "user003@gmail.com",
                NormalizedUserName = "USER003@GMAIL.COM",
                Email = "user003@gmail.com",
                NormalizedEmail = "USER003@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEC0wboFql1srGjHszTiqm3InN9wF7Pfr2kuWMB1Oj26eCWAM5isLhq9q7VdlbDOqYg==",
                SecurityStamp = "YOTYFOKCMFTXHBRLSNZKIUC5FLQMJWBK",
                ConcurrencyStamp = "685782e1-520c-4368-b135-c89ba75606ed",
                LockoutEnabled = true
            };


            var pro1 = new User
            {
                UserName = "valeria@gmail.com",
                NormalizedUserName = "VALERIA@GMAIL.COM",
                Email = "valeria@gmail.com",
                NormalizedEmail = "VALERIA@GMAIL.COM",
                Photo = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674222541/valeria_logo_gu2y8u.jpg"),
                PasswordHash = "AQAAAAEAACcQAAAAEMMFtdkCwrYJeFxxnmgK/wOWJSmoEkh0EX6upIlz+lmTQ9UKT9xcLnOX3CxUZkJacQ==",
                SecurityStamp = "5CYRL73DAQVRV4ZLVTSLIT6TDHREIAX3",
                ConcurrencyStamp = "910c4360-ff21-4a66-9a21-f0cce83c07a5",
                LockoutEnabled = true
            };

            var prosList = new List<User>();
            var logos = GetLogos();

            for (int i = 0; i < 30; i++)
            {
                var pro = new User
                {
                    UserName = "pro" + i,
                    Photo = logos[i],
                    NormalizedUserName = "PRO" + i,
                    Email = "pro" + i + "@gmail.com",
                    NormalizedEmail = "PRO" + i + "@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEOe+/aq0RmbSA47OOmU6iAJhGZfMpnb9YiRyKiF557uEwwPKZ+j/Qg6HnzAyrJHFQw==",
                    SecurityStamp = "VLB5NTCUF5S2STCJ5FFYNMEQHRZPVJKB",
                    ConcurrencyStamp = "af7bceef-fd7c-45a2-a296-6e39d458a362",
                    LockoutEnabled = true
                };
                prosList.Add(pro);
            }

            context.Users.Add(admin1);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(pro1);
            foreach (var pro in prosList)
            {
                context.Users.Add(pro);
            }

            context.SaveChanges();

            context.UserRoles.Add(new IdentityUserRole<long>
            {
                UserId = admin1.Id,
                RoleId = adminRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<long>
            {
                UserId = user1.Id,
                RoleId = userRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<long>
            {
                UserId = user2.Id,
                RoleId = userRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<long>
            {
                UserId = user3.Id,
                RoleId = userRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<long>
            {
                UserId = pro1.Id,
                RoleId = proRole.Id
            });

            foreach (var pro in prosList)
            {
                context.UserRoles.Add(new IdentityUserRole<long>
                {
                    UserId = pro.Id,
                    RoleId = proRole.Id
                });
            }
            #endregion Users

            #region Tags

            var tags = GetTags(context);

            #endregion Tags

            #region City

            var cities = GetCities(context);

            #endregion City

            #region Images

            //var logo1 = new Image("");

            //var header1 = new Image("");

            #endregion Images

            #region Agencies

            var agency1 = new Agency
            {
                User = pro1,
                Name = "Valery Design",
                LogoImg = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674222541/valeria_logo_gu2y8u.jpg"),
                HeaderImg = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040380/main_w8tl7o.jpg"),
                About = "Архітектура, ландшафт, інтер’єр",
                Description = "Студія Valery Design досить молода студія дизайну, але вже позиціонує себе як талановита та " +
                "професійна команда. Наша головна задача реалізація всіх мрій та побажань замовників саме так, як вони це бачать. " +
                "Ми створюємо комфортні та багатофункціональні дизайни за короткий термін та доволі незначний бюджет.\r\n" +
                "Ми використовуємо лише якісні матеріали та співпрацюємо з перевіренимим виробниками.\r\nНаша мета залишити після " +
                "себе присмак естетичного та  довершеного задоволення.",
                City = cities[0],
                Budget = "$$$",
                IsVerified = true,
                IsAvailable = true
            };

            var agencies = GetAgencies(context, prosList, tags, cities, logos);

            #endregion Agencies

            #region Projects

            var projects = GetProjects(context, agencies);

            var project1 = new Project
            {
                Name = "Спальня",
                MainImage = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040380/main_w8tl7o.jpg"),
                Agency = agency1
            };
            project1.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Затишний Контемпорарі з елементами лаунжу\r\nДизайн: Трачук Валерія\r\n" +
                "Розташування: Михайлівка-Рубежівка, Україна\r\nПлоща: 61 м2\r\nРік: 2023",
                OrderNumber = 1,
            });
            project1.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040380/main_w8tl7o.jpg"),
                    Project = project1
                },
                OrderNumber = 2,
            });
            project1.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Дизайн спальної кімнати виконано з урахуванням головних побажаннь замовниці стосовно мінімалістичного " +
                "наповнення, \r\nзонування спальних місць та меблів білого кольору.\r\nНапольним покриттям є ламінатна дошка.\r\n",
                OrderNumber = 3,
            });
            project1.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040346/%D1%811_gta4ro.jpg"),
                    Project = project1
                },
                OrderNumber = 4,
            });
            project1.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Мінімум аксесуарів та зроблений акцент на текстиль чудово передають дух стилю.\r\n" +
                "Штори було обрано з функцією день-ніч та за кольоровою гаммою чудово гармонують з усією кімнатою. \r\n",
                OrderNumber = 5,
            });
            project1.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040346/%D1%812_j0tbur.jpg"),
                    Project = project1
                },
                OrderNumber = 6,
            });
            var project2 = new Project
            {
                Name = "Кухня",
                MainImage = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040970/main_pioafq.jpg"),
                Agency = agency1
            };
            project2.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Затишний Контемпорарі з елементами лаунжу\r\nДизайн: Трачук Валерія\r\n" +
                "Розташування: Михайлівка-Рубежівка, Україна\r\nПлоща: 61 м2\r\nРік: 2023",
                OrderNumber = 1,
            });
            project2.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040970/main_pioafq.jpg"),
                    Project = project2
                },
                OrderNumber = 2,
            });
            project2.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Кухона зона виконана в головних кольорах дизайну, багатофункціональні шафи облаштовані механізмами push-open. " +
                "\r\nДодаткове обладння приховано за рахунок спланового дизану гарнітуру.\r\nТакож присутня система тепла підлога.",
                OrderNumber = 3,
            });
            project2.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040970/k1_f4vafn.jpg"),
                    Project = project2
                },
                OrderNumber = 4,
            });
            project2.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Також присутнє зонування яке чудово вписується в інтерьєр всієї оселі та зокрема кухні.\r\n" +
                "Також вдалося облаштувати доволі затишне місце прийому їжі та відпочинку.",
                OrderNumber = 5,
            });
            project2.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674040970/k2_ebul0m.jpg"),
                    Project = project2
                },
                OrderNumber = 6,
            });
            var project3 = new Project
            {
                Name = "Вітальня",
                MainImage = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041268/main_adisad.jpg"),
                Agency = agency1
            };
            project3.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Затишний Контемпорарі з елементами лаунжу\r\nДизайн: Трачук Валерія\r\n" +
                "Розташування: Михайлівка-Рубежівка, Україна\r\nПлоща: 61 м2\r\nРік: 2023",
                OrderNumber = 1,
            });
            project3.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041268/main_adisad.jpg"),
                    Project = project3
                },
                OrderNumber = 2,
            });
            project3.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Гостина кімната являє собою одночасно і зону відпочинку, і робочу зону.\r\n" +
                "Для зонування було використано підвісний стіл та декоративне оформлення стіни.\r\n ",
                OrderNumber = 3,
            });
            project3.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041268/v1_opgr93.jpg"),
                    Project = project3
                },
                OrderNumber = 4,
            });
            project3.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Картини якими оздобленно інтерьєр підкреслюють основну ідейну лінію.\r\n" +
                "Теплий зелений колір заспокоює та створює атмосферу затишку.\r\n",
                OrderNumber = 5,
            });
            project3.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041268/v2_b2n4vq.jpg"),
                    Project = project3
                },
                OrderNumber = 6,
            });
            var project4 = new Project
            {
                Name = "Ванна кімната",
                MainImage = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041377/main_m2kr16.jpg"),
                Agency = agency1
            };
            project4.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Затишний Контемпорарі з елементами лаунжу\r\nДизайн: Трачук Валерія\r\n" +
                "Розташування: Михайлівка-Рубежівка, Україна\r\nПлоща: 61 м2\r\nРік: 2023",
                OrderNumber = 1,
            });
            project4.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041377/main_m2kr16.jpg"),
                    Project = project4
                },
                OrderNumber = 2,
            });
            project4.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Простір ванної кімнати організовано таким чином, щоб комфортно було і власниці, і її пухнастому " +
                "співмешканцю.\r\nВбудована шафа дозволяю приховати всі необхідні побутові речі.\r\nМармурова плитка представляє " +
                "собою продовження єдиного кольрового вибору. \r\n",
                OrderNumber = 3,
            });
            project4.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041377/v1_tzwxo1.jpg"),
                    Project = project4
                },
                OrderNumber = 4,
            });
            project4.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Вибір техніки пав на функціональність, тому обрано було 2в1-пральна машина та сушка, щоб позбавитися можливості " +
                "загромаджувати квартиру чи псувати приміщення лоджії.\r\nМатова скляна перегородка дозволяє візуально поділя простір кімнати.\r\n",
                OrderNumber = 5,
            });
            project4.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041377/v2_gz4eno.jpg"),
                    Project = project4
                },
                OrderNumber = 6,
            });
            var project5 = new Project
            {
                Name = "Передпокій",
                MainImage = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041878/main_ihryxh.jpg"),
                Agency = agency1
            };
            project5.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Затишний Контемпорарі з елементами лаунжу\r\nДизайн: Трачук Валерія\r\n" +
                "Розташування: Михайлівка-Рубежівка, Україна\r\nПлоща: 61 м2\r\nРік: 2023",
                OrderNumber = 1,
            });
            project5.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041878/main_ihryxh.jpg"),
                    Project = project5
                },
                OrderNumber = 2,
            });
            project5.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Основною ідеєю було мінімалістичне наповнення та облаштування вхідної частини по принципцу \"все під рукою\"." +
                "\r\nОсвітлення розбито секціоно, тож ви самі можете обрати,що увімкнути. ",
                OrderNumber = 3,
            });
            project5.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041878/p1_pqa5yi.jpg"),
                    Project = project5
                },
                OrderNumber = 4,
            });
            project5.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Стіни зроблено фактурною штукатуркою,як і у всій квартирі.\r\n" +
                "Ергомномічна шафа дозволяє вмістити всі необхідні речі гардеробу та будь-що інше за бажанням.",
                OrderNumber = 5,
            });
            project5.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041878/p2_opnr60.jpg"),
                    Project = project5
                },
                OrderNumber = 6,
            });
            var project6 = new Project
            {
                Name = "Лоджія",
                MainImage = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041994/main_jrbhl6.jpg"),
                Agency = agency1
            };
            project6.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Затишний Контемпорарі з елементами лаунжу\r\nДизайн: Трачук Валерія\r\n" +
                "Розташування: Михайлівка-Рубежівка, Україна\r\nПлоща: 61 м2\r\nРік: 2023",
                OrderNumber = 1,
            });
            project6.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041994/main_jrbhl6.jpg"),
                    Project = project6
                },
                OrderNumber = 2,
            });
            project6.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Саме це місце в квартирі було позначено як місце релаксу та основного відпочинку.\r\n" +
                "Тому було максимально спрощено наповнювання та облаштовано все для спокійного головного хоббі замовниці - читання.\r\n",
                OrderNumber = 3,
            });
            project6.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041994/l1_wfp7rn.jpg"),
                    Project = project6
                },
                OrderNumber = 4,
            });
            project6.Elements.Add(new ProjectElement
            {
                Type = "text",
                Text = "Для комфорного перебування було облаштовано мягке місце, столик для дрібних речей та книжні полиці, " +
                "в якості міні бібліотеки.\r\nОзелення підібрано з категорії стійких рослин до зовнішніх факторів.",
                OrderNumber = 5,
            });
            project6.Elements.Add(new ProjectElement
            {
                Type = "image",
                ProjectImage = new ProjectImage
                {
                    Image = new Image("https://res.cloudinary.com/interiorhub/image/upload/v1674041994/l2_lomwtu.jpg"),
                    Project = project6
                },
                OrderNumber = 6,
            });

            context.Projects.AddRange(projects);
            context.Projects.Add(project1);
            context.Projects.Add(project2);
            context.Projects.Add(project3);
            context.Projects.Add(project4);
            context.Projects.Add(project5);
            context.Projects.Add(project6);

            #endregion Projects

            #region Reviews

            var review1 = new Review
            {
                User = user1,
                UserName = "Діана Васильчук",
                Agency = agencies[0],
                Message = "Замовляла дизайн однокімнатної квартири, все просто супер! Швидко, якісно я неймовірно задоволена. Рекомендую.",
                Rate = 4,
                CreatedOn = DateTime.Now.AddMonths(-1)
            };

            var review2 = new Review
            {
                User = user2,
                UserName = "Марина Кравчук",
                Agency = agencies[0],
                Message = "Ставлю 5 зірок! Дякую!",
                Rate = 5,
                CreatedOn = DateTime.Now.AddMonths(-2)
            };

            var review3 = new Review
            {
                User = user3,
                UserName = "Руслан Онопрієнко",
                Agency = agencies[0],
                Message = "Робота виконана якісно, мені та дружині подобається. Але маю зазначити кілька недоліків. " +
                "Як на таку ціну, я вважаю, має бути більш чуйне відношення до клієнта. " +
                "Перший менеджер, який працював з нами був не відповідальним, постійно переносив зустрічі із-за чого затякувався час виконання робіт. " +
                "Після нашої скарги, нащастя, нам замінили менеджера і далі все було чудово. ",
                Rate = 3,
                CreatedOn = DateTime.Now.AddMonths(-3)
            };

            context.Reviews.Add(review1);
            context.Reviews.Add(review2);
            context.Reviews.Add(review3);

            #endregion Reviews

            #region Likes

            //context.Likes.Add(new Like(user1, project1));
            //context.Likes.Add(new Like(user1, project2));

            #endregion Likes

            #region Saves

            context.Saves.Add(new Save(user1, projects[0], "projects"));
            context.Saves.Add(new Save(user1, projects[1], "projects"));
            context.Saves.Add(new Save(user1, projects[2], "projects"));
            context.Saves.Add(new Save(user1, projects[3], "projects"));
            context.Saves.Add(new Save(user1, projects[4], "projects"));
            context.Saves.Add(new Save(user1, projects[5], "projects"));

            context.Saves.Add(new Save(user1, agencies[0], "agencies"));
            context.Saves.Add(new Save(user1, agencies[3], "agencies"));
            context.Saves.Add(new Save(user1, agencies[6], "agencies"));
            context.Saves.Add(new Save(user1, agencies[9], "agencies"));
            context.Saves.Add(new Save(user1, agencies[12], "agencies"));
            context.Saves.Add(new Save(user1, agencies[15], "agencies"));

            #endregion Saves

            #region Messages

            var dialog1 = new Dialog();
            dialog1.Users.Add(user1);
            dialog1.Users.Add(pro1);

            var message1 = new Message
            {
                Sender = user1,
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris semper facilisis tellus.",
                Dialog = dialog1,
            };
            var message2 = new Message
            {
                Sender = user1,
                Text = "Integer interdum pulvinar nunc, nec volutpat dui egestas sed.",
                Dialog = dialog1,
            };
            var message3 = new Message
            {
                Sender = pro1,
                Text = "Suspendisse non convallis neque. Nunc porta non quam quis interdum. " +
                "Ut sed venenatis nisi, nec sagittis mi. Etiam turpis libero, feugiat quis ut ante.",
                Dialog = dialog1,
            };
            var message4 = new Message
            {
                Sender = pro1,
                Text = "Pellentesque sed velit id diam consequat rhoncus vitae ac diam. \n" +
                "In fermentum eu felis in accumsan. Mauris eleifend, lacus sit amet tempus suscipit, " +
                "velit ipsum commodo mi, at tincidunt metus dolor vel massa.",
                Dialog = dialog1,
            };
            var message5 = new Message
            {
                Sender = user1,
                Text = "Ut commodo porta lobortis.",
                Dialog = dialog1,
            };

            //context.Messages.Add(message1);
            //context.Messages.Add(message2);
            //context.Messages.Add(message3);
            //context.Messages.Add(message4);
            //context.Messages.Add(message5);
            #endregion Messages

            context.SaveChanges();

        }

        private static List<Agency> GetAgencies(DataContext context, List<User> prosList, List<Tag> tags, List<City> cities, List<Image> logos)
        {
            var headers = GetHeaderImages();
            var agencies = new List<Agency>();

            var random = new Random();

            for (int i = 0; i < 30; i++)
            {
                var agency = new Agency
                {
                    User = prosList[i],
                    LogoImg = logos[i],
                    HeaderImg = headers[i / 2],
                    City = cities[i % 10],
                    IsVerified = true,
                    IsAvailable = true,
                };
                agency.RemoteAvailable = random.Next(3) == 0;
                agency.OnSiteAvailable = random.Next(3) != 1 || !agency.RemoteAvailable;
                switch (i % 3)
                {
                    case 0:
                        agency.Budget = "$$$";
                        break;
                    case 1:
                        agency.Budget = "$$";
                        break;
                    case 2:
                        agency.Budget = "$";
                        break;
                }
                switch (i % 5)
                {
                    case 0:
                        agency.About = "Архітектура, ландшафт, інтер’єр";
                        agency.Description = "Ми – амбітна студія дизайну інтер’єрів у Києві з успішним міжнародним досвідом реалізації проектів," +
                            " що втілює сміливі дизайнерські ідеї для вашого бізнесу.\r\n\r\nМи виконуємо всі види робіт з дизайну інтер’єру, архітектурного та" +
                            " інженерного проектування. Наші спеціалісти створять авторський дизайн-проект для будь-якої комерційної нерухомості – вашого офісу," +
                            " магазину, клініки, коворкінгу, ресторану чи кафе. Ми також допоможемо виконати і ремонтні роботи.\r\n\r\nДизайн інтер’єру вашої" +
                            " мрії починається з концепції, яка відображається в кресленнях та 3D візуалізаціях. Будь-яке приміщення можливо зробити цікавішим," +
                            " привабливішим та функціональнішим.\r\n\r\nЯкщо замовити дизайн інтер’єру в студії Partner Design, ви можете бути впевнені, що гроші" +
                            " не будуть витрачені марно, результат не розчарує і перевершить усі ваші очікування.\r\n\r\nНаша мета – створення надійних відносин з" +
                            " клієнтами. З першого дня діяльності нашої дизайн студії ми орієнтуємося на результат, а також першокласне та оперативне виконання" +
                            " проектів будь-якої складності.\r\n\r\nЯкісний сучасний дизайн збільшує вартість об’єкту, покращує його прибутковість та зменшує строки" +
                            " окупності проекту. Ми сприяємо розвитку та успіху вашого бізнесу. Ми допоможемо уникнути багатьох помилок, мінімізувати витрати на" +
                            " оздоблювальні матеріали, підібрати найкращий спосіб реалізації вашого бачення проекту, сформувавши цільну концепцію.";
                        break;
                    case 1:
                        agency.About = "Архітектура, ландшафт, інтер’єр";
                        agency.Description = "Про нас\r\nКоманда нашої студії створює дизайн-проєкти інтер’єрів та екстер’єрів, розробляє архітектурні рішення," +
                            " проєктує будівлі різного цільового призначення, виконує комерційну візуалізацію і просто займається улюбленою справою, яка приносить" +
                            " задоволення. В нас є власне виробництво корпусних меблів, тому ми можемо виготовити проєкт будь-якої складності. Підхід нашої команди" +
                            " - це комплексне рішення, яке дозволяє реалізувати кожен спроєктований нами елемент.\r\n\r\nЦіль нашої студії - створити максимально" +
                            " комфортний та естетично довершений простір.\r\n\r\nЗавдяки великому досвіду нам вдалось зібрати надійну команду з: архітекторів," +
                            " дизайнерів та інженерів, тому клієнт у результаті отримує  красиву візуалізацію та грамотні креслення. З комплексом цієї документації" +
                            " будь-яка будівельна компанія виконає проєкт без зайвих запитань.\r\n\r\nНаша команда завжди рада новим клієнтам і завданням з розширення" +
                            " простору: у комерційних приміщеннях – для успішного бізнесу, у житлових – для комфортного життя.\r\n\r\nНам приємно працювати з клієнтами" +
                            " по всій Україні та за її межами.";
                        break;
                    case 2:
                        agency.About = "Архітектура, ландшафт, інтер’єр";
                        agency.Description = "Студія дизайну Alta Idea заснована у 2008 році у Києві. Головний напрямок діяльності – дизайн інтер’єру житлових та" +
                            " комерційних об’єктів. У нашому портфоліо проєкти будинків та квартир, готелів, лобі, ресторанів та офісів, спорт і спа зон. Ми не" +
                            " зациклюємося на чомусь одному, нам подобається експериментувати: прагнемо створити простір, оснащений всіма можливими зручностями для" +
                            " невимушеного та елегантного стилю життя.\r\n\r\nНас надихає сучасна лаконічна розкіш і творча експресія, увага до деталей та комфорту." +
                            " Ми любимо працювати з кольором, спостерігати за діалогом відтінків: як вони взаємодіють між собою, які емоції викликають і як проявляють" +
                            " себе в різні етапи дня й року.\r\n\r\nБути дизайнерами для нас означає не тільки створювати нові простори, але й формувати окремий вид" +
                            " мистецтва, в якому люди будуть жити та яким будуть насолоджуватись роками. Ми намагаємося думати наперед без прив’язки до часу, для того" +
                            " щоб наші проєкти були актуальними якомога довше.\r\n\r\nМи не прихильники пустих аскетичних інтер’єрів. Нам подобаються декоративно" +
                            " насичені соковиті ідеї, ритм та постійний розвиток. Прагнемо динаміки, як в інтер’єрах, так і в житті. Життя одне і його слід прожити" +
                            " красиво, вже сьогодні!";
                        break;
                    case 3:
                        agency.About = "Архітектура, ландшафт, інтер’єр";
                        agency.Description = "Студія дизайну інтер'єрів\r\n\r\nНаша компанія розробляє, проектує, візуалізує та 3D-моделює дизайни інтер'єрів." +
                            " Ми працюємо з будь-якими приміщеннями: будинками, квартирами, студіями, офісами, ресторанами та іншою житловою та комерційною" +
                            " нерухомістю.\r\n\r\nДля нас не існує поняття \"це неможливо\". Ми з радістю візьмемося до перепланування приміщень, розробимо унікальний" +
                            " дизайн-проект з урахуванням усіх ваших побажань. Замовивши дизайн-проект у нас, вам більше не доведеться страждати через нестачу розеток," +
                            " неправильну установку дверей або помилки електриків.\r\n\r\nМи втілимо в життя найсміливіші ідеї та креативні дизайнерські рішення.";
                        break;
                    case 4:
                        agency.About = "Архітектура, ландшафт, інтер’єр";
                        agency.Description = "ПРО НАС\r\nНаша студія створює розкішний і комфортний дизайн інтер'єру\r\nМи створюємо інтер’єр зручний для життя." +
                            " Ваша квартира не тільки буде виглядати як з журналу, вона буде наповнена гармонією. Наші інтер’єри розкішні, унікальні, і комфортабельні!" +
                            " Вам не потрібно жертвувати нічим. Не обмежуйте комфорт заради краси! Ви все отримаєте разом. Богемський шик – це комбінація зручності" +
                            " та функціональності. Проект втілюється в життя лише тоді, коли ви будете повністю задоволені.";
                        break;
                }

                for (int j = 0; j < 5; j++)
                {
                    var tagIndex = random.Next(j * 3, j * 3 + 2);
                    agency.Tags.Add(tags[tagIndex]);
                }
                agencies.Add(agency);
            }
            agencies[0].Name = "Ясінова Студіо";
            agencies[1].Name = "BautiGroup";
            agencies[2].Name = "Bim-Bim go";
            agencies[3].Name = "Bloomor";
            agencies[4].Name = "Briks";
            agencies[5].Name = "Atmostudio";
            agencies[6].Name = "Bulska Design";
            agencies[7].Name = "Design Factory";
            agencies[8].Name = "Figure House";
            agencies[9].Name = "Domiformi";
            agencies[10].Name = "Easy Renovation";
            agencies[11].Name = "Indigo";
            agencies[12].Name = "Flat Nest";
            agencies[13].Name = "Key Stone";
            agencies[14].Name = "Family Nest";
            agencies[15].Name = "Line Design";
            agencies[16].Name = "Grafiko";
            agencies[17].Name = "Mimimo";
            agencies[18].Name = "Lucky Green";
            agencies[19].Name = "Letify";
            agencies[20].Name = "Movers";
            agencies[21].Name = "Prosviring Design";
            agencies[22].Name = "Okno";
            agencies[23].Name = "Partner Design";
            agencies[24].Name = "Patternville";
            agencies[25].Name = "Quadro";
            agencies[26].Name = "Real Estate";
            agencies[27].Name = "Rivenoria";
            agencies[28].Name = "Quick Repair";
            agencies[29].Name = "Roomie";

            return agencies;
        }

        private static List<Project> GetProjects(DataContext context, List<Agency> agencies)
        {
            var projects = new List<Project>();
            var images = GetProjectImages();
            var count = 0;
            var methods = new List<MethodInfo>();
            for(var i = 1; i < 26; i++)
            {
                var type = typeof(TestData);
                var methodName = "GetProject" + i;
                var methodInfo = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                methods.Add(methodInfo);
            }
            Random rng = new Random();
            foreach (var agency in agencies)
            {
                switch (count % 5)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        var projectCount = rng.Next(4, 6);
                        for (int i = 0; i < projectCount; i++)
                        {
                            int index = rng.Next(methods.Count);
                            var method = methods[index];
                            var project = (Project)method.Invoke(null, new object[] { agency, images, count });
                            projects.Add(project);
                            methods.RemoveAt(index);
                        }
                        count++;
                        break;
                    case 4:
                        for (int i = 0; i < methods.Count; i++)
                        {
                            int index = rng.Next(methods.Count);
                            var method = methods[index];
                            var project = (Project)method.Invoke(null, new object[] { agency, images, count });
                            projects.Add(project);
                            methods.RemoveAt(index);
                        }
                        for (var i = 1; i < 26; i++)
                        {
                            var type = typeof(TestData);
                            var methodName = "GetProject" + i;
                            var methodInfo = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                            methods.Add(methodInfo);
                        }
                        count++;
                        break;
                }
            }

            return projects;
        }

        private static List<Image> GetProjectImages()
        {
            var images = new List<Image>();

            //project 1
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673874785/1_mykqpc.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673874785/2_cbx90x.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673874785/3_rxdm4r.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673874785/4_udgyvz.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673874785/5_bnoehe.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673874785/6_tdu7oo.jpg"));

            //project 2
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883657/1_qcbjx3.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883657/2_xjm9zn.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883657/3_kfd9w9.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883657/4_xajchk.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883658/5_sdeidt.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883658/6_dvmydq.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883658/7_eluyc0.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883658/8_bn3ovl.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883657/9_oiagnf.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673883657/" +
                "%D0%BE%D1%81%D1%82%D0%B0%D0%BD%D0%BD%D1%8F_%D1%84%D0%BE%D1%82%D0%BA%D0%B0_zf86og.jpg"));

            //project 3
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/1_t9rxlw.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/2_xcwopw.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/3_nlowjl.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/4_oltrbj.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/5_m1iety.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/6_wmrv3f.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/7_j3idxg.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/8_qpwlef.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673885483/9_asjvww.jpg"));

            //project 4
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886066/1_mojd8c.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886066/2_nzq3uz.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886066/3_q5mm1a.jpg"));

            //project 5
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886215/2_nzdbpd.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886215/1_yf3uz0.jpg"));

            //project 6
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886934/1_tehw9k.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886934/2_tt9xzq.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886934/3_nitqo6.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886934/4_r3avzd.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886934/5_hqzxjn.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673886934/6_yhmq5n.jpg"));

            //project 7
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887227/1_b9ed2h.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887226/2_pdv0he.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887226/3_pemymb.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887226/4_wuylbk.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887227/5_qobtas.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887227/6_hztfh5.jpg"));

            //project 8
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887464/1_hnyhcf.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887464/2_if7wgr.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887464/3_uc28rn.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887464/4_u784ua.jpg"));

            //project 9
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887641/1_gnfah4.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887641/2_ddqggr.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887641/3_yha2xq.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887641/4_snhxxs.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887641/5_xwgmbl.jpg"));

            //project 10
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/1_vyj0ru.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/2_jcgra8.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/3_gpmrs4.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887900/4_otwiho.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887900/5_owmazj.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/6_lbtfc7.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887900/7_i1ozog.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/8_jpb7f8.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/10_lqznyo.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/11_saczdx.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887898/12_iztfuq.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887898/13_lul4by.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887898/14_mtz6vp.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887898/15_wmhe6a.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887899/16_difato.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673887898/17_k4yy70.jpg"));

            //project 11
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903908/1_hozxvb.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903908/2_t7fynv.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903908/3_frjawu.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903908/4_j9z3ij.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903909/5_ccnbiw.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903907/6_l0xfil.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903908/7_gml2b4.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903907/8_mpznun.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673903908/9_rukblt.jpg"));

            //project 12
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904379/1_auvy28.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904379/2_vqfnxv.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904381/3_oxxqf6.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904379/4_q1nudj.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904382/5_uyuhvj.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904381/6_y9wzty.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904379/7_na9eej.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904379/8_a7sskk.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904381/9_tdum9b.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904382/10_eil16q.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904379/11_v43xjw.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904380/12_ff81kb.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904382/13_jj6or8.jpg"));

            //project 13
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904711/1_inxt06.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904711/2_opaqvk.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904711/3_hmvphv.jpg"));

            //project 14
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904928/1_m7pu9v.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904928/2_pyvmhf.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904928/3_zv5vem.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904928/4_gjpf92.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904929/5_rhvfdy.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904929/6_m9qvsm.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904928/7_qk3oa2.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904929/8_e0vcrm.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904929/9_ow9ioz.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673904928/10_ocapw7.jpg"));

            //project 15
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/1_iqv30f.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905250/2_h1ltfw.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905250/3_utruom.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/4_gyn7mb.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905250/5_cbyvjn.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905250/6_fiud8e.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/7_zp7fp1.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/8_ksbvii.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/9_jo0gjn.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/10_zfn0gb.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/11_zkg7x0.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905250/12_wbcnmk.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905249/13_zvgata.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905248/14_jscfx2.jpg"));

            //project 16
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905491/1_xnqko9.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905491/2_l161f7.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905491/3_qvkilg.png"));

            //project 17
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905789/1_kj3apv.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905789/2_vymnz1.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905789/3_versjj.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905790/4_ozjxu0.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905790/5_pczdqn.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905790/6_s8dl8v.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905789/7_afub6i.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905789/8_i0rug9.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905789/9_cjrtip.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673905789/10_z6f05p.jpg"));

            //project 18
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906353/1_tujjqm.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906354/2_ug9a2w.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906353/3_dku6vo.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906353/4_lvxqc4.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906354/5_fh45uk.png"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906353/6_rw0d3a.png"));

            //project 19
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906570/1_yykump.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906570/2_hvipcr.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906571/3_rvdvoo.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906570/4_twvewa.jpg"));

            //project 20
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906767/1_lz3vif.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906767/2_kcefob.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906767/3_qteun0.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906767/4_rfrqzg.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906768/5_i2o2dx.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906768/6_tcpuv1.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906767/7_osnil6.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906767/8_gdoj5p.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673906766/9_kv9jtx.jpg"));

            //project 21
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673977137/1_zhki3o.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907621/2_plwjlt.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907621/3_bztqmk.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907621/4_jxxbtt.jpg"));

            //project 22
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907733/1_kwqpxr.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907732/2_kimvnu.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907732/3_fspndr.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907733/4_ky6ddx.jpg"));

            //project 23
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907794/1_mxgkkq.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907794/2_gayby1.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907794/3_wuafor.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907794/4_ig15hy.jpg"));

            //project 24
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907899/1_hji3on.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907897/2_f6ukdj.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907898/3_lkqzoe.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907898/4_snnof8.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907897/5_vabesd.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907899/6_cbp64t.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907899/7_md4nqd.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907898/8_bblhou.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907897/9_sqgorl.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673907897/10_gnmv5g.jpg"));

            //project 25
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/1_a55hse.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/2_wipp1r.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/3_y2hgcy.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/4_sdgpg4.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/5_fza9b1.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/6_amnvzk.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/7_fn9enz.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673908156/8_ga7uqm.jpg"));


            return images;
        }

        private static List<Image> GetLogos()
        {
            var logos = new List<Image>();

            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870202/%D0%AF%D1%81%D1%96%D0" +
                "%BD%D0%BE%D0%B2%D0%B0_%D0%A1%D1%82%D1%83%D0%B4%D1%96%D0%BE_jxwflx.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Bauti_Group_gjg6wr.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Bim-Bim_go_v4ipot.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Bloomor_weerbc.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Briks_cvibch.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Atmostudio_dwdxeo.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Bulska_Design_rh3sas.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Design_Factory_pkt7lk.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/FigureHouse_upshwu.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Domiformi_cg56v4.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Easy_Renovation_iksgz8.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Indigo_ieyq7l.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Flat_Nest_kc7fkl.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/KeyStone_xz6rpv.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Family_Nest_pzd0l3.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/Line_Design_bbysgj.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870203/grafiko_aawmhl.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Mimimo_pvmriq.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Lucky_Green_aiutts.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Letify_r2puxf.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Movers_pd3iyi.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Prosviring_Design_vocqzu.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Okno_qeqzdw.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Partner_Design_nrtlcg.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Patternville_rtow4a.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Quadro_udurxi.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Real_Estate_wb6dra.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Rivenoria_mcrfh1.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Quick_Repair_p5g1it.jpg"));
            logos.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673870204/Roomie_dvjr88.jpg"));

            return logos;
        }

        private static List<Image> GetHeaderImages()
        {
            var images = new List<Image>();

            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/1_r37dpj.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/8_mblzbt.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/6_wlk4n6.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/12_mlhhi1.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/10_oqq2z9.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/2_i7sans.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/5_f3f9zt.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871203/4_" +
                "%D0%BD%D0%B5_%D1%83%D0%BD%D1%96%D0%BA%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0_i2zasc.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871219/11_qax6y1.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871224/PROSTIR_Design_rgw6sl.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871228/7_wfcump.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871232/3_ne660a.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871238/9_jpimi2.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871520/5_hth7dx.jpg"));
            images.Add(new Image("https://res.cloudinary.com/interiorhub/image/upload/v1673871612/16_oavuzp.jpg"));

            return images;
        }

        private static List<City> GetCities(DataContext context)
        {
            var cities = new List<City>();

            cities.Add(new City("Kyiv", "Kyiv", "Київ"));
            cities.Add(new City("Lviv", "Lviv", "Львів"));
            cities.Add(new City("Kherson", "Kherson", "Херсон"));
            cities.Add(new City("Odesa", "Odesa", "Одеса"));
            cities.Add(new City("Kharkiv", "Kharkiv", "Харків"));
            cities.Add(new City("Dnipro", "Dnipro", "Дніпро"));
            cities.Add(new City("Vinnytsia", "Vinnytsia", "Вінниця"));
            cities.Add(new City("Zaporizhzhia", "Zaporizhzhia", "Запоріжжя"));
            cities.Add(new City("Kryvyi Rih", "Kryvyi Rih", "Кривий Ріг"));
            cities.Add(new City("Mykolaiv", "Mykolaiv", "Миколаїв"));

            context.Cities.AddRange(cities);
            //context.Cities.Add(new City("Mariupol", "Mariupol", "Маріуполь"));
            //context.Cities.Add(new City("Chernihiv", "Chernihiv", "Чернігів"));
            //context.Cities.Add(new City("Poltava", "Poltava", "Полтава"));
            //context.Cities.Add(new City("Khmelnytskyi", "Khmelnytskyi", "Хмельницький"));
            //context.Cities.Add(new City("Cherkasy", "Cherkasy", "Черкаси"));
            //context.Cities.Add(new City("Chernivtsi", "Chernivtsi", "Чернівці"));
            //context.Cities.Add(new City("Zhytomyr", "Zhytomyr", "Житомир"));
            //context.Cities.Add(new City("Sumy", "Sumy", "Суми"));
            //context.Cities.Add(new City("Ivano-Frankivsk", "Ivano-Frankivsk", "Івано-Франківськ"));
            //context.Cities.Add(new City("Rivne", "Rivne", "Рівне"));
            //context.Cities.Add(new City("Ternopil", "Ternopil", "Тернопіль"));
            //context.Cities.Add(new City("Lutsk", "Lutsk", "Луцьк"));
            //context.Cities.Add(new City("Kremenchuk", "Kremenchuk", "Кременчук"));
            //context.Cities.Add(new City("Uzhhorod", "Uzhhorod", "Ужгород"));

            return cities;
        }

        private static List<Tag> GetTags(DataContext context)
        {
            var tags = new List<Tag>();

            tags.Add(new Tag("Eco-design", "style", "Eco-design", "Еко-дизайн"));
            tags.Add(new Tag("Exterior", "style", "Exterior", "Екстер’єр"));
            tags.Add(new Tag("3D Visualization", "style", "3D Visualization", "3D Візуалізація"));
            tags.Add(new Tag("Planning", "style", "Planning", "Планування"));
            tags.Add(new Tag("Interior", "style", "Interior", "Інтер’єр"));
            tags.Add(new Tag("Landscaping", "style", "Landscaping", "Ландшафтний дизайн"));
            tags.Add(new Tag("Replanning", "style", "Replanning", "Перепланування"));
            tags.Add(new Tag("Architecture", "style", "Architecture", "Архітектура"));
            tags.Add(new Tag("Children's space", "style", "Children's space", "Дитячий простір"));
            tags.Add(new Tag("Turnkey design", "style", "Turnkey design", "Дизайн під ключ"));
            tags.Add(new Tag("Turnkey repair", "style", "Turnkey repair", "Ремонт під ключ"));
            tags.Add(new Tag("Modern design", "style", "Modern design", "Сучасний дизайн"));
            tags.Add(new Tag("Refined design", "style", "Refined design", "Вишуканий дизайн"));
            tags.Add(new Tag("Construction works", "style", "Construction works", "Будівельні роботи"));
            tags.Add(new Tag("Furnishing", "style", "Furnishing", "Меблювання"));
            tags.Add(new Tag("Recommendations", "style", "Recommendations", "Рекомендації"));

            // change "style" to something else

            context.Tags.AddRange(tags);

            return tags;
        }

    }
}
