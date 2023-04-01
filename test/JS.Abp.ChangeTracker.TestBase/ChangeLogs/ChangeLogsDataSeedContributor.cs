using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using JS.Abp.ChangeTracker.ChangeLogs;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IChangeLogRepository _changeLogRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ChangeLogsDataSeedContributor(IChangeLogRepository changeLogRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _changeLogRepository = changeLogRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _changeLogRepository.InsertAsync(new ChangeLog
            (
                id: Guid.Parse("c7c89106-4819-4d28-9dc9-43358ea5e790"),
                userId: Guid.Parse("172536b5-6bd2-4666-bfc7-1237472e06cd"),
                userName: "58ab2ea1eb1747fc9f09f2584491cbfcad93acb7876f45cebc52c3c1ff2f74c28384dbc8d52d4b57a91ad0f54ad4b40cd8f6bf6bea264615816be9745860aac0",
                description: "73e4b7e323aa426ba5cb5b982a842648aad9258243234a93b819033c41484b3d734bbdb8ee264f4da76ccb934756",
                changeType: default,
                systemId: Guid.Parse("53f05edc-627c-44f6-a245-7a9483ccb9d4"),
                systemName: "952607eff6754dc1b505f854749e3a83df13d1e1240845d790"
            ));

            await _changeLogRepository.InsertAsync(new ChangeLog
            (
                id: Guid.Parse("843d2e7b-27f2-47b5-b775-6e251d514b44"),
                userId: Guid.Parse("55b7b8f5-6b02-43c0-b87f-ac39408b15b9"),
                userName: "6639fd22aad441609d025e29206555a664f1fa4e35134e1ab0b2f0a92192e55d9ee0fa77d07a48fb85f1d3f17e812b85deaf5ebbd3d94adda7ab083fd77321f2",
                description: "178fe95b334a458f900928bbcdff06a17a85db01dc654306a56",
                changeType: default,
                systemId: Guid.Parse("4b908820-dc09-4442-bb3a-3071c981046e"),
                systemName: "654b1d401a5e45f8a3ef9c3940526a624b601b54b27c4b709f"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}