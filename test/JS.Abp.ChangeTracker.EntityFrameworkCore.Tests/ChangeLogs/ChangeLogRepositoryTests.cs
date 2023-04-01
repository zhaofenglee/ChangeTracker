using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using JS.Abp.ChangeTracker.ChangeLogs;
using JS.Abp.ChangeTracker.EntityFrameworkCore;
using Xunit;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogRepositoryTests : ChangeTrackerEntityFrameworkCoreTestBase
    {
        private readonly IChangeLogRepository _changeLogRepository;

        public ChangeLogRepositoryTests()
        {
            _changeLogRepository = GetRequiredService<IChangeLogRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _changeLogRepository.GetListAsync(
                    userId: Guid.Parse("172536b5-6bd2-4666-bfc7-1237472e06cd"),
                    userName: "58ab2ea1eb1747fc9f09f2584491cbfcad93acb7876f45cebc52c3c1ff2f74c28384dbc8d52d4b57a91ad0f54ad4b40cd8f6bf6bea264615816be9745860aac0",
                    description: "73e4b7e323aa426ba5cb5b982a842648aad9258243234a93b819033c41484b3d734bbdb8ee264f4da76ccb934756",
                    changeType: default,
                    systemId: Guid.Parse("53f05edc-627c-44f6-a245-7a9483ccb9d4"),
                    systemName: "952607eff6754dc1b505f854749e3a83df13d1e1240845d790"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _changeLogRepository.GetCountAsync(
                    userId: Guid.Parse("55b7b8f5-6b02-43c0-b87f-ac39408b15b9"),
                    userName: "6639fd22aad441609d025e29206555a664f1fa4e35134e1ab0b2f0a92192e55d9ee0fa77d07a48fb85f1d3f17e812b85deaf5ebbd3d94adda7ab083fd77321f2",
                    description: "178fe95b334a458f900928bbcdff06a17a85db01dc654306a56",
                    changeType: default,
                    systemId: Guid.Parse("4b908820-dc09-4442-bb3a-3071c981046e"),
                    systemName: "654b1d401a5e45f8a3ef9c3940526a624b601b54b27c4b709f"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}