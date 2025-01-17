using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Equip.Command;
using RFLOT.Application.Equip.Models;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.Equip.CommandHandler;

public class CheckEquipCommandHandler : IRequestHandler<CheckEquipCommand, EquipInfo>
{
    private readonly EquipDbContext _dbContext;

    public CheckEquipCommandHandler(EquipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EquipInfo> Handle(CheckEquipCommand command, CancellationToken cancellationToken)
    {
        var equip =
            await _dbContext.Equips.FirstOrDefaultAsync(e => e.Id == command.IdEquip,
                cancellationToken) ?? throw new ApplicationException("АСО не найдено");
        var equipLastStatus = equip.LastStatus;
        equip.CheckEquip(command.StatusEquip, command.IdReport, command.IdZone, command.IdUser);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new EquipInfo
        {
            Space = equip.Space,
            Type = equip.Type,
            Name = equip.Name,
            LastStatus = equipLastStatus
        };
    }
}