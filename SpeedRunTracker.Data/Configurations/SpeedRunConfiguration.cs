using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;
using System.Xml.Linq;

namespace SpeedRunTracker.Data.Configurations
{
    public class SpeedRunConfiguration : IEntityTypeConfiguration<SpeedRun>
    {
        public void Configure(EntityTypeBuilder<SpeedRun> builder)
        {
            builder.HasData(GenerateData());
        }

        private IEnumerable<SpeedRun> GenerateData() 
        {
            var data = new HashSet<SpeedRun>();

            SpeedRun sr = new SpeedRun()
            {
                Id = Guid.Parse("BBD08A56-D96D-4972-88FC-B028BD52AAB0"),
                SpeedRunVideoUrl = "https://www.youtube.com/watch?v=Xx0w_xFr_88",
                CategoryId = 3,
                GameId = 1,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddYears(-1).AddMonths(-3).AddDays(-2),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(0, 1,46, 58, 75),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("7B848C6B-7722-43B9-970E-CFD8B38BCF51"),
                SpeedRunVideoUrl = "https://youtu.be/D4Qp-JWll7M",
                CategoryId = 3,
                GameId = 1,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddMonths(-8).AddDays(-23),
                SpeedRunerId = Guid.Parse("DE5697F9-1610-4C65-986D-998A20D207EC"),
                SpeedRunTime = new TimeSpan(0, 56, 10),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("6E5B4681-5CFB-4D1B-9192-400A5D4A05F7"),
                SpeedRunVideoUrl = "https://youtu.be/mO6AzhxlU6s",
                CategoryId = 3,
                GameId = 1,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddMonths(-6).AddDays(-13),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(0, 57, 21),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("C50261BD-22D4-4091-9451-766391ED78F0"),
                SpeedRunVideoUrl = "https://youtu.be/dwoImoxer40",
                CategoryId = 1,
                GameId = 1,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddYears(-1).AddMonths(-1),
                SpeedRunerId = Guid.Parse("6A490127-80C3-49C1-B851-A6A24BE09EC7"),
                SpeedRunTime = new TimeSpan(1, 2, 10),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("6D9D8FAA-59A2-4A4F-82B8-3D8BE04A2A37"),
                SpeedRunVideoUrl = "https://youtu.be/U0DS3UNwM1M",
                CategoryId = 3,
                GameId = 1,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddYears(-1).AddMonths(-9).AddDays(-17),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(1, 2, 23),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("751F9621-3919-46F8-B5ED-FD6343BC5433"),
                SpeedRunVideoUrl = "https://youtu.be/LSRZk4jtWyc",
                CategoryId = 3,
                GameId = 1,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddMonths(-10).AddDays(-28),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(1, 5, 0),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("C3CA6C60-2CD1-464C-BD4A-8D01837BE2AC"),
                SpeedRunVideoUrl = "https://youtu.be/yxrxUDD_4-U",
                CategoryId = 1,
                GameId = 2,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddYears(-3).AddMonths(-2).AddDays(-12),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(0, 12, 40),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("1FBC13B9-A4EE-4807-84A7-693ACDC12BFB"),
                SpeedRunVideoUrl = "https://youtu.be/OYmpVcgpKxc",
                CategoryId = 2,
                GameId = 2,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddYears(-2).AddMonths(-1).AddDays(-15),
                SpeedRunerId = Guid.Parse("6A490127-80C3-49C1-B851-A6A24BE09EC7"),
                SpeedRunTime = new TimeSpan(0, 16, 37),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("E4FD2F72-A0BC-47D4-89A4-FEA6472DA5E6"),
                SpeedRunVideoUrl = "https://youtu.be/Tds0511PfNc",
                CategoryId = 4,
                GameId = 3,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddMonths(-11).AddDays(-24),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(1, 28, 14),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("099C2308-7931-4B24-A6EC-96505ED3E1C8"),
                SpeedRunVideoUrl = "https://youtu.be/iFIpaKxbMeI",
                CategoryId = 3,
                GameId = 3,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddYears(-1).AddMonths(-5).AddDays(-19),
                SpeedRunerId = Guid.Parse("6A490127-80C3-49C1-B851-A6A24BE09EC7"),
                SpeedRunTime = new TimeSpan(1, 20, 42),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("78C800E3-AD7B-4EF4-950B-CB48EEF15B64"),
                SpeedRunVideoUrl = "https://www.youtube.com/watch?v=d5sH2XgIKmA",
                CategoryId = 4,
                GameId = 4,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddMonths(-1).AddDays(-4),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(16, 9, 50)
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("8E3C8352-0B2B-47B0-A95E-FDC9D7833ADE"),
                SpeedRunVideoUrl = "https://youtu.be/3izKku1J6XA",
                CategoryId = 1,
                GameId = 5,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddDays(-24),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(0, 0, 14, 11, 930),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("3FE0FE8C-FE75-4AB9-9F7F-1D43A281C92A"),
                SpeedRunVideoUrl = "https://youtu.be/kVBGRnrWhgE",
                CategoryId = 3,
                GameId = 5,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddYears(-3).AddDays(-23),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(0, 46, 59),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("B1602B03-DB0F-4D4B-B8AE-869DC7C36B8F"),
                SpeedRunVideoUrl = "https://youtu.be/bcSnIAnTxPA",
                CategoryId = 3,
                GameId = 6,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddMonths(-3).AddDays(-2),
                SpeedRunerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                SpeedRunTime = new TimeSpan(1, 14, 19),
            };

            data.Add(sr);

            sr = new SpeedRun()
            {
                Id = Guid.Parse("164F8EC8-5096-4731-8A7D-FB0264EDF0BC"),
                SpeedRunVideoUrl = "https://youtu.be/0JEQh49IqJc",
                CategoryId = 3,
                GameId = 6,
                IsActive = true,
                IsVerified = false,
                SubmitionDate = DateTime.UtcNow.AddDays(-28),
                SpeedRunerId = Guid.Parse("6A490127-80C3-49C1-B851-A6A24BE09EC7"),
                SpeedRunTime = new TimeSpan(1, 16, 21),
            };

            data.Add(sr);

            return data.ToArray();
        }
    }
}