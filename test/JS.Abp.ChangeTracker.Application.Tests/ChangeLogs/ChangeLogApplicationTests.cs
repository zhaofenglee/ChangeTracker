using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogsAppServiceTests : ChangeTrackerApplicationTestBase
    {
        private readonly IChangeLogsAppService _changeLogsAppService;
        private readonly IRepository<ChangeLog, Guid> _changeLogRepository;

        public ChangeLogsAppServiceTests()
        {
            _changeLogsAppService = GetRequiredService<IChangeLogsAppService>();
            _changeLogRepository = GetRequiredService<IRepository<ChangeLog, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _changeLogsAppService.GetListAsync(new GetChangeLogsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("843d2e7b-27f2-47b5-b775-6e251d514b44")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _changeLogsAppService.GetAsync(Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ChangeLogCreateDto
            {
                UserId = Guid.Parse("84e5a14c-8427-46d6-8af6-50447be11f57"),
                UserName = "d798d9d799a34d438f2c3ae28ac88e5681d652368f9f4d4aa42b905fcc3ed233be7a743769e14c1988fe95a68b777f0fb228dd3981704bd7adf2989925096c16",
                Description = "c008f35973284aadb4c14bb166cb5e4",
                ChangeType = default,
                SystemId = Guid.Parse("3de87058-5d68-46e7-9287-f50935f9bbca"),
                SystemName = "2fef91805151451294332a7bba3baed9addd5592852c46aaa2"
            };

            // Act
            var serviceResult = await _changeLogsAppService.CreateAsync(input);

            // Assert
            var result = await _changeLogRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(Guid.Parse("84e5a14c-8427-46d6-8af6-50447be11f57"));
            result.UserName.ShouldBe("d798d9d799a34d438f2c3ae28ac88e5681d652368f9f4d4aa42b905fcc3ed233be7a743769e14c1988fe95a68b777f0fb228dd3981704bd7adf2989925096c16");
            result.Description.ShouldBe("c008f35973284aadb4c14bb166cb5e4");
            result.ChangeType.ShouldBe(default);
            result.SystemId.ShouldBe(Guid.Parse("3de87058-5d68-46e7-9287-f50935f9bbca"));
            result.SystemName.ShouldBe("2fef91805151451294332a7bba3baed9addd5592852c46aaa2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ChangeLogUpdateDto()
            {
                UserId = Guid.Parse("b31f7ec6-b579-435e-9d54-757978feb651"),
                UserName = "fc4ac5299a154fe6939645db47931b511fbdc8f5ebfd4b8393b5494f01f263bbd937a383b74f46deb40bba543cfaa0d78420cf2cdfaa4bac83076d22dba21696",
                Description = "fedc3831e4c642b2a56b6abea9d65c9e76711df75b2e4467bdf2ca2b40ad813c3",
                ChangeType = default,
                SystemId = Guid.Parse("3927b0c3-8963-46d5-afe1-0d4a504ad1f4"),
                SystemName = "3dce6c3f0dbe430dad6a4e00b47b283f5f0405f6479e4236a4"
            };

            // Act
            var serviceResult = await _changeLogsAppService.UpdateAsync(Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790"), input);

            // Assert
            var result = await _changeLogRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(Guid.Parse("b31f7ec6-b579-435e-9d54-757978feb651"));
            result.UserName.ShouldBe("fc4ac5299a154fe6939645db47931b511fbdc8f5ebfd4b8393b5494f01f263bbd937a383b74f46deb40bba543cfaa0d78420cf2cdfaa4bac83076d22dba21696");
            result.Description.ShouldBe("fedc3831e4c642b2a56b6abea9d65c9e76711df75b2e4467bdf2ca2b40ad813c3");
            result.ChangeType.ShouldBe(default);
            result.SystemId.ShouldBe(Guid.Parse("3927b0c3-8963-46d5-afe1-0d4a504ad1f4"));
            result.SystemName.ShouldBe("3dce6c3f0dbe430dad6a4e00b47b283f5f0405f6479e4236a4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _changeLogsAppService.DeleteAsync(Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790"));

            // Assert
            var result = await _changeLogRepository.FindAsync(c => c.Id == Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790"));

            result.ShouldBeNull();
        }
    }
}